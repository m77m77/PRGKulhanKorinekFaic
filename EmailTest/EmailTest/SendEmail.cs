﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASendMail;
using System.Net.Http;
using Newtonsoft.Json;
using EmailTest.CommunicationClasses;

namespace EmailTest
{
    public class SendEmail
    {
        public EmailSettings settings { get; set; }

        public string Server { get; private set; } = "http://localhost:63058";

        public string Token { get; private set; } = "ieJXXqXme7lSFiyzecjcctE46nm23DiS";

        public async void SendingEmail()
        {
            SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();

            Response r = new Response();
            r = await GetEmailSettings();

            
            
            //Console.WriteLine(emailaddress);

            SmtpServer oServer = new SmtpServer("");
            try
            {
            if(r.Status == "OK")
            {
            ListEmailSettingsData lesd = (ListEmailSettingsData)r.Data;
            List<EmailSettings> l = lesd.ListEmailSettings;
            
            for(int i = 0;i < l.Count;i++)
            {
                    oMail.From = "info@gmail.com";

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
                            if(now != sunday.ToString("dd.mm.yyyy"))
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
                    oMail.To = l[i].EmailAddress;

                    oMail.Subject = "Subject";

                    oMail.TextBody = "Text";

                    oSmtp.SendMail(oServer, oMail);
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

    }
}
