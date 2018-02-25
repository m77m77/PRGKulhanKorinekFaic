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

        public string Server { get; private set; }

        public string Token { get; private set; }

        public void SendingEmail()
        {
            SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();

            
            oMail.From = "faicdavid@sssvt.cz";

            oMail.To = settings.EmailAddress;
            
            oMail.Subject = "";
            
            oMail.TextBody = "";
            
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
                HttpResponseMessage res = await http.GetAsync(this.Server + "/api/email/emailSettings/" + this.Token);
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
