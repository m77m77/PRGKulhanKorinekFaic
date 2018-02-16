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

namespace DaemonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Task<bool> a = SettingsManager.GetNewSettings();
            a.Wait();
            Console.WriteLine(SettingsManager.CurrentSettings.DaemonName);
            Console.ReadLine();
        }
    }
}
