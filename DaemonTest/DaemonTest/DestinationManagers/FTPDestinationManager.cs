using DaemonTest.Models.Settings;
using FluentFTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DaemonTest.DestinationManagers
{
    public class FTPDestinationManager : IDestinationManager
    {

        private FTPDestination destination;
        private string tempDir;
        private SettingsManager SettingsManager;

        public FTPDestinationManager(FTPDestination destination, SettingsManager settingsManager)
        {
            this.SettingsManager = settingsManager;
            this.destination = destination;

            this.tempDir = Path.Combine(Path.GetTempPath(),"PRGKulhanKorinekFaic","FTP");

            if (Directory.Exists(this.tempDir))
                Directory.Delete(this.tempDir, true);
            Directory.CreateDirectory(this.tempDir);
        }

        private void UploadDirectory(string url, DirectoryInfo directory,FtpClient client)
        {
            client.CreateDirectory(url);
            foreach (FileInfo item in directory.GetFiles())
            {
                string fileUrl = url + item.Name;
                DateTime lastWriteTime = item.LastWriteTime;
                Console.WriteLine("U " + fileUrl);
                client.UploadFile(item.FullName, fileUrl);
                client.SetModifiedTime(fileUrl, lastWriteTime);

            }

            foreach (DirectoryInfo item in directory.GetDirectories())
            {
                this.UploadDirectory(url + item.Name + "/", item,client);
            }
        }

        public string GetPath()
        {
            return this.tempDir;
        }

        public void Save()
        {
            using (FtpClient client = new FtpClient(this.destination.Adress, Convert.ToInt32(this.destination.Port), this.destination.Username, this.destination.Password))
            {
                client.Connect();
                client.UploadDataType = FtpDataType.Binary;
                this.UploadDirectory(this.destination.Path + "/" + SettingsManager.GetFolderNameBasedOnDate() + "/", new DirectoryInfo(this.tempDir),client);
            }

            
            Directory.Delete(this.tempDir, true);
        }

    }
}
