using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASendMail;
using System.Net.Http;
using Newtonsoft.Json;

namespace EmailTest
{
    public class SendEmail
    {
        public EmailSettings settings { get; set; }

        public string Server { get; private set; } = "http://localhost:63058";

        public string Token { get; private set; } = "VXmWiky6lx7n4B8TlEfYnmXx2T2qBd9a";

        public async void SendingEmail()
        {
            SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();

            Response r = new Response();
            r = await GetEmailSettings();
            string emailaddress = ((EmailSettings)r.Data).EmailAddress;

            oMail.From = "faicdavid@seznam.cz";

            oMail.To = emailaddress;
            
            oMail.Subject = "";
            
            oMail.TextBody = "";
            
            SmtpServer oServer = new SmtpServer("");
            Console.WriteLine(emailaddress);


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
