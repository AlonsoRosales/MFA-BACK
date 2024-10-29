using System.Text.RegularExpressions;

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
