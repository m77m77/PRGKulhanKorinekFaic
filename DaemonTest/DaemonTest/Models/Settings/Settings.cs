using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaemonTest.Models.Settings
{
    public class Settings
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