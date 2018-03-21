using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonTest.Config
{
    public interface IConfig
    {
        public string Server { get; set; }
        public string Token { get; set; }
    }
}
