using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class ServidorEstadoReforcoMap : IEntityTypeConfiguration<ServidorEstadoReforco>
    {
        public void Configure(EntityTypeBuilder<ServidorEstadoReforco> builder)
        {
            builder.ToTable("ServidoresEstadoReforcos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.DataPrevistaInicio)
                .IsRequired();
            
            builder.Property(c => c.DataPrevistaFim)
                .IsRequired();
            
            builder.Property(c => c.DiaSemana)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(c => c.MesExtenso)
                .IsRequired();
            
            builder.Property(c => c.MesNumeral)
                .IsRequired();

            builder.Property(c => c.ReforcoSituacao)
                .IsRequired();
            

            //Relacionamentos
            builder
                .HasOne(c => c.ServidorEstado)
                .WithMany(c => c.ServidoresEstadoReforcos)
                .HasForeignKey(c => c.ServidorEstadoId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
