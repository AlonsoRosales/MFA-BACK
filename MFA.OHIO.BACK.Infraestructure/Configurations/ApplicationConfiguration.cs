using Entity = MFA.OHIO.BACK.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MFA.OHIO.BACK.Infraestructure.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Entity.Application>
    {
        public void Configure(EntityTypeBuilder<Entity.Application> builder)
        {
            builder.ToTable("TBL_Aplicaciones");

            builder.HasKey(a => a.applicationId);

            builder.Property(a => a.applicationId)
                .HasColumnName("APPLICATION_ID");

            builder.Property(a => a.nombre)
                .HasColumnName("NOMBRE")
                .IsRequired();

            builder.Property(a => a.status)
                .HasColumnName("ESTADO")
                .IsRequired();

            builder.Property(a => a.fechaHoraCreacion)
                .HasColumnName("FECHA_CREACION")
                .IsRequired();

            builder.Property(a => a.ipRanges)
                .HasColumnName("IP_RANGES")
                .IsRequired();

            builder.Property(a => a.userIdCreacion)
                .HasColumnName("USUARIO_ID_CREACION")
                .IsRequired();

            builder.Property(a => a.fechaHoraModificacion)
                .HasColumnName("FECHA_MODIFICACION");

            builder.Property(a => a.userIdModificacion)
                .HasColumnName("USUARIO_ID_MODIFICACION");
        }
    }
}
