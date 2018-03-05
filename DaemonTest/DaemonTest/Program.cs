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

            //Uri uri = new Uri("prgkulhankorinekfaic.g6.cz/web/BACKUP/WEEKLY 19.02.2018 - 25.02.2018/FULL_24_02_2018_21_21/a.txt", UriKind.Absolute);

            //IDestinationManager manager = SettingsManager.GetDestinationManager();
            //manager.Save();
            //SettingsManager.CurrentSettings.Destination = new LocalNetworkDestination() { Path = @"E:\BACKUP" };

            IBackupMethod bcMethod = new DifferentialBackupMethod();
            BackupStatus status = bcMethod.Backup();
            Console.WriteLine(JsonConvert.SerializeObject(status));
            Console.WriteLine("DONE");
            Console.ReadLine();
        }
    }
}
