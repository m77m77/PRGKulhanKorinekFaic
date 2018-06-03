using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DaemonLibrary.Models;

namespace DaemonLibrary.CommunicationClasses
{
    public class ListDaemonBackupInfoData : IData
    {
        public List<BackupStatus> ListDaemonBackupInfo { get; set; }
    }
}