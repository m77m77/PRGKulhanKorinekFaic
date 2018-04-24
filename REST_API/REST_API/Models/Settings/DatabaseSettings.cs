using Newtonsoft.Json;
using REST_API.CommunicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models.Settings
{
    public class DatabaseSettings : IData
    {
        public int SettingsID { get; set; }
        public string Name { get; set; }
        public List<string> BackupSources { get; set; }

        public IDestination Destination { get; set; }
        public List<IDestination> Destinations { get; set; }
    }
}