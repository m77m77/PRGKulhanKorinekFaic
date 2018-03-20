using Newtonsoft.Json;
using REST_API.CommunicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models.Settings
{
    public class Settings : IData
    {
        public int SettingsID { get; set; }
        public string BackupSourcePath { get; set; }
        public string ActionAfterBackup { get; set; }
        public string SaveFormat { get; set; }
        public BackupScheme BackupScheme { get; set; }

        public IDestination Destination { get; set; }

    }
}