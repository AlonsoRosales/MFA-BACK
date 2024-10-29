using MediatR;
using MFA.OHIO.BACK.Application.DTO.Response;
using MFA.OHIO.BACK.Application.Models.Request;

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
