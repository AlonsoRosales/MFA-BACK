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
    public class PortalUserConfiguration : IEntityTypeConfiguration<PortalUser>
    {
        public void Configure(EntityTypeBuilder<PortalUser> builder)
        {
            builder.ToTable("TBL_PortalUsers");

            builder.HasKey(p => p.userId);

            builder.Property(p => p.userId)
                .HasColumnName("USER_ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.nombre)
                .HasColumnName("NOMBRE")
                .IsRequired();

            builder.Property(p => p.apellido)
                .HasColumnName("APELLIDO")
                .IsRequired();

            builder.Property(p => p.dni)
                .HasColumnName("DNI")
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(p => p.usuario)
                .HasColumnName("USUARIO")
                .IsRequired();

            builder.Property(p => p.password)
                .HasColumnName("PASSWORD")
                .IsRequired();

            builder.Property(p => p.rol)
                .HasColumnName("ROL")
                .IsRequired();

            builder.Property(p => p.status)
                .HasColumnName("STATUS")
                .IsRequired();

            builder.Property(p => p.fechaHoraCreacion)
                .HasColumnName("FECHAHORACREACION")
                .IsRequired();
        }
    }
}
