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
                return new Response(null,"TokenNotFound",null,null);
            }
            if (!t.IsAdmin)
            {
                //token nepatří adminovi  
                return new Response(null, "TokenIsNotMatched", null, null);
            }

            MySqlCommand Query = Connection.CreateCommand();

            Query.CommandText = "SELECT settings FROM daemons"; //WHERE @id = id";

            //Query.Parameters.AddWithValue("@id", id);

            Response r = new Response();

            ListSettingsData data = new ListSettingsData();
            data.ListSettings = new List<Settings>();
            r.Data = data;


            try
            {
                Connection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                
            }

            MySqlDataReader Reader = Query.ExecuteReader();

            while (Reader.Read())
            {
                data.ListSettings.Add(JsonConvert.DeserializeObject<Settings>(Reader["settings"].ToString()));
            }

            Reader.Close();
            Connection.Close();

            return r;
        }
    }
}
