using DaemonTest.SaveMethods;
using System;
using System.Collections.Generic;
using System.Text;
using DaemonTest.Models;

namespace DaemonTest.DestinationManagers
{
    public interface IDestinationManager
    {
        string GetPath();
        void Save();
        ISaveMethod SaveMethod { get; }
    }
}
