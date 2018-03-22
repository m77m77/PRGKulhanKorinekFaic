using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonTest.Config
{
    public interface IConfig
    {
        string Server { get; }
        string Token { get; }

        void Save();
        void Load();
    }
}
