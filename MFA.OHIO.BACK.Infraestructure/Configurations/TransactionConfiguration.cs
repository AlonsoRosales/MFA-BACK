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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("TBL_Transacciones");

            builder.HasKey(t => t.transactionId);

            builder.Property(t => t.transactionId)
                .HasColumnName("TRANSACTION_ID")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.messageType)
                .HasColumnName("MESSAGE_TYPE")
                .IsRequired();

            builder.Property(t => t.originType)
                .HasColumnName("ORIGIN_TYPE")
                .IsRequired();

            builder.Property(t => t.grantedUserId)
                .HasColumnName("GRANTEDUSER_ID")
                .IsRequired();

            builder.Property(t => t.applicationId)
                .HasColumnName("APPLICATION_ID")
                .IsRequired();

            builder.Property(t => t.ipv4)
                .HasColumnName("IPv4")
                .IsRequired();

            builder.Property(t => t.reqDate)
                .HasColumnName("REQ_DATE")
                .IsRequired();

            builder.Property(t => t.tokenGenerated)
                .HasColumnName("TOKEN_GENERATED");

            builder.Property(t => t.tokenRequested)
                .HasColumnName("TOKEN_REQUESTED");

            builder.Property(t => t.fechaHoraTransaccion)
                .HasColumnName("FECHAHORA_TRANSACCION")
                .IsRequired();

            builder.Property(t => t.responseStatus)
                .HasColumnName("RESPONSE_STATUS")
                .IsRequired();

            builder.Property(t => t.responseMessage)
                .HasColumnName("RESPONSE_MESSAGE")
                .IsRequired();

            builder.Property(t => t.detalleAdicional)
                .HasColumnName("DETALLE_ADICIONAL")
                .IsRequired();
        }
    }
}
