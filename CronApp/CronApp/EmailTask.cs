using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CronApp.CommunicationClasses;
using CronApp.HttpRequests;
using CronApp.Models.EmailSettings;

namespace CronApp
{
    public class EmailTask : TimeTask
    {
        public EmailTask(params TimeSpan[] times) : base(times)
        {

        }

        public override void RunInTime(TimeSpan time)
        {
            //Console.WriteLine("NOW");
            Task<Response> taskGetSettings = EmailRequests.GetEmailSettings();
            taskGetSettings.Wait();

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

            if (responseGetSettings.Status != "OK" || responseGetInfoMonthly.Status != "OK" || responseGetInfoWeekly.Status != "OK" || responseGetInfoDaily.Status != "OK")
                return;

            ListEmailSettingsData data = (ListEmailSettingsData)responseGetSettings.Data;

            foreach (EmailSettings item in data.ListEmailSettings)
            {
                if (!item.OwnSmtp)
                    continue;


            }
        }

        private void SendDailyDaemon(EmailSettings setting,ListDaemonBackupInfoData backupInfos)
        {

        }
    }
}
