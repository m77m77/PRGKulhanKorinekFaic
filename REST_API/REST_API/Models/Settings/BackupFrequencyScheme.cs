using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models.Settings
{
    public class BackupFrequencyScheme
    {
        public string Type { get; set; }
        public List<BackupTime> BackupTimes { get; set; }
    }
}