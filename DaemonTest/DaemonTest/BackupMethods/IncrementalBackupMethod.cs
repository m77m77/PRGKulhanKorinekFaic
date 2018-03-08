using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DaemonTest.DestinationManagers;
using DaemonTest.Models;
using DaemonTest.SaveMethods;

namespace DaemonTest.BackupMethods
{
    public class IncrementalBackupMethod : IBackupMethod
    {
        private ISaveMethod saveMethod;
        private IDestinationManager destinationManager;
        private DirectoryInfo sourceDir;

        public IncrementalBackupMethod()
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
            BackupStatus status = new BackupStatus() { BackupType = "INC" };

            try
            {
                this.destinationManager.DownloadFiles("FULL","DIFF","INC");

                List<BackupDirectory> prevBackups = this.saveMethod.GetListOfPreviusBackups(this.destinationManager);
                if (prevBackups.Count <= 0)
                    return new BackupStatus() { Status = "FAIL", FailMessage = "There is no previous backup" };

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
                    return new BackupStatus() { Status = "FAIL", FailMessage = "There is no previous full or diferential backup" };

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

                this.saveMethod.Start(this.destinationManager, "INC");

                this.BackupRecursively(this.sourceDir, "", errors, prevBackedUpFiles);

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

            return status;
        }

        private void BackupRecursively(DirectoryInfo dir, string path, List<BackupError> errors, Dictionary<string, DateTime> previousBackups)
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
                            this.saveMethod.AddFile(path, item);
                        }

                    }
                    else
                    {
                        this.saveMethod.AddFile(path, item);
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
                    this.BackupRecursively(item, Path.Combine(path, item.Name), errors, previousBackups);
                }
                catch (Exception ex)
                {
                    errors.Add(new BackupError() { Path = item.FullName, Message = ex.Message });
                }
            }
        }
    }
}
