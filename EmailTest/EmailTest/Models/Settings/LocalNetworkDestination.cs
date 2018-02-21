using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTest
{
    public class LocalNetworkDestination : IDestination
    {
        public string Path { get; set; }
        public string Type { get => "LOCAL_NETWORK"; set { } }
    }
}
