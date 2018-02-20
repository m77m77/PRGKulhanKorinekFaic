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
                return new LocalNetworkDestinationManager((LocalNetworkDestination)CurrentSettings.Destination);
            }
            else if(destType == "FTP")
            {
                return new FTPDestinationManager((FTPDestination)CurrentSettings.Destination);
            }
            else if(destType == "SFTP")
            {
                return new SFTPDestinationManager((SFTPDestination)CurrentSettings.Destination);
            }

            return null;
        }

        public static string GetFolderNameBasedOnDate()
        {
            string type = CurrentSettings.BackupScheme.Type;

            if (type == "ONE_TIME")
            {
                return type;
            }
            else if (type == "DAILY")
            {
                return type + " " + DateTime.Now.ToString("dd.MM.yyyy");
            }
            else if (type == "WEEKLY")
            {
                int diff = (7 + (DateTime.Now.DayOfWeek - DayOfWeek.Monday)) % 7;
                DateTime monday = DateTime.Now.AddDays(-1 * diff).Date;
                DateTime sunday = monday.AddDays(6);

                return type + " " + monday.ToString("dd.MM.yyyy") + " - " + sunday.ToString("dd.MM.yyyy");
            }
            else if (type == "MONTHLY")
            {
                DateTime first = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime last = first.AddMonths(1).AddDays(-1);

                return type + " " + first.ToString("dd.MM.yyyy") + " - " + last.ToString("dd.MM.yyyy");
            }

            return "";
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
