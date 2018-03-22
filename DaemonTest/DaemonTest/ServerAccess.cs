using DaemonTest.CommunicationClasses;
using DaemonTest.Models;
using DaemonTest.Utilities;
using DaemonTest.Models.Settings;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DaemonTest
{
    public static class ServerAccess
    {
        private static string serverAddress;
        private static string token;

        static ServerAccess()
        {

        }

        private static void CheckNewToken(Response response)
        {
            if (response.Status != "OK")
                return;

            string newToken = response.NewToken;
            if(!String.IsNullOrWhiteSpace(newToken))
            {
                ServerAccess.token = newToken;
            }
        }

        public async static Task<bool> Connect(string serverAddress, string token)
        {
            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage httpResponse = await client.GetAsync(serverAddress);

                if (!httpResponse.IsSuccessStatusCode)
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

            ServerAccess.serverAddress = serverAddress;
            ServerAccess.token = token;

            return true;
        }

        public async static Task<Response> GetNewSettings()
        {
            HttpClient client = new HttpClient();
            Response response = new Response();
            try
            {
                HttpResponseMessage httpResponse = await client.GetAsync(ServerAccess.serverAddress + "/api/daemon/" + ServerAccess.token);
                response = JsonSerializationUtility.Deserialize<Response>(await httpResponse.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            return response;

        }

        public async static Task<Response> GetBackupsInfos(string type,int settingsID)
        {
            HttpClient client = new HttpClient();
            Response response = new Response();
            try
            {
                HttpResponseMessage httpResponse = await client.GetAsync(serverAddress + "/api/backupstatus/daemon/" + token + "/" + type + "/" + settingsID);
                response = JsonSerializationUtility.Deserialize<Response>(await httpResponse.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            ServerAccess.CheckNewToken(response);

            return response;
        }

        public async static Task<Response> SendBackupStatus(BackupStatus status)
        {
            HttpClient client = new HttpClient();
            Response response = new Response();
            StringContent sc = new StringContent(JsonSerializationUtility.Serialize(status), Encoding.UTF8, "application/json");
            
            try
            {
                HttpResponseMessage httpResponse = await client.PostAsync(serverAddress + "/api/backupstatus/daemon/" + token,sc);
                response = JsonSerializationUtility.Deserialize<Response>(await httpResponse.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            ServerAccess.CheckNewToken(response);

            return response;
        }
    }
}
