using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronApp
{
    public class EmailTask : ITask
    {
        int curr = 0;
        public void Run()
        {
            Console.WriteLine((char)curr);
            curr++;
        }
    }
}
