using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DaemonTest.DestinationManagers;
using DaemonTest.Models;

namespace DaemonTest.SaveMethods
{
    public interface ISaveMethod
    {
        void Start(IDestinationManager destinationManager,string backupType);
        void AddFile(string dirPath, FileInfo file, Dictionary<string, DateTime> files);
        void End();

        List<BackupDirectory> GetListOfPreviusBackups();
    }
}
