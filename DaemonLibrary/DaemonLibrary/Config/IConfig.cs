using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonLibrary.Config
{
    public interface IConfig
    {
        string Server { get; set; }
        string Token { get; set; }
        string InitializationToken { get; set; }

        void Save();
        bool Load();
    }
}
