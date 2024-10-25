using MFA.OHIO.BACK.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
