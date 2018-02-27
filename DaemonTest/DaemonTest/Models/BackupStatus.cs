using System;
using System.Collections.Generic;
using System.Text;
using DaemonTest.CommunicationClasses;

namespace DaemonTest.Models
{
    public class BackupStatus : IData
    {
        public string Status { get; set; }
        public string FailMessage { get; set; }
        public List<BackupError> Errors { get; set; }
    }
}
