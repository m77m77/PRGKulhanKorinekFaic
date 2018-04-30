using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DaemonTest.DestinationManagers;
using DaemonTest.Models;
using DaemonTest.Models.Settings;
using DaemonTest.SaveMethods;

namespace DaemonTest.BackupMethods
{
    public class IncrementalBackupMethod : IBackupMethod
    {
        private List<DirectoryInfo> sourcesDirs;
        private List<IDestinationManager> destinationManagers;
        private SettingsManager SettingsManager;

        public IncrementalBackupMethod(SettingsManager settingsManager)
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
            BackupStatus status = new BackupStatus() { BackupType = "INC",TimeOfBackup = DateTime.Now, SettingsID = SettingsManager.CurrentSettings.SettingsID };

            try
            {

                List<BackupDirectory> prevBackups = ServerAccess.GetListOfPreviusBackups(this.SettingsManager);
                if (prevBackups.Count <= 0)
                    return new BackupStatus() { Status = "FAIL", FailMessage = "There is no previous backup", SettingsID = SettingsManager.CurrentSettings.SettingsID, TimeOfBackup = DateTime.Now, BackupType = "INC" };

                BackupDirectory lastFullOrDiffBackup = null;

                foreach (BackupDirectory item in prevBackups)
                {
                    if (item.Type == "FULL" || item.Type == "DIFF")
                    {
                        if (lastFullOrDiffBackup != null)
                        {
                            if (lastFullOrDiffBackup.LastWrite < item.LastWrite)
                                lastFullOrDiffBackup = item;
                        }
                        else
                        {
                            lastFullOrDiffBackup = item;
                        }
                    }
                }

                if(lastFullOrDiffBackup == null)
                    return new BackupStatus() { Status = "FAIL", FailMessage = "There is no previous full or diferential backup", SettingsID = SettingsManager.CurrentSettings.SettingsID, TimeOfBackup = DateTime.Now, BackupType = "INC" };

                if(lastFullOrDiffBackup.Type == "DIFF")
                {
                    BackupDirectory lastFull = null;
                    foreach (BackupDirectory item in prevBackups)
                    {
                        if (item.Type == "FULL")
                        {
                            if (lastFull != null)
                            {
                                if (lastFull.LastWrite < item.LastWrite && lastFull.LastWrite < lastFullOrDiffBackup.LastWrite)
                                    lastFull = item;
                            }
                            else
                            {
                                lastFull = item;
                            }
                        }
                    }

                    if (lastFull == null)
                        return new BackupStatus() { Status = "FAIL", FailMessage = "There is no previous full backup", SettingsID = SettingsManager.CurrentSettings.SettingsID, TimeOfBackup = DateTime.Now, BackupType = "INC" };

                    foreach (KeyValuePair<string,DateTime> item in lastFull.Files)
                    {
                        if(!lastFullOrDiffBackup.Files.ContainsKey(item.Key))
                        {
                            lastFullOrDiffBackup.Files.Add(item.Key, item.Value);
                        }
                    }
                }

                List<BackupDirectory> prevIncBackups = new List<BackupDirectory>();

                foreach (BackupDirectory item in prevBackups)
                {
                    if (item.Type != "INC")
                        continue;

                    if (item.LastWrite > lastFullOrDiffBackup.LastWrite)
                        prevIncBackups.Add(item);
                }

                Dictionary<string, DateTime> prevBackedUpFiles = new Dictionary<string, DateTime>();
                foreach (KeyValuePair<string,DateTime> item in lastFullOrDiffBackup.Files)
                {
                    prevBackedUpFiles.Add(item.Key, item.Value);
                }
                foreach (BackupDirectory item in prevIncBackups)
                {
                    foreach (KeyValuePair<string,DateTime> bcFile in item.Files)
                    {
                        if(prevBackedUpFiles.ContainsKey(bcFile.Key))
                        {
                            if(prevBackedUpFiles[bcFile.Key] < bcFile.Value)
                            {
                                prevBackedUpFiles[bcFile.Key] = bcFile.Value;
                            }
                        }else
                        {
                            prevBackedUpFiles.Add(bcFile.Key, bcFile.Value);
                        }
                    }
                }

                Dictionary<string, DateTime> removedFiles = new Dictionary<string, DateTime>(prevBackedUpFiles);

                foreach (IDestinationManager item in this.destinationManagers)
                {
                    item.SaveMethod.Start(item, "INC");

                    foreach (DirectoryInfo source in this.sourcesDirs)
                    {
                        this.BackupRecursively(item.SaveMethod, source, source.Name, errors, prevBackedUpFiles,removedFiles, files);
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

        private void BackupRecursively(ISaveMethod saveMethod,DirectoryInfo dir, string path, List<BackupError> errors, Dictionary<string, DateTime> previousBackups, Dictionary<string, DateTime> removedFiles, Dictionary<string, DateTime> files)
        {
            foreach (FileInfo item in dir.GetFiles())
            {
                try
                {
                    string fullName = Path.Combine(path, item.Name);

                    if (previousBackups.ContainsKey(fullName))
                    {

                        DateTime lastWrite = previousBackups[fullName];
                        if (lastWrite.AddSeconds(5) < item.LastWriteTime)
                        {
                            saveMethod.AddFile(path, item,files);
                        }

                        if (removedFiles.ContainsKey(fullName))
                            removedFiles.Remove(fullName);
                    }
                    else
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
                    this.BackupRecursively(saveMethod,item, Path.Combine(path, item.Name), errors, previousBackups,removedFiles,files);
                }
                catch (Exception ex)
                {
                    errors.Add(new BackupError() { Path = item.FullName, Message = ex.Message });
                }
            }
        }
    }
}
