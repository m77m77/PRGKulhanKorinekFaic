using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using DaemonTest.DestinationManagers;
using DaemonTest.SaveMethods;

namespace DaemonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(Path.GetTempFileName());

            Console.WriteLine(File.Exists(@"C:\Users\Matouš\AppData\Local\Temp\PRGKulhanKorinekFaic\FTP\WEEKLY - 1\FULL_15_02_2018_18_47.zip"));
            Console.ReadLine();
            ISaveMethod m = new ZipSaveMethod();
            m.Start(new FTPDestinationManager(),"FULL");
            m.AddFile(@"ABCD", new System.IO.FileInfo(@"F:\Obrázky\Google Earth VR\North_America.jpg"));
            m.End();
            Console.ReadLine();
        }
    }
}
