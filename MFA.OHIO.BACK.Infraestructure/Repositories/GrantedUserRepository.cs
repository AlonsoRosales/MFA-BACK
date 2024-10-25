using MFA.OHIO.BACK.Core.Entity;
using MFA.OHIO.BACK.Core.Repositories;
using MFA.OHIO.BACK.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MFA.OHIO.BACK.Infraestructure.Repositories
{
    public class GrantedUserRepository : IGrantedUserRepository
    {
        private readonly MFADbContext _mfaDbContext;
        public GrantedUserRepository(MFADbContext mfaDbContext)
        {
            _mfaDbContext = mfaDbContext;
        }
        public Task<List<GrantedUser>> GetAllGrantedUserAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GrantedUser> GetGrantedUserByIdAsync(int id)
        {
            return await _mfaDbContext.GrantedUser.AsNoTracking().SingleOrDefaultAsync(x => x.granteduserId == id);
        }
        public async Task<GrantedUser> GetGrantedUserByUserAsync(string user)
        {
            return await _mfaDbContext.GrantedUser.AsNoTracking().SingleOrDefaultAsync(x => x.user.Equals(user));
        }
        public async Task<GrantedUser> CreateGrantedUserAsync(GrantedUser grantedUser)
        {
            await _mfaDbContext.GrantedUser.AddAsync(grantedUser);
            await _mfaDbContext.SaveChangesAsync();
            return grantedUser;
        }

        public async Task<bool> DeleteGrantedUserAsync(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> UpdateGrantedUserAsync(GrantedUser grantedUser)
        {
            throw new NotImplementedException();
        }
    }
}
