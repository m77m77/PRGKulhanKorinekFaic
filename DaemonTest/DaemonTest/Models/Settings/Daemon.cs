using DaemonTest.CommunicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaemonTest.Models.Settings
{
    public class Daemon : IData
    {
        public int DaemonID { get; set; }
        public string DaemonName { get; set; }
        public List<Settings> Settings { get; set; }
    }
}