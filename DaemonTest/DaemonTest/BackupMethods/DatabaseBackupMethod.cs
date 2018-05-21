using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DaemonTest.DestinationManagers;
using DaemonTest.Models;
using DaemonTest.Models.Settings;
using MySql.Data.MySqlClient;

namespace DaemonTest.BackupMethods
{
    public class DatabaseBackupMethod : IBackupMethod
    {
        private List<IDestinationManager> destinationManagers;
        private SettingsManager SettingsManager;

        public DatabaseBackupMethod(SettingsManager settingsManager)
        {
            this.SettingsManager = settingsManager;

            this.destinationManagers = SettingsManager.GetDestinationManagers();
        }

        public BackupStatus Backup()
        {
            BackupStatus status = new BackupStatus() { BackupType = "DATABASE", TimeOfBackup = DateTime.Now, SettingsID = SettingsManager.CurrentSettings.SettingsID };

            Dictionary<string, DateTime> files = new Dictionary<string, DateTime>();

            try
            {
                SettingsDatabase settings = this.SettingsManager.CurrentSettings as SettingsDatabase;
                string constring = $"server={settings.Server};uid={settings.Username};pwd={settings.Password};database={settings.Database};SSL Mode=None;";
                FileInfo file = new FileInfo(Path.Combine(Path.GetTempPath(), "PRGKulhanKorinekFaic", "DATABASE","backup.sql"));
                file.Directory.Create();


                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            
                            mb.ExportToFile(file.FullName);
                            conn.Close();
                        }
                    }
                }

                foreach (IDestinationManager item in this.destinationManagers)
                {
                    item.SaveMethod.Start(item, "DATABASE");

                    item.SaveMethod.AddFile("", file, files);

                    item.SaveMethod.End();
                }

                foreach (IDestinationManager item in this.destinationManagers)
                {
                    item.Save();
                }
                file.Delete();
                status.Status = "SUCCESS";
            }
            catch (Exception ex)
            {
                status.Status = "FAIL";
                status.FailMessage = ex.Message;
            }

            return status;
        }
    }
}
