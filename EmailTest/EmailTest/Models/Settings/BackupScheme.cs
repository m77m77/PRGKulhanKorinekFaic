using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTest
{
    public class BackupScheme
    {
        public string Type { get; set; }
        public int MaxBackups { get; set; }
        public OneTimeBackup OneTimeBackup { get; set; }
        public List<BackupTime> BackupTimes { get; set; }
    }
}
