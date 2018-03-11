using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DaemonTest.CommunicationClasses;
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
            dir = new DirectoryInfo(Path.Combine(destinationManager.GetPath(),dirName));
            dir.Create();
        }

        public void AddFile(string dirPath, FileInfo file, Dictionary<string, DateTime> files)
        {
            string fileName = Path.Combine(dirPath, file.Name);
            files.Add(fileName, file.LastWriteTime);

            Directory.CreateDirectory(Path.Combine(dir.FullName,dirPath));
            file.CopyTo(Path.Combine(dir.FullName, fileName));
        }

        public void End()
        {
            
        }

        public List<BackupDirectory> GetListOfPreviusBackups()
        {
            List<BackupDirectory> list = new List<BackupDirectory>();

            Task<Response> response = ServerAccess.GetBackupsInfos(SettingsManager.CurrentSettings.BackupScheme.Type);
            response.Wait();

            if (response.Result.Status == "OK")
            {
                ListDaemonBackupInfoData infos = (ListDaemonBackupInfoData)response.Result.Data;

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
