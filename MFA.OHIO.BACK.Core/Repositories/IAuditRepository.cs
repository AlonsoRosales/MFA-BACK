using MFA.OHIO.BACK.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Core.Repositories
{
    public interface IAuditRepository
    {
        Task<List<Audit>> GetAllAuditAsync();
        Task<Audit> GetAuditByIdAsync(int id);
        Task<Audit> CreateAuditAsync(Audit audit);
        Task<bool> UpdateAuditAsync(Audit audit);
        Task<bool> DeleteAuditAsync(int id);
    }
}
