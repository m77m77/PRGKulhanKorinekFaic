using Newtonsoft.Json;
using DaemonLibrary.CommunicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaemonLibrary.Models.Settings
{
    public class Settings : IData,ISettings
    {
        public int SettingsID { get; set; }
        public string BackupSourcePath { get; set; }
        public List<string> BackupSources { get; set; }
        public string ActionAfterBackup { get; set; }
        public string SaveFormat { get; set; }
        public BackupScheme BackupScheme { get; set; }

        public IDestination Destination { get; set; }
        public List<IDestination> Destinations { get; set; }
    }
}