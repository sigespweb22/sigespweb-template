using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class ServidorEstadoMap : IEntityTypeConfiguration<ServidorEstado>
    {
        public void Configure(EntityTypeBuilder<ServidorEstado> builder)
        {
            builder.ToTable("ServidoresEstado");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.Nome)
                .IsRequired(false);
            
            builder.Property(c => c.Matricula)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.PlantaoNome)
                .HasDefaultValue(PlantaoNomeEnum.NENHUM);
            
            builder.Property(c => c.Galeria)
                .HasDefaultValue(GaleriaEnum.NENHUMA);
            
            builder.Property(c => c.HasPrioridadeMarcacaoReforco)
                .HasDefaultValue(false);
            
            builder.Property(c => c.IsExpediente)
                .HasDefaultValue(false);
            
            //Relacionamentos
            builder
                .HasOne(c => c.ApplicationUser)
                .WithOne(c => c.ServidorEstado)
                .HasForeignKey<ServidorEstado>(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.ServidoresEstado)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}