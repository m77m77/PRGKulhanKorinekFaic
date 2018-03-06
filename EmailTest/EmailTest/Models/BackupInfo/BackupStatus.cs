using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTest.Models.BackupInfo
{
    public class BackupStatus : IData
    {
        public string Status { get; set; }
        public DateTime TimeOfBackup { get; set; }
        public string FailMessage { get; set; }
        public List<BackupError> Errors { get; set; }
    }
}
