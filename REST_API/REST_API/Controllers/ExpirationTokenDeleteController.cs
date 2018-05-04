using MySql.Data.MySqlClient;
using REST_API.CommunicationClasses;
using REST_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace REST_API.Controllers
{
    public class ExpirationTokenDeleteController : ApiController
    {
        [Route("api/expirationtokendelete/{token}/{id}")]
        public Response Delete(string token)
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

            Response r = new Response();

            try
            {
                Connection.Open();

                DateTime now = DateTime.Now.Date;

                MySqlCommand query = Connection.CreateCommand();
                query.CommandText = "DELETE FROM tokens WHERE @now > expiration";

                query.Parameters.AddWithValue("@now", now);

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
    }
}
