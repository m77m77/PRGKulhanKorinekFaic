using Newtonsoft.Json;
using AdminApp.CommunicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminApp.Models.Settings
{
    public class Settings : IData
    {
        public int DaemonID { get; set; }
        public string DaemonName { get; set; }
        public string BackupSourcePath { get; set; }
        public string ActionAfterBackup { get; set; }
        public string SaveFormat { get; set; }
        public BackupScheme BackupScheme { get; set; }

        public IDestination Destination { get; set; }

    }
}