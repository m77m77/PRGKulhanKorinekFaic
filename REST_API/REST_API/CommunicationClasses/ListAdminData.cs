using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.CommunicationClasses
{
    public class ListAdminData : IData
    {
        public List<AdminPost> ListAdmin { get; set; }
    }
}