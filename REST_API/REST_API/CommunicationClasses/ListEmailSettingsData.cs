using REST_API.Models.EmailSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.CommunicationClasses
{
    public class ListEmailSettingsData : IData
    {
        public List<EmailSettings> ListEmailSettings { get; set; }
        //public EmailSettings DefaultEmailSettings { get; set; }
    }
}