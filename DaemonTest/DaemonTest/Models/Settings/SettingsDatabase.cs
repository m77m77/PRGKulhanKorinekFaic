using Newtonsoft.Json;
using DaemonTest.CommunicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaemonTest.Models.Settings
{
    public class SettingsDatabase : IData
    {
        public int SettingsID { get; set; }
        public string Name { get; set; }
        public List<string> BackupSources { get; set; }
        public BackupScheme BackupScheme { get; set; }
        public IDestination Destination { get; set; }
        public List<IDestination> Destinations { get; set; }
    }
}