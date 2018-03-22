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

namespace DaemonTest
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Task<bool> sa = ServerAccess.Connect("http://localhost:63058", "zZn4L8,WKTb6iEPonSEa5vP3dEsHQZmk");
            sa.Wait();
            Console.WriteLine(sa.Result);

            Task<Response> res = ServerAccess.GetNewSettings();
            res.Wait();

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
