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
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MFADbContext _mfaDbContext;
        public TransactionRepository(MFADbContext mfaDbContext)
        {
            _mfaDbContext = mfaDbContext;
        }
        public Task<Transaction> CreateTransactionAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTransactionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transaction>> GetAllTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> GetTransactionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTransactionAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
