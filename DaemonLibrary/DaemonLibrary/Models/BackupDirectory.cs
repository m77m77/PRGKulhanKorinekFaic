using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonLibrary.Models
{
    public class BackupDirectory
    {
        public string Type { get; set; }
        public DateTime LastWrite { get; set; }
        public Dictionary<string,DateTime> Files { get; set; }
    }
}
