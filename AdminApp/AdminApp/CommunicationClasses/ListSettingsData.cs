using AdminApp.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminApp.CommunicationClasses
{
    public class ListSettingsData : IData
    {
        public List<Settings> ListSettings {get;set;}
        public Settings DefaultSettings { get; set; }
    }
}