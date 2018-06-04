using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CronApp.Models.BackupInfo;
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
    public static class EmailRequests
    {
        public static string Server { get; private set; } = "http://localhost:63058";

        public static string Token { get; private set; } = "PiS-TGP018dizhga6Wkqy6PbtgrwtMi,";

        public static async Task<Response> ExpireTokens()
        {
            HttpClient http = new HttpClient();
            Response response;

            try
            {
                HttpResponseMessage res = await http.DeleteAsync(EmailRequests.Server + "/api/expirationtokendelete/" + EmailRequests.Token);
                response = JsonConvert.DeserializeObject<Response>(await res.Content.ReadAsStringAsync(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
            }
            catch
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            return response;
        }

        
        public static async Task<Response> GetTemplate()
        {
            HttpClient http = new HttpClient();
            Response response;

            try
            {
                HttpResponseMessage res = await http.GetAsync(EmailRequests.Server + "/api/email/template/" + EmailRequests.Token);
                response = JsonConvert.DeserializeObject<Response>(await res.Content.ReadAsStringAsync(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
            }
            catch
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            return response;
        }


        public static async Task<Response> GetEmailSettings()
        {
            HttpClient http = new HttpClient();
            Response response;

            try
            {
                HttpResponseMessage res = await http.GetAsync(EmailRequests.Server + "/api/email/" + EmailRequests.Token);
                response = JsonConvert.DeserializeObject<Response>(await res.Content.ReadAsStringAsync(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
            }
            catch
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            return response;
        }

        public static async Task<Response> GetBackupInfoMonthly()
        {
            HttpClient http = new HttpClient();
            Response response;

            try
            {
                HttpResponseMessage res = await http.GetAsync(EmailRequests.Server + "/api/backupstatus/email/" + EmailRequests.Token + "/MONTHLY");
                response = JsonConvert.DeserializeObject<Response>(await res.Content.ReadAsStringAsync(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
            }
            catch
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            return response;
        }

        public static async Task<Response> GetBackupInfoWeekly()
        {
            HttpClient http = new HttpClient();
            Response response;

            try
            {
                HttpResponseMessage res = await http.GetAsync(EmailRequests.Server + "/api/backupstatus/email/" + EmailRequests.Token + "/WEEKLY");
                response = JsonConvert.DeserializeObject<Response>(await res.Content.ReadAsStringAsync(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
            }
            catch
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            return response;
        }

        public static async Task<Response> GetBackupInfoDaily()
        {
            HttpClient http = new HttpClient();
            Response response;

            try
            {
                HttpResponseMessage res = await http.GetAsync(EmailRequests.Server + "/api/backupstatus/email/" + EmailRequests.Token + "/DAILY");
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
