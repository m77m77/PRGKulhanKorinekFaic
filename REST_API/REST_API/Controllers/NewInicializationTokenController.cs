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
    public class NewInicializationTokenController : ApiController
    {
        [Route("api/token/inicialization/{token}")]
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
            //if (t.AdminType != "master")
            //{
            //    return new Response("ERROR", "AdminIsNotMaster", null, null);
            //}

            MySqlConnection Connection = WebApiConfig.Connection();

            MySqlCommand Query = Connection.CreateCommand();

            Query.CommandText = "SELECT token FROM tokens where status='inicialize'";
            //Query.Parameters.AddWithValue("@DaemonID", t.DaemonID);

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
                    litd.ListInicializationToken[i].DaemonID = t.DaemonID;
                    litd.ListInicializationToken[i].Token = Reader["token"].ToString();
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

        [Route("api/token/inicialization/{token}")]
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
            if (t.AdminType != "master")
            {
                return new Response("ERROR", "AdminIsNotMaster", null, null);
            }

            MySqlConnection Connection = WebApiConfig.Connection();

            Response r = new Response();

            try
            {
                Token.GenerateNewInicializationToken(t.DaemonID);
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
