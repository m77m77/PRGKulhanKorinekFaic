using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using REST_API.CommunicationClasses;
using REST_API.Models;

namespace REST_API.Controllers
{
    public class NewTokenController : ApiController
    {
        //GET api/newtoken
        public string Get()
        {
            return "a";
        }

        //POST api/newtoken/admin
        [Route("api/newtoken/admin")]
        public Token PostAdmin([FromBody] AdminPost value)
        {
            using (MySqlConnection connection = WebApiConfig.Connection())
            {

            }
            return Token.GenerateNewTokenForAdmin(2);
            //return new Response() {Status="OK", NewToken = "jfkl"};
        }
    }
}
