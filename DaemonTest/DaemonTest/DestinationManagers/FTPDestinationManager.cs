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
        private string uploadFullDirName;
        private string downloadFullDirName;

        public FTPDestinationManager(FTPDestination destination)
        {
            this.destination = destination;

            this.tempDir = Path.Combine(Path.GetTempPath(),"PRGKulhanKorinekFaic","FTP");

            this.uploadFullDirName = Path.Combine(tempDir, "upload");
            if (Directory.Exists(this.uploadFullDirName))
                Directory.Delete(this.uploadFullDirName, true);
            Directory.CreateDirectory(this.uploadFullDirName);

            this.downloadFullDirName = Path.Combine(tempDir, "download");
            if (Directory.Exists(this.downloadFullDirName))
                Directory.Delete(this.downloadFullDirName, true);
            Directory.CreateDirectory(this.downloadFullDirName);

            //FtpClient client = new FtpClient(this.destination.Adress, Convert.ToInt32(this.destination.Port), this.destination.Username, this.destination.Password);
            //client.Connect();

            //Console.WriteLine(client.GetModifiedTime("/prgkulhankorinekfaic.g6.cz/web/BACKUP/WEEKLY 19.02.2018 - 25.02.2018/DIFF_24_02_2018_22_23/gtsshhs.xlsx"));

            //client.Dispose();
        }

        public void DownloadFiles(params string[] startsWith)
        {
            using (FtpClient client = new FtpClient(this.destination.Adress, Convert.ToInt32(this.destination.Port), this.destination.Username, this.destination.Password))
            {
                client.Connect();
                client.UploadDataType = FtpDataType.Binary;
                this.DownloadDirectory(this.destination.Path + "/" + SettingsManager.GetFolderNameBasedOnDate() + "/", new DirectoryInfo(this.downloadFullDirName),client, startsWith.Length > 0 ? startsWith : null);
            }
        }

        private void DownloadDirectory(string url, DirectoryInfo localDirectory,FtpClient client, string[] startsWith = null)
        {
            foreach (FtpListItem item in client.GetListing(url))
            {
                if (item.Name == "." || item.Name == "..")
                    continue;

                if (startsWith != null)
                {
                    bool contains = false;
                    foreach (string start in startsWith)
                    {
                        if (item.Name.StartsWith(start))
                            contains = true;
                    }

                    if (!contains)
                        continue;
                }

                if (item.Type == FtpFileSystemObjectType.File)
                {
                    DateTime time = item.Modified;
                    Console.WriteLine("D " +time+ " " + item.FullName);

                    string localPath = Path.Combine(localDirectory.FullName, item.Name);

                    client.DownloadFile(localPath, item.FullName);

                    FileInfo file = new FileInfo(localPath);
                    file.LastWriteTime = time;
                }else if(item.Type == FtpFileSystemObjectType.Directory)
                {
                    DirectoryInfo subDir = localDirectory.CreateSubdirectory(item.Name);

                    DownloadDirectory(item.FullName,subDir,  client);
                    subDir.LastWriteTime = item.Modified;
                }
            }
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

        public string GetDownloadPath()
        {
            return this.downloadFullDirName;
        }

        public string GetUploadPath()
        {
            return this.uploadFullDirName;
        }

        public void Save()
        {
            using (FtpClient client = new FtpClient(this.destination.Adress, Convert.ToInt32(this.destination.Port), this.destination.Username, this.destination.Password))
            {
                client.Connect();
                client.UploadDataType = FtpDataType.Binary;
                this.UploadDirectory(this.destination.Path + "/" + SettingsManager.GetFolderNameBasedOnDate() + "/", new DirectoryInfo(this.uploadFullDirName),client);
            }

            
            //Directory.Delete(this.tempDir, true);
        }

    }
}
