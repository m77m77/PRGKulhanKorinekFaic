using EmailTest.CommunicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EmailTest
{
    
    public class TimerClass
    {
        TaskClass tc = new TaskClass();
        public void Timer()
        {
            Timer timer = new Timer();
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = 1000 * 60 * 60 * 24;
            timer.Enabled = true;
            timer.Start();

        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            tc.Task.Play();
        }

    }
}

