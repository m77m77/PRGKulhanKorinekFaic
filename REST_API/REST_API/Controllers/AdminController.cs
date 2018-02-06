using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace REST_API.Controllers
{
    public class AdminController : ApiController
    {
        // GET api/admin
        public string[] GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("api/admin/{token}")]
        public string Get(string token)
        {
            return token;
        }
    }
}
