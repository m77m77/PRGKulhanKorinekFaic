using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using REST_API.CommunicationClasses;
using REST_API.Models;
using REST_API.Models.EmailSettings;
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
    public class EmailController : ApiController
    {
        [Route("api/email/{token}")]
        public Response Get(string token)
        {
            MySqlConnection Connection = WebApiConfig.Connection();

            Token t = Token.ExistsEmail(token);
            if (t == null)
            {
                //token není v databázi  
                return new Response("ERROR", "TokenNotFound", null, null);
            }
            //if (!t.IsAdmin)
            //{
            //    //token nepatří adminovi  
            //    return new Response("ERROR", "TokenIsNotMatched", null, null);
            //}

            MySqlCommand Query = Connection.CreateCommand();

            Query.CommandText = "SELECT adminId,emailSettings FROM emails"; // WHERE @id = id";

            //Query.Parameters.AddWithValue("@id", t.AdminID);

            Response r = new Response();
            
            ListEmailSettingsData data = new ListEmailSettingsData();
            data.ListEmailSettings = new List<EmailSettings>();
            r.Data = data;

            try
            {
                Connection.Open();
                MySqlDataReader Reader = Query.ExecuteReader();

                while (Reader.Read())
                {
                    EmailSettings es = JsonConvert.DeserializeObject<EmailSettings>(Reader["emailSettings"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
                    es.AdminId = Convert.ToInt32(Reader["adminId"].ToString());
                    data.ListEmailSettings.Add(es);
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

        [Route("api/email/{token}")]
        public Response Post(string token, [FromBody]EmailSettings value)
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
            Query.CommandText = "UPDATE emails SET emailSettings = @value WHERE adminId = @AdminId;";
            value.AdminId = 0;

            Query.Parameters.AddWithValue("@AdminId", t.AdminID);

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

        [Route("api/email/daemonname/{token}/{idDaemon}")]
        public Response GetDaemonName(string token, int idDaemon)
        {
            Token t = Token.ExistsEmail(token);
            if (t == null)
            {
                //token není v databázi  
                return new Response("ERROR", "TokenNotFound", null, null);
            }

            Response response;
            

            using (MySqlConnection connection = WebApiConfig.Connection())
            {
                try
                {
                    connection.Open();

                    string sql = "SELECT name FROM daemons WHERE id=@idDaemon";
                    MySqlCommand query = new MySqlCommand(sql, connection);
                    query.Parameters.AddWithValue("@idDaemon", idDaemon);

                    MySqlDataReader reader = query.ExecuteReader();
                    EmailDaemonName emailDaemonName = new EmailDaemonName();

                    while (reader.Read())
                    {
                        emailDaemonName.Name = reader["name"].ToString();
                    }

                    response = new Response("OK", null, null, emailDaemonName);
                }
                catch (Exception)
                {
                    response = new Response("ERROR", "ConnectionWithDatabaseProblem", null, null);
                }
                
            }

            return response;
        }

        [Route("api/email/OneAdmin/{token}")]
        public Response GetOneAdminEmailSetting(string token)
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

            Query.CommandText = "SELECT emailSettings FROM emails WHERE @adminId = adminId";

            Query.Parameters.AddWithValue("@adminId", t.AdminID);

            MySqlCommand getTemplatesQuery = new MySqlCommand("SELECT id, name FROM emailTemplates", Connection);
            MySqlCommand getDaemonsQuery = new MySqlCommand("SELECT id, name FROM daemons", Connection);

            Response r = new Response();
            EmailAdminData emailAdminData = new EmailAdminData();
            //ListEmailSettingsData data = new ListEmailSettingsData();
            //data.ListEmailSettings = new List<EmailSettings>();
            //r.Data = data;

            try
            {
                Connection.Open();
                MySqlDataReader Reader = Query.ExecuteReader();

                if (Reader.Read())
                {
                    EmailSettings es = JsonConvert.DeserializeObject<EmailSettings>(Reader["emailSettings"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
                    emailAdminData.Settings = es;
                }
                Reader.Close();

                EmailInfo emailInfo = new EmailInfo();
                emailInfo.Templates = new Dictionary<int, string>();
                emailInfo.Daemons = new Dictionary<int, string>();

                
                using (MySqlDataReader readerTemplates = getTemplatesQuery.ExecuteReader())
                {
                    while (readerTemplates.Read())
                    {
                        emailInfo.Templates.Add(Convert.ToInt32(readerTemplates["id"].ToString()), readerTemplates["name"].ToString());
                    }
                }


                using (MySqlDataReader readerDaemons = getDaemonsQuery.ExecuteReader())
                {
                    while (readerDaemons.Read())
                    {
                        emailInfo.Daemons.Add(Convert.ToInt32(readerDaemons["id"].ToString()), readerDaemons["name"].ToString());
                    }
                }

                emailAdminData.Info = emailInfo;

                r.Data = emailAdminData;
                
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
