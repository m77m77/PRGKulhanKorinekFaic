using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonTest.DestinationManagers
{
    public interface IDestinationManager
    {
        void DownloadFiles(params string[] startsWith);
        string GetUploadPath();
        string GetDownloadPath();
        void Save();
    }
}
