using REST_API.CommunicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models.EmailSettings
{
    public class EmailSettings : IData
    {
        public int AdminId { get; set; }
        public string EmailAddress { get; set; }
        public string ServerName { get; set; }
        public int Port { get; set; }
        public string From { get; set; }
        public bool SslTls { get; set; }
        public DateTime When { get; set; }
    }
}