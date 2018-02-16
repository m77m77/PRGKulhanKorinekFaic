using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DaemonTest.DestinationManagers
{
    public class FTPDestinationManager : IDestinationManager
    {
        private DirectoryInfo dir;

        public FTPDestinationManager()
        {
            string tempPath = Path.Combine(Path.GetTempPath(),"PRGKulhanKorinekFaic","FTP");
            string path = @"WEEKLY - 1";
            dir = new DirectoryInfo(Path.Combine(tempPath,path));
            dir.Create();
        }

        public string GetPath()
        {
            return dir.FullName;
        }

        public void Save()
        {
            
        }
    }
}
