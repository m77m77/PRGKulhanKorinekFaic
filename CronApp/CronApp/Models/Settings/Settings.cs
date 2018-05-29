using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CronApp.CommunicationClasses;

namespace CronApp.Models.Settings
{
    public class Settings : IData
    {
        public int SettingsID { get; set; }
        public List<string> BackupSources { get; set; }
        public string ActionAfterBackup { get; set; }
        public BackupScheme BackupScheme { get; set; }
        public List<IDestination> Destinations { get; set; }

    }
}
