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
            CronTimer timer = new CronTimer(TimeSpan.Zero,new TimeSpan(0,0,1));

            timer.AddTask(new EmailTask(new TimeSpan(8,39,0),new TimeSpan(8, 39, 20)));
            timer.AddTask(new TokenTask());

            Console.ReadLine();
        }
    }
}
