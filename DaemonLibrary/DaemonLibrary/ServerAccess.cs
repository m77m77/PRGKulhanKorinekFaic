using DaemonLibrary.CommunicationClasses;
using DaemonLibrary.Models;
using DaemonLibrary.Utilities;
using DaemonLibrary.Models.Settings;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DaemonLibrary.Config;

namespace DaemonLibrary
{
    public static class ServerAccess
    {
        public static IConfig Config { get; private set; }

        static ServerAccess()
        {
            ServerAccess.Config = new FileConfig();
        }

        private static void CheckNewToken(Response response)
        {
            if (response.Status != "OK")
                return;

            string newToken = response.NewToken;
            if(!String.IsNullOrWhiteSpace(newToken))
            {
                ServerAccess.Config.Token = newToken;
                ServerAccess.Config.InitializationToken = "";
                ServerAccess.Config.Save();
            }
        }

        public async static Task<Response> GetToken()
        {
            HttpClient client = new HttpClient();
            Response response = new Response();
            NewDaemon newDaemon = new NewDaemon() { Name = Environment.MachineName, Token = ServerAccess.Config.InitializationToken }; 
            StringContent sc = new StringContent(JsonSerializationUtility.Serialize(newDaemon), Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage httpResponse = await client.PostAsync(ServerAccess.Config.Server + "/api/newtoken/daemon/", sc);
                response = JsonSerializationUtility.Deserialize<Response>(await httpResponse.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            ServerAccess.CheckNewToken(response);

            return response;
        }

        public async static Task<Response> GetNewSettings()
        {
            HttpClient client = new HttpClient();
            Response response = new Response();
            try
            {
                HttpResponseMessage httpResponse = await client.GetAsync(ServerAccess.Config.Server + "/api/daemon/" + ServerAccess.Config.Token);
                response = JsonSerializationUtility.Deserialize<Response>(await httpResponse.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            ServerAccess.CheckNewToken(response);

            return response;

        }

        public async static Task<Response> GetBackupsInfos(string type,int settingsID)
        {
            HttpClient client = new HttpClient();
            Response response = new Response();
            try
            {
                HttpResponseMessage httpResponse = await client.GetAsync(ServerAccess.Config.Server + "/api/backupstatus/daemon/" + ServerAccess.Config.Token + "/" + type + "/" + settingsID);
                response = JsonSerializationUtility.Deserialize<Response>(await httpResponse.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            ServerAccess.CheckNewToken(response);

            return response;
        }

        public static List<BackupDirectory> GetListOfPreviusBackups(SettingsManager SettingsManager)
        {
            List<BackupDirectory> list = new List<BackupDirectory>();

            Task<Response> response = ServerAccess.GetBackupsInfos(SettingsManager.CurrentSettings.BackupScheme.Type, SettingsManager.CurrentSettings.SettingsID);
            response.Wait();

            if (response.Result.Status == "OK")
            {
                ListDaemonBackupInfoData infos = (ListDaemonBackupInfoData)response.Result.Data;

                foreach (BackupStatus item in infos.ListDaemonBackupInfo)
                {
                    if (item.Status != "SUCCESS")
                        continue;

                    BackupDirectory bd = new BackupDirectory();
                    bd.Files = item.Files;
                    bd.Type = item.BackupType;
                    bd.LastWrite = item.TimeOfBackup;

                    list.Add(bd);
                }
            }

            return list;
        }

        public async static Task<Response> SendBackupStatus(BackupStatus status)
        {
            HttpClient client = new HttpClient();
            Response response = new Response();
            StringContent sc = new StringContent(JsonSerializationUtility.Serialize(status), Encoding.UTF8, "application/json");
            
            try
            {
                HttpResponseMessage httpResponse = await client.PostAsync(ServerAccess.Config.Server + "/api/backupstatus/daemon/" + ServerAccess.Config.Token, sc);
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
