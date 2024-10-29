using MFA.OHIO.BACK.Application.Common.Base;

namespace MFA.OHIO.BACK.Application.DTO.Response
{
    public sealed class ResponseDTO: BaseResponse
    {
        public string detail { get; set; }
        public DateTime fechaHoraExpiracion { get; set; }
    }
}
