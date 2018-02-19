using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASendMail;

namespace EmailTest
{
    public class SendEmail
    {
        public EmailSettings settings { get; set; }

        public void SendingEmail()
        {
            SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();

            
            oMail.From = "faic@david";

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
    }
}
