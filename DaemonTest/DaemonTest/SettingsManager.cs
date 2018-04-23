using DaemonTest.BackupMethods;
using DaemonTest.CommunicationClasses;
using DaemonTest.DestinationManagers;
using DaemonTest.Models.Settings;
using DaemonTest.SaveMethods;
using DaemonTest.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DaemonTest
{
    public class SettingsManager
    {
        public Settings CurrentSettings { get; private set; }

        public SettingsManager(Settings settings)
        {
            this.CurrentSettings = settings;
        }

        public IBackupMethod GetBackupMethod(string type)
        {
            if(type == "FULL")
            {
                return new FullBackupMethod(this);
            }
            else if (type == "DIFF")
            {
                return new DifferentialBackupMethod(this);
            }
            else if(type == "INC")
            {
                return new IncrementalBackupMethod(this);
            }

            return null;
        }

        public ISaveMethod GetSaveMethod()
        {
            string saveFormat = CurrentSettings.SaveFormat;
            if (saveFormat == "ZIP")
            {
                return new ZipSaveMethod(this);
            }
            else if (saveFormat == "PLAIN")
            {
                return new PlainSaveMethod(this);
            }

            return null;
        }

        public IDestinationManager GetDestinationManager()
        {
            string destType = CurrentSettings.Destination.Type;
            if (destType == "LOCAL_NETWORK")
            {
                return new LocalNetworkDestinationManager((LocalNetworkDestination)CurrentSettings.Destination, this);
            }
            else if(destType == "FTP")
            {
                return new FTPDestinationManager((FTPDestination)CurrentSettings.Destination,this);
            }
            else if(destType == "SFTP")
            {
                return new SFTPDestinationManager((SFTPDestination)CurrentSettings.Destination,this);
            }

            return null;
        }

        public List<IDestinationManager> GetDestinationManagers()
        {
            List<IDestinationManager> result = new List<IDestinationManager>();

            foreach (IDestination item in this.CurrentSettings.Destinations)
            {
                string destType = item.Type;

                if (destType == "LOCAL_NETWORK")
                {
                    result.Add(new LocalNetworkDestinationManager((LocalNetworkDestination)item, this));
                }
                else if (destType == "FTP")
                {
                    result.Add(new FTPDestinationManager((FTPDestination)item, this));
                }
                else if (destType == "SFTP")
                {
                    result.Add(new SFTPDestinationManager((SFTPDestination)item, this));
                }
            }

            return result;
        }

        public string GetFolderNameBasedOnDate()
        {
            string type = CurrentSettings.BackupScheme.Type;

            if (type == "ONE_TIME")
            {
                return type + " SETTINGS" + CurrentSettings.SettingsID;
            }
            else if (type == "DAILY")
            {
                return type + " SETTINGS" + CurrentSettings.SettingsID + " " + DateTime.Now.ToString("dd.MM.yyyy");
            }
            else if (type == "WEEKLY")
            {
                int diff = (7 + (DateTime.Now.DayOfWeek - DayOfWeek.Monday)) % 7;
                DateTime monday = DateTime.Now.AddDays(-1 * diff).Date;
                DateTime sunday = monday.AddDays(6);

                return type + " SETTINGS" + CurrentSettings.SettingsID + " " + monday.ToString("dd.MM.yyyy") + " - " + sunday.ToString("dd.MM.yyyy");
            }
            else if (type == "MONTHLY")
            {
                DateTime first = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime last = first.AddMonths(1).AddDays(-1);

                return type + " SETTINGS" + CurrentSettings.SettingsID + " " + first.ToString("dd.MM.yyyy") + " - " + last.ToString("dd.MM.yyyy");
            }

            return "";
        }
    }
}
