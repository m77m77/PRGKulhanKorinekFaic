using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTest
{
    public class EmailSettings
    {
        public string EmailAddress { get; set; }
        public string ServerName { get; set; }
        public int Port { get; set; }
        public string From { get; set; }
        public bool SslTls { get; set; }
        public DateTime When { get; set; }
    }
}
