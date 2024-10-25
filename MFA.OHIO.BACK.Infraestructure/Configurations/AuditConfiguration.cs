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
    public class AuditConfiguration : IEntityTypeConfiguration<Audit>
    {
        public void Configure(EntityTypeBuilder<Audit> builder)
        {
            builder.ToTable("TBL_Auditoria");

            builder.HasKey(a => a.eventId);

            builder.Property(a => a.eventId)
                .HasColumnName("EVENT_ID")
                .ValueGeneratedOnAdd();

            builder.Property(a => a.userId)
                .HasColumnName("USER_ID")
                .IsRequired();

            builder.Property(a => a.eventType)
                .HasColumnName("EVENT_TYPE")
                .IsRequired();

            builder.Property(a => a.fechaHoraEvento)
                .HasColumnName("FECHAHORA_EVENTO")
                .IsRequired();

            builder.Property(a => a.eventDescription)
                .HasColumnName("EVENTO_DESCRIPCION")
                .IsRequired();
        }
    }
}
