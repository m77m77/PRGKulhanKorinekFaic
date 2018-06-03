using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DaemonLibrary.DestinationManagers;
using DaemonLibrary.Models;
using DaemonLibrary.Models.Settings;
using DaemonLibrary.SaveMethods;

namespace DaemonLibrary.BackupMethods
{
    public class DifferentialBackupMethod : IBackupMethod
    {
        private List<DirectoryInfo> sourcesDirs;
        private List<IDestinationManager> destinationManagers;
        private SettingsManager SettingsManager;

        public DifferentialBackupMethod(SettingsManager settingsManager)
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
                if (!item.Exists)
                    return new BackupStatus() { Status = "FAIL", FailMessage = "Source path " + item.FullName + " doesnt exist", SettingsID = SettingsManager.CurrentSettings.SettingsID, TimeOfBackup = DateTime.Now, BackupType = "FULL" };
            }

            List<BackupError> errors = new List<BackupError>();
            Dictionary<string, DateTime> files = new Dictionary<string, DateTime>();
            BackupStatus status = new BackupStatus() { BackupType = "DIFF",TimeOfBackup = DateTime.Now, SettingsID = SettingsManager.CurrentSettings.SettingsID };

            try
            {

                List<BackupDirectory> prevBackups = ServerAccess.GetListOfPreviusBackups(this.SettingsManager);
                if(prevBackups.Count <= 0)
                    return new BackupStatus() { Status = "FAIL", FailMessage = "There is no full backup", SettingsID = SettingsManager.CurrentSettings.SettingsID, TimeOfBackup = DateTime.Now, BackupType = "DIFF" };

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
                    return new BackupStatus() { Status = "FAIL", FailMessage = "There is no full backup", SettingsID = SettingsManager.CurrentSettings.SettingsID, TimeOfBackup = DateTime.Now, BackupType = "DIFF" };


                Dictionary<string, DateTime> removedFiles = new Dictionary<string, DateTime>(lastFullBackup.Files);

                foreach (IDestinationManager item in this.destinationManagers)
                {
                    item.SaveMethod.Start(item, "DIFF");

                    foreach (DirectoryInfo source in this.sourcesDirs)
                    {
                        this.BackupRecursively(item.SaveMethod, source, source.Name, errors,lastFullBackup.Files,removedFiles, files);
                    }

                    item.SaveMethod.End();
                }

                foreach (IDestinationManager item in this.destinationManagers)
                {
                    item.Save();
                }

                status.Status = "SUCCESS";
                status.RemovedFiles = removedFiles;
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

        private void BackupRecursively(ISaveMethod saveMethod,DirectoryInfo dir, string path, List<BackupError> errors,Dictionary<string,DateTime> fullBackup,Dictionary<string,DateTime> removedFiles, Dictionary<string, DateTime> files)
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
                            saveMethod.AddFile(path, item,files);
                        }

                        if(removedFiles.ContainsKey(fullName))
                            removedFiles.Remove(fullName);
                    }else
                    {
                        saveMethod.AddFile(path, item,files);
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
                    this.BackupRecursively(saveMethod,item, Path.Combine(path, item.Name), errors,fullBackup,removedFiles,files);
                }
                catch (Exception ex)
                {
                    errors.Add(new BackupError() { Path = item.FullName, Message = ex.Message });
                }
            }
        }
    }
}
