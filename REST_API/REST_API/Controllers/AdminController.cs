using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace REST_API.Controllers
{
    public class Settings
    {
        public string DataType { get; set; }
        public string TypeOfBackup { get; set; }
        public string BeforeBackup { get; set; }
        public string AfterBackup { get; set; }
        public bool Comprimation { get; set; }
        
        public IDestination Destination {get;set;}
        

        public string Error { get; set; }

        public Settings(string DataType,string TypeOfBackup,string BeforeBackup,string AfterBackup,bool Comprimation,string Error)
        {
            this.AfterBackup = AfterBackup;
            this.BeforeBackup = BeforeBackup;
            this.Comprimation = Comprimation;
            this.DataType = DataType;
            this.TypeOfBackup = TypeOfBackup;
            this.Error = Error;

            this.FTP = ftp;

        }
    }

    public class AdminController : ApiController
    {
        // GET api/admin

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
                settings.Add(new Settings(null, null, ex.ToString()));
            }

            MySqlDataReader Reader = Query.ExecuteReader();

            while (Reader.Read())
            {
                settings.Add(new Settings(Reader["id"].ToString(), Reader["value"].ToString(), null,null,null,null,null,null));
            }

            Reader.Close();
            Connection.Close();

            //for(int i = 0;i > settings.Count;i++)
            //{
            //    string json = JsonConvert.SerializeObject(settings[i]);
            //    yield return json;
            //}

            return settings;
        }
    }
}
