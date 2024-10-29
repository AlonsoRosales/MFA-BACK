using Microsoft.EntityFrameworkCore;
using MFA.OHIO.BACK.Infraestructure.Configurations;
using Entity = MFA.OHIO.BACK.Core.Entities;
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
        public DbSet<Entity.SystemVariables> SystemVariable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new AuditConfiguration());
            modelBuilder.ApplyConfiguration(new GrantedUserConfiguration());
            modelBuilder.ApplyConfiguration(new PortalUserConfiguration());
            modelBuilder.ApplyConfiguration(new TokenConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new SystemVariablesConfiguration());
        }
    }
}
