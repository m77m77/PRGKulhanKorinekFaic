using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CronApp
{
    public class CronTimer
    {
        private List<ITask> tasks;
        public CronTimer(TimeSpan dueTime,TimeSpan period)
        {
            this.tasks = new List<ITask>();

            Timer timer = new Timer(this.Tick, null, dueTime,period);
            
        }

        public void AddTask(ITask task)
        {
            this.tasks.Add(task);
        }

        public bool RemoveTask(ITask task)
        {
            return this.tasks.Remove(task);
        }

        public void RemoveTask(int index)
        {
            this.tasks.RemoveAt(index);
        }

        private void Tick(object state)
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString());
            foreach (ITask item in this.tasks)
            {
                item.Run();
            }
        }
    }
}
