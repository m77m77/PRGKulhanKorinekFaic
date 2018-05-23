using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using REST_API.Models.Settings;
using REST_API.CommunicationClasses;
using REST_API.Models;

namespace REST_API.Controllers
{
    public class AdminController : ApiController
    {
        // GET api/admin

        [Route("api/admin/{token}")]
        public Response Get(string token)
        {
            MySqlConnection Connection = WebApiConfig.Connection();

            Token t = Token.Exists(token);
            if (t == null)
            {
                //token není v databázi  
                return new Response("ERROR", "TokenNotFound", null, null);
            }
            if (!t.IsAdmin)
            {
                //token nepatří adminovi  
                return new Response("ERROR", "TokenIsNotMatched", null, null);
            }

            MySqlCommand Query = Connection.CreateCommand();

            Query.CommandText = "SELECT * " +
                                "FROM " +
                                "( " +
                                "SELECT daemons.id AS DaemonID, daemonsSettings.id, daemonsSettings.settings, daemons.name, daemons.updateTime,daemons.enabled, 'FILE' AS typ FROM daemons LEFT JOIN daemonsSettings ON daemons.id = daemonsSettings.idDaemon " +
                                "UNION " +
                                "SELECT daemons.id AS DaemonID, daemonsSettingsDatabase.id, daemonsSettingsDatabase.settings, daemons.name, daemons.updateTime,daemons.enabled, 'DATABASE' AS typ FROM daemons " +
                                "INNER JOIN daemonsSettingsDatabase ON daemons.id = daemonsSettingsDatabase.idDaemon " +
                                ") AS a " +
                                "ORDER BY DaemonID";


            MySqlCommand defaultSettingsQuery = Connection.CreateCommand();

            defaultSettingsQuery.CommandText = "SELECT value FROM systemSettings WHERE name='defaultDaemonSettings'";

            MySqlCommand defaultSettingsDatabaseQuery = Connection.CreateCommand();

            defaultSettingsDatabaseQuery.CommandText = "SELECT value FROM systemSettings WHERE name='defaultDaemonSettingsDatabase'";

            //Query.Parameters.AddWithValue("@id", id);

            Response r = new Response();

            ListSettingsData data = new ListSettingsData();
            data.ListDaemons = new List<Daemon>();
            r.Data = data;


            try
            {
                Connection.Open();
                MySqlDataReader Reader = Query.ExecuteReader();

                Daemon daemon = new Daemon();
                daemon.Settings = new List<Settings>();
                daemon.SettingsDatabase = new List<SettingsDatabase>();
                while (Reader.Read())
                {
                    int dId = Convert.ToInt32(Reader["DaemonID"]);
                    int sId = 0;
                    object sSettings = Reader["settings"];

                    Settings settings = null;
                    SettingsDatabase settingsDatabase = null;

                    if (sSettings != DBNull.Value)
                    {
                        sId = Convert.ToInt32(Reader["id"]);
                        string typ = Reader["typ"].ToString();
                        if(typ == "FILE")
                            settings = JsonConvert.DeserializeObject<Settings>(sSettings.ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
                        else if(typ == "DATABASE")
                            settingsDatabase = JsonConvert.DeserializeObject<SettingsDatabase>(sSettings.ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
                    }
                    string name = Reader["name"].ToString();
                    int updateTime = Convert.ToInt32(Reader["updateTime"].ToString());
                    bool enabled = Convert.ToBoolean(Reader["enabled"]);

                    if (daemon.DaemonID == 0)
                    {
                        daemon.DaemonID = dId;
                        daemon.DaemonName = name;
                        daemon.UpdateTime = updateTime;
                        daemon.Enabled = enabled;
                    }

                    if (daemon.DaemonID == dId)
                    {
                        if (settings != null)
                        {
                            settings.SettingsID = sId;
                            daemon.Settings.Add(settings);
                        }
                        if (settingsDatabase != null)
                        {
                            settingsDatabase.SettingsID = sId;
                            daemon.SettingsDatabase.Add(settingsDatabase);
                        }
                    }
                    else
                    {
                        data.ListDaemons.Add(daemon);
                        daemon = new Daemon();
                        daemon.Settings = new List<Settings>();
                        daemon.SettingsDatabase = new List<SettingsDatabase>();
                        daemon.DaemonID = dId;
                        daemon.DaemonName = name;
                        daemon.UpdateTime = updateTime;
                        daemon.Enabled = enabled;

                        if (settings != null)
                        {
                            settings.SettingsID = sId;
                            daemon.Settings.Add(settings);
                        }
                        if (settingsDatabase != null)
                        {
                            settingsDatabase.SettingsID = sId;
                            daemon.SettingsDatabase.Add(settingsDatabase);
                        }
                    }
                }

                data.ListDaemons.Add(daemon);
                Reader.Close();

                string defaultSettingsJson = defaultSettingsQuery.ExecuteScalar().ToString();
                data.DefaultSettings = JsonConvert.DeserializeObject<Settings>(defaultSettingsJson, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });

                string defaultSettingsDatabaseJson = defaultSettingsDatabaseQuery.ExecuteScalar().ToString();
                data.DefaultSettingsDatabase = JsonConvert.DeserializeObject<SettingsDatabase>(defaultSettingsDatabaseJson, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });

            }
            catch (Exception ex)
            {
                r = new Response("ERROR", "ConnectionWithDatabaseProblem", null, null);
            }
            Connection.Close();

            if (r.Status == null)
                r.Status = "OK";

            return r;
        }

