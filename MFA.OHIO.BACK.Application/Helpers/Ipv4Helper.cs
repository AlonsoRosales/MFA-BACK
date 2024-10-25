using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Application.Helpers
{
    public sealed class Ipv4Helper
    {
        private readonly string _ipv4Pattern = @"^(25[0-5]|(2[0-4][0-9]|[1][0-9]{2}|[1-9]?[0-9]))\.(25[0-5]|(2[0-4][0-9]|[1][0-9]{2}|[1-9]?[0-9]))\.(25[0-5]|(2[0-4][0-9]|[1][0-9]{2}|[1-9]?[0-9]))\.(25[0-5]|(2[0-4][0-9]|[1][0-9]{2}|[1-9]?[0-9]))$";
        public bool validateIpv4(string ipv4)
        {
            return Regex.IsMatch(ipv4, _ipv4Pattern);
        }
    }
}
