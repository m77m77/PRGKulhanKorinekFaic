using DaemonTest.CommunicationClasses;
using DaemonTest.Models;
using DaemonTest.Utilities;
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

        public async static Task<Response> GetBackupsInfos(string type)
        {
            HttpClient client = new HttpClient();
            Response response = new Response();
            try
            {
                HttpResponseMessage httpResponse = await client.GetAsync(serverAddress + "/api/daemon/getInfo/" + token + "/" + type);
                response = JsonSerializationUtility.Deserialize<Response>(await httpResponse.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            return response;
        }

        public async static Task<Response> SendBackupStatus(BackupStatus status)
        {
            HttpClient client = new HttpClient();
            Response response = new Response();
            StringContent sc = new StringContent(JsonSerializationUtility.Serialize(status), Encoding.UTF8, "application/json");
            
            try
            {
                HttpResponseMessage httpResponse = await client.PostAsync(serverAddress + "/api/daemon/" + token,sc);
                response = JsonSerializationUtility.Deserialize<Response>(await httpResponse.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            return response;
        }
    }
}
