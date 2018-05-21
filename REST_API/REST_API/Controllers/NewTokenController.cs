using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using REST_API.CommunicationClasses;
using REST_API.Models;
using REST_API.Utilities;
using REST_API.Models.Settings;
using REST_API.Models.BackupInfo;

namespace REST_API.Controllers
{
    public class NewTokenController : ApiController
    {

        //POST api/newtoken/admin
        /// <summary>
        /// Admin zažádá o nový token a ověří se pomocí jména a hesla
        /// </summary>
        /// <param name="value">Json od admina, který by měl obsahovat jméno a heslo</param>
        /// <returns>Response; Nový token nebo chybovou hlášku</returns>
        [Route("api/newtoken/admin")]
        public Response PostAdmin([FromBody] AdminPost value)
        {
            Response response;

            using (MySqlConnection connection = WebApiConfig.Connection())
            {
                try
                {
                    connection.Open();

                    string sql =
                    "SELECT id,password FROM admins WHERE name=@name LIMIT 1";

                    MySqlCommand query = new MySqlCommand(sql, connection);
                    query.Parameters.AddWithValue("@name", value.Name);

                    MySqlDataReader reader = query.ExecuteReader();
                    if (reader.Read())
                    {
                        if(HashUtility.VerifyPassword(reader["password"].ToString(),value.Password))
                        {
                            Token newToken = Token.GenerateNewTokenForAdmin(Convert.ToInt32(reader["id"]));

                            if(newToken != null)
                                response = new Response("OK", null, newToken.Value, null);
                            else
                                response = new Response("ERROR", "TokenGenerationFailed", null, null);

                        }
                        else
                            response = new Response("ERROR", "BadPassword", null, null);
                    }
                    else
                        response = new Response("ERROR", "BadUserName", null, null);
                }
                catch (Exception)
                {
                    response = new Response("ERROR", "ConnectionWithDatabaseProblem", null, null);
                }
            }

            return response;
        }


        //POST api/newtoken/admin
        [Route("api/newtoken/daemon")]
        public Response PostDaemon([FromBody] InicializationToken token)
        {
            string value = token.Token;
            Response response;

            using (MySqlConnection connection = WebApiConfig.Connection())
            {
                try
                {
                    connection.Open();

                    string sql =
                    "SELECT id " + 
                    "FROM tokens " +
                    "WHERE token = @token AND status = 'initialize' AND expiration > NOW()";

                    MySqlCommand query = new MySqlCommand(sql, connection);
                    query.Parameters.AddWithValue("@token", value);

                    MySqlDataReader reader = query.ExecuteReader();
                    if (reader.Read())
                    {
                        int idToken = Convert.ToInt32(reader["id"]);
                        reader.Close();
                        string insertDaemonsSQL = "INSERT INTO daemons(name, updateTime,enabled) VALUES ('New daemon',60,0);SELECT last_insert_id();";
                        MySqlCommand insertDaemonsQuery = new MySqlCommand(insertDaemonsSQL, connection);
                        int idDaemon = Convert.ToInt32(insertDaemonsQuery.ExecuteScalar());

                        if(idDaemon > 0)
                        {
                            string deleteSQL = "DELETE FROM tokens WHERE id = @id";
                            MySqlCommand deleteQuery = new MySqlCommand(deleteSQL, connection);

                            deleteQuery.ExecuteNonQuery();

                            Token newToken = Token.GenerateNewTokenForDaemon(idDaemon);

                            if (newToken != null)
                                response = new Response("OK", null, newToken.Value, null);
                            else
                                response = new Response("ERROR", "TokenGenerationFailed", null, null);
                        }
                        else
                        {
                            response = new Response("ERROR", "DatabaseProblem", null, null);
                        }
                    }
                    else
                        response = new Response("ERROR", "BadInitializationToken", null, null);
                }
                catch (Exception)
                {
                    response = new Response("ERROR", "ConnectionWithDatabaseProblem", null, null);
                }
            }

            return response;
            //return new Response("ERROR", "NotYetImplemented", null, null);
        }
    }
}
