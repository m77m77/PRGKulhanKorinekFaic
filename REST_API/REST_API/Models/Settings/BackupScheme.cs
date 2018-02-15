using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models.Settings
{
    public class BackupScheme
    {
        public string Type { get; set; }
        public OneTimeBackup OneTimeBackup { get; set; }
        public List<BackupTime> BackupTimes { get; set; }
    }
}