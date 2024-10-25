using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Application.Helpers
{
    public sealed class EmailHelper
    {
        private readonly string _emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        public bool validateEmail(string email)
        {
            return Regex.IsMatch(email, _emailPattern);   
        }
    }
}
