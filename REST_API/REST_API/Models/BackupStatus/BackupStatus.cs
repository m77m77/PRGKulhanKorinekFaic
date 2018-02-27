using System;
using System.Collections.Generic;
using System.Text;
using REST_API.CommunicationClasses;

namespace REST_API.Models.BackupStatus
{
    public class BackupStatus : IData
    {
        public string Status { get; set; }
        public string FailMessage { get; set; }
        public List<BackupError> Errors { get; set; }
    }
}
