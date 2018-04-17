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

                    string sql = "SELECT idSettings, backupStatus, backupDate, backupType, backupFailMessage, backupErrors, backupFiles,backupRemovedFiles FROM backupsInfo WHERE backupDate >= @date";

                    MySqlCommand query = new MySqlCommand(sql, connection);
                    query.Parameters.AddWithValue("@date", date);

                    MySqlDataReader reader = query.ExecuteReader();

                    ListDaemonBackupInfoData data = new ListDaemonBackupInfoData();
                    data.ListDaemonBackupInfo = new List<BackupStatus>();

                    while (reader.Read())
                    {
                        BackupStatus bs = new BackupStatus();
                        bs.SettingsID = Convert.ToInt32(reader["idSettings"]);
                        bs.Status = reader["backupStatus"].ToString();
                        bs.TimeOfBackup = (DateTime)reader["backupDate"];
                        bs.BackupType = reader["backupType"].ToString();
                        bs.FailMessage = reader["backupFailMessage"].ToString();

                        bs.Errors = JsonConvert.DeserializeObject<List<BackupError>>(reader["backupErrors"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
                        bs.Files = JsonConvert.DeserializeObject<Dictionary<string, DateTime>>(reader["backupFiles"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
                        bs.RemovedFiles = JsonConvert.DeserializeObject<Dictionary<string, DateTime>>(reader["backupRemovedFiles"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });

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


        [Route("api/backupstatus/daemon/{token}/{type}/{settingsID}")]
        public Response GetDaemon(string token, string type, int settingsID)
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

                    string sql = "SELECT backupStatus, backupDate, backupType, backupFailMessage, backupErrors, backupFiles,backupRemovedFiles FROM backupsInfo WHERE idSettings = @idSettings AND backupStatus = 'SUCCESS' AND backupDate >= @date";

                    MySqlCommand query = new MySqlCommand(sql, connection);
                    query.Parameters.AddWithValue("@idSettings", settingsID);
                    query.Parameters.AddWithValue("@date", date);

                    MySqlDataReader reader = query.ExecuteReader();

                    ListDaemonBackupInfoData data = new ListDaemonBackupInfoData();
                    data.ListDaemonBackupInfo = new List<BackupStatus>();

                    while (reader.Read())
                    {
                        BackupStatus bs = new BackupStatus();
                        bs.SettingsID = settingsID;
                        bs.Status = reader["backupStatus"].ToString();
                        bs.TimeOfBackup = (DateTime)reader["backupDate"];
                        bs.BackupType = reader["backupType"].ToString();
                        bs.FailMessage = reader["backupFailMessage"].ToString();

                        bs.Errors = JsonConvert.DeserializeObject<List<BackupError>>(reader["backupErrors"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
                        bs.Files = JsonConvert.DeserializeObject<Dictionary<string, DateTime>>(reader["backupFiles"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
                        bs.RemovedFiles = JsonConvert.DeserializeObject<Dictionary<string, DateTime>>(reader["backupRemovedFiles"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
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

                string sql = "INSERT INTO backupsInfo(idSettings, backupStatus, backupDate,backupType,backupFailMessage,backupErrors,backupFiles,backupRemovedFiles) VALUES (@idSettings,@status,@date,@type,@failMessage,@errors,@files,@removedFiles)";

                MySqlCommand query = new MySqlCommand(sql, connection);
                query.Parameters.AddWithValue("@idSettings", status.SettingsID);
                query.Parameters.AddWithValue("@status", status.Status);
                query.Parameters.AddWithValue("@date", status.TimeOfBackup);
                query.Parameters.AddWithValue("@type", status.BackupType);
                query.Parameters.AddWithValue("@failMessage", status.FailMessage);
                query.Parameters.AddWithValue("@errors", JsonConvert.SerializeObject(status.Errors, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() }));
                query.Parameters.AddWithValue("@files", JsonConvert.SerializeObject(status.Files, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() }));
                query.Parameters.AddWithValue("@removedFiles", JsonConvert.SerializeObject(status.RemovedFiles, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() }));

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


        [Route("api/backupstatus/daemon/{token}/{type}")]
        public Response GetAllDaemons(string token, string type)
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

                    string sql = "SELECT d.name,idSettings, backupStatus, backupDate, backupType, backupFailMessage, backupErrors, backupFiles,backupRemovedFiles FROM backupsInfo  bi inner join daemonSettings ds on bi.idSettings = ds.id inner join daemons d on ds.idDaemon = daemons.id WHERE backupDate >= @date";

                    MySqlCommand query = new MySqlCommand(sql, connection);
                    query.Parameters.AddWithValue("@date", date);

                    MySqlDataReader reader = query.ExecuteReader();

                    ListBackupStatusName data = new ListBackupStatusName();
                    data.ListBackupStatusNameData = new List<BackupStatusName>();

                    while (reader.Read())
                    {
                        BackupStatusName bs = new BackupStatusName();
                        bs.backupStatus = new BackupStatus();
                        bs.Name = reader["name"].ToString();
                        bs.backupStatus.SettingsID = Convert.ToInt32(reader["idSettings"]);
                        bs.backupStatus.Status = reader["backupStatus"].ToString();
                        bs.backupStatus.TimeOfBackup = (DateTime)reader["backupDate"];
                        bs.backupStatus.BackupType = reader["backupType"].ToString();
                        bs.backupStatus.FailMessage = reader["backupFailMessage"].ToString();

                        bs.backupStatus.Errors = JsonConvert.DeserializeObject<List<BackupError>>(reader["backupErrors"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
                        bs.backupStatus.Files = JsonConvert.DeserializeObject<Dictionary<string, DateTime>>(reader["backupFiles"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
                        bs.backupStatus.RemovedFiles = JsonConvert.DeserializeObject<Dictionary<string, DateTime>>(reader["backupRemovedFiles"].ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
                        data.ListBackupStatusNameData.Add(bs);
                    }

                    result = new Response("OK","","", data);
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