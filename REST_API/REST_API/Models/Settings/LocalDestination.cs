using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models.Settings
{
    public class LocalDestination : IDestination
    {
        public string Path { get; set; }
        public string Type { get; set; }
    }
}