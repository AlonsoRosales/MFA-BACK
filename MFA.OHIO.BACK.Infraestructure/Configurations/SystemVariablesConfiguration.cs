using MFA.OHIO.BACK.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MFA.OHIO.BACK.Infraestructure.Configurations
{
    public class SystemVariablesConfiguration : IEntityTypeConfiguration<SystemVariables>
    {
        public void Configure(EntityTypeBuilder<SystemVariables> builder)
        {
            builder.ToTable("TBL_JOBPARAMETERS");

            builder.HasKey(j => j.systemVariableId);

            builder.Property(j => j.systemVariableId)
                .HasColumnName("JOB_ID")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(j => j.systemVariableName)
                .HasColumnName("JOB_NAME")
                .IsRequired();

            builder.Property(j => j.systemVariableDescription)
                .HasColumnName("JOB_DES")
                .IsRequired();

            builder.Property(j => j.scheduleInterval)
                .HasColumnName("SCHEDULE_INTERVAL")
                .IsRequired();

            builder.Property(j => j.timeUnit)
                .HasColumnName("TIMEUNIT")
                .IsRequired();

            builder.Property(j => j.status)
                .HasColumnName("STATUS")
                .IsRequired();

            builder.Property(j => j.userIdMofication)
                .HasColumnName("USER_ID_MODIFICATION")
                .IsRequired();

            builder.Property(j => j.fechaHoraModificacion)
                .HasColumnName("FECHAHORAMODIFICACION")
                .IsRequired();
        }
    }
}
