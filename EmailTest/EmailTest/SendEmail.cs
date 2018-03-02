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
    public class SendEmail
    {
        public EmailSettings settings { get; set; }

        public string Server { get; private set; } = "http://localhost:63058";

        public string Token { get; private set; } = "ieJXXqXme7lSFiyzecjcctE46nm23DiS";

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

            
            
            
            for(int i = 0;i < l.Count;i++)
            {
                        //oMail.From = "info@gmail.com";

                        if (l[i].HowOften == "Daily")
                        {

                        }
                        else if (l[i].HowOften == "Weekly")
                        {
                            int diff = (7 + (DateTime.Now.DayOfWeek - DayOfWeek.Monday)) % 7;
                            DateTime monday = DateTime.Now.AddDays(-1 * diff).Date;
                            DateTime sunday = monday.AddDays(6);

                            DateTime time = DateTime.Now;
                            string now = time.ToString("dd.mm.yyyy");
                            if (now != sunday.ToString("dd.mm.yyyy"))
                            {
                                continue;
                            }
                        }
                        else if (l[i].HowOften == "Monthly")
                        {
                            DateTime first = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                            DateTime last = first.AddMonths(1).AddDays(-1);

                            DateTime time = DateTime.Now;
                            string now = time.ToString("dd.mm.yyyy");
                            if (now != last.ToString("dd.mm.yyyy"))
                            {
                                continue;
                            }
                        }
                        for (int a = 0;a < lesd.ListEmailSettings[i].FromDaemons.Count; a++)
                        {
                            message.Body = lesd.ListEmailSettings[i].Template.Replace("...",ls[a].DaemonName);
                            message.Body = message.Body.Replace("---", ls[a].BackupSourcePath) + "\n";
                        }
                        
                        Console.WriteLine(message.Body);

                        //oMail.To = l[i].EmailAddress;

                        //oMail.Subject = "Daemons report";

                        //oMail.TextBody = lesd.ListEmailSettings[i].Template;

                        //oSmtp.SendMail(oServer, oMail);

                        message.To.Add(lesd.ListEmailSettings[i].EmailAddress);
                        message.From = new MailAddress("programovanismtp@gmail.com");
                        oSmtp.EnableSsl = true;
                        oSmtp.Host = "smtp.gmail.com";
                        oSmtp.Credentials = new NetworkCredential("programovanismtp@gmail.com", "heslo123.");
                        oSmtp.Send(message);
                        message.Body = "";
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
    }
}
