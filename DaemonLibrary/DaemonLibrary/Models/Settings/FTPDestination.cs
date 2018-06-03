using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaemonLibrary.Models.Settings
{
    public class FTPDestination : IDestination
    {
        public string Adress { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Path { get; set; }
        public string Type { get => "FTP"; set { } }
        public string SaveFormat { get; set; }
    }
}