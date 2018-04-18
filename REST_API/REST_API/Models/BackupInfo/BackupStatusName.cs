using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using REST_API.CommunicationClasses;

namespace REST_API.Models.BackupInfo
{
    public class BackupStatusName : IData
    {
        public BackupStatus backupStatus { get; set; }
        public string Name { get; set; }
    }
}