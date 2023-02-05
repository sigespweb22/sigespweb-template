using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class EdiLogMap : IEntityTypeConfiguration<EdiLog>
    {
        public void Configure(EntityTypeBuilder<EdiLog> builder)
        {
            builder.ToTable("EdisLogs");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.EntityName)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(c => c.EntityProperty)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(c => c.EntityPropertyOldValue)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(c => c.EntityPropertyNewValue)
                .HasMaxLength(255)
                .IsRequired(false);
            
            builder.Property(c => c.Tipo)
                .HasDefaultValue(EdiLogTipoEnum.NAO_INFORMADO);

            //Relacionamentos
            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.EdisLogs)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(c => c.TenantId)
                .HasDefaultValue(new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"))
                .IsRequired();

            builder
                .HasOne(c => c.Edi)
                .WithMany(d => d.EdiLogs)
                .HasForeignKey(c => c.EdiId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(c => c.EdiId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
            
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}