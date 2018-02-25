using System;
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

            if(r.Status == "OK")
            {
            ListEmailSettingsData lesd = (ListEmailSettingsData)r.Data;
            List<EmailSettings> l = lesd.ListEmailSettings;
            string emailaddress = lesd.ListEmailSettings[0].EmailAddress;
            //string emailaddress = ((ListEmailSettingsData)r.Data).ListEmailSettings[0].EmailAddress;

            oMail.From = "davidfaic@seznam.cz";

            oMail.To = emailaddress;
            
            oMail.Subject = "FAJCY";
            
            oMail.TextBody = "JDI SPÁT";
            
            
            }
            
            //Console.WriteLine(emailaddress);

            SmtpServer oServer = new SmtpServer("");
            try
            {
                //Console.WriteLine("start to send email directly ...");
                oSmtp.SendMail(oServer, oMail);
                //Console.WriteLine("email was sent successfully!");
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
