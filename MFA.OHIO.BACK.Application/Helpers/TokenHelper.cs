using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Application.Helpers
{
    public sealed class TokenHelper
    {
        private readonly string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private readonly int _tokenLength = 8;

        public string generateRandomTokenString()
        {
            var result = new StringBuilder(_tokenLength);
            var randomBytes = new byte[_tokenLength];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            foreach (var randomByte in randomBytes)
            {
                result.Append(_chars[randomByte % _chars.Length]);
            }

            return result.ToString();
        }
    }
}
