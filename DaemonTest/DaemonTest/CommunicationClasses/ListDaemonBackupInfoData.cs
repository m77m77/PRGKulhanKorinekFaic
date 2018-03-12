using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DaemonTest.Models;

namespace DaemonTest.CommunicationClasses
{
    public class ListDaemonBackupInfoData : IData
    {
        public List<BackupStatus> ListDaemonBackupInfo { get; set; }
    }
}