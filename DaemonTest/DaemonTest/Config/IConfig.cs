using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonTest.Config
{
    public interface IConfig
    {
        string Server { get; set; }
        string Token { get; set; }

        void Save();
        bool Load();
    }
}
