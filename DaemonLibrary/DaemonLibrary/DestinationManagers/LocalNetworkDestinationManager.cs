using DaemonLibrary.CommunicationClasses;
using DaemonLibrary.Models;
using DaemonLibrary.Models.Settings;
using DaemonLibrary.SaveMethods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DaemonLibrary.DestinationManagers
{
    public class LocalNetworkDestinationManager : IDestinationManager
    {
        private LocalNetworkDestination destination;
        private string dirName;
        private SettingsManager SettingsManager;

        public ISaveMethod SaveMethod { get; private set; }

        public LocalNetworkDestinationManager(LocalNetworkDestination destination, SettingsManager settingsManager)
        {
            this.SettingsManager = settingsManager;
            this.destination = destination;

            this.dirName = SettingsManager.GetFolderNameBasedOnDate();

            string saveFormatSettings = this.destination.SaveFormat;
            if (saveFormatSettings == "ZIP")
            {
                this.SaveMethod = new ZipSaveMethod(this.SettingsManager);
            }
            else if (saveFormatSettings == "PLAIN")
            {
                this.SaveMethod = new PlainSaveMethod(this.SettingsManager);
            }

            

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
