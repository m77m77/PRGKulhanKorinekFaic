﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaemonLibrary.Models.Settings
{
    public class LocalNetworkDestination : IDestination
    {
        public string Path { get; set; }
        public string Type { get => "LOCAL_NETWORK"; set { } }

        public string SaveFormat { get; set; }
    }
}