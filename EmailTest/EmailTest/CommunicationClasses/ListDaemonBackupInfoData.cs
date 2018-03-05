using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailTest.Models.BackupInfo;

namespace EmailTest.CommunicationClasses
{
    public class ListDaemonBackupInfoData : IData
    {
        public List<BackupStatus> ListDaemonBackupInfo { get; set; }
    }
}
