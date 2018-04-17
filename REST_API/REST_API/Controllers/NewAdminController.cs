using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using REST_API.CommunicationClasses;
using REST_API.Models;
using MySql.Data.MySqlClient;
using REST_API.Models.BackupInfo;
using Newtonsoft.Json;
using REST_API.Utilities;
using REST_API.Models.EmailSettings;

namespace REST_API.Controllers
{
    public class NewAdminController : ApiController
    {
        [Route("api/newadmin/{token}")]
        public Response Post(string token,[FromBody]AdminPost value)
        {
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
            if(t.AdminType != "master")
            {
                return new Response("ERROR", "AdminIsNotMaster", null, null);
            }

            MySqlConnection Connection = WebApiConfig.Connection();

            MySqlCommand QueryInsertAdmin = Connection.CreateCommand();
            MySqlCommand QueryInsertEmail = Connection.CreateCommand();
            MySqlCommand QuerySelectAdminId = Connection.CreateCommand();

            QueryInsertAdmin.CommandText = "INSERT INTO admins (name,password) VALUES (@name,@password);" + " SELECT last_insert_id();";
            QueryInsertAdmin.Parameters.AddWithValue("@name", value.Name);
            QueryInsertAdmin.Parameters.AddWithValue("@password", HashUtility.HashPassword(value.Password));


            Response r = new Response();

            try
            {
                Connection.Open();

                int AdminId = Convert.ToInt32(QueryInsertAdmin.ExecuteScalar());

                QueryInsertEmail.CommandText = "INSERT INTO emails (adminId,emailSettings) VALUES (@adminId,@emailSettings);";
                QueryInsertEmail.Parameters.AddWithValue("@adminId", AdminId);
                QueryInsertEmail.Parameters.AddWithValue("@emailSettings", JsonConvert.SerializeObject(new EmailSettings() {EmailAddress = "",Template = 1, FromDaemonsDaily = new List<int>(), FromDaemonsMonthly = new List<int>(), FromDaemonsWeekly = new List<int>() }, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() }));

                
                QueryInsertEmail.ExecuteNonQuery();
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
        [Route("api/newadmin/delete/{token}/{AdminId}")]
        public Response Delete(string token, int AdminId)
        {
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
            if (t.AdminType != "master")
            {
                return new Response("ERROR", "AdminIsNotMaster", null, null);
            }

            MySqlConnection Connection = WebApiConfig.Connection();

            Response r = new Response();

            try
            {
                Connection.Open();

                MySqlCommand query = Connection.CreateCommand();
                query.CommandText = "DELETE admins.*,emails.*,tokensAdmins.*,tokens.* FROM admins " +
                                    "LEFT JOIN emails ON admins.id = emails.adminId " +
                                    "LEFT JOIN tokensAdmins ON admins.id = tokensAdmins.idAdmin " +
                                    "LEFT JOIN tokens ON tokens.id = tokensAdmins.idToken " +
                                    "WHERE admins.id = @adminId";

                query.Parameters.AddWithValue("@adminId", AdminId);

                query.ExecuteNonQuery();
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
        [Route("api/newadmin/{token}")]
        public Response Get(string token)
        {
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
            if (t.AdminType != "master")
            {
                return new Response("ERROR", "AdminIsNotMaster", null, null);
            }

            MySqlConnection Connection = WebApiConfig.Connection();

            MySqlCommand Query = Connection.CreateCommand();

            Query.CommandText = "SELECT id,name,type FROM admins";

            Response r = new Response();

            ListAdminData data = new ListAdminData();
            data.ListAdmin = new List<AdminPost>();
            r.Data = data;

            try
            {
                Connection.Open();
                MySqlDataReader Reader = Query.ExecuteReader();
                int i = 0;
                while (Reader.Read())
                {
                    data.ListAdmin.Add(new AdminPost());
                    data.ListAdmin[i].Name = Reader["name"].ToString();
                    data.ListAdmin[i].Type = Reader["type"].ToString();
                    data.ListAdmin[i].Id = Convert.ToInt32(Reader["id"]);
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

        [Route("api/newadmin/type/{token}")]
        public Response GetType(string token)
        {
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

            MySqlConnection Connection = WebApiConfig.Connection();

            MySqlCommand Query = Connection.CreateCommand();

            Query.CommandText = "SELECT type FROM admins where id=@AdminID";
            Query.Parameters.AddWithValue("@AdminID", t.AdminID);

            Response r = new Response();
            AdminInfo ai = new AdminInfo();
            //r.Data = ap;

            try
            {
                Connection.Open();
                MySqlDataReader Reader = Query.ExecuteReader();
                
                while (Reader.Read())
                {
                    ai.Type = Reader["Type"].ToString();
                }
                Reader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                r = new Response("ERROR", "ConnectionWithDatabaseProblem", null, null);
            }
            Connection.Close();

            r.Data = ai;

            if (r.Status == null)
                r.Status = "OK";

            return r;
        }
    }
}