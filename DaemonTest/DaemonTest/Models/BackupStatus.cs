using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonTest.Models
{
    public class BackupStatus
    {
        public string Status { get; set; }
        public string FailMessage { get; set; }
        public List<BackupError> Errors { get; set; }
    }
}
