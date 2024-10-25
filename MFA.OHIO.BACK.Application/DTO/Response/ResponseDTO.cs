using MFA.OHIO.BACK.Application.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Application.DTO.Response
{
    public sealed class ResponseDTO: BaseResponse
    {
        public string detail { get; set; }
        public DateTime fechaHoraExpiracion { get; set; }
    }
}