        [Route("api/admin/{token}")]
        public Response Post(string token, [FromBody]Daemon value)
        {
            MySqlConnection Connection = WebApiConfig.Connection();

            Token t = Token.Exists(token);
            if (t == null)
            {
                //token není v databázi  
                return new Response("ERROR", "TokenNotFound", null, null);
            }
            if (!t.IsAdmin)
            {
                //token nepatří adminovi  
                return new Response("ERROR", "TokenIsNotMatched", null, null);
            }
            Response r = new Response();


            try
            {
                Connection.Open();
                
                foreach (Settings item in value.Settings)
                {
                    MySqlCommand Query = Connection.CreateCommand();
                    Query.CommandText = "UPDATE daemonsSettings INNER JOIN daemons ON daemons.id = daemonsSettings.idDaemon SET daemonsSettings.settings = @value,daemons.name = @name,daemons.updateTime = @time,daemons.enabled = @enabled WHERE daemonsSettings.id = @SettingsID AND daemonsSettings.idDaemon = @DaemonID ";
                    Query.Parameters.AddWithValue("@SettingsID", item.SettingsID);
                    Query.Parameters.AddWithValue("@DaemonID", value.DaemonID);
                    Query.Parameters.AddWithValue("@name", value.DaemonName);
                    Query.Parameters.AddWithValue("@time", value.UpdateTime);
                    Query.Parameters.AddWithValue("@enabled", value.Enabled);

                    item.SettingsID = 0;
                    Query.Parameters.AddWithValue("@value", JsonConvert.SerializeObject(item, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() }));
                    Query.ExecuteNonQuery();
                }
                foreach (SettingsDatabase item in value.SettingsDatabase)
                {
                    MySqlCommand QueryDatabase = Connection.CreateCommand();
                    QueryDatabase.CommandText = "UPDATE daemonsSettingsDatabase INNER JOIN daemons ON daemons.id = daemonsSettingsDatabase.idDaemon SET daemonsSettingsDatabase.settings = @value,daemons.name = @name,daemons.updateTime = @time WHERE daemonsSettingsDatabase.id = @SettingsID AND daemonsSettingsDatabase.idDaemon = @DaemonID ";
                    QueryDatabase.Parameters.AddWithValue("@SettingsID", item.SettingsID);
                    QueryDatabase.Parameters.AddWithValue("@DaemonID", value.DaemonID);
                    QueryDatabase.Parameters.AddWithValue("@name", value.DaemonName);
                    QueryDatabase.Parameters.AddWithValue("@time", value.UpdateTime);

                    item.SettingsID = 0;
                    QueryDatabase.Parameters.AddWithValue("@value", JsonConvert.SerializeObject(item, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() }));
                    QueryDatabase.ExecuteNonQuery();
                }
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

        //api/admin/system/{token}

        [Route("api/admin/system/{token}")]
        public Response Post(string token,[FromBody]SystemSettings value)
        {

            MySqlConnection Connection = WebApiConfig.Connection();

            Token t = Token.Exists(token);
            if (t == null)
            {
                //token není v databázi  
                return new Response("ERROR", "TokenNotFound", null, null);
            }
            if (!t.IsAdmin)
            {
                //token nepatří adminovi  
                return new Response("ERROR", "TokenIsNotMatched", null, null);
            }

            MySqlCommand Query = Connection.CreateCommand();

            Response r = new Response();

            try
            {
                Connection.Open();

                Query.CommandText = "UPDATE `3b2_kulhanmatous_db2`.`systemSettings` SET `value` = @Value WHERE `systemSettings`.`name` = @Name";
                Query.Parameters.AddWithValue("@Value", value.Value);
                Query.Parameters.AddWithValue("@Name", value.Name);
                Query.ExecuteNonQuery();
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
