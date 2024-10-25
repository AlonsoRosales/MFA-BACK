using MFA.OHIO.BACK.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Infraestructure.Configurations
{
    public class GrantedUserConfiguration : IEntityTypeConfiguration<GrantedUser>
    {
        public void Configure(EntityTypeBuilder<GrantedUser> builder)
        {
            builder.ToTable("TBL_GrantedUsers");

            builder.HasKey(g => g.granteduserId);

            builder.Property(g => g.granteduserId)
                .HasColumnName("GRANTEDUSER_ID")
                .ValueGeneratedOnAdd();

            builder.Property(g => g.user)
                .HasColumnName("USER")
                .IsRequired();

            builder.Property(g => g.email)
                .HasColumnName("EMAIL")
                .IsRequired();

            builder.Property(g => g.applicationId)
                .HasColumnName("APPLICATION_ID")
                .IsRequired();

            builder.Property(g => g.userStatus)
                .HasColumnName("USER_STATUS")
                .IsRequired();
            
            builder.Property(g => g.fechaHoraCreacion)
                .HasColumnName("FECHAHORACREACION")
                .IsRequired();
        }
    }
}
