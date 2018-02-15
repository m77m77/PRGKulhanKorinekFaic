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
        public async Task<Response> GetTokenMethod(AdminPost adminpost)
        {
        Response r = new Response();

        string json = "";
        json = JsonConvert.SerializeObject(adminpost, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

        HttpClient http = new HttpClient();
        StringContent sc = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage t = new HttpResponseMessage();
        
            try
            {
                t = await http.PostAsync("http://localhost:63058/api/newtoken/admin", sc);
                r = JsonConvert.DeserializeObject<Response>(t.Content.ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            }
            catch(Exception ex)
            {
                r = new Response("ERROR", "ConnectionError", null, null);
            }
            if (r.Status == null)
                r.Status = "OK";


            if(r.Error == "ConnectionError")
            {
                MessageBox.Show("fail0");
            }
            if (r.Error == "TokenGenerationFailed")
            {
                MessageBox.Show("fail1");
            }
            if (r.Error == "BadPassword")
            {
                MessageBox.Show("fail2");
            }
            if (r.Error == "BadUserName")
            {
                MessageBox.Show("fail3");
            }
            if (r.Error == "ConnectionWithDatabaseProblem")
            {
                MessageBox.Show("fail4");
            }

            return r;
        }
        

    }
}
