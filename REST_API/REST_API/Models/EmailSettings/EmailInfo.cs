using REST_API.CommunicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models.EmailSettings
{
    public class EmailInfo : IData
    {
        public Dictionary<int,string> Daemons { get; set; }
        public Dictionary<int,string> Templates { get; set; }
    }
}