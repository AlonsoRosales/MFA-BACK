using Entity = MFA.OHIO.BACK.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFA.OHIO.BACK.Infraestructure.Configurations;

namespace MFA.OHIO.BACK.Infraestructure.Data
{
    public class MFADbContext : DbContext
    {
        public MFADbContext(DbContextOptions<MFADbContext> dbContextOptions) : base(dbContextOptions) {}
        public DbSet<Entity.Application> Application { get; set; }
        public DbSet<Entity.Audit> Audit { get; set; }
        public DbSet<Entity.GrantedUser> GrantedUser { get; set; }
        public DbSet<Entity.PortalUser> PortalUser { get; set; }
        public DbSet<Entity.Token> Token { get; set; }
        public DbSet<Entity.Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new AuditConfiguration());
            modelBuilder.ApplyConfiguration(new GrantedUserConfiguration());
            modelBuilder.ApplyConfiguration(new PortalUserConfiguration());
            modelBuilder.ApplyConfiguration(new TokenConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        }
    }
}
