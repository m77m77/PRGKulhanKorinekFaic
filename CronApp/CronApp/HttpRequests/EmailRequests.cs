using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CronApp.Models.BackupInfo;
using CronApp.Models.EmailSettings;
using CronApp.Models.Settings;
using CronApp.CommunicationClasses;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Net.Http;

namespace CronApp.HttpRequests
{
    public class EmailRequests
    {
        public string Server { get; private set; } = "http://localhost:63058";

        public string Token { get; private set; } = "PiS-TGP018dizhga6Wkqy6PbtgrwtMi,";

        public async Task<Response> GetEmailSettings()
        {
            HttpClient http = new HttpClient();
            Response response;

            try
            {
                HttpResponseMessage res = await http.GetAsync(this.Server + "/api/email/" + this.Token);
                response = JsonConvert.DeserializeObject<Response>(await res.Content.ReadAsStringAsync(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
            }
            catch
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            return response;
        }

        public async Task<Response> GetAllDaemonSettings()
        {

            HttpClient http = new HttpClient();
            Response response;

            try
            {
                HttpResponseMessage res = await http.GetAsync(this.Server + "/api/admin/" + this.Token);
                response = JsonConvert.DeserializeObject<Response>(await res.Content.ReadAsStringAsync(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
            }
            catch
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            return response;
        }
        public async Task<Response> GetAllDaemonBackupInfo()
        {
            HttpClient http = new HttpClient();
            Response response;

            try
            {
                HttpResponseMessage res = await http.GetAsync(this.Server + "/api/backupstatus/email/" + this.Token + "/MONTHLY");
                response = JsonConvert.DeserializeObject<Response>(await res.Content.ReadAsStringAsync(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
            }
            catch
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            return response;
        }

    }
}
