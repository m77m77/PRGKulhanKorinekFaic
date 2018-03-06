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
                return new Response("ERROR","TokenNotFound",null,null);
            }
            if (!t.IsAdmin)
            {
                //token nepatří adminovi  
                return new Response("ERROR", "TokenIsNotMatched", null, null);
            }

            MySqlCommand Query = Connection.CreateCommand();

            Query.CommandText = "SELECT settings,id FROM daemons"; //WHERE @id = id";


            MySqlCommand defaultSettingsQuery = Connection.CreateCommand();

            defaultSettingsQuery.CommandText = "SELECT value FROM systemSettings WHERE name='defaultDaemonSettings'";

            //Query.Parameters.AddWithValue("@id", id);

            Response r = new Response();

            ListSettingsData data = new ListSettingsData();
            data.ListSettings = new List<Settings>();
            r.Data = data;

            try
            {
                Connection.Open();
                MySqlDataReader Reader = Query.ExecuteReader();
                int i = 0;
                while (Reader.Read())
                {
                    //data.ListSettings.Add(JsonConvert.DeserializeObject<Settings>(Reader["settings"].ToString()));
                    //JsonConvert.DeserializeObject<Settings>(Reader["settings"].ToString()).DaemonID = Convert.ToInt32(Reader["id"]);

                    data.ListSettings.Add(JsonConvert.DeserializeObject<Settings>(Reader["settings"].ToString(),new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() }));
                    data.ListSettings[i].DaemonID = Convert.ToInt32(Reader["id"]);
                    i++;
                }
                Reader.Close();

                string defaultSettingsJson = defaultSettingsQuery.ExecuteScalar().ToString();
                data.DefaultSettings = JsonConvert.DeserializeObject<Settings>(defaultSettingsJson, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });

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
        public Response Post(string token, [FromBody]Settings value)
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

            //Query.CommandText = "INSERT INTO `3b2_kulhanmatous_db2`.`daemons` (`settings`) VALUES (@value);";
            Query.CommandText = "UPDATE `3b2_kulhanmatous_db2`.`daemons` SET `settings` = @value WHERE `daemons`.`id` = @DaemonID;";

            Query.Parameters.AddWithValue("@DaemonID", value.DaemonID);
            value.DaemonID = t.DaemonID;
            Query.Parameters.AddWithValue("@value", JsonConvert.SerializeObject(value, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() }));
            
            
            Response r = new Response();

            //ListSettingsData data = new ListSettingsData();
            //data.ListSettings = new List<Settings>();
            //r.Data = data;


            try
            {
                Connection.Open();
                Query.ExecuteNonQuery();

                //data.ListSettings.Add(JsonConvert.DeserializeObject<Settings>(value.ToString()));
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
