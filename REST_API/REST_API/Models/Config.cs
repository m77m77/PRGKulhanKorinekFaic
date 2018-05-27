using REST_API.CommunicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models
{
    public class Config : IData
    {
        public string Server { get; set; }
        public string Token { get; set; }
        public string InitializationToken { get; set; }
    }
}