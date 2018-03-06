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

namespace EmailTest
{
    public class SendEmail : ITask
    {
        public EmailSettings settings { get; set; }

        public string Server { get; private set; } = "http://localhost:63058";

        public string Token { get; private set; } = "VXmWiky6lx7n4B8TlEfYnmXx2T2qBd9a";

        public async void SendingEmail()
        {
            //SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();

            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;

            Response emailResponse = new Response();
            emailResponse = await GetEmailSettings();

            Response daemonResponse = new Response();
            daemonResponse = await GetAllDaemonSettings();

            Response daemonBackupInfoResponse = new Response();
            daemonBackupInfoResponse = await GetAllDaemonBackupInfo();
            
            //Console.WriteLine(emailaddress);

            //SmtpServer oServer = new SmtpServer("");
            try
            {
            if(emailResponse.Status == "OK")
            {
            ListEmailSettingsData lesd = (ListEmailSettingsData)emailResponse.Data;
            List<EmailSettings> l = lesd.ListEmailSettings;
            
            

            ListSettingsData lsd = (ListSettingsData)daemonResponse.Data;
            List<Settings> ls = lsd.ListSettings;
            
            message.Body = "";
            
            
            for(int i = 0;i < l.Count;i++)
            {
                        //oMail.From = "info@gmail.com";

                        if(l[i].FromDaemonsDaily != null)
                        {

                            for (int a = 0; a < lesd.ListEmailSettings[i].FromDaemonsDaily.Count; a++)
                            {
                                message.Body = message.Body + lesd.ListEmailSettings[i].Template.Replace("...", ls[a].DaemonName);
                                message.Body = message.Body.Replace("---", ls[a].BackupSourcePath) + "<br />";
                            }

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
                                message.Body = message.Body + lesd.ListEmailSettings[i].Template.Replace("...", ls[a].DaemonName);
                                message.Body = message.Body.Replace("---", ls[a].BackupSourcePath) + "<br />";
                            }

                            message.To.Add(lesd.ListEmailSettings[i].EmailAddress);
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
                                    message.Body = message.Body + lesd.ListEmailSettings[i].Template.Replace("...", ls[a].DaemonName);
                                    message.Body = message.Body.Replace("---", ls[a].BackupSourcePath) + "<br />";
                                }

                                message.To.Add(lesd.ListEmailSettings[i].EmailAddress);
                                message.From = new MailAddress("programovanismtp@gmail.com");
                                oSmtp.EnableSsl = true;
                                oSmtp.Host = "smtp.gmail.com";
                                oSmtp.Credentials = new NetworkCredential("programovanismtp@gmail.com", "heslo123.");
                                oSmtp.Send(message);
                                message.Body = "";
                                message.To.RemoveAt(0);
                            }
                        }

                        //for (int a = 0;a < lesd.ListEmailSettings[i].FromDaemonsDaily.Count; a++)
                        //{
                        //    message.Body = message.Body + lesd.ListEmailSettings[i].Template.Replace("...",ls[a].DaemonName);
                        //    message.Body = message.Body.Replace("---", ls[a].BackupSourcePath) + "<br />";
                        //}
                        //for (int a = 0; a < lesd.ListEmailSettings[i].FromDaemonsWeekly.Count; a++)
                        //{
                        //    message.Body = message.Body + lesd.ListEmailSettings[i].Template.Replace("...", ls[a].DaemonName);
                        //    message.Body = message.Body.Replace("---", ls[a].BackupSourcePath) + "<br />";
                        //}
                        //for (int a = 0; a < lesd.ListEmailSettings[i].FromDaemonsMonthly.Count; a++)
                        //{
                        //    message.Body = message.Body + lesd.ListEmailSettings[i].Template.Replace("...", ls[a].DaemonName);
                        //    message.Body = message.Body.Replace("---", ls[a].BackupSourcePath) + "<br />";
                        //}

                        //Console.WriteLine(message.Body);

                        ////oMail.To = l[i].EmailAddress;

                        ////oMail.Subject = "Daemons report";

                        ////oMail.TextBody = lesd.ListEmailSettings[i].Template;

                        ////oSmtp.SendMail(oServer, oMail);

                        //message.To.Add(lesd.ListEmailSettings[i].EmailAddress);
                        //message.From = new MailAddress("programovanismtp@gmail.com");
                        //oSmtp.EnableSsl = true;
                        //oSmtp.Host = "smtp.gmail.com";
                        //oSmtp.Credentials = new NetworkCredential("programovanismtp@gmail.com", "heslo123.");
                        //oSmtp.Send(message);
                        //message.Body = "";
                        //message.To.RemoveAt(0);
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
                HttpResponseMessage res = await http.GetAsync(this.Server + "/api/email/backup/" + this.Token);
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
