using DaemonTest.Models.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonTest.DestinationManagers
{
    public class SFTPDestinationManager : IDestinationManager
    {
        private SFTPDestination destination;

        public SFTPDestinationManager(SFTPDestination destination)
        {
            this.destination = destination;
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
            throw new NotImplementedException();
        }
    }
}
