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
    public class Result
    {
        public string id { get; set; } // id a value > name,surname....
        public string value { get; set; }

        public string error { get; set; }

        public Result(string id, string value, string error)
        {
            this.id = id;
            this.value = value;
            this.error = error;
        }
    }

    public class AdminController : ApiController
    {
        // GET api/admin

        [Route("api/admin/{token}")]
        public List<Result> Get(string token)
        {
            MySqlConnection Connection = WebApiConfig.Connection();

            MySqlCommand Query = Connection.CreateCommand();
            Query.CommandText = "SELECT settings FROM daemons"; //WHERE @id = id";

            //Query.Parameters.AddWithValue("@id", id);
            var results = new List<Result>();

            try
            {
                Connection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                results.Add(new Result(null, null, ex.ToString()));
            }

            MySqlDataReader Fetch_query = Query.ExecuteReader();

            while (Fetch_query.Read())
            {
                results.Add(new Result(Fetch_query["id"].ToString(), Fetch_query["value"].ToString(), null));
            }

            return results;
            //return token;
        }
    }
}
