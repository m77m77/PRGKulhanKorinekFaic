using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronApp
{
    public class EmailTask : TimeTask
    {
        public EmailTask(params TimeSpan[] times) : base(times)
        {

        }

        public override void RunInTime(TimeSpan time)
        {
            Console.WriteLine("NOW");
        }
    }
}
