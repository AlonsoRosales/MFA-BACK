using MFA.OHIO.BACK.Core.Entities;

namespace MFA.OHIO.BACK.Core.Repositories
{
    public interface ISystemVariablesRepository
    {
        Task<List<SystemVariables>> GetAllSystemVariablesAsync();
        Task<SystemVariables> GetSystemVariableByIdAsync(int id);
        Task<SystemVariables> GetSystemVariableByNameAsync(string name);
        Task<SystemVariables> CreateSystemVariableAsync(SystemVariables systemVariable);
        Task<bool> UpdateSystemVariableAsync(SystemVariables systemVariable);
        Task<bool> DeleteSystemVariableAsync(int id);
    }
}
