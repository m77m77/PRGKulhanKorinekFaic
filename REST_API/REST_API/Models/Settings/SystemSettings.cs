using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models.Settings
{
    public class SystemSettings
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}