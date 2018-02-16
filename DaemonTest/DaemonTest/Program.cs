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

namespace DaemonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(Path.GetTempFileName());

            Console.WriteLine(File.Exists(@"C:\Users\Matouš\AppData\Local\Temp\PRGKulhanKorinekFaic\FTP\WEEKLY - 1\FULL_15_02_2018_18_47.zip"));
            //Console.WriteLine(JsonConvert.SerializeObject(new Settings() { Destination = new FTPDestination() },new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Auto,SerializationBinder = new SettingsSerializationBinder() }));
            JsonConvert.DeserializeObject<Settings>("{\"DaemonID\":0,\"DaemonName\":null,\"BackupSourcePath\":null,\"ActionAfterBackup\":null,\"SaveFormat\":null,\"BackupScheme\":null,\"Destination\":{\"$type\":\"REST_API.Models.Settings.FTPDestination, REST_API\",\"Adress\":null,\"Port\":null,\"Username\":null,\"Password\":null,\"Path\":null,\"Type\":\"FTP\"}}", new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
            Console.ReadLine();
            ISaveMethod m = new ZipSaveMethod();
            m.Start(new FTPDestinationManager(),"FULL");
            m.AddFile(@"ABCD", new System.IO.FileInfo(@"F:\Obrázky\Google Earth VR\North_America.jpg"));
            m.End();
            Console.ReadLine();
        }
    }
}
