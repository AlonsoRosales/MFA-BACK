using MFA.OHIO.BACK.Application.Common.Base;

namespace MFA.OHIO.BACK.Application.Models.Request
{
    public sealed class ValidateTokenRequestDTO : BaseRequest
    { 
        public string token { get; set; }
    }
}
