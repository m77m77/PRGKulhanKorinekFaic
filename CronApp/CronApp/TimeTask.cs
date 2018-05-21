using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronApp
{
    public abstract class TimeTask : ITask
    {

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
