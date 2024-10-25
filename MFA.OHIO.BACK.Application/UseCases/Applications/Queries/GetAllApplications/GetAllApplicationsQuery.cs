using MediatR;
using MFA.OHIO.BACK.Application.DTO.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Application.UseCases.Applications.Queries.GetAllApplications
{
    public class GetAllApplicationsQuery : IRequest<List<GetAllApplicationsDTO>>
    {
    }
}
