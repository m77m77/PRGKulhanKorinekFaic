using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using REST_API;
using System.Security.Cryptography;

namespace REST_API.Models
{
    public class Token
    {
        /// <summary>
        /// Zkontroluje databázi zda obsahuje token a vrátí instanci třídy Token pro další použití, nebo null pokud v databázi token není.
        /// </summary>
        /// <param name="token">Token který se kontroluje</param>
        /// <returns>Instanci třídy Token nebo null</returns>
        public static Token Exists(string token)
        {
            Token result = null;

            using (MySqlConnection connection = WebApiConfig.Connection()) {
                try
                {
                    connection.Open();

                    string sql =
                    "SELECT tokens.id,idAdmin,idDaemon,type " +
                    "FROM tokens " +
                    "LEFT JOIN tokensAdmins ON tokens.id = tokensAdmins.idToken " +
                    "LEFT JOIN admins ON tokensAdmins.idAdmin = admins.id " +
                    "LEFT JOIN tokensDaemons ON tokens.id = tokensDaemons.idToken " +
                    "WHERE token=@token AND status='current' LIMIT 1";

                    MySqlCommand query = new MySqlCommand(sql, connection);
                    query.Parameters.AddWithValue("@token", token);

                    MySqlDataReader reader = query.ExecuteReader();
                    if(reader.Read())
                    {
                        result = new Token(token, Convert.ToInt32(reader["id"]), reader["idAdmin"], reader["idDaemon"], reader["type"]);
                    }
                }
                catch (Exception)
                {
                }
            }

            return result;
        }

        public static Token ExistsEmail(string token)
        {
            Token result = null;

            using (MySqlConnection connection = WebApiConfig.Connection())
            {
                try
                {
                    connection.Open();

                    string sql =
                    "SELECT tokens.id " +
                    "FROM tokens " +
                    "WHERE token=@token AND status='email' LIMIT 1";

                    MySqlCommand query = new MySqlCommand(sql, connection);
                    query.Parameters.AddWithValue("@token", token);

                    MySqlDataReader reader = query.ExecuteReader();
                    if (reader.Read())
                    {
                        result = new Token(token, Convert.ToInt32(reader["id"]), 0,0, null);
                    }
                }
                catch (Exception)
                {
                }
            }

            return result;
        }


        /// <summary>
        /// Generuje nový token pro admina. Vrací instanci třídy Token, nebo null při vyjímce.
        /// </summary>
        /// <param name="idAdmin">Id admina</param>
        /// <returns>Instance třídy Token nebo null</returns>
        public static Token GenerateNewTokenForAdmin(int idAdmin)
        {
            Token result = null;
            using (MySqlConnection connection = WebApiConfig.Connection())
            {
                try
                {
                    string newToken = Token.GenerateNewToken();
                    connection.Open();

                    string sqlUpdate = 
                    "UPDATE tokens INNER JOIN tokensAdmins ON tokens.id = tokensAdmins.idToken " +
                    "SET tokens.token = @newToken " +
                    "WHERE tokensAdmins.idAdmin = @adminId AND status='current'";

                    MySqlCommand queryUpdate = new MySqlCommand(sqlUpdate, connection);
                    queryUpdate.Parameters.AddWithValue("@newToken", newToken);
                    queryUpdate.Parameters.AddWithValue("@adminId", idAdmin);

                    int rows = queryUpdate.ExecuteNonQuery();

                    if(rows <= 0)
                    {
                        string sqlInsertIntoTokens =
                        "INSERT INTO tokens(token,status) VALUES(@token,'current');" +
                        "SELECT last_insert_id();";

                        MySqlCommand queryInsertIntoTokens = new MySqlCommand(sqlInsertIntoTokens, connection);
                        queryInsertIntoTokens.Parameters.AddWithValue("@token", newToken);

                        
                        int id = Convert.ToInt32(queryInsertIntoTokens.ExecuteScalar());

                        string sqlInsertIntoTokensAdmins = "INSERT INTO tokensAdmins(idToken,idAdmin) VALUES(@idToken,@idAdmin);";

                        MySqlCommand queryInsertIntoTokensAdmins = new MySqlCommand(sqlInsertIntoTokensAdmins,connection);
                        queryInsertIntoTokensAdmins.Parameters.AddWithValue("@idAdmin", idAdmin);
                        queryInsertIntoTokensAdmins.Parameters.AddWithValue("@idToken", id);
                        queryInsertIntoTokensAdmins.ExecuteNonQuery();


                        MySqlCommand queryGetAdminType = new MySqlCommand("SELECT type FROM admins WHERE id = @adminId",connection);
                        queryGetAdminType.Parameters.AddWithValue("@adminId", idAdmin);
                        string type = queryGetAdminType.ExecuteScalar().ToString();

                        result = new Token(newToken, id, idAdmin, 0,type);
                    }else
                    {
                        result = Exists(newToken);
                    }
                }
                catch (Exception)
                {

                }
            }

            return result;
        }

