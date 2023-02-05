using System.Data;
using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class SequenciaOficioMap : IEntityTypeConfiguration<SequenciaOficio>
    {
        public void Configure(EntityTypeBuilder<SequenciaOficio> builder)
        {
            builder.ToTable("SequenciasOficios");

            builder
                .HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}