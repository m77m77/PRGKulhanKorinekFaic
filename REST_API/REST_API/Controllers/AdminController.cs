using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using REST_API.Models.Settings;

namespace REST_API.Controllers
{
    public class AdminController : ApiController
    {
        // GET api/admin
        //public Settings Get()                                                     // testovací metoda get !
        //{
        //    MySqlConnection Connection = WebApiConfig.Connection();

        //    MySqlCommand Query = Connection.CreateCommand();
        //    Query.CommandText = "SELECT settings FROM daemons"; //WHERE @id = id";

        //    //Query.Parameters.AddWithValue("@id", id);
        //    var settings = new List<Settings>();

        //    try
        //    {
        //        Connection.Open();
        //    }
        //    catch (MySql.Data.MySqlClient.MySqlException ex)
        //    {
        //        settings.Add(new Settings(null, null, null, null, true, ex.ToString()));
        //    }

        //    MySqlDataReader Reader = Query.ExecuteReader();

        //    while (Reader.Read())
        //    {
        //        //settings.Add(new Settings(Reader["DataType"].ToString(), Reader["TypeOfBackup"].ToString(), null, null, true, null));
        //        settings.Add(new Settings("a","b","c","d",true,"e"));
        //    }

        //    Reader.Close();
        //    Connection.Close();

        //    //for (int i = 0; i > settings.Count; i++)
        //    //{
        //    //    string json = JsonConvert.SerializeObject(settings[i]);
        //    //    yield return json;
        //    //}

        //    return settings[0];
        //}
        [Route("api/admin/{token}")]
        public List<Settings> Get(string token)
        {
            MySqlConnection Connection = WebApiConfig.Connection();

            MySqlCommand Query = Connection.CreateCommand();
            Query.CommandText = "SELECT settings FROM daemons"; //WHERE @id = id";

            //Query.Parameters.AddWithValue("@id", id);
            var settings = new List<Settings>();

            try
            {
                Connection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                settings.Add(new Settings(null, null,null, null,true, ex.ToString()));
            }

            MySqlDataReader Reader = Query.ExecuteReader();

            while (Reader.Read())
            {
                settings.Add(new Settings(Reader["DataType"].ToString(), Reader["TypeOfBackup"].ToString(), null,null,true,null));
            }

            Reader.Close();
            Connection.Close();

            //for (int i = 0; i > settings.Count; i++)
            //{
            //    string json = JsonConvert.SerializeObject(settings[i]);
            //    yield return json;
            //}

            return settings;
        }
    }
}
