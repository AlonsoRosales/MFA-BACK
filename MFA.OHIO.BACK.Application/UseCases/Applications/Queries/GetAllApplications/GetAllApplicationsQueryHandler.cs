using AutoMapper;
using MediatR;
using MFA.OHIO.BACK.Application.DTO.Application;
using MFA.OHIO.BACK.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Application.UseCases.Applications.Queries.GetAllApplications
{
    public class GetAllApplicationsQueryHandler : IRequestHandler<GetAllApplicationsQuery, List<GetAllApplicationsDTO>>
    {
        private readonly IApplicationRepository _applicationsRepository;
        private readonly IMapper _mapper;
        public GetAllApplicationsQueryHandler(IApplicationRepository applicationsRepository, IMapper mapper)
        {
            _applicationsRepository = applicationsRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllApplicationsDTO>> Handle(GetAllApplicationsQuery request, CancellationToken cancellationToken)
        {
            var applications = await _applicationsRepository.GetAllApplicationsAsync();
            var applicationsList = _mapper.Map<List<GetAllApplicationsDTO>>(applications);
            return applicationsList;
        }
    }
}
