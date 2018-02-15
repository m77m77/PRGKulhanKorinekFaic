using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DaemonTest.DestinationManagers
{
    public class LocalNetworkDestinationManager : IDestinationManager
    {
        public string GetPath()
        {
            string path = @"C:\ZIP\WEEKLY - 1\";
            Directory.CreateDirectory(path);
            return path;
        }

        public void Save()
        {
            
        }
    }
}
