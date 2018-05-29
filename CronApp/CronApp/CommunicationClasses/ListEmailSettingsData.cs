using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CronApp.Models.EmailSettings;

namespace CronApp.CommunicationClasses
{
    public class ListEmailSettingsData : IData
    {

         public List<EmailSettings> ListEmailSettings { get; set; }
         //public EmailSettings DefaultEmailSettings { get; set; }

    }
}
