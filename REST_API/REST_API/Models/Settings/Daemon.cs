using REST_API.CommunicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models.Settings
{
    public class Daemon : IData
    {
        public int DaemonID { get; set; }
        public string DaemonName { get; set; }
        public int UpdateTime { get; set; }
        public List<Settings> Settings { get; set; }
        public List<SettingsDatabase> SettingsDatabase { get; set; }
    }
}