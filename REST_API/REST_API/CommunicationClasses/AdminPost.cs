using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.CommunicationClasses
{
    public class AdminPost : IData
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}