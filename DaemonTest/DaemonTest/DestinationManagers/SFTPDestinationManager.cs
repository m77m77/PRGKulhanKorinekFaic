using DaemonTest.CommunicationClasses;
using DaemonTest.Models;
using DaemonTest.Models.Settings;
using DaemonTest.SaveMethods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Rebex.Net;

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

            this.tempDir = Path.Combine(Path.GetTempPath(), "PRGKulhanKorinekFaic", "FTP");

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
                //sftp.Connect(hostname);

                // authenticate
                //sftp.Login(username, password);

                //sftp.Upload(@"C:\MyData\file1.txt", "/MyData");
                //sftp.Download("/MyData/file2.txt", @"C:\MyData");

                // disconnect (not required, but polite)
                sftp.Disconnect();
            }

            if (Directory.Exists(this.tempDir))
                Directory.Delete(this.tempDir, true);
        }
    }
}
