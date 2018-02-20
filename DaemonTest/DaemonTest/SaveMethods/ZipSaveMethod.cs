using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using DaemonTest.DestinationManagers;
using DaemonTest.Models;

namespace DaemonTest.SaveMethods
{
    class ZipSaveMethod : ISaveMethod
    {
        private ZipArchive archive;

        public void Start(IDestinationManager destinationManager, string backupType)
        {
            string fileName = backupType + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".zip";
            archive = ZipFile.Open(Path.Combine(destinationManager.GetUploadPath(),fileName), ZipArchiveMode.Create);
        }

        public void AddFile(string dirPath, FileInfo file)
        {
            archive.CreateEntryFromFile(file.FullName, Path.Combine(dirPath, file.Name),CompressionLevel.Optimal);
        }

        public void End()
        {
            archive.Dispose();
        }

        public List<BackupDirectory> GetListOfPreviusBackups(IDestinationManager destinationManager)
        {
            List<BackupDirectory> list = new List<BackupDirectory>();
            DirectoryInfo directory = new DirectoryInfo(destinationManager.GetDownloadPath());

            foreach (FileInfo item in directory.GetFiles())
            {
                if (item.Extension != ".zip")
                    continue;

                string type = null;
                if(item.Name.StartsWith("FULL"))
                {
                    type = "FULL";
                }
                else if (item.Name.StartsWith("DIFF"))
                {
                    type = "DIFF";
                }
                else if (item.Name.StartsWith("INC"))
                {
                    type = "INC";
                }

                if (type == null)
                    continue;

                
                try
                {
                    BackupDirectory backup = new BackupDirectory();
                    backup.LastWrite = item.LastWriteTime;
                    backup.Type = type;
                    backup.Files = this.GetListOfFilesInBackup(item);

                    list.Add(backup);
                }
                catch (Exception)
                {
                    
                }
            }

            return list;
        }

        private Dictionary<string,DateTime> GetListOfFilesInBackup(FileInfo file)
        {
            ZipArchive archive = ZipFile.Open(file.FullName, ZipArchiveMode.Read);
            Dictionary<string, DateTime> list = new Dictionary<string, DateTime>();

            foreach (ZipArchiveEntry item in archive.Entries)
            {
                list.Add(item.FullName, item.LastWriteTime.DateTime);
            }

            return list;
        }
    }
}
