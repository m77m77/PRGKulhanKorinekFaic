using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CronApp.Models.Settings;

namespace CronApp.CommunicationClasses
{
    public class ListSettingsData : IData
    {
        public List<Settings> ListSettings { get; set; }
        public Settings DefaultSettings { get; set; }
        public SettingsDatabase DefaultSettingsDatabase { get; set; }
    }
}
