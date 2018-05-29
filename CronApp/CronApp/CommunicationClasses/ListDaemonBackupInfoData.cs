using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CronApp.Models.BackupInfo;

namespace CronApp.CommunicationClasses
{
    public class ListDaemonBackupInfoData : IData
    {
        public List<BackupStatus> ListDaemonBackupInfo { get; set; }
    }
}
