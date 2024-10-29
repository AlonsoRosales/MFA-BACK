using MFA.OHIO.BACK.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MFA.OHIO.BACK.Infraestructure.Configurations
{
    public class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.ToTable("TBL_Tokens");

            builder.HasKey(t => t.tokenId);

            builder.Property(t => t.tokenId)
                .HasColumnName("TOKEN_ID")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.token)
                .HasColumnName("TOKEN")
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(t => t.grantedUserId)
                .HasColumnName("GRANTEDUSER_ID")
                .IsRequired();

            builder.Property(t => t.status)
                .HasColumnName("STATUS")
                .IsRequired();

            builder.Property(t => t.fechaHoraCreacion)
               .HasColumnName("FECHAHORACREACION")
               .IsRequired();

            builder.Property(t => t.fechaHoraExpiracion)
                .HasColumnName("FECHAHORAEXPIRACION")
                .IsRequired();

            builder.Property(t => t.fechaHoraCambioEstado)
                .HasColumnName("FECHAHORACAMBIOESTADO");

            builder.Property(t => t.ttlConfig)
                .HasColumnName("TTLCONFIG")
                .IsRequired();

            builder.Property(t => t.failCounts)
                .HasColumnName("FAIL_COUNTS")
                .IsRequired();

            builder.Property(t => t.failCountsSet)
                .HasColumnName("FAIL_COUNTS_SET")
                .IsRequired ();
        }
    }
}
