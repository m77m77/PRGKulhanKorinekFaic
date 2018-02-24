using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using DaemonTest.DestinationManagers;
using DaemonTest.SaveMethods;
using Newtonsoft.Json;
using DaemonTest.Models.Settings;
using System.Threading.Tasks;
using DaemonTest.CommunicationClasses;
using DaemonTest.BackupMethods;
using DaemonTest.Models;

namespace DaemonTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Task<Response> res = SettingsManager.GetNewSettings();
            res.Wait();

            IBackupMethod bcMethod = new IncrementalBackupMethod();
            BackupStatus status = bcMethod.Backup();
            Console.WriteLine(JsonConvert.SerializeObject(status));
            Console.WriteLine("DONE");
            Console.ReadLine();
        }
    }
}
