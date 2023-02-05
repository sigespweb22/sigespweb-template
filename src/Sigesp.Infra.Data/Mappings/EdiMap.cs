using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class EdiMap : IEntityTypeConfiguration<Edi>
    {
        public void Configure(EntityTypeBuilder<Edi> builder)
        {
            builder.ToTable("Edis");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.ArquivoNome)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.ArquivoExtensao)
                .HasMaxLength(10)
                .IsRequired();
            
            //Relacionamentos
            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.Edis)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(c => c.TenantId)
                .HasDefaultValue(new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"))
                .IsRequired();
            
            builder
                .HasMany(c => c.ColaboradoresPonto)
                .WithOne(c => c.Edi)
                .HasForeignKey(c => c.EdiId)
                .OnDelete(DeleteBehavior.Cascade);            
            
            builder
                .HasMany(c => c.EdiLogs)
                .WithOne(d => d.Edi)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}