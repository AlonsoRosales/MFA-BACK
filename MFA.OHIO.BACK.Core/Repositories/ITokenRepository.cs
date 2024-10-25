using MFA.OHIO.BACK.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Core.Repositories
{
    public interface ITokenRepository
    {
        Task<List<Token>> GetAllTokenAsync();
        Task<Token> GetTokenByIdAsync(int id);
        Task<Token> GetTokenByGrantedUserIdAsync(int userId);
        Task<Token> CreateTokenAsync(Token token);
        Task<bool> UpdateTokenAsync(Token token);
        Task<bool> DeleteTokenAsync(int id);
    }
}
