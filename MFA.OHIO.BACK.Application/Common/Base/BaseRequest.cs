using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Application.Common.Base
{
    public class BaseRequest
    {
        public string user { get; set; }
        public string email { get; set; }
        public string ipv4 { get; set; }
        public string application_id { get; set; }
        public string req_date { get; set; }
    }
}
