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
    public class GetToken
    {
        public async Task GetTokenMethod(AdminPost adminpost)
        {
        Response r = new Response();

        string json = "";
        json = JsonConvert.SerializeObject(adminpost, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

        HttpClient http = new HttpClient();
        StringContent sc = new StringContent(json);

        HttpResponseMessage t = new HttpResponseMessage();

        t = await http.PostAsync("http://localhost:63058/api/newtoken/admin", sc);

        }
        

    }
}
