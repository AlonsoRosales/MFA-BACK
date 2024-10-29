using MediatR;
using MFA.OHIO.BACK.Application.DTO.Response;
using MFA.OHIO.BACK.Application.Models.Request;

namespace MFA.OHIO.BACK.Application.UseCases.Token.Command.ValidateToken
{
    public record class ValidateTokenCommand: IRequest<ResponseDTO>
    {
        public ValidateTokenRequestDTO validateTokenRequestDTO { get; set; }

        public ValidateTokenCommand(ValidateTokenRequestDTO request)
        {
            validateTokenRequestDTO = request;
        }
    }
}
