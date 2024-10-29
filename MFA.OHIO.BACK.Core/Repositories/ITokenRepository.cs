using MFA.OHIO.BACK.Core.Entities;

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
