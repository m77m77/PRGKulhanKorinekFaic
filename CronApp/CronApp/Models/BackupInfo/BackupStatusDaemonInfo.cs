using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CronApp.Models.BackupInfo
{
    public class BackupStatusDaemonInfo
    {
        public int DaemonID { get; set; }
        public string DaemonName { get; set; }
        public BackupStatus BackupStatus { get; set; }
    }
}