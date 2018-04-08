using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonTest.Config
{
    public class FileConfig : IConfig
    {
        public string Server { get; set; }

        public string Token { get; set; }

        public bool Load()
        {
            this.Server = "http://localhost:63058";
            this.Token = "zZn4L8,WKTb6iEPonSEa5vP3dEsHQZmk";

            return true;
        }

        public void Save()
        {
            
        }
    }
}
