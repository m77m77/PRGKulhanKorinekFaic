using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using DaemonTest.Models.Settings;
using DaemonTest.Models;

namespace DaemonTest.Utilities
{
    public class SettingsSerializationBinder : ISerializationBinder
    {
        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.Name;
        }

        public Type BindToType(string assemblyName, string typeName)
        {
            switch (typeName)
            {
                case "FTPDestination":
                    return typeof(FTPDestination);
                case "LocalNetworkDestination":
                    return typeof(LocalNetworkDestination);
                case "SFTPDestination":
                    return typeof(SFTPDestination);
                case "Settings":
                    return typeof(Settings);
                case "BackupStatus":
                    return typeof(BackupStatus);
            }

            return null;
        }
    }
}
