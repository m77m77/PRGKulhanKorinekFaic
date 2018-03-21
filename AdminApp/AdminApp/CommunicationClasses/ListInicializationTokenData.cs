using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminApp.Models.InicializationToken;

namespace AdminApp.CommunicationClasses
{
    public class ListInicializationTokenData : IData
    {
        public List<InicializationToken> ListInicializationToken { get; set; }
    }
}
