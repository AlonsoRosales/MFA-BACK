using MFA.OHIO.BACK.Core.Entity;
using MFA.OHIO.BACK.Core.Repositories;
using MFA.OHIO.BACK.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Infraestructure.Repositories
{
    public class PortalUserRepository : IPortalUserRepository
    {
        private readonly MFADbContext _mfaDbContext;
        public PortalUserRepository(MFADbContext mfaDbContext)
        {
            _mfaDbContext = mfaDbContext;   
        }
        public Task<PortalUser> CreatePortalUserAsync(PortalUser portalUser)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePortalUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PortalUser>> GetAllPortalUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PortalUser> GetPortalUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePortalUserAsync(PortalUser portalUser)
        {
            throw new NotImplementedException();
        }
    }
}
