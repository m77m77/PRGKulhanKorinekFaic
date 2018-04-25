using MySql.Data.MySqlClient;
using REST_API.CommunicationClasses;
using REST_API.Models;
using REST_API.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace REST_API.Controllers
{
    public class NewSettingsController : ApiController
    {
        [Route("api/newsettings/{token}")]
        public Response Post(string token, [FromBody] Daemon daemon)
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

            Response response;


            using (MySqlConnection connection = WebApiConfig.Connection())
            {
                try
                {
                    connection.Open();

                    string sql = "INSERT INTO daemonsSettings(idDaemon,settings) SELECT @idDaemon, value FROM systemSettings WHERE name='defaultDaemonSettings'";
                    MySqlCommand query = new MySqlCommand(sql, connection);
                    query.Parameters.AddWithValue("@idDaemon", daemon.DaemonID);

                    query.ExecuteNonQuery();

                    response = new Response("OK", null, null, null);
                }
                catch (Exception)
                {
                    response = new Response("ERROR", "ConnectionWithDatabaseProblem", null, null);
                }

            }

            return response;
        }
        [Route("api/newsettingsdatabase/{token}")]
        public Response PostDatabase(string token, [FromBody] Daemon daemon)
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

            Response response;


            using (MySqlConnection connection = WebApiConfig.Connection())
            {
                try
                {
                    connection.Open();

                    string sqlDatabase = "INSERT INTO daemonsSettingsDatabase(idDaemon,settings) SELECT value FROM systemSettings WHERE name='defaultDaemonSettingsDatabase'";
                    MySqlCommand queryDatabase = new MySqlCommand(sqlDatabase, connection);
                    queryDatabase.Parameters.AddWithValue("@idDaemon", daemon.DaemonID);

                    queryDatabase.ExecuteNonQuery();

                    response = new Response("OK", null, null, null);
                }
                catch (Exception)
                {
                    response = new Response("ERROR", "ConnectionWithDatabaseProblem", null, null);
                }

            }

            return response;
        }

        [Route("api/newsettings/delete/{token}/{SettingsID}")]
        public Response Delete(string token, int SettingsID)
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

            Response response;


            using (MySqlConnection connection = WebApiConfig.Connection())
            {
                try
                {
                    connection.Open();

                    string sql = "DELETE FROM daemonsSettings WHERE id = @id; ";
                    MySqlCommand query = new MySqlCommand(sql, connection);
                    query.Parameters.AddWithValue("@id", SettingsID);

                    query.ExecuteNonQuery();

                    response = new Response("OK", null, null, null);
                }
                catch (Exception)
                {
                    response = new Response("ERROR", "ConnectionWithDatabaseProblem", null, null);
                }

            }

            return response;
        }
    }
}
