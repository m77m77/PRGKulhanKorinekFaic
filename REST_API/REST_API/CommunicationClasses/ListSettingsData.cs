﻿using REST_API.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.CommunicationClasses
{
    public class ListSettingsData : IData
    {
        public List<Settings> ListSettings {get;set;}
    }
}