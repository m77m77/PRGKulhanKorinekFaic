using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DaemonLibrary.DestinationManagers;
using DaemonLibrary.Models;

namespace DaemonLibrary.SaveMethods
{
    public interface ISaveMethod
    {
        void Start(IDestinationManager destinationManager,string backupType);
        void AddFile(string dirPath, FileInfo file, Dictionary<string, DateTime> files);
        void End();



        
    }
}
