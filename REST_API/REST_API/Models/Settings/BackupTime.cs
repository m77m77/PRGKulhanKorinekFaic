using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models.Settings
{
    public class BackupTime
    {
        public string Type { get; set; }
        public TimeSpan Time { get; set; }
        public int DayNumber { get; set; }
    }
}