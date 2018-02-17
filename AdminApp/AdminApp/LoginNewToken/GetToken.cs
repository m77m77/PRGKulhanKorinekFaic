using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminApp.CommunicationClasses;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace AdminApp.LoginNewToken
{
    public class ServerAccess
    {
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
                label.Text = "ConnectionError";
                label.Visible = true;
                ret = false;
            }
            if (r.Error == "TokenGenerationFailed")
            {
                label.Text = "TokenGenerationFailed";
                label.Visible = true;
                ret = false;
            }
            if (r.Error == "BadPassword")
            {
                label.Text = "BadPassword";
                label.Visible = true;
                ret = false;
            }
            if (r.Error == "BadUserName")
            {
                label.Text = "BadUserName";
                label.Visible = true;
                ret = false;
            }
            if (r.Error == "ConnectionWithDatabaseProblem")
            {
                label.Text = "ConnectionWithDatabaseProblem";
                label.Visible = true;
                ret = false;
            }

            return ret;
        }
        

    }
}
