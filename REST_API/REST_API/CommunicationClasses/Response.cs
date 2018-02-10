using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.CommunicationClasses
{
    public class Response
    {
        public string Status { get; set; }
        public string NewToken { get; set; }
        public IData Data { get; set; }
    }
}