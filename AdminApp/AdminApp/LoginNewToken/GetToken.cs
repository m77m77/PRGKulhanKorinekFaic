using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminApp.CommunicationClasses;
using System.Net.Http;
using Newtonsoft.Json;

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
        StringContent sc = new StringContent(json);

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

            return r;
        }
        

    }
}