        public static Token GenerateNewTokenForDaemon(int idDaemon)
        {
            Token result = null;
            using (MySqlConnection connection = WebApiConfig.Connection())
            {
                try
                {
                    string newToken = Token.GenerateNewToken();
                    connection.Open();

                    string sqlUpdate =
                    "UPDATE tokens INNER JOIN tokensDaemons ON tokens.id = tokensDaemons.idToken " +
                    "SET tokens.token = @newToken " +
                    "WHERE tokensDaemons.idDaemon = @daemonId AND status='current'";

                    MySqlCommand queryUpdate = new MySqlCommand(sqlUpdate, connection);
                    queryUpdate.Parameters.AddWithValue("@newToken", newToken);
                    queryUpdate.Parameters.AddWithValue("@daemonId", idDaemon);

                    int rows = queryUpdate.ExecuteNonQuery();

                    if (rows <= 0)
                    {
                        string sqlInsertIntoTokens =
                        "INSERT INTO tokens(token,status) VALUES(@token,'current');" +
                        "SELECT last_insert_id();";

                        MySqlCommand queryInsertIntoTokens = new MySqlCommand(sqlInsertIntoTokens, connection);
                        queryInsertIntoTokens.Parameters.AddWithValue("@token", newToken);


                        int id = Convert.ToInt32(queryInsertIntoTokens.ExecuteScalar());

                        string sqlInsertIntoTokensAdmins = "INSERT INTO tokensDaemons(idToken,idDaemon) VALUES(@idToken,@daemonId);";

                        MySqlCommand queryInsertIntoTokensAdmins = new MySqlCommand(sqlInsertIntoTokensAdmins, connection);
                        queryInsertIntoTokensAdmins.Parameters.AddWithValue("@daemonId", idDaemon);
                        queryInsertIntoTokensAdmins.Parameters.AddWithValue("@idToken", id);
                        queryInsertIntoTokensAdmins.ExecuteNonQuery();

                        result = new Token(newToken, id, idDaemon, 0, null);
                    }
                    else
                    {
                        result = Exists(newToken);
                    }
                }
                catch (Exception)
                {

                }
            }

            return result;
        }

        public static Token GenerateNewInicializationToken()
        {
            Token result = null;
            using (MySqlConnection connection = WebApiConfig.Connection())
            {
                try
                {
                    string newToken = Token.GenerateNewToken();
                    connection.Open();

                        string sqlInsertIntoTokens =
                        "INSERT INTO tokens(token,status) VALUES(@token,'initialize');" +
                        "SELECT last_insert_id();";

                        MySqlCommand queryInsertIntoTokens = new MySqlCommand(sqlInsertIntoTokens, connection);
                        queryInsertIntoTokens.Parameters.AddWithValue("@token", newToken);


                        int id = Convert.ToInt32(queryInsertIntoTokens.ExecuteScalar());

                        result = new Token(newToken, id, null, 0, null);
                }
                catch (Exception)
                {

                }
            }

            return result;
        }

        private static string GenerateNewToken()
        {
            const int length = 32;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890,-";
            char[] result = new char[length];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                for (int i = 0; i < length; i++)
                {
                    rng.GetBytes(uintBuffer);
                    uint rndNum = BitConverter.ToUInt32(uintBuffer, 0);
                    result[i] = valid[(int)(rndNum % (uint)valid.Length)];
                }
            }

            return new string(result);
        }

        public int ID { get; private set; }
        public string Value { get; private set; }
        public int AdminID { get; private set; }
        public int DaemonID { get; private set; }
        public string AdminType { get; set; }
        public bool IsAdmin
        {
            get { return this.AdminID > 0; }
        }
        public bool IsDaemon
        {
            get { return this.DaemonID > 0; }
        }


        private Token(string token, int id, object idAdmin, object idDaemon,object adminType)
        {
            this.ID = id;
            this.Value = token;
            this.AdminID = idAdmin == DBNull.Value ? 0 : ((int)idAdmin);
            this.DaemonID = idDaemon == DBNull.Value ? 0 : ((int) idDaemon);
            this.AdminType = adminType != null ? adminType.ToString() : null;
        }
    }
}