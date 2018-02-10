using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_API.Models.Settings
{
    public interface IDestination
    {
        string Adress { get; set; }
        string Port { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}
