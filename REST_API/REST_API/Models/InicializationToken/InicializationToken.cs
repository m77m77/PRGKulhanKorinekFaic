using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.CommunicationClasses
{
    public class InicializationToken
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public DateTime Expiration { get; set; }
    }
}