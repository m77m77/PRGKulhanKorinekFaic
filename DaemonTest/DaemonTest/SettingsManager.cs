using DaemonTest.CommunicationClasses;
using DaemonTest.DestinationManagers;
using DaemonTest.Models.Settings;
using DaemonTest.SaveMethods;
using DaemonTest.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DaemonTest
{
    public static class SettingsManager
    {
        public static Settings CurrentSettings { get; private set; }

        public static ISaveMethod GetSaveMethod()
        {
            string saveFormat = CurrentSettings.SaveFormat;
            if (saveFormat == "ZIP")
            {
                return new ZipSaveMethod();
            }
            else if (saveFormat == "PLAIN")
            {
                return new PlainSaveMethod();
            }

            return null;
        }

        public static IDestinationManager GetDestinationManager()
        {
            string destType = CurrentSettings.Destination.Type;
            if (destType == "LOCAL_NETWORK")
            {
                return new LocalNetworkDestinationManager();
            }
            else if(destType == "FTP")
            {
                return new FTPDestinationManager();
            }
            else if(destType == "SFTP")
            {
                return new SFTPDestinationManager();
            }

            return null;
        }

        public async static Task<Response> GetNewSettings()
        {
            HttpClient client = new HttpClient();
            Response response = new Response();
            try
            {
                HttpResponseMessage httpResponse = await client.GetAsync("http://localhost:63058/api/daemon/rBBthQbuOrwM40e3-yvKLk5bspE7,N8Y");
                response = JsonSerializationUtility.Deserialize<Response>(await httpResponse.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            if (response.Status == "OK")
            {
                CurrentSettings = (Settings)response.Data;
            }

            return response;

        }
    }
}
