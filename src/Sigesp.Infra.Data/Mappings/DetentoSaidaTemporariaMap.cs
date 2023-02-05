using System.Reflection.Emit;
using System.Collections.Immutable;
using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class DetentoSaidaTemporariaMap : IEntityTypeConfiguration<DetentoSaidaTemporaria>
    {
        public void Configure(EntityTypeBuilder<DetentoSaidaTemporaria> builder)
        {
            builder.ToTable("DetentoSaidasTemporaria");

            builder
                .HasKey(c => c.Id);

            //Relacionamentos
            builder
                .HasIndex(c => c.DetentoId)
                .IsUnique(false);
                
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}