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
        public string SmtpPort { get; set; }
        public string HostName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<int> FromDaemonsDaily { get; set; }
        public List<int> FromDaemonsWeekly { get; set; }
        public List<int> FromDaemonsMonthly { get; set; }
        public bool OwnSmtp { get; set; }
        public bool SendEmails { get; set; }
        //public string HowOften { get; set; }
        public int Template { get; set; }
    }
}