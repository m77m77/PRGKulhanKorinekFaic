using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.CommunicationClasses
{
    public class ListAdminData : IData
    {
        public List<AdminPost> ListAdmin { get; set; }
    }
}
