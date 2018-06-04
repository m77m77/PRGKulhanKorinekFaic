using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using REST_API.Models.BackupInfo;

namespace REST_API.CommunicationClasses
{
    public class ListBackupInfoDaemonInfo : IData
    {
        public List<BackupStatusDaemonInfo> Infos { get; set; }
    }
}