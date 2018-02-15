using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using DaemonTest.DestinationManagers;

namespace DaemonTest.SaveMethods
{
    class ZipSaveMethod : ISaveMethod
    {
        private ZipArchive archive;

        public void Start(IDestinationManager destinationManager, string backupType)
        {
            string fileName = backupType + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".zip";
            archive = ZipFile.Open(Path.Combine(destinationManager.GetPath(),fileName), ZipArchiveMode.Create);
        }

        public void AddFile(string dirPath, FileInfo file)
        {
            archive.CreateEntryFromFile(file.FullName, Path.Combine(dirPath, file.Name),CompressionLevel.Optimal);
        }

        public void End()
        {
            archive.Dispose();
        }

        
    }
}
