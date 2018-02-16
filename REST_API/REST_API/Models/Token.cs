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
                    "SELECT id,idAdmin,idDaemon " +
                    "FROM tokens " +
                    "LEFT JOIN tokensAdmins ON tokens.id = tokensAdmins.idToken " +
                    "LEFT JOIN tokensDaemons ON tokens.id = tokensDaemons.idToken " +
                    "WHERE token=@token AND status='current' LIMIT 1";

                    MySqlCommand query = new MySqlCommand(sql, connection);
                    query.Parameters.AddWithValue("@token", token);

                    MySqlDataReader reader = query.ExecuteReader();
                    if(reader.Read())
                    {
                        result = new Token(token, Convert.ToInt32(reader["id"]), reader["idAdmin"], reader["idDaemon"]);
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
            string sqlInsertIntoTokensAdmins = "INSERT INTO tokensAdmins(idToken,idAdmin) VALUES(@idToken,@idAdmin);";

            MySqlCommand queryInsertIntoTokensAdmins = new MySqlCommand(sqlInsertIntoTokensAdmins);
            queryInsertIntoTokensAdmins.Parameters.AddWithValue("@idAdmin", idAdmin);

            Token token = InsertIntoTokens(queryInsertIntoTokensAdmins);

            if(token != null)
            {
                token.AdminID = idAdmin;
            }

            return token;
        }

        private static Token InsertIntoTokens(MySqlCommand additionalCommand)
        {
            Token result = null;

            using (MySqlConnection connection = WebApiConfig.Connection())
            {
                try
                {
                    string newToken = Token.GenerateNewToken();
                    connection.Open();

                    string sqlInsertIntoTokens =
                    "INSERT INTO tokens(token,status) VALUES(@token,'current');" +
                    "SELECT last_insert_id();";

                    MySqlCommand queryInsertIntoTokens = new MySqlCommand(sqlInsertIntoTokens, connection);
                    queryInsertIntoTokens.Parameters.AddWithValue("@token", newToken);


                    int id =  Convert.ToInt32(queryInsertIntoTokens.ExecuteScalar());

                    additionalCommand.Connection = connection;
                    additionalCommand.Parameters.AddWithValue("@idToken", id);
                    additionalCommand.ExecuteNonQuery();

                    result = new Token(newToken, id, 0, 0);

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
        public bool IsAdmin
        {
            get { return this.AdminID > 0; }
        }
        public bool IsDaemon
        {
            get { return this.DaemonID > 0; }
        }


        private Token(string token, int id, object idAdmin, object idDaemon)
        {
            this.ID = id;
            this.Value = token;
            this.AdminID = idAdmin == DBNull.Value ? 0 : ((int)idAdmin);
            this.DaemonID = idDaemon == DBNull.Value ? 0 : ((int) idDaemon);
        }
    }
}