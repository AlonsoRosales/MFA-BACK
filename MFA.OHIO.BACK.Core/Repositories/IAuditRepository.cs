using MFA.OHIO.BACK.Core.Entities;

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
