using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DaemonTest.DestinationManagers;
using DaemonTest.Models;

namespace DaemonTest.SaveMethods
{
    public class PlainSaveMethod : ISaveMethod
    {
        private DirectoryInfo dir;

        public void Start(IDestinationManager destinationManager, string backupType)
        {
            string dirName = backupType + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm");
            dir = new DirectoryInfo(Path.Combine(destinationManager.GetUploadPath(),dirName));
            dir.Create();
        }

        public void AddFile(string dirPath, FileInfo file)
        {
            Directory.CreateDirectory(Path.Combine(dir.FullName,dirPath));
            file.CopyTo(Path.Combine(dir.FullName, dirPath,file.Name));
        }

        public void End()
        {
            
        }

        public List<BackupDirectory> GetListOfPreviusBackups(IDestinationManager destinationManager)
        {
            List<BackupDirectory> list = new List<BackupDirectory>();
            DirectoryInfo directory = new DirectoryInfo(destinationManager.GetDownloadPath());

            foreach (DirectoryInfo item in directory.GetDirectories())
            {
                string type = null;
                if (item.Name.StartsWith("FULL"))
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
                    Dictionary<string, DateTime> files = new Dictionary<string, DateTime>();
                    this.GetListOfFilesInBackup(item,"",files);
                    backup.Files = files;

                    list.Add(backup);
                }
                catch (Exception)
                {

                }
            }

            return list;
        }

        private void GetListOfFilesInBackup(DirectoryInfo directory,string path, Dictionary<string, DateTime> list)
        {
            foreach (FileInfo item in directory.GetFiles())
            {
                list.Add(Path.Combine(path, item.Name), item.LastWriteTime);
            }

            foreach (DirectoryInfo item in directory.GetDirectories())
            {
                this.GetListOfFilesInBackup(item, Path.Combine(path, item.Name), list);
            }
        }
    }
}
