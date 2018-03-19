using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using REST_API.CommunicationClasses;
using REST_API.Models;
using MySql.Data.MySqlClient;
using REST_API.Models.BackupInfo;
using Newtonsoft.Json;

namespace REST_API.Controllers
{
    public class BackupStatusController : ApiController
    {

        [Route("api/backupstatus/email/{token}/{type}")]
        public Response GetEmail(string token, string type)
        {
            Token t = Token.ExistsEmail(token);
            if (t == null)
            {
                //token není v databázi  
                return new Response("ERROR", "TokenNotFound", null, null);
            }

            Response result;
            DateTime date = DateTime.Now;

            if (type == "DAILY")
            {
                date = DateTime.Today;
            }
            else if (type == "WEEKLY")
            {
                int diff = (7 + (DateTime.Now.DayOfWeek - DayOfWeek.Monday)) % 7;
                date = DateTime.Now.AddDays(-1 * diff).Date;
            }
            else if (type == "MONTHLY")
            {
                date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }

            using (MySqlConnection connection = WebApiConfig.Connection())
            {
                try
                {
                    connection.Open();

                    string sql = "SELECT idDaemon, backupStatus, backupDate, backupType, backupFailMessage, backupErrors, backupFiles FROM backupsInfo WHERE backupDate >= @date";

                    MySqlCommand query = new MySqlCommand(sql, connection);
                    query.Parameters.AddWithValue("@date", date);

                    MySqlDataReader reader = query.ExecuteReader();

                    ListDaemonBackupInfoData data = new ListDaemonBackupInfoData();
                    data.ListDaemonBackupInfo = new List<BackupStatus>();

                    while (reader.Read())
                    {
                        BackupStatus bs = new BackupStatus();
                        bs.DaemonId = Convert.ToInt32(reader["idDaemon"]);
                        bs.Status = reader["backupStatus"].ToString();
                        bs.TimeOfBackup = (DateTime)reader["backupDate"];
                        bs.BackupType = reader["backupType"].ToString();
                        bs.FailMessage = reader["backupFailMessage"].ToString();

                        bs.Errors = JsonConvert.DeserializeObject<List<BackupError>>(reader["backupErrors"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
                        bs.Files = JsonConvert.DeserializeObject<Dictionary<string, DateTime>>(reader["backupFiles"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });

                        data.ListDaemonBackupInfo.Add(bs);
                    }

                    result = new Response("OK", null, null, data);
                }
                catch (Exception)
                {
                    result = new Response("ERROR", "ConnectionWithDatabaseProblem", null, null);
                }
            }

            return result;
        }


        [Route("api/backupstatus/daemon/{token}/{type}")]
        public Response GetDaemon(string token, string type)
        {
            Token t = Token.Exists(token);
            if (t == null)
            {
                //token není v databázi  
                return new Response("ERROR", "TokenNotFound", null, null);
            }
            if (!t.IsDaemon)
            {
                //token nepatří daemonovi
                return new Response("ERROR", "TokenIsNotMatched", null, null);
            }

            Response result;
            DateTime date = DateTime.Now;

            if (type == "DAILY")
            {
                date = DateTime.Today;
            }
            else if (type == "WEEKLY")
            {
                int diff = (7 + (DateTime.Now.DayOfWeek - DayOfWeek.Monday)) % 7;
                date = DateTime.Now.AddDays(-1 * diff).Date;
            }
            else if (type == "MONTHLY")
            {
                date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }

            using (MySqlConnection connection = WebApiConfig.Connection())
            {
                try
                {
                    connection.Open();

                    string sql = "SELECT backupStatus, backupDate, backupType, backupFailMessage, backupErrors, backupFiles FROM backupsInfo WHERE idDaemon = @idDaemon AND backupStatus = 'SUCCESS' AND backupDate >= @date";

                    MySqlCommand query = new MySqlCommand(sql, connection);
                    query.Parameters.AddWithValue("@idDaemon", t.DaemonID);
                    query.Parameters.AddWithValue("@date", date);

                    MySqlDataReader reader = query.ExecuteReader();

                    ListDaemonBackupInfoData data = new ListDaemonBackupInfoData();
                    data.ListDaemonBackupInfo = new List<BackupStatus>();

                    while (reader.Read())
                    {
                        BackupStatus bs = new BackupStatus();
                        bs.DaemonId = t.DaemonID;
                        bs.Status = reader["backupStatus"].ToString();
                        bs.TimeOfBackup = (DateTime)reader["backupDate"];
                        bs.BackupType = reader["backupType"].ToString();
                        bs.FailMessage = reader["backupFailMessage"].ToString();

                        bs.Errors = JsonConvert.DeserializeObject<List<BackupError>>(reader["backupErrors"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
                        bs.Files = JsonConvert.DeserializeObject<Dictionary<string, DateTime>>(reader["backupFiles"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });

                        data.ListDaemonBackupInfo.Add(bs);
                    }

                    result = new Response("OK", null, null, data);
                }
                catch (Exception)
                {
                    result = new Response("ERROR", "ConnectionWithDatabaseProblem", null, null);
                }
            }

            return result;
        }

        [Route("api/backupstatus/daemon/{token}")]
        public Response PostDaemon(string token, [FromBody] BackupStatus status)
        {
            Token t = Token.Exists(token);
            if (t == null)
            {
                //token není v databázi  
                return new Response("ERROR", "TokenNotFound", null, null);
            }
            if (!t.IsDaemon)
            {
                //token nepatří daemonovi
                return new Response("ERROR", "TokenIsNotMatched", null, null);
            }

            Response result;

            using (MySqlConnection connection = WebApiConfig.Connection())
            {
                try
                {
                    connection.Open();

                string sql = "INSERT INTO backupsInfo(idDaemon, backupStatus, backupDate,backupType,backupFailMessage,backupErrors,backupFiles) VALUES (@idDaemon,@status,@date,@type,@failMessage,@errors,@files)";

                MySqlCommand query = new MySqlCommand(sql, connection);
                query.Parameters.AddWithValue("@idDaemon", t.DaemonID);
                query.Parameters.AddWithValue("@status", status.Status);
                query.Parameters.AddWithValue("@date", status.TimeOfBackup);
                query.Parameters.AddWithValue("@type", status.BackupType);
                query.Parameters.AddWithValue("@failMessage", status.FailMessage);
                query.Parameters.AddWithValue("@errors", JsonConvert.SerializeObject(status.Errors, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() }));
                query.Parameters.AddWithValue("@files", JsonConvert.SerializeObject(status.Files, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() }));


                query.ExecuteNonQuery();

                result = new Response("OK", null, null, null);
                }
                catch (Exception)
                {
                    result = new Response("ERROR", "ConnectionWithDatabaseProblem", null, null);
                }
            }

            return result;
        }
    }
}