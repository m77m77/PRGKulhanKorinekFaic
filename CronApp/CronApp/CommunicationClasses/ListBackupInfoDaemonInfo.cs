using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CronApp.Models.BackupInfo;

namespace CronApp.CommunicationClasses
{
    public class ListBackupInfoDaemonInfo : IData
    {
        public List<BackupStatusDaemonInfo> Infos { get; set; }
    }
}