using MediatR;
using MFA.OHIO.BACK.Application.DTO.Response;
using MFA.OHIO.BACK.Application.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Application.UseCases.Token.Command.GenerateToken
{
    public sealed record class GenerateTokenCommand : IRequest<ResponseDTO>
    {
        public GenerateTokenRequestDTO generateTokenRequestDTO { get; set; }

        public GenerateTokenCommand(GenerateTokenRequestDTO request)
        {
            generateTokenRequestDTO = request;
        }
    }
}
