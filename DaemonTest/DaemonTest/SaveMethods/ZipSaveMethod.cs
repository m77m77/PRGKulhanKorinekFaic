using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using DaemonTest.CommunicationClasses;
using DaemonTest.DestinationManagers;
using DaemonTest.Models;

namespace DaemonTest.SaveMethods
{
    class ZipSaveMethod : ISaveMethod
    {
        private ZipArchive archive;
        private SettingsManager SettingsManager;

        public ZipSaveMethod(SettingsManager settingsManager)
        {
            this.SettingsManager = settingsManager;
        }

        public void Start(IDestinationManager destinationManager, string backupType)
        {
            string fileName = backupType + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".zip";
            archive = ZipFile.Open(Path.Combine(destinationManager.GetPath(),fileName), ZipArchiveMode.Create);
        }

        public void AddFile(string dirPath, FileInfo file,Dictionary<string,DateTime> files)
        {
            string fileName = Path.Combine(dirPath, file.Name);
            files.Add(fileName, file.LastWriteTime);

            archive.CreateEntryFromFile(file.FullName, fileName,CompressionLevel.Optimal);
        }

        public void End()
        {
            archive.Dispose();
        }

        public List<BackupDirectory> GetListOfPreviusBackups()
        {
            List<BackupDirectory> list = new List<BackupDirectory>();

            Task<Response> response = ServerAccess.GetBackupsInfos(SettingsManager.CurrentSettings.BackupScheme.Type,SettingsManager.CurrentSettings.SettingsID);
            response.Wait();

            if(response.Result.Status == "OK")
            {
                ListDaemonBackupInfoData infos = (ListDaemonBackupInfoData) response.Result.Data;

                foreach (BackupStatus item in infos.ListDaemonBackupInfo)
                {
                    if (item.Status != "SUCCESS")
                        continue;

                    BackupDirectory bd = new BackupDirectory();
                    bd.Files = item.Files;
                    bd.Type = item.BackupType;
                    bd.LastWrite = item.TimeOfBackup;

                    list.Add(bd);
                }
            }

            return list;
        }

        
    }
}
