using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Serialization;
using REST_API.Models.Settings;
using REST_API.CommunicationClasses;
using REST_API.Models.EmailSettings;
using REST_API.Models.BackupStatus;

namespace REST_API
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
                case "ListSettingsData":
                    return typeof(ListSettingsData);
                case "Settings":
                    return typeof(Settings);
                case "EmailSettings":
                    return typeof(EmailSettings);
                case "ListEmailSettingsData":
                    return typeof(ListEmailSettingsData);
                case "ListDaemonBackupInfo":
                    return typeof(ListDaemonBackupInfoData);
                case "BackupStatus":
                    return typeof(BackupStatus);

            }

            return null;
        }
    }
}