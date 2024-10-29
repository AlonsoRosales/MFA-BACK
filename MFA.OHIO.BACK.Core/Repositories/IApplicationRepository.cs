using MFA.OHIO.BACK.Core.Entities;

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
