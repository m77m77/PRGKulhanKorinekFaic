using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminApp.CommunicationClasses;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows.Forms;
using AdminApp.Models.Settings;

namespace AdminApp.LoginNewToken
{
    public class ServerAccess
    {
        public string Server { get; private set; }
        public string Token { get; private set; }

        public async Task<bool> GetTokenMethod(AdminPost adminpost,Label label,TextBox textbox)
        {
        bool ret = true;
        Response r = new Response();

        string json = "";
        json = JsonConvert.SerializeObject(adminpost, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto,SerializationBinder = new SettingsSerializationBinder() });

        HttpClient http = new HttpClient();
        StringContent sc = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage t = new HttpResponseMessage();
        
            try
            {
                //t = await http.PostAsync("http://localhost:63058/api/newtoken/admin", sc);
                t = await http.PostAsync(textbox.Text + "/api/newtoken/admin", sc);
                r = JsonConvert.DeserializeObject<Response>(await t.Content.ReadAsStringAsync(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto,SerializationBinder = new SettingsSerializationBinder() });
            }
            catch(Exception ex)
            {
                r = new Response("ERROR", "ConnectionError", null, null);
            }
            if (r.Status == null)
                r.Status = "OK";

            label.Visible = false;

            if(r.Error == "ConnectionError")
            {
                label.Text = "Connection error";
                label.Visible = true;
                ret = false;
            }
            if (r.Error == "TokenGenerationFailed")
            {
                label.Text = "Token generation failed";
                label.Visible = true;
                ret = false;
            }
            if (r.Error == "BadPassword")
            {
                label.Text = "Bad password";
                label.Visible = true;
                ret = false;
            }
            if (r.Error == "BadUserName")
            {
                label.Text = "Bad username";
                label.Visible = true;
                ret = false;
            }
            if (r.Error == "ConnectionWithDatabaseProblem")
            {
                label.Text = "Connection with database problem";
                label.Visible = true;
                ret = false;
            }

            if(r.Status == "OK")
            {
                this.Token = r.NewToken;
                this.Server = textbox.Text;
            }

            return ret;
        }

        public async Task<Response> GetAllSettings(Label label)
        {

            HttpClient http = new HttpClient();
            Response response;

            try
            {
                HttpResponseMessage res = await http.GetAsync(this.Server + "/api/admin/" + this.Token);
                response = JsonConvert.DeserializeObject<Response>(await res.Content.ReadAsStringAsync(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
            }
            catch
            {
                response = new Response("ERROR", "ConnectionError", null, null);
            }

            label.Visible = false;
            if(response.Status == "ERROR")
            {
                label.Visible = true;
                label.Text = response.Error;
            }

            return response;
        }

        public async Task<Response> PostSettings(Settings settings,Label label)
        {
            Response r = new Response();

            string json = JsonConvert.SerializeObject(settings, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });

            HttpClient http = new HttpClient();
            StringContent sc = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage res = await http.PostAsync(this.Server + "/api/admin/" + this.Token,sc);
                r = JsonConvert.DeserializeObject<Response>(await res.Content.ReadAsStringAsync(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
            }
            catch (Exception ex)
            {
                r = new Response("ERROR", "ConnectionError", null, null);
            }

            if(r.Status == "ERROR")
            {
                label.Visible = true;
                label.Text = r.Error;
                
            }

            return r;
        }

        public async Task<Response> PostDefaultSettings(Settings settings, Label label)
        {
            Response r = new Response();

            string value = JsonConvert.SerializeObject(settings, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });

            string json = JsonConvert.SerializeObject(new SystemSettings() { Name = "defaultDaemonSettings", Value = value }, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });

            HttpClient http = new HttpClient();
            StringContent sc = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage res = await http.PostAsync(this.Server + "/api/admin/system/" + this.Token, sc);
                r = JsonConvert.DeserializeObject<Response>(await res.Content.ReadAsStringAsync(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, SerializationBinder = new SettingsSerializationBinder() });
            }
            catch (Exception ex)
            {
                r = new Response("ERROR", "ConnectionError", null, null);
            }

            if (r.Status == "ERROR")
            {
                label.Visible = true;
                label.Text = r.Error;
            }

            return r;
        }

    }
}
