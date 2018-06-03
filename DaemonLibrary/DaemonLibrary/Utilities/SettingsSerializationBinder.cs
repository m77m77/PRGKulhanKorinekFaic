using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using DaemonLibrary.Models.Settings;
using DaemonLibrary.Models;
using DaemonLibrary.CommunicationClasses;

namespace DaemonLibrary.Utilities
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
                case "ListDaemonBackupInfoData":
                    return typeof(ListDaemonBackupInfoData);
                case "Daemon":
                    return typeof(Daemon);

            }

            return null;
        }
    }
}
