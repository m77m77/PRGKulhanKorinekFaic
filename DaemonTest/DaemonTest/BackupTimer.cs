using DaemonTest.BackupMethods;
using DaemonTest.CommunicationClasses;
using DaemonTest.Models;
using DaemonTest.Models.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonTest
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
            
            Console.WriteLine(DateTime.Now.ToShortTimeString() + " Tick - Remaining: " +checkSettingsRemaining);
            if(checkSettingsRemaining <= 0)
            {
                checkSettingsRemaining = checkSettings;

                Response response = await ServerAccess.GetNewSettings();
                Console.WriteLine(response.Status + " " + response.Error);

                if (response.Status == "OK")
                {
                    currentDaemon = (Daemon) response.Data;
                }
            }else
            {
                checkSettingsRemaining--;
            }

            if(this.currentDaemon != null)
            {
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
                    string type = this.CheckIfSettingsShouldRun(item);
                    if(type != null)
                    {
                        Console.WriteLine(type);
                        SettingsManager settingsManager = new SettingsManager(item);
                        IBackupMethod backupMethod = settingsManager.GetBackupMethod(type);
                        BackupStatus status = backupMethod.Backup();

                        Response response = await ServerAccess.SendBackupStatus(status);
                        

                        if(response.Status != "OK")
                        {
                            this.unsendStatuses.Add(status);
                        }
                    }
                }
            }
        }

        private string CheckIfSettingsShouldRun(Settings settings)
        {
            string result = null;

            BackupScheme scheme = settings.BackupScheme;
            string type = scheme.Type;

            if(type == "ONE_TIME")
            {
                DateTime when = scheme.OneTimeBackup.When;
                if(when.Date == DateTime.Now.Date && when.Hour == DateTime.Now.Hour && when.Minute == DateTime.Now.Minute)
                {
                    result = "FULL";
                }
            }
            else if (type == "DAILY")
            {
                result = this.ListBackupTimes(scheme.BackupTimes, 0);
            }
            else if (type == "WEEKLY")
            {
                int dayNumber = (7 + (int) DateTime.Now.DayOfWeek - 1) % 7;

                result = this.ListBackupTimes(scheme.BackupTimes, dayNumber);
            }
            else if (type == "MONTHLY")
            {
                int dayNumber = DateTime.Now.Day - 1;

                result = this.ListBackupTimes(scheme.BackupTimes, dayNumber);
            }

            return result;
        }

        private string ListBackupTimes(List<BackupTime> times,int dayNumber)
        {
            string result = null;

            foreach (BackupTime item in times)
            {
                if (item.DayNumber == dayNumber && item.Time.Hours == DateTime.Now.Hour && item.Time.Minutes == DateTime.Now.Minute)
                {
                    result = item.Type;
                }
            }

            return result;
        }
    }
}
