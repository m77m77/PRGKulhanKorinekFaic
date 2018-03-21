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
using DaemonTest.Utilities;
using DaemonTest.Models.Settings;

namespace DaemonTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Task<Response> res = SettingsManager.GetNewSettings();
            res.Wait();
            Task<bool> sa = ServerAccess.Connect("http://localhost:63058", "rBBthQbuOrwM40e3-yvKLk5bspE7,N8Y");
            sa.Wait();
            Console.WriteLine(sa.Result);

            Daemon daemon = (Daemon)res.Result.Data;

            SettingsManager settingsManager = new SettingsManager(daemon.Settings[0]);

            IBackupMethod bcMethod = new IncrementalBackupMethod(settingsManager);
            BackupStatus status = bcMethod.Backup();
            Task<Response> response = ServerAccess.SendBackupStatus(status);
            response.Wait();
            Console.WriteLine(JsonSerializationUtility.Serialize(response.Result));
            Console.ReadLine();
        }
    }
}
