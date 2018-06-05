using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CronTimer timer = new CronTimer(TimeSpan.Zero,new TimeSpan(0,1,0));

            timer.AddTask(new EmailTask());
            timer.AddTask(new TokenTask());

            Console.ReadLine();
        }
    }
}
