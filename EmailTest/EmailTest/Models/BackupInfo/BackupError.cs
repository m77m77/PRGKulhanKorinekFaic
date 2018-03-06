using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EmailTest.Models.BackupInfo
{
    public class BackupError
    {
        public string Path { get; set; }
        public string Message { get; set; }
    }
}
