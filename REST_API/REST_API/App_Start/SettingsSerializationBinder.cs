﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Serialization;
using REST_API.Models.Settings;
using REST_API.CommunicationClasses;

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
            }

            return null;
        }
    }
}