using AdminApp.Models.EmailSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.CommunicationClasses
{
    public class ListEmailSettingsData : IData
    {
        public List<EmailSettings> ListEmailSettings { get; set; }
        //public EmailSettings DefaultEmailSettings { get; set; }
    }
}
