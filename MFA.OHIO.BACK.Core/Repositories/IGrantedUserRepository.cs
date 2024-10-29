using MFA.OHIO.BACK.Core.Entities;

namespace MFA.OHIO.BACK.Core.Repositories
{
    public interface IGrantedUserRepository
    {
        Task<List<GrantedUser>> GetAllGrantedUserAsync();
        Task<GrantedUser> GetGrantedUserByIdAsync(int id);
        Task<GrantedUser> GetGrantedUserByUserAsync(string name);
        Task<GrantedUser> CreateGrantedUserAsync(GrantedUser grantedUser);
        Task<bool> UpdateGrantedUserAsync(GrantedUser grantedUser);
        Task<bool> DeleteGrantedUserAsync(int id);
    }
}
