using MFA.OHIO.BACK.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Core.Repositories
{
    public interface IPortalUserRepository
    {
        Task<List<PortalUser>> GetAllPortalUserAsync();
        Task<PortalUser> GetPortalUserByIdAsync(int id);
        Task<PortalUser> CreatePortalUserAsync(PortalUser portalUser);
        Task<bool> UpdatePortalUserAsync(PortalUser portalUser);
        Task<bool> DeletePortalUserAsync(int id);
    }
}
