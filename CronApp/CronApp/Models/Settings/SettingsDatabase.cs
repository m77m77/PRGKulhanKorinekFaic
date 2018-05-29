using Newtonsoft.Json;
using CronApp.CommunicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CronApp.Models.Settings
{
    public class SettingsDatabase : IData
    {
        public int SettingsID { get; set; }
        public string Database { get; set; }
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public BackupScheme BackupScheme { get; set; }
        public List<IDestination> Destinations { get; set; }
    }
}
