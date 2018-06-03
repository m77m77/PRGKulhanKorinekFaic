using CronApp.CommunicationClasses;
using CronApp.HttpRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronApp
{
    public class TokenTask : TimeTask
    {
        public TokenTask() : base(new TimeSpan(23,59,0),new TimeSpan(12,0,0))
        {

        }

        public override void RunInTime(TimeSpan time)
        {
            Task<Response> task = EmailRequests.ExpireTokens();
            task.Wait();
        }
    }
}
