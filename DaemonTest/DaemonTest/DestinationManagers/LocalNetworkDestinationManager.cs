using DaemonTest.Models.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DaemonTest.DestinationManagers
{
    public class LocalNetworkDestinationManager : IDestinationManager
    {
        private LocalNetworkDestination destination;
        private string dirName;
        private SettingsManager SettingsManager;

        public LocalNetworkDestinationManager(LocalNetworkDestination destination, SettingsManager settingsManager)
        {
            this.SettingsManager = settingsManager;
            this.destination = destination;

            this.dirName = SettingsManager.GetFolderNameBasedOnDate();

        }

        public string GetPath()
        {
            string path = Path.Combine(this.destination.Path, this.dirName);
            Directory.CreateDirectory(path);
            return path;
        }

        public void Save()
        {
            
        }
    }
}
