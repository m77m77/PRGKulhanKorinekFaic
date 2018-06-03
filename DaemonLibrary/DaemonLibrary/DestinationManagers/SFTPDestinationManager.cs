using DaemonLibrary.CommunicationClasses;
using DaemonLibrary.Models;
using DaemonLibrary.Models.Settings;
using DaemonLibrary.SaveMethods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Rebex.Net;

namespace DaemonLibrary.DestinationManagers
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

            Directory.CreateDirectory(this.tempDir);
        }

        public string GetPath()
        {
            return this.tempDir;
        }

        public void Save()
        {
            using (var sftp = new Sftp())
            {
                sftp.Connect(this.destination.Adress,Convert.ToInt32(this.destination.Port));

                sftp.Login(this.destination.Username, this.destination.Password);
                
                sftp.Upload(Path.Combine(this.tempDir,"*"), this.destination.Path + "/" + SettingsManager.GetFolderNameBasedOnDate());

                sftp.Disconnect();
            }

            if (Directory.Exists(this.tempDir))
                Directory.Delete(this.tempDir, true);
        }
    }
}
