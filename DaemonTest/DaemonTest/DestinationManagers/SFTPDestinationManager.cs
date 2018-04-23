using DaemonTest.CommunicationClasses;
using DaemonTest.Models;
using DaemonTest.Models.Settings;
using DaemonTest.SaveMethods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DaemonTest.DestinationManagers
{
    public class SFTPDestinationManager : IDestinationManager
    {
        private SFTPDestination destination;
        private string tempDir;
        private SettingsManager SettingsManager;

        public ISaveMethod SaveMethod { get; private set; }

        public SFTPDestinationManager(SFTPDestination destination, SettingsManager settingsManager)
        {
            this.SettingsManager = settingsManager;
            this.destination = destination;

            this.tempDir = Path.Combine(Path.GetTempPath(), "PRGKulhanKorinekFaic", "SFTP");

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
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
