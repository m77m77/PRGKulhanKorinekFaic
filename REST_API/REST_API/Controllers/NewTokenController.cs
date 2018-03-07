using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using REST_API.CommunicationClasses;
using REST_API.Models;
using REST_API.Utilities;
using REST_API.Models.Settings;
using REST_API.Models.BackupInfo;

namespace REST_API.Controllers
{
    public class NewTokenController : ApiController
    {
        public BackupStatus Get()
        {
            Settings s = new Settings();
            s.ActionAfterBackup = "RESTART";
            s.BackupSourcePath = @"C:\DATA";
            s.DaemonName = "Main daemon";
            s.Destination = new LocalNetworkDestination() { Path = @"E:\BACKUP" };
            s.SaveFormat = "ZIP";
            BackupScheme scheme = new BackupScheme();
            scheme.Type = "WEEKLY";
            scheme.MaxBackups = 5;
            scheme.BackupTimes = new List<BackupTime>();
            scheme.BackupTimes.Add(new BackupTime() { DayNumber = 1, Time = new TimeSpan(5, 0, 0), Type = "FULL" });
            scheme.BackupTimes.Add(new BackupTime() { DayNumber = 4, Time = new TimeSpan(4, 0, 0), Type = "DIFF" });
            scheme.BackupTimes.Add(new BackupTime() { DayNumber = 7, Time = new TimeSpan(21, 0, 0), Type = "DIFF" });

            s.BackupScheme = scheme;

            return new BackupStatus() { Status = "OK", TimeOfBackup = DateTime.Now, Errors = null, FailMessage = null };
            //return s;
            //return JsonConvert.DeserializeObject<Settings>("{\"DataType\":null,\"BeforeBackup\":null,\"AfterBackup\":null,\"SaveFormat\":null,\"Destination\":{\"$type\":\"REST_API.Models.Settings.FTPDestination, REST_API\",\"Adress\":null,\"Port\":null,\"Username\":null,\"Password\":null,\"Path\":null,\"Type\":\"FTP\"}}", new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto});
            //return JsonConvert.SerializeObject(new Settings() { Destination = new FTPDestination() }, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
        }

        //POST api/newtoken/admin
        /// <summary>
        /// Admin zažádá o nový token a ověří se pomocí jména a hesla
        /// </summary>
        /// <param name="value">Json od admina, který by měl obsahovat jméno a heslo</param>
        /// <returns>Response; Nový token nebo chybovou hlášku</returns>
        [Route("api/newtoken/admin")]
        public Response PostAdmin([FromBody] AdminPost value)
        {
            Response response;

            using (MySqlConnection connection = WebApiConfig.Connection())
            {
                try
                {
                    connection.Open();

                    string sql =
                    "SELECT id,password FROM admins WHERE name=@name LIMIT 1";

                    MySqlCommand query = new MySqlCommand(sql, connection);
                    query.Parameters.AddWithValue("@name", value.Name);

                    MySqlDataReader reader = query.ExecuteReader();
                    if (reader.Read())
                    {
                        if(HashUtility.VerifyPassword(reader["password"].ToString(),value.Password))
                        {
                            Token newToken = Token.GenerateNewTokenForAdmin(Convert.ToInt32(reader["id"]));

                            if(newToken != null)
                                response = new Response("OK", null, newToken.Value, null);
                            else
                                response = new Response("ERROR", "TokenGenerationFailed", null, null);

                        }
                        else
                            response = new Response("ERROR", "BadPassword", null, null);
                    }
                    else
                        response = new Response("ERROR", "BadUserName", null, null);
                }
                catch (Exception)
                {
                    response = new Response("ERROR", "ConnectionWithDatabaseProblem", null, null);
                }
            }

            return response;
        }

        //POST api/newtoken/admin
        [Route("api/newtoken/daemon")]
        public Response PostDaemon([FromBody] string value)
        {
            return new Response("ERROR", "NotYetImplemented", null, null);
        }
    }
}
