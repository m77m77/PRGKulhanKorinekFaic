using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models.Settings
{
    public class Settings
    {
        public int DaemonID { get; set; }
        public string BackupSourcePath { get; set; }
        public string ActionBeforeBackup { get; set; }
        public string ActionAfterBackup { get; set; }
        public string SaveFormat { get; set; }

        public IDestination Destination { get; set; }

    }
}