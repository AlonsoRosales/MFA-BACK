using MediatR;
using MFA.OHIO.BACK.Application.DTO.Application;

namespace MFA.OHIO.BACK.Application.UseCases.Applications.Commands.CreateApplication
{
    public class CreateApplicationCommand : IRequest<Unit>
    {
        public CreateApplicationDTO createApplicationDTO { get; set; }
    }
}
