using DaemonLibrary.BackupMethods;
using DaemonLibrary.CommunicationClasses;
using DaemonLibrary.Models;
using DaemonLibrary.Models.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DaemonLibrary
{
    public class BackupTimer
    {
        private Daemon currentDaemon;
        private int checkSettings = 60;
        private int checkSettingsRemaining = 0;

        private List<BackupStatus> unsendStatuses;

        public void Start()
        {
            this.unsendStatuses = new List<BackupStatus>();
            ServerAccess.Config.Load();
        }

        public async void Tick(object state)
        {
            if (String.IsNullOrWhiteSpace(ServerAccess.Config.Token))
            {
                Response newTokenRes = await ServerAccess.GetToken();
            }

            Console.WriteLine(DateTime.Now.ToShortTimeString() + " Tick - Remaining: " +checkSettingsRemaining);
            if(this.checkSettingsRemaining <= 0)
            {
                this.checkSettingsRemaining = this.checkSettings;

                Response response = await ServerAccess.GetNewSettings();
                Console.WriteLine(response.Status + " " + response.Error);

                if (response.Status == "OK")
                {
                    this.currentDaemon = (Daemon) response.Data;
                    this.checkSettings = this.currentDaemon.UpdateTime;
                    this.checkSettingsRemaining = this.currentDaemon.UpdateTime;

                }
            }else
            {
                checkSettingsRemaining--;
            }

            if(this.currentDaemon != null)
            {
                if (!this.currentDaemon.Enabled)
                    return;

                if(this.unsendStatuses.Count > 0)
                {
                    List<BackupStatus> sentSuccesfully = new List<BackupStatus>();
                    foreach (BackupStatus item in this.unsendStatuses)
                    {
                        Response response = await ServerAccess.SendBackupStatus(item);

                        if(response.Status == "OK")
                        {
                            sentSuccesfully.Add(item);
                        }
                    }

                    foreach (BackupStatus item in sentSuccesfully)
                    {
                        this.unsendStatuses.Remove(item);
                    }
                }

                foreach (Settings item in this.currentDaemon.Settings)
                {
                    this.Backup(item);
                }
                foreach (SettingsDatabase item in this.currentDaemon.SettingsDatabase)
                {
                    this.Backup(item);
                }
            }
        }

        private async void Backup(ISettings item)
        {
            string type = this.CheckIfSettingsShouldRun(item);
            if (type != null)
            {
                Console.WriteLine(type);
                SettingsManager settingsManager = new SettingsManager(item);
                IBackupMethod backupMethod = settingsManager.GetBackupMethod(type);
                BackupStatus status = backupMethod.Backup();

                Response response = await ServerAccess.SendBackupStatus(status);


                if (response.Status != "OK")
                {
                    this.unsendStatuses.Add(status);
                }
            }
        }

        private string CheckIfSettingsShouldRun(ISettings settings)
        {
            string result = null;

            BackupScheme scheme = settings.BackupScheme;
            string type = scheme.Type;

            if(type == "ONE_TIME")
            {
                DateTime when = scheme.OneTimeBackup.When;
                if(when.Date == DateTime.Now.Date && when.Hour == DateTime.Now.Hour && when.Minute == DateTime.Now.Minute)
                {
                    if (settings is SettingsDatabase)
                        result = "DATABASE";
                    else
                        result = "FULL";
                }
            }
            else if (type == "DAILY")
            {
                result = this.ListBackupTimes(scheme.BackupTimes, 0, settings is SettingsDatabase);
            }
            else if (type == "WEEKLY")
            {
                int dayNumber = (7 + (int) DateTime.Now.DayOfWeek - 1) % 7;

                result = this.ListBackupTimes(scheme.BackupTimes, dayNumber, settings is SettingsDatabase);
            }
            else if (type == "MONTHLY")
            {
                int dayNumber = DateTime.Now.Day - 1;

                result = this.ListBackupTimes(scheme.BackupTimes, dayNumber, settings is SettingsDatabase);
            }

            return result;
        }

        private string ListBackupTimes(List<BackupTime> times,int dayNumber,bool isDatabase)
        {
            string result = null;

            foreach (BackupTime item in times)
            {
                if (item.DayNumber == dayNumber && item.Time.Hours == DateTime.Now.Hour && item.Time.Minutes == DateTime.Now.Minute)
                {
                    if (isDatabase)
                        result = "DATABASE";
                    else
                        result = item.Type;
                }
            }

            return result;
        }
    }
}
