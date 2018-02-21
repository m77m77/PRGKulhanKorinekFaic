using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTest
{
    public class Response
    {
        public string Status { get; set; }
        public string Error { get; set; }
        public string NewToken { get; set; }
        public IData Data { get; set; }

        public Response(string status, string error, string newToken, IData data)
        {
            this.Status = status;
            this.Error = error;
            this.NewToken = newToken;
            this.Data = data;
        }

        public Response()
        {

        }
    }
}
