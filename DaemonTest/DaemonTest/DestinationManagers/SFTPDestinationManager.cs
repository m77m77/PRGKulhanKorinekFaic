using DaemonTest.Models.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DaemonTest.DestinationManagers
{
    public class SFTPDestinationManager : IDestinationManager
    {
        private SFTPDestination destination;
        private string tempDir;
        private SettingsManager SettingsManager;

        public SFTPDestinationManager(SFTPDestination destination, SettingsManager settingsManager)
        {
            this.SettingsManager = settingsManager;
            this.destination = destination;

            this.tempDir = Path.Combine(Path.GetTempPath(), "PRGKulhanKorinekFaic", "SFTP");
        }

        public string GetPath()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
