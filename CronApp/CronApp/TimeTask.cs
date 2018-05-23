using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronApp
{
    public abstract class TimeTask : ITask
    {
        private List<TimeSpan> runAt;

        public TimeTask(params TimeSpan[] times)
        {
            this.runAt = times.ToList();
        }


        public void Run()
        {
            foreach (TimeSpan item in this.runAt)
            {
                if (item.Hours == DateTime.Now.TimeOfDay.Hours && item.Minutes == DateTime.Now.TimeOfDay.Minutes && item.Seconds == DateTime.Now.TimeOfDay.Seconds)
                {
                    this.RunInTime(item);
                }
            }
        }

        public abstract void RunInTime(TimeSpan time);
    }
}
