using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DaemonTest.DestinationManagers;
using DaemonTest.Models;
using DaemonTest.SaveMethods;

namespace DaemonTest.BackupMethods
{
    public class DifferentialBackupMethod : IBackupMethod
    {
        private ISaveMethod saveMethod;
        private IDestinationManager destinationManager;
        private DirectoryInfo sourceDir;
        private SettingsManager SettingsManager;

        public DifferentialBackupMethod(SettingsManager settingsManager)
        {
            this.SettingsManager = settingsManager;

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
            BackupStatus status = new BackupStatus() { BackupType = "DIFF",TimeOfBackup = DateTime.Now };

            try
            {

                List<BackupDirectory> prevBackups = this.saveMethod.GetListOfPreviusBackups();
                if(prevBackups.Count <= 0)
                    return new BackupStatus() { Status = "FAIL", FailMessage = "There is no full backup" };

                BackupDirectory lastFullBackup = null;

                foreach (BackupDirectory item in prevBackups)
                {
                    if(item.Type == "FULL")
                    {
                        if(lastFullBackup != null)
                        {
                            if (lastFullBackup.LastWrite < item.LastWrite)
                                lastFullBackup = item;
                        }else
                        {
                            lastFullBackup = item;
                        }
                    }
                }

                if(lastFullBackup == null)
                    return new BackupStatus() { Status = "FAIL", FailMessage = "There is no full backup" };


                this.saveMethod.Start(this.destinationManager, "DIFF");

                this.BackupRecursively(this.sourceDir, "", errors,lastFullBackup.Files,files);

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

        private void BackupRecursively(DirectoryInfo dir, string path, List<BackupError> errors,Dictionary<string,DateTime> fullBackup, Dictionary<string, DateTime> files)
        {
            foreach (FileInfo item in dir.GetFiles())
            {
                try
                {
                    string fullName = Path.Combine(path, item.Name);
                    
                    if (fullBackup.ContainsKey(fullName))
                    {
                        
                        DateTime lastWrite = fullBackup[fullName];
                        if (lastWrite.AddSeconds(5) < item.LastWriteTime)
                        {
                            this.saveMethod.AddFile(path, item,files);
                        }

                    }else
                    {
                        this.saveMethod.AddFile(path, item,files);
                    }
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
                    this.BackupRecursively(item, Path.Combine(path, item.Name), errors,fullBackup,files);
                }
                catch (Exception ex)
                {
                    errors.Add(new BackupError() { Path = item.FullName, Message = ex.Message });
                }
            }
        }
    }
}
