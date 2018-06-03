using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using DaemonLibrary.CommunicationClasses;
using DaemonLibrary.DestinationManagers;
using DaemonLibrary.Models;

namespace DaemonLibrary.SaveMethods
{
    class ZipSaveMethod : ISaveMethod
    {
        private ZipArchive archive;
        private SettingsManager SettingsManager;

        private bool alreadyExists;

        public ZipSaveMethod(SettingsManager settingsManager)
        {
            this.SettingsManager = settingsManager;
        }

        public void Start(IDestinationManager destinationManager, string backupType)
        {
            string fileName = backupType + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".zip";

            string fullName = Path.Combine(destinationManager.GetPath(), fileName);

            this.alreadyExists = File.Exists(fullName);

            if(!this.alreadyExists)
                this.archive = ZipFile.Open(fullName, ZipArchiveMode.Create);
        }

        public void AddFile(string dirPath, FileInfo file,Dictionary<string,DateTime> files)
        {
            if (this.alreadyExists)
                return;

            string fileName = Path.Combine(dirPath, file.Name);

            if(!files.ContainsKey(fileName))
                files.Add(fileName, file.LastWriteTime);

            archive.CreateEntryFromFile(file.FullName, fileName,CompressionLevel.Optimal);
        }

        public void End()
        {
            if (this.alreadyExists)
                return;

            archive.Dispose();
        }

        
    }
}
