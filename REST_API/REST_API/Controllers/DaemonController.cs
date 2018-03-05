using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using REST_API.CommunicationClasses;
using REST_API.Models;
using REST_API.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using REST_API.Models.BackupStatus;

namespace REST_API.Controllers
{
    public class DaemonController : ApiController
    {
        [Route("api/daemon/{token}")]
        public Response Get(string token)
        {
            MySqlConnection Connection = WebApiConfig.Connection();

            Token t = Token.Exists(token);
            if (t == null)
            {
                //token není v databázi  
                return new Response("ERROR", "TokenNotFound", null, null);
            }
            if (!t.IsDaemon)
            {
                //token nepatří daemonovi
                return new Response("ERROR", "TokenIsNotMatched", null, null);
            }

            MySqlCommand Query = Connection.CreateCommand();

            Query.CommandText = "SELECT settings FROM daemons WHERE @id = id";

            Query.Parameters.AddWithValue("@id", t.DaemonID);

            Response r = new Response();

            try
            {
                Connection.Open();
                MySqlDataReader Reader = Query.ExecuteReader();

                while (Reader.Read())
                {
                    Settings s = JsonConvert.DeserializeObject<Settings>(Reader["settings"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
                    s.DaemonID = t.DaemonID;
                    r.Data = s;
                }
                Reader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                r = new Response("ERROR", "ConnectionWithDatabaseProblem", null, null);
            }
            Connection.Close();

            if (r.Status == null)
                r.Status = "OK";

            return r;
        }

        [Route("api/daemon/{token}")]
        public Response Post(string token,[FromBody] BackupStatus status)
        {
            Token t = Token.Exists(token);
            if (t == null)
            {
                //token není v databázi  
                return new Response("ERROR", "TokenNotFound", null, null);
            }
            if (!t.IsDaemon)
            {
                //token nepatří daemonovi
                return new Response("ERROR", "TokenIsNotMatched", null, null);
            }

            Response result;

            using (MySqlConnection connection = WebApiConfig.Connection())
            {
                try
                {
                    connection.Open();

                    string sql = "INSERT INTO backupsInfo(idDaemon, info, backupDate) VALUES (@idDaemon,@info,@date)";

                    MySqlCommand query = new MySqlCommand(sql, connection);
                    query.Parameters.AddWithValue("@idDaemon", t.DaemonID);
                    query.Parameters.AddWithValue("@info", JsonConvert.SerializeObject(status, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() }));
                    query.Parameters.AddWithValue("@date", status.TimeOfBackup);

                    query.ExecuteNonQuery();

                    result = new Response("OK", null,null,null);
                }
                catch (Exception)
                {
                    result = new Response("ERROR", "ConnectionWithDatabaseProblem", null, null);
                }
            }

            return result;
        }
    }
}
