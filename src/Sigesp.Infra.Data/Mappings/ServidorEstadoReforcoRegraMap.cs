using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class ServidorEstadoReforcoRegraMap : IEntityTypeConfiguration<ServidorEstadoReforcoRegra>
    {
        public void Configure(EntityTypeBuilder<ServidorEstadoReforcoRegra> builder)
        {
            builder.ToTable("ServidorEstadoReforcoRegras");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            //Relacionamentos
            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.ServidoEstadoReforcoRegras)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
