using System;
using System.Collections.Generic;
using System.Text;
using DaemonTest.CommunicationClasses;

namespace DaemonTest.Models
{
    public class BackupStatus : IData
    {
        public int SettingsID { get; set; }
        public string Status { get; set; }
	    public DateTime TimeOfBackup { get; set; }
        public string BackupType { get; set; }
        public string FailMessage { get; set; }
        public List<BackupError> Errors { get; set; }
        public Dictionary<string,DateTime> Files { get; set; }
        public Dictionary<string,DateTime> RemovedFiles { get; set; }
    }
}
