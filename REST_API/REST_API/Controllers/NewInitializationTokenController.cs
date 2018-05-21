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
    public class NewInitializationTokenController : ApiController
    {
        [Route("api/newinitializationtoken/{token}")]
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

            MySqlConnection Connection = WebApiConfig.Connection();

            MySqlCommand Query = Connection.CreateCommand();

            Query.CommandText = "SELECT id, token,expiration FROM tokens where status='initialize'";

            Response r = new Response();
            ListInicializationTokenData litd = new ListInicializationTokenData();
            litd.ListInicializationToken = new List<InicializationToken>();
            r.Data = litd;

            try
            {
                Connection.Open();
                MySqlDataReader Reader = Query.ExecuteReader();
                int i = 0;
                while (Reader.Read())
                {
                    litd.ListInicializationToken.Add(new InicializationToken());
                    litd.ListInicializationToken[i].Token = Reader["token"].ToString();
                    litd.ListInicializationToken[i].Id = Convert.ToInt32(Reader["id"]);
                    litd.ListInicializationToken[i].Expiration = Convert.ToDateTime(Reader["expiration"]);
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

        [Route("api/newinitializationtoken/{token}")]
        public Response Post(string token)
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

                Token tok = Token.GenerateNewInicializationToken();
                if (tok != null)
                    r.NewToken = tok.Value;
                else
                    r = new Response("ERROR", "TokenGenerationFailed", null, null);
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
        [Route("api/newinitializationtoken/{token}/{id}")]
        public Response Delete(string token, int id)
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

                MySqlCommand query = Connection.CreateCommand();
                query.CommandText = "DELETE FROM tokens WHERE @id = id";

                query.Parameters.AddWithValue("@id", id);

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
