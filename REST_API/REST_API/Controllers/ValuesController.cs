using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace REST_API.Controllers
{
    /// <summary>
    /// https://www.youtube.com/watch?v=TcovfE8IsHs
    /// </summary>

    public class Result
    {
        public string xxx { get; set; } // xxx a yyy > name,surname....
        public string yyy { get; set; }

        public string error { get; set; }

        public Result(string xxx,string yyy,string error)
        {
            this.xxx = xxx;
            this.yyy = yyy;
            this.error = error;
        }
    }

    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public List<Result> Get(int id)
        {
            MySqlConnection Connection = WebApiConfig.Connection();

            MySqlCommand Query = Connection.CreateCommand();
            Query.CommandText = "SELECT xxx FROM xxx WHERE @id = id";

            Query.Parameters.AddWithValue("@id", id);
            var results = new List<Result>();

            try
            {
                Connection.Open();
            }
            catch(MySql.Data.MySqlClient.MySqlException ex)
            {
                results.Add(new Result(null, null, ex.ToString()));
            }

            MySqlDataReader Fetch_query = Query.ExecuteReader();

            while(Fetch_query.Read())
            {
                results.Add(new Result(Fetch_query["xxx"].ToString(), Fetch_query["yyy"].ToString(),null));
            }

            return results;
            //return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
