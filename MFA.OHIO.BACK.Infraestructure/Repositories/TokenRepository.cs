using MFA.OHIO.BACK.Core.Entity;
using MFA.OHIO.BACK.Core.Repositories;
using MFA.OHIO.BACK.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MFA.OHIO.BACK.Infraestructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly MFADbContext _mfaDbContext;
        public TokenRepository(MFADbContext mfaDbContext)
        {
            _mfaDbContext = mfaDbContext;
        }
        public async Task<List<Token>> GetAllTokenAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Token> GetTokenByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<Token> GetTokenByGrantedUserIdAsync(int userId)
        {
            return await _mfaDbContext.Token.Where(x => x.grantedUserId == userId).OrderByDescending(x => x.fechaHoraCreacion).LastOrDefaultAsync();
        }
        public async Task<Token> CreateTokenAsync(Token token)
        {
            await _mfaDbContext.Token.AddAsync(token);
            await _mfaDbContext.SaveChangesAsync();
            return token;
        }

        public async Task<bool> DeleteTokenAsync(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> UpdateTokenAsync(Token token)
        {
            throw new NotImplementedException();
        }

    }
}
