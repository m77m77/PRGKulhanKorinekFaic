using System;
using System.Threading;
using DaemonLibrary;

namespace DaemonMultiplatform
{
    class Program
    {
        static void Main(string[] args)
        {
            BackupTimer backupTimer = new BackupTimer();
            backupTimer.Start();

            Timer timer = new Timer(backupTimer.Tick, null, new TimeSpan(0, 0, 0), new TimeSpan(0, 1, 0));

            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}
