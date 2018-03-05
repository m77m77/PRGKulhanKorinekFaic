using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using REST_API.Models.BackupStatus;

namespace REST_API.CommunicationClasses
{
    public class ListDaemonBackupInfoData : IData
    {
        public List<BackupStatus> ListDaemonBackupInfo { get; set; }
    }
}