using DaemonLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DaemonWindows
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            BackupTimer backupTimer = new BackupTimer();
            backupTimer.Start();

            Timer timer = new Timer(backupTimer.Tick, null, new TimeSpan(0, 0, 0), new TimeSpan(0, 1, 0));
        }

        protected override void OnStop()
        {
        }
    }
}
