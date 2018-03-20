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
using REST_API.Models.BackupInfo;

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

            Query.CommandText = "SELECT daemonsSettings.id,daemonsSettings.settings,daemons.name FROM daemonsSettings INNER JOIN daemons ON daemons.id = daemonsSettings.idDaemon WHERE daemons.id = @idDaemon";

            Query.Parameters.AddWithValue("@idDaemon", t.DaemonID);

            Response r = new Response();
            Daemon daemon = new Daemon();
            daemon.DaemonID = t.DaemonID;
            daemon.Settings = new List<Settings>();

            try
            {
                Connection.Open();
                MySqlDataReader Reader = Query.ExecuteReader();

                while (Reader.Read())
                {
                    Settings s = JsonConvert.DeserializeObject<Settings>(Reader["settings"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
                    s.SettingsID = Convert.ToInt32(Reader["id"].ToString());
                    daemon.DaemonName = Reader["name"].ToString();
                    daemon.Settings.Add(s);
                }
                Reader.Close();

                r.Data = daemon;
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
    }
}
