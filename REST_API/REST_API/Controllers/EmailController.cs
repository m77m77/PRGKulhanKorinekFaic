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
using REST_API.Models.BackupStatus;

namespace REST_API.Controllers
{
    public class EmailController : ApiController
    {
        [Route("api/email/{token}")]
        public Response Get(string token)
        {
            MySqlConnection Connection = WebApiConfig.Connection();

            Token t = Token.Exists(token);
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

            Query.CommandText = "SELECT emailSettings FROM emails"; // WHERE @id = id";

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
                    data.ListEmailSettings.Add(JsonConvert.DeserializeObject<EmailSettings>(Reader["emailSettings"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() }));
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
            Query.CommandText = "UPDATE `3b2_kulhanmatous_db2`.`emails` SET `emailSettings` = @value WHERE `emails`.`adminId` = @AdminId;";
            value.AdminId = t.AdminID;
            Query.Parameters.AddWithValue("@AdminId", value.AdminId);

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

            Response r = new Response();
            EmailSettings es = new EmailSettings();
            //ListEmailSettingsData data = new ListEmailSettingsData();
            //data.ListEmailSettings = new List<EmailSettings>();
            //r.Data = data;

            try
            {
                Connection.Open();
                MySqlDataReader Reader = Query.ExecuteReader();

                while (Reader.Read())
                {
                    es = JsonConvert.DeserializeObject<EmailSettings>(Reader["emailSettings"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
                    r.Data = es;
                    //data.ListEmailSettings.Add(JsonConvert.DeserializeObject<EmailSettings>(Reader["emailSettings"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() }));
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

        [Route("api/email/backup/{token}")]
        public Response GetBackupInfo(string token)
        {
            MySqlConnection Connection = WebApiConfig.Connection();

            Token t = Token.Exists(token);
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

            Query.CommandText = "SELECT info,idDaemon,backupType FROM backupsInfo WHERE backupDate > @LastMonth";

            Query.Parameters.AddWithValue("@LastMonth", DateTime.Now.AddMonths(-1));

            Response r = new Response();

            ListDaemonBackupInfoData data = new ListDaemonBackupInfoData();
            data.ListDaemonBackupInfo = new List<BackupStatus>();
            r.Data = data;

            
            try
            {
                Connection.Open();
                MySqlDataReader Reader = Query.ExecuteReader();

                int i = 0;
                while (Reader.Read())
                {
                    data.ListDaemonBackupInfo.Add(JsonConvert.DeserializeObject<BackupStatus>(Reader["info"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() }));
                    data.ListDaemonBackupInfo[i].daemonId = Convert.ToInt32(Reader["idDaemon"]);
                    data.ListDaemonBackupInfo[i].backupType = (Reader["backupType"]).ToString();
                    i++;
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
    }
}
