using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DaemonTest.CommunicationClasses;
using DaemonTest.DestinationManagers;
using DaemonTest.Models;

namespace DaemonTest.SaveMethods
{
    public class PlainSaveMethod : ISaveMethod
    {
        private DirectoryInfo dir;
        private SettingsManager SettingsManager;

        private bool alreadyExists;

        public PlainSaveMethod(SettingsManager settingsManager)
        {
            this.SettingsManager = settingsManager;
        }

        public void Start(IDestinationManager destinationManager, string backupType)
        {
            string dirName = backupType + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm");
            dir = new DirectoryInfo(Path.Combine(destinationManager.GetPath(),dirName));
            this.alreadyExists = dir.Exists;

            if(!this.alreadyExists)
                dir.Create();
        }

        public void AddFile(string dirPath, FileInfo file, Dictionary<string, DateTime> files)
        {
            if (this.alreadyExists)
                return;

            string fileName = Path.Combine(dirPath, file.Name);

            if (!files.ContainsKey(fileName))
                files.Add(fileName, file.LastWriteTime);

            Directory.CreateDirectory(Path.Combine(dir.FullName,dirPath));
            file.CopyTo(Path.Combine(dir.FullName, fileName));
        }

        public void End()
        {
            
        }
    }
}
