using MySql.Data.MySqlClient;
using REST_API.CommunicationClasses;
using REST_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using System.Xml;

namespace REST_API.Controllers
{
    public class XMLFileController : ApiController
    {
        [Route("api/xmlfile/{token}/{initializationtoken}")]
        public Response Post(string token,string initializationtoken)
        {
            MySqlConnection Connection = WebApiConfig.Connection();

            Token t = Token.Exists(token);
            if (t == null)
            {
                //token není v databázi  
                return new Response("ERROR", "TokenNotFound", null, null);
            }
            if (!t.IsAdmin)
            {
                //token nepatří adminovi  
                return new Response("ERROR", "TokenIsNotMatched", null, null);
            }

            MySqlCommand Query = Connection.CreateCommand();


            Response r = new Response();

            try
            {
                Connection.Open();

                XmlTextWriter writer = new XmlTextWriter(@"D:\config.xml", System.Text.Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                writer.WriteStartElement("Config");

                writer.WriteStartElement("Server");
                writer.WriteString("http://localhost:63058");
                writer.WriteEndElement();
                writer.WriteStartElement("Token");
                writer.WriteString(token);
                writer.WriteEndElement();
                writer.WriteStartElement("InitializationToken");
                writer.WriteString(initializationtoken);
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                byte[] file;
                using (var stream = new FileStream(@"D:\config.xml", FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        file = reader.ReadBytes((int)stream.Length);
                    }
                }

                Query.CommandText = "INSERT INTO configs (idTokens,configXML) VALUES ((select id from tokens where token = @itoken),@config);";
                Query.Parameters.AddWithValue("@config",file);
                Query.Parameters.AddWithValue("@itoken", initializationtoken);

                Query.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                r = new Response("ERROR", "ConnectionWithDatabaseProblem", null, null);
            }
            Connection.Close();

            if (r.Status == null)
                r.Status = "OK";

            return r;
        }

        [Route("api/xmlfile/{token}/{initializationtoken}")]
        public Response Get(string token,string initializationtoken)
        {
            Token t = Token.Exists(token);
            if (t == null)
            {
                //token není v databázi  
                return new Response("ERROR", "TokenNotFound", null, null);
            }
            if (!t.IsAdmin)
            {
                //token nepatří adminovi  
                return new Response("ERROR", "TokenIsNotMatched", null, null);
            }

            MySqlConnection Connection = WebApiConfig.Connection();

            MySqlCommand Query = Connection.CreateCommand();

            Query.CommandText = "SELECT configXML FROM configs where idConfig = (select id from tokens where token = @itoken)";
            Query.Parameters.AddWithValue("@itoken", initializationtoken);

            Config c = new Config();
            Response r = new Response();
            r.Data = c;
            try
            {
                Connection.Open();
                MySqlDataReader Reader = Query.ExecuteReader();
                c.Token = "sssss";
                c.Server = "sssss";
                c.InitializationToken = "sssss";
                r.Data = c;
                Reader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                r = new Response("ERROR", "ConnectionWithDatabaseProblem", null, null);
            }
            Connection.Close();

            if (r.Status == null)
                r.Status = "OK";

            return r;
        }
    }
}
