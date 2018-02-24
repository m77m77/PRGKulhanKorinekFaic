﻿using DaemonTest.Models.Settings;
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

        public LocalNetworkDestinationManager(LocalNetworkDestination destination)
        {
            this.destination = destination;

            this.dirName = SettingsManager.GetFolderNameBasedOnDate();

        }

        public void DownloadFiles(params string[] startsWith)
        {
            
        }

        public string GetDownloadPath()
        {
            string path = Path.Combine(this.destination.Path, this.dirName);
            Directory.CreateDirectory(path);
            return path;
        }

        public string GetUploadPath()
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
