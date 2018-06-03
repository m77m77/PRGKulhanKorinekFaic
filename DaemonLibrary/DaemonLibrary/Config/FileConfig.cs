using DaemonLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DaemonLibrary.Config
{
    public class FileConfig : IConfig
    {
        public string Server { get; set; }

        public string Token { get; set; }

        public string InitializationToken { get; set; }

        private string path;

        public FileConfig()
        {
            this.path = Path.Combine(Environment.CurrentDirectory,"config.json");
        }

        public bool Load()
        {
            //this.Server = "http://localhost:63058";
            //this.Token = "";// "zZn4L8,WKTb6iEPonSEa5vP3dEsHQZmk";
            //this.InitializationToken = "M3d3S5z,hod1XEb5jLaqGOk3FrQvkkvb";

            try
            {
                StreamReader reader = new StreamReader(this.path);

                FileConfig config = JsonSerializationUtility.Deserialize<FileConfig>(reader.ReadToEnd());
                reader.Close();

                this.Server = config.Server;
                this.Token = config.Token;
                this.InitializationToken = config.InitializationToken;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Save()
        {
            try
            {
                StreamWriter writer = new StreamWriter(this.path);
                writer.Write(JsonSerializationUtility.Serialize(this));
                writer.Close();
            }
            catch (Exception)
            {
            }
        }
    }
}
