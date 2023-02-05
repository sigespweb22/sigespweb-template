using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sigesp.Infra.Data.Mappings
{
    public class ContabilEventoMap : IEntityTypeConfiguration<ContabilEvento>
    {
        public void Configure(EntityTypeBuilder<ContabilEvento> builder)
        {
            builder.ToTable("ContabilEventos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();;

            builder.Property(c => c.Codigo)
                .HasMaxLength(150)
                .IsRequired(false);

            builder.Property(c => c.Especificacao)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .HasMany(c => c.Lancamentos)
                .WithOne(c => c.ContabilEvento)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}