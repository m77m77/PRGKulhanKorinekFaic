using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_API.Controllers
{
    public interface IDestination
    {
        string Adress;
        string Port;
        string Username;
        string Password;
    }
}
