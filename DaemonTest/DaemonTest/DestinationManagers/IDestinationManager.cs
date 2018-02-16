using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonTest.DestinationManagers
{
    public interface IDestinationManager
    {
        string GetPath();
        void Save();
    }
}
