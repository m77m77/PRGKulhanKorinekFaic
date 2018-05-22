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
            Query.CommandText = "SELECT daemonsSettingsDatabase.id,daemonsSettingsDatabase.settings,'DATABASE' AS typ,daemons.name,daemons.updateTime,daemons.enabled " +
                                "FROM daemonsSettingsDatabase " +
                                "INNER JOIN daemons ON daemons.id = daemonsSettingsDatabase.idDaemon "+
                                "WHERE daemons.id = @idDaemon " +
                                "UNION "+
                                "SELECT daemonsSettings.id,daemonsSettings.settings,'FILE' AS typ, daemons.name,daemons.updateTime,daemons.enabled " +
                                "FROM daemonsSettings "+
                                "INNER JOIN daemons ON daemons.id = daemonsSettings.idDaemon "+
                                "WHERE daemons.id = @idDaemon ";

            Query.Parameters.AddWithValue("@idDaemon", t.DaemonID);

            Response r = new Response();
            Daemon daemon = new Daemon();
            daemon.DaemonID = t.DaemonID;
            daemon.Settings = new List<Settings>();
            daemon.SettingsDatabase = new List<SettingsDatabase>();

            try
            {
                Connection.Open();
                MySqlDataReader Reader = Query.ExecuteReader();

                while (Reader.Read())
                {
                    string typ = Reader["typ"].ToString();

                    if(typ == "DATABASE")
                    {
                        SettingsDatabase sd = JsonConvert.DeserializeObject<SettingsDatabase>(Reader["settings"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
                        sd.SettingsID = Convert.ToInt32(Reader["id"].ToString());
                        daemon.SettingsDatabase.Add(sd);
                    }
                    else if(typ == "FILE")
                    {
                        Settings s = JsonConvert.DeserializeObject<Settings>(Reader["settings"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
                        s.SettingsID = Convert.ToInt32(Reader["id"].ToString());
                        daemon.Settings.Add(s);
                    }
                    daemon.DaemonName = Reader["name"].ToString();
                    daemon.UpdateTime = Convert.ToInt32(Reader["updateTime"].ToString());
                    daemon.Enabled = Convert.ToBoolean(Reader["enabled"]);
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
