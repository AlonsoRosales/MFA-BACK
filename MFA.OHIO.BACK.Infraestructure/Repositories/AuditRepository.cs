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
    public class AuditRepository: IAuditRepository
    {
        private readonly MFADbContext _mfaDbContext;
        public AuditRepository(MFADbContext mfaDbContext)
        {
            _mfaDbContext = mfaDbContext;
        }

        public Task<Audit> CreateAuditAsync(Audit audit)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAuditAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Audit>> GetAllAuditAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Audit> GetAuditByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAuditAsync(Audit audit)
        {
            throw new NotImplementedException();
        }
    }
}
