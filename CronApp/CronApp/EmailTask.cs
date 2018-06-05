using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CronApp.CommunicationClasses;
using CronApp.HttpRequests;
using CronApp.Models.EmailSettings;
using CronApp.Models.BackupInfo;
using System.Net.Mail;
using System.Net;

namespace CronApp
{
    public class EmailTask : TimeTask
    {
        public EmailTask() : base(new TimeSpan(23,59,0))
        {

        }

        public override void RunInTime(TimeSpan time)
        {
            Console.WriteLine("NOW");
            Task<Response> taskGetSettings = EmailRequests.GetEmailSettings();
            taskGetSettings.Wait();

            Task<Response> taskGetTemplates = EmailRequests.GetTemplate();
            taskGetTemplates.Wait();

            Task<Response> taskGetInfoMonthly = EmailRequests.GetBackupInfoMonthly();
            taskGetInfoMonthly.Wait();
            Task<Response> taskGetInfoWeekly = EmailRequests.GetBackupInfoWeekly();
            taskGetInfoWeekly.Wait();
            Task<Response> taskGetInfoDaily = EmailRequests.GetBackupInfoDaily();
            taskGetInfoDaily.Wait();

            Response responseGetInfoMonthly = taskGetInfoMonthly.Result;
            Response responseGetInfoWeekly = taskGetInfoWeekly.Result;
            Response responseGetInfoDaily = taskGetInfoDaily.Result;

            Response responseGetSettings = taskGetSettings.Result;

            Response responseGetTemplate = taskGetTemplates.Result;

            if (responseGetSettings.Status != "OK" || responseGetInfoMonthly.Status != "OK" || responseGetInfoWeekly.Status != "OK" || responseGetInfoDaily.Status != "OK" || responseGetTemplate.Status != "OK")
                return;

            ListTemplates templates = (ListTemplates)responseGetTemplate.Data;
            ListEmailSettingsData data = (ListEmailSettingsData)responseGetSettings.Data;

            foreach (EmailSettings item in data.ListEmailSettings)
            {
                if (!item.SendEmails)
                    continue;
                
                EmailTemplate template = null;

                foreach (EmailTemplate temp in templates.Templates)
                {
                    if(temp.ID == item.Template)
                    {
                        template = temp;
                        break;
                    }
                }

                SendDaemon(item, item.FromDaemonsDaily, (ListBackupInfoDaemonInfo)responseGetInfoDaily.Data, "Info about backups - daily",template);

                if(DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                {
                    SendDaemon(item, item.FromDaemonsWeekly, (ListBackupInfoDaemonInfo)responseGetInfoWeekly.Data, "Info about backups - weekly", template);
                }

                DateTime first = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime last = first.AddMonths(1).AddDays(-1);

                if (last.Day == DateTime.Now.Day && last.Month == DateTime.Now.Month && last.Year == DateTime.Now.Year)
                {
                    SendDaemon(item, item.FromDaemonsMonthly, (ListBackupInfoDaemonInfo)responseGetInfoMonthly.Data, "Info about backups - monthly", template);
                }
            }
        }

        private void SendMail(EmailSettings settings,string body,string subject)
        {
            SmtpClient smtp = new SmtpClient();

            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;

            message.Subject = subject;
            message.Body = body;
            message.To.Add(settings.EmailAddress);
            if (settings.OwnSmtp)
            {
                message.From = new MailAddress(settings.Username);
                smtp.EnableSsl = false;
                smtp.Host = settings.HostName;
                smtp.Credentials = new NetworkCredential(settings.Username, settings.Password);
            } else {
                message.From = new MailAddress("programovanismtp@gmail.com");
                smtp.EnableSsl = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new NetworkCredential("programovanismtp@gmail.com", "heslo123.");
            }

            smtp.Send(message);
        }

        private void SendDaemon(EmailSettings setting,List<int> daemons,ListBackupInfoDaemonInfo backupInfos,string subject,EmailTemplate template)
        {
            string message = "";
            string daemonsMessage = "";
            string backups = "";
            int prevId = 0;
            foreach (BackupStatusDaemonInfo item in backupInfos.Infos)
            {
                int dId = item.DaemonID;
                if (!daemons.Contains(dId))
                    continue;

                if(dId != prevId)
                {
                    if(prevId != 0)
                    {
                        
                        daemonsMessage = daemonsMessage.Replace(@"|*_BACKUPS_*|", backups);
                        message += daemonsMessage;
                        backups = "";
                        daemonsMessage = "";
                    }

                    daemonsMessage = template.Daemons.Replace(@"|*_NAME_*|", item.DaemonName);

                    prevId = dId;
                }
                string backup = template.Backups;
                backup = backup.Replace(@"|*_DATE_*|", item.BackupStatus.TimeOfBackup.ToShortDateString() + " " + item.BackupStatus.TimeOfBackup.ToShortTimeString());
                backup = backup.Replace(@"|*_TYPE_*|", item.BackupStatus.BackupType);
                backup = backup.Replace(@"|*_STATUS_*|", item.BackupStatus.Status);
                //backup = backup.Replace(@"|*__*|", item.BackupStatus.TimeOfBackup.ToShortDateString());

                backups += backup;
            }

            if(prevId != 0)
            {
                daemonsMessage = daemonsMessage.Replace(@"|*_BACKUPS_*|", backups);
                message += daemonsMessage;
            }


            SendMail(setting, template.Body.Replace(@"|*_DAEMONS_*|",message), subject);
            //Console.WriteLine(message);
        }
    }
}
