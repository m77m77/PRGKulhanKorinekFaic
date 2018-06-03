using DaemonLibrary.DestinationManagers;
using DaemonLibrary.Models;
using DaemonLibrary.Models.Settings;
using DaemonLibrary.SaveMethods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DaemonLibrary.BackupMethods
{
    public class FullBackupMethod : IBackupMethod
    {
        private List<DirectoryInfo> sourcesDirs;
        private List<IDestinationManager> destinationManagers;
        private SettingsManager SettingsManager;

        public FullBackupMethod(SettingsManager settingsManager)
        {
            this.SettingsManager = settingsManager;

            this.destinationManagers = SettingsManager.GetDestinationManagers();

            this.sourcesDirs = new List<DirectoryInfo>();

            foreach (string item in (SettingsManager.CurrentSettings as Settings).BackupSources)
            {
                this.sourcesDirs.Add(new DirectoryInfo(item));
            }
        }

        public BackupStatus Backup()
        {
            foreach (DirectoryInfo item in this.sourcesDirs)
            {
                if(!item.Exists)
                    return new BackupStatus() { Status = "FAIL", FailMessage = "Source path "+ item.FullName+" doesnt exist", SettingsID = SettingsManager.CurrentSettings.SettingsID, TimeOfBackup = DateTime.Now, BackupType = "FULL" };
            }

            List<BackupError> errors = new List<BackupError>();
            Dictionary<string, DateTime> files = new Dictionary<string, DateTime>();
            BackupStatus status = new BackupStatus() { BackupType = "FULL",TimeOfBackup = DateTime.Now,SettingsID = SettingsManager.CurrentSettings.SettingsID };

            try
            {
                foreach (IDestinationManager item in this.destinationManagers)
                {
                    item.SaveMethod.Start(item, "FULL");

                    foreach (DirectoryInfo source in this.sourcesDirs)
                    {
                        this.BackupRecursively(item.SaveMethod, source, source.Name, errors, files);
                    }

                    item.SaveMethod.End();
                }

                foreach (IDestinationManager item in this.destinationManagers)
                {
                    item.Save();
                }

                status.Status = "SUCCESS";
            }
            catch (Exception ex)
            {
                status.Status = "FAIL";
                status.FailMessage = ex.Message;
            }

            status.Errors = errors;
            status.Files = files;

            return status;
        }

        private void BackupRecursively(ISaveMethod saveMethod,DirectoryInfo dir,string path,List<BackupError> errors,Dictionary<string,DateTime> files)
        {
            foreach (FileInfo item in dir.GetFiles())
            {
                try
                {
                    saveMethod.AddFile(path, item,files);
                }
                catch (Exception ex)
                {
                    errors.Add(new BackupError() { Path = item.FullName, Message = ex.Message });
                }
            }

            foreach (DirectoryInfo item in dir.GetDirectories())
            {
                try
                {
                    this.BackupRecursively(saveMethod,item,Path.Combine(path,item.Name),errors,files);       
                }
                catch (Exception ex)
                {
                    errors.Add(new BackupError() { Path = item.FullName, Message = ex.Message });
                }
            }
        }
    }
}
