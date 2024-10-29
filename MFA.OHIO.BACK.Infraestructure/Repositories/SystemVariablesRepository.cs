using MFA.OHIO.BACK.Core.Entities;
using MFA.OHIO.BACK.Core.Repositories;
using MFA.OHIO.BACK.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MFA.OHIO.BACK.Infraestructure.Repositories
{
    public class SystemVariablesRepository : ISystemVariablesRepository
    {
        private readonly MFADbContext _mfaDbContext;
        public SystemVariablesRepository(MFADbContext mfaDbContext)
        {
            _mfaDbContext = mfaDbContext;
        }
        public Task<SystemVariables> CreateSystemVariableAsync(SystemVariables systemVariable)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSystemVariableAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SystemVariables>> GetAllSystemVariablesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SystemVariables> GetSystemVariableByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<SystemVariables> GetSystemVariableByNameAsync(string name)
        {
            return await _mfaDbContext.SystemVariable.AsNoTracking().SingleOrDefaultAsync(x => x.systemVariableName.Equals(name));
        }

        public Task<bool> UpdateSystemVariableAsync(SystemVariables systemVariable)
        {
            throw new NotImplementedException();
        }
    }
}
