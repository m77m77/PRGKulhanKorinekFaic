using DaemonLibrary.SaveMethods;
using System;
using System.Collections.Generic;
using System.Text;
using DaemonLibrary.Models;

namespace DaemonLibrary.DestinationManagers
{
    public interface IDestinationManager
    {
        string GetPath();
        void Save();
        ISaveMethod SaveMethod { get; }
    }
}
