using CronApp.CommunicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CronApp.Models.EmailSettings
{
    public class EmailTemplate
    {
        public int ID { get; set; }
        public string Backups { get; set; }
        public string Daemons { get; set; }
        public string Body { get; set; }
    }
}