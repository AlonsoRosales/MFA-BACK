using MediatR;
using MFA.OHIO.BACK.Application.Common.Base;
using MFA.OHIO.BACK.Application.DTO.Response;
using MFA.OHIO.BACK.Application.Models.Request;
using MFA.OHIO.BACK.Application.UseCases.Token.Command.GenerateToken;
using MFA.OHIO.BACK.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MFA.OHIO.BACK.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ISender _mediator;

        [HttpPost("generate", Name="Generar Token")]
        public async Task<IActionResult> GenerateToken(GenerateTokenRequestDTO generateTokenRequest)
        {
            ResponseDTO responseDTO = await _mediator.Send(new GenerateTokenCommand(generateTokenRequest));
            switch(responseDTO.statusCode)
            {
                case (int)ResponseStatusEnum.SUCCESS:
                    return StatusCode(responseDTO.statusCode, new { fechaHoraExpiracion = responseDTO.fechaHoraExpiracion });
                default:
                    return StatusCode(responseDTO.statusCode, new { detail = responseDTO.detail});
            }
        }
    }
}
