using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Serialization;
using AdminApp.Models.Settings;
using AdminApp.CommunicationClasses;
using AdminApp.Models.EmailSettings;
using AdminApp.Models.InicializationToken;

namespace AdminApp
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
                case "ListAdminData":
                    return typeof(ListAdminData);
                case "AdminPost":
                    return typeof(AdminPost);
                case "InicializationToken":
                    return typeof(InicializationToken);
                case "ListInicializationTokenData":
                    return typeof(ListInicializationTokenData);

            }

            return null;
        }
    }
}