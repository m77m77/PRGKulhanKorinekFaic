using EmailTest.CommunicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTest
{
    public class StartTask
    {
        TaskClass taskClass = new TaskClass();

        public void Start()
        {
            taskClass.Task.Play();
        }
    }
}
