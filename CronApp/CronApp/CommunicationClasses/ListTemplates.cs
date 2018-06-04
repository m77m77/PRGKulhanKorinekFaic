using CronApp.Models.EmailSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CronApp.CommunicationClasses
{
    public class ListTemplates : IData
    {
        public List<EmailTemplate> Templates { get; set; }
    }
}