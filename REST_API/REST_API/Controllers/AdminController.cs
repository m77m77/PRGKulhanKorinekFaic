﻿using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace REST_API.Controllers
{
    public interface IDestination
    {
        string Adress { get; set; }
        string Port { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
    public class FTPDestination : IDestination
    {
        public string Adress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Port { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Username { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    public class Frequency
    {
        public string Time { get; set; }
        public string Interval { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string DayOfTheWeek { get; set; }
        public string DayOfTheMonth { get; set; }
    }
    public class Settings
    {
        public string DataType { get; set; }
        public string TypeOfBackup { get; set; }
        public string BeforeBackup { get; set; }
        public string AfterBackup { get; set; }
        public bool Comprimation { get; set; }
        
        public IDestination Destination {get;set;}
        
        
        public string Error { get; set; }

        public Settings(string DataType,string TypeOfBackup,string BeforeBackup,string AfterBackup,bool Comprimation,string Error)
        {
            this.AfterBackup = AfterBackup;
            this.BeforeBackup = BeforeBackup;
            this.Comprimation = Comprimation;
            this.DataType = DataType;
            this.TypeOfBackup = TypeOfBackup;
            this.Error = Error;

        }
    }

    public class AdminController : ApiController
    {
        // GET api/admin
        //public Settings Get()                                                     // testovací metoda get !
        //{
        //    MySqlConnection Connection = WebApiConfig.Connection();

        //    MySqlCommand Query = Connection.CreateCommand();
        //    Query.CommandText = "SELECT settings FROM daemons"; //WHERE @id = id";

        //    //Query.Parameters.AddWithValue("@id", id);
        //    var settings = new List<Settings>();

        //    try
        //    {
        //        Connection.Open();
        //    }
        //    catch (MySql.Data.MySqlClient.MySqlException ex)
        //    {
        //        settings.Add(new Settings(null, null, null, null, true, ex.ToString()));
        //    }

        //    MySqlDataReader Reader = Query.ExecuteReader();

        //    while (Reader.Read())
        //    {
        //        //settings.Add(new Settings(Reader["DataType"].ToString(), Reader["TypeOfBackup"].ToString(), null, null, true, null));
        //        settings.Add(new Settings("a","b","c","d",true,"e"));
        //    }

        //    Reader.Close();
        //    Connection.Close();

        //    //for (int i = 0; i > settings.Count; i++)
        //    //{
        //    //    string json = JsonConvert.SerializeObject(settings[i]);
        //    //    yield return json;
        //    //}

        //    return settings[0];
        //}
        [Route("api/admin/{token}")]
        public List<Settings> Get(string token)
        {
            MySqlConnection Connection = WebApiConfig.Connection();

            MySqlCommand Query = Connection.CreateCommand();
            Query.CommandText = "SELECT settings FROM daemons"; //WHERE @id = id";

            //Query.Parameters.AddWithValue("@id", id);
            var settings = new List<Settings>();

            try
            {
                Connection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                settings.Add(new Settings(null, null,null, null,true, ex.ToString()));
            }

            MySqlDataReader Reader = Query.ExecuteReader();

            while (Reader.Read())
            {
                settings.Add(new Settings(Reader["DataType"].ToString(), Reader["TypeOfBackup"].ToString(), null,null,true,null));
            }

            Reader.Close();
            Connection.Close();

            //for (int i = 0; i > settings.Count; i++)
            //{
            //    string json = JsonConvert.SerializeObject(settings[i]);
            //    yield return json;
            //}

            return settings;
        }
    }
}
