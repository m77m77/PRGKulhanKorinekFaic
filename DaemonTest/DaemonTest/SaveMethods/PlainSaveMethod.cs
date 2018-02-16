using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DaemonTest.DestinationManagers;

namespace DaemonTest.SaveMethods
{
    public class PlainSaveMethod : ISaveMethod
    {
        private DirectoryInfo dir;

        public void Start(IDestinationManager destinationManager, string backupType)
        {
            string dirName = backupType + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm");
            dir = new DirectoryInfo(Path.Combine(destinationManager.GetPath(),dirName));
            dir.Create();
        }

        public void AddFile(string dirPath, FileInfo file)
        {
            Directory.CreateDirectory(Path.Combine(dir.FullName,dirPath));
            file.CopyTo(Path.Combine(dir.FullName, dirPath,file.Name));
        }

        public void End()
        {
            
        }
    }
}
