using Entity = MFA.OHIO.BACK.Core.Entity;
using MFA.OHIO.BACK.Core.Repositories;
using MFA.OHIO.BACK.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Infraestructure.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly MFADbContext _mfaDbContext;

        public ApplicationRepository(MFADbContext mfaDbContext)
        {
            _mfaDbContext = mfaDbContext;
        }
        public async Task<List<Entity.Application>> GetAllApplicationsAsync()
        {
            return await _mfaDbContext.Application.ToListAsync();
        }
        public async Task<Entity.Application> GetApplicationByIdAsync(string id)
        {
            return await _mfaDbContext.Application.AsNoTracking().SingleOrDefaultAsync(x => x.applicationId.Equals(id));
        }
        public async Task<Entity.Application> CreateApplicationAsync(Entity.Application application)
        {
            await _mfaDbContext.Application.AddAsync(application);
            await _mfaDbContext.SaveChangesAsync();
            return application;
        }
        public async Task<bool> UpdateApplicationAsync(Entity.Application application)
        {
            _mfaDbContext.Application.Update(application);
            return await Task.FromResult(true);
        }

    }
}
