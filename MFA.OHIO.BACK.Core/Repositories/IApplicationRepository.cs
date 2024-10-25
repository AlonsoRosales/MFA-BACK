using MediatR;
using MFA.OHIO.BACK.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Core.Repositories
{
    public interface IApplicationRepository
    {
        Task<List<Application>> GetAllApplicationsAsync();
        Task<Application> GetApplicationByIdAsync(string id);
        Task<Application> CreateApplicationAsync(Application application);
        Task<bool> UpdateApplicationAsync(Application application);
    }
}
