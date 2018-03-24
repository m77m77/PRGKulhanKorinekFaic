using REST_API.Models.EmailSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.CommunicationClasses
{
    public class EmailAdminData : IData
    {
        public EmailSettings Settings { get; set; }
        public EmailInfo Info { get; set; }
    }
}