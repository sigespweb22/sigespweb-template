using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class AlunoLeituraCronogramaMap : IEntityTypeConfiguration<AlunoLeituraCronograma>
    {
        public void Configure(EntityTypeBuilder<AlunoLeituraCronograma> builder)
        {
            builder.ToTable("AlunosLeiturasCronogramas");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.AnoReferencia)
                .IsRequired();

            builder.Property(c => c.PeriodoInicio)
                .IsRequired();
            
            builder.Property(c => c.PeriodoFim)
                .IsRequired();
            
            builder.Property(c => c.PeriodoReferencia)
                .IsRequired();  
            
            builder.Property(c => c.DiasPeriodo)
                .IsRequired();
            
            builder.Property(c => c.Nome)
                .HasMaxLength(25)   
                .IsRequired();
            
            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.AlunosLeiturasCronogramas)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(c => c.TenantId)
                .HasDefaultValue(new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"))
                .IsRequired();
            
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}