using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using EASendMail;
using System.Net.Http;
using Newtonsoft.Json;
using EmailTest.CommunicationClasses;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using EmailTest.Models.BackupInfo;

namespace EmailTest
{
    public class SendEmail : ITask
    {
        public EmailSettings settings { get; set; }

        public string Server { get; private set; } = "http://localhost:63058";

        public string Token { get; private set; } = "PiS-TGP018dizhga6Wkqy6PbtgrwtMi,";

        public async void SendingEmail()
        {
            SmtpClient oSmtp = new SmtpClient();

            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;

            Response emailResponse = new Response();
            emailResponse = await GetEmailSettings();

            Response daemonResponse = new Response();
            daemonResponse = await GetAllDaemonSettings();

            Response daemonBackupInfoResponse = new Response();
            daemonBackupInfoResponse = await GetAllDaemonBackupInfo();
            try
            {
            if(emailResponse.Status == "OK" && daemonResponse.Status == "OK" && daemonBackupInfoResponse.Status == "OK")
            {
            ListEmailSettingsData lesd = (ListEmailSettingsData)emailResponse.Data;
            List<EmailSettings> l = lesd.ListEmailSettings;

            ListDaemonBackupInfoData ldbid = (ListDaemonBackupInfoData)daemonBackupInfoResponse.Data;
            List<BackupStatus> lb = ldbid.ListDaemonBackupInfo;


                    //ListSettingsData lsd = (ListSettingsData)daemonResponse.Data;
                    //List<Settings> ls = lsd.ListSettings;

                    //message.IsBodyHtml = true;

            for(int i = 0;i < l.Count;i++)
            {
                        
                        //oMail.From = "info@gmail.com";

                        if(l[i].FromDaemonsDaily != null)
                        {

                            for (int a = 0; a < lesd.ListEmailSettings[i].FromDaemonsDaily.Count; a++)
                            {
                                for (int e = 0; e < lb.Count; e++)
                                {
                                    if (l[i].FromDaemonsDaily[a] == lb[e].DaemonId)
                                    {
                                        message.Body = message.Body + lesd.ListEmailSettings[i].Template.Replace("<DaemonID>", lb[e].DaemonId.ToString());
                                        message.Body = message.Body.Replace("<BackupType>", lb[e].BackupType) + "<br />";
                                        message.Body = message.Body.Replace("<BackupDate>", Convert.ToString(lb[e].TimeOfBackup));
                                    }
                                }
                                //message.Body = message.Body + lesd.ListEmailSettings[i].Template.Replace("...", ls[a].DaemonName);
                                //message.Body = message.Body.Replace("---", ls[a].BackupSourcePath) + "<br />";
                            }
                            Console.WriteLine(message.Body);
                            //message.IsBodyHtml = true;
                            message.Subject = "Info about backups - daily";
                            message.To.Add(lesd.ListEmailSettings[i].EmailAddress);
                            message.From = new MailAddress("programovanismtp@gmail.com");
                            oSmtp.EnableSsl = true;
                            oSmtp.Host = "smtp.gmail.com";
                            oSmtp.Credentials = new NetworkCredential("programovanismtp@gmail.com", "heslo123.");
                            oSmtp.Send(message);
                            message.Body = "";
                            message.To.RemoveAt(0);
                        }
                        if (l[i].FromDaemonsWeekly != null)
                        {
                            int diff = (7 + (DateTime.Now.DayOfWeek - DayOfWeek.Monday)) % 7;
                            DateTime monday = DateTime.Now.AddDays(-1 * diff).Date;
                            DateTime sunday = monday.AddDays(6);

                            DateTime time = DateTime.Now;
                            string now = time.ToString("dd.mm.yyyy");
                            if (now == sunday.ToString("dd.mm.yyyy"))
                            {
                                for (int a = 0; a < lesd.ListEmailSettings[i].FromDaemonsWeekly.Count; a++)
                            {
                                    for (int e = 0; e < lb.Count; e++)
                                    {
                                        if (l[i].FromDaemonsWeekly[a] == lb[e].DaemonId)
                                        {
                                            message.Body = message.Body + lesd.ListEmailSettings[i].Template.Replace("<DaemonID>", lb[e].DaemonId.ToString());
                                            message.Body = message.Body.Replace("<BackupType>", lb[e].BackupType) + "<br />";
                                            message.Body = message.Body.Replace("<BackupDate>", Convert.ToString(lb[e].TimeOfBackup));
                                        }
                                    }
                                    //message.Body = message.Body + lesd.ListEmailSettings[i].Template.Replace("...", ls[a].DaemonName);
                                    //message.Body = message.Body.Replace("---", ls[a].BackupSourcePath) + "<br />";
                                }

                            message.To.Add(lesd.ListEmailSettings[i].EmailAddress);
                            message.Subject = "Info about backups - weekly";
                            message.From = new MailAddress("programovanismtp@gmail.com");
                            oSmtp.EnableSsl = true;
                            oSmtp.Host = "smtp.gmail.com";
                            oSmtp.Credentials = new NetworkCredential("programovanismtp@gmail.com", "heslo123.");
                            oSmtp.Send(message);
                            message.Body = "";
                            message.To.RemoveAt(0);
                            }
                        }
                        if (l[i].FromDaemonsMonthly != null)
                        {
                            DateTime first = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                            DateTime last = first.AddMonths(1).AddDays(-1);

                            DateTime time = DateTime.Now;
                            string now = time.ToString("dd.mm.yyyy");
                            if (now == last.ToString("dd.mm.yyyy"))
                            {
                                for (int a = 0; a < lesd.ListEmailSettings[i].FromDaemonsMonthly.Count; a++)
                                {
                                    for (int e = 0; e < lb.Count; e++)
                                    {
                                        if (l[i].FromDaemonsMonthly[a] == lb[e].DaemonId)
                                        {
                                            message.Body = message.Body + lesd.ListEmailSettings[i].Template.Replace("<DaemonID>", lb[e].DaemonId.ToString());
                                            message.Body = message.Body.Replace("<BackupType>", lb[e].BackupType) + "<br />";
                                            message.Body = message.Body.Replace("<BackupDate>", Convert.ToString(lb[e].TimeOfBackup));
                                        }
                                    }
                                    //message.Body = message.Body + lesd.ListEmailSettings[i].Template.Replace("...", ls[a].DaemonName);
                                    //message.Body = message.Body.Replace("---", ls[a].BackupSourcePath) + "<br />";
                                }

                                message.To.Add(lesd.ListEmailSettings[i].EmailAddress);
                                message.Subject = "Info about backups - monthly";
                                message.From = new MailAddress("programovanismtp@gmail.com");
                                oSmtp.EnableSsl = true;
                                oSmtp.Host = "smtp.gmail.com";
                                oSmtp.Credentials = new NetworkCredential("programovanismtp@gmail.com", "heslo123.");
                                oSmtp.Send(message);
                                message.Body = "";
                                message.To.RemoveAt(0);
                            }
                        }
                }
            }
            }
            catch (Exception ep)
            {
                Console.WriteLine(ep.Message);
            }
        }
        public async Task<Response> GetEmailSettings()
        {
            HttpClient http = new HttpClient();
            Response response;

            try
            {
                HttpResponseMessage res = await http.GetAsync(this.Server + "/api/email/" + this.Token);
                response = JsonConvert.DeserializeObject<Response>(await res.Content.ReadAsStringAsync(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
            }
            catch
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            return response;
        }

        public async Task<Response> GetAllDaemonSettings()
        {

            HttpClient http = new HttpClient();
            Response response;

            try
            {
                HttpResponseMessage res = await http.GetAsync(this.Server + "/api/admin/" + this.Token);
                response = JsonConvert.DeserializeObject<Response>(await res.Content.ReadAsStringAsync(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
            }
            catch
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            return response;
        }
        public async Task<Response> GetAllDaemonBackupInfo()
        {
            HttpClient http = new HttpClient();
            Response response;

            try
            {
                HttpResponseMessage res = await http.GetAsync(this.Server + "/api/backupstatus/email/" + this.Token + "/MONTHLY");
                response = JsonConvert.DeserializeObject<Response>(await res.Content.ReadAsStringAsync(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
            }
            catch
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            return response;
        }

        public void Play()
        {
            SendEmail se = new SendEmail();
            se.SendingEmail();
        }
    }
}
