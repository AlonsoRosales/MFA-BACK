using MediatR;
using MFA.OHIO.BACK.Core.Repositories;
using Entity = MFA.OHIO.BACK.Core.Entity;

namespace MFA.OHIO.BACK.Application.UseCases.Applications.Commands.CreateApplication
{
    public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand, Unit>
    {
        private readonly IApplicationRepository _applicationsRepository;

        public CreateApplicationCommandHandler(IApplicationRepository applicationsRepository)
        {
            _applicationsRepository = applicationsRepository;
        }

        public async Task<Unit> Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
        {
            var application = new Entity.Application()
            {
                nombre = request.createApplicationDTO.nombre,
                status = request.createApplicationDTO.status,
                fechaHoraCreacion = DateTime.Now,
                ipRanges = request.createApplicationDTO.ipRanges,
                userIdCreacion = 1,
                fechaHoraModificacion = DateTime.Now,
                userIdModificacion = 1
            };
            await _applicationsRepository.CreateApplicationAsync(application);
            return Unit.Value;
        }
    }
}
