using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminApp.Models.Settings
{
    public class LocalNetworkDestination : IDestination
    {
        public string Path { get; set; }
        public string Type { get => "LOCAL_NETWORK"; set { } }
    }
}