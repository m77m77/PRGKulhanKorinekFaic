using DaemonTest.Models.Settings;
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

        private NetworkCredential credentials;
        private string connectionString;

        public FTPDestinationManager(FTPDestination destination)
        {
            this.destination = destination;

            this.credentials = new NetworkCredential(destination.Username, destination.Password);
            this.connectionString = "ftp://" + destination.Adress + ":" + destination.Port + "/" + destination.Path + "/" + SettingsManager.GetFolderNameBasedOnDate() + "/";

            this.tempDir = Path.Combine(Path.GetTempPath(),"PRGKulhanKorinekFaic","FTP");

            this.uploadFullDirName = Path.Combine(tempDir, "upload");
            if (Directory.Exists(this.uploadFullDirName))
                Directory.Delete(this.uploadFullDirName, true);
            Directory.CreateDirectory(this.uploadFullDirName);

            this.downloadFullDirName = Path.Combine(tempDir, "download");
            if (Directory.Exists(this.downloadFullDirName))
                Directory.Delete(this.downloadFullDirName, true);
            Directory.CreateDirectory(this.downloadFullDirName);


        }

        public void DownloadFiles(params string[] startsWith)
        {
            this.DownloadDirectory(this.connectionString, this.downloadFullDirName, startsWith.Length > 0 ? startsWith : null);
        }

        private void DownloadDirectory(string url, string localPath,string[] startsWith = null)
        {
            FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(url);
            listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            listRequest.Credentials = this.credentials;

            List<string> lines = new List<string>();

            using (FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse())
            using (Stream listStream = listResponse.GetResponseStream())
            using (StreamReader listReader = new StreamReader(listStream))
            {
                while (!listReader.EndOfStream)
                {
                    lines.Add(listReader.ReadLine());
                }
            }

            foreach (string line in lines)
            {
                string[] tokens =
                    line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[8];
                string permissions = tokens[0];

                if (name == "." || name == "..")
                {
                    continue;
                }
                if(startsWith != null)
                {
                    bool contains = false;
                    foreach (string item in startsWith)
                    {
                        if (name.StartsWith(item))
                            contains = true;
                    }

                    if (!contains)
                        continue;
                }

                string localFilePath = Path.Combine(localPath, name);
                string fileUrl = url + name;

                if (permissions[0] == 'd')
                {
                    if (!Directory.Exists(localFilePath))
                    {
                        Directory.CreateDirectory(localFilePath);
                    }

                    this.DownloadDirectory(fileUrl + "/", localFilePath);
                }
                else
                {
                    Console.WriteLine(line);
                    FtpWebRequest downloadRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                    downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                    downloadRequest.Credentials = this.credentials;
                    downloadRequest.UseBinary = true;
                    

                    using (FtpWebResponse downloadResponse =
                              (FtpWebResponse)downloadRequest.GetResponse())
                    using (Stream sourceStream = downloadResponse.GetResponseStream())
                    using (Stream targetStream = File.Create(localFilePath))
                    {
                        sourceStream.CopyTo(targetStream);
                        
                    }
                }
            }
        }

        private void UploadDirectory(string url, DirectoryInfo directory)
        {
            try
            {
                FtpWebRequest uploadDir = (FtpWebRequest)WebRequest.Create(url);
                uploadDir.Method = WebRequestMethods.Ftp.MakeDirectory;
                uploadDir.Credentials = this.credentials;
                uploadDir.UseBinary = true;

                FtpWebResponse response = (FtpWebResponse)uploadDir.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception)
            {

            }

            foreach (FileInfo item in directory.GetFiles())
            {
                string fileUrl = url + item.Name;
                Console.WriteLine(fileUrl);
                FtpWebRequest uploadRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;
                uploadRequest.Credentials = this.credentials;
                uploadRequest.UseBinary = true;

                using (Stream targetStream = uploadRequest.GetRequestStream())
                using (Stream sourceStream = item.OpenRead())
                {
                    sourceStream.CopyTo(targetStream);
                }
            }

            foreach (DirectoryInfo item in directory.GetDirectories())
            {
                this.UploadDirectory(url + item.Name + "/", item);
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
            this.UploadDirectory(this.connectionString, new DirectoryInfo(this.uploadFullDirName));

            Directory.Delete(this.tempDir, true);
        }

    }
}
