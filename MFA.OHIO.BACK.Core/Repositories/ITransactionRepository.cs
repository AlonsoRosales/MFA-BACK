using MFA.OHIO.BACK.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Core.Repositories
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetAllTransactionAsync();
        Task<Transaction> GetTransactionByIdAsync(int id);
        Task<Transaction> CreateTransactionAsync(Transaction transaction);
        Task<bool> UpdateTransactionAsync(Transaction transaction);
        Task<bool> DeleteTransactionAsync(int id);

    }
}
