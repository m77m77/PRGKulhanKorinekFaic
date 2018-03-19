using REST_API.CommunicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models.EmailSettings
{
    public class EmailDaemonName : IData
    {
        public string Name { get; set; }
    }
}