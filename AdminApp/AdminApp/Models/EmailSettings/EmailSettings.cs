using AdminApp.CommunicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Models.EmailSettings
{
    public class EmailSettings : IData
    {
        public int AdminId { get; set; }
        public string EmailAddress { get; set; }
        public List<int> FromDaemons { get; set; }
        public bool SendEmails { get; set; }
        public string HowOften { get; set; }
    }
}
