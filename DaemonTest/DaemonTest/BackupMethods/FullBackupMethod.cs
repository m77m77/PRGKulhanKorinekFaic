using DaemonTest.DestinationManagers;
using DaemonTest.Models;
using DaemonTest.SaveMethods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DaemonTest.BackupMethods
{
    public class FullBackupMethod : IBackupMethod
    {
        private ISaveMethod saveMethod;
        private IDestinationManager destinationManager;
        private DirectoryInfo sourceDir;

        public FullBackupMethod()
        {
            this.saveMethod = SettingsManager.GetSaveMethod();
            this.destinationManager = SettingsManager.GetDestinationManager();

            this.sourceDir = new DirectoryInfo(SettingsManager.CurrentSettings.BackupSourcePath);
        }

        public BackupStatus Backup()
        {
            if (!sourceDir.Exists)
                return new BackupStatus() { Status = "FAIL", FailMessage = "Source path doesnt exist" };

            List<BackupError> errors = new List<BackupError>();
            Dictionary<string, DateTime> files = new Dictionary<string, DateTime>();
            BackupStatus status = new BackupStatus() { BackupType = "FULL",TimeOfBackup = DateTime.Now };

            try
            {
                this.saveMethod.Start(this.destinationManager, "FULL");

                this.BackupRecursively(this.sourceDir, "", errors,files);

                this.saveMethod.End();
                this.destinationManager.Save();

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

        private void BackupRecursively(DirectoryInfo dir,string path,List<BackupError> errors,Dictionary<string,DateTime> files)
        {
            foreach (FileInfo item in dir.GetFiles())
            {
                try
                {
                    this.saveMethod.AddFile(path, item,files);
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
                    this.BackupRecursively(item,Path.Combine(path,item.Name),errors,files);       
                }
                catch (Exception ex)
                {
                    errors.Add(new BackupError() { Path = item.FullName, Message = ex.Message });
                }
            }
        }
    }
}
