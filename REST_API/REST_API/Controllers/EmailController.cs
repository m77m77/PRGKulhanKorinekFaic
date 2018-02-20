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

            Query.CommandText = "SELECT emailSettings FROM emails WHERE @id = id";

            Query.Parameters.AddWithValue("@id", t.AdminID);

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
    }
}
