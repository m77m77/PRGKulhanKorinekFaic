using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CronApp.Models.BackupInfo;
using CronApp.Models.EmailSettings;
using CronApp.Models.Settings;
using CronApp.CommunicationClasses;
using Newtonsoft.Json.Serialization;

namespace CronApp
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
                case "ListDaemonBackupInfoData":
                    return typeof(ListDaemonBackupInfoData);
                case "BackupStatus":
                    return typeof(BackupStatus);
                case "Errors":
                    return typeof(BackupError);
            }

            return null;
        }
    }
}
