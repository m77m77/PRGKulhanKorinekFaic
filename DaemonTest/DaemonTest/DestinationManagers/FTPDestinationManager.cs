using DaemonTest.Models.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DaemonTest.DestinationManagers
{
    public class FTPDestinationManager : IDestinationManager
    {
        private DirectoryInfo dir;
        private FTPDestination destination;

        public FTPDestinationManager(FTPDestination destination)
        {
            this.destination = destination;

            string tempPath = Path.Combine(Path.GetTempPath(),"PRGKulhanKorinekFaic","FTP");
            string path = @"WEEKLY - 1";
            dir = new DirectoryInfo(Path.Combine(tempPath,path));
            dir.Create();
        }

        public string GetDownloadPath()
        {
            throw new NotImplementedException();
        }

        public string GetUploadPath()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            
        }
    }
}
