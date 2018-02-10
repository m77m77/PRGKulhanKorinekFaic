using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models.Settings
{
    public class Frequency
    {
        public string Time { get; set; }
        public string Interval { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string DayOfTheWeek { get; set; }
        public string DayOfTheMonth { get; set; }
    }
}