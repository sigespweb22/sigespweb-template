using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Models;

namespace Sigesp.Infra.Data.Mappings
{
    public class FormularioLeituraDicaEscritaMap : IEntityTypeConfiguration<FormularioLeituraDicaEscrita>
    {
        public void Configure(EntityTypeBuilder<FormularioLeituraDicaEscrita> builder)
        {
            builder.ToTable("FormularioLeituraDicasEscrita");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.Nome)
                .HasMaxLength(255)
                .IsRequired();
                
            builder
                .Property(c => c.TenantId)
                .HasDefaultValue(new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"))
                .IsRequired();
            
            builder.HasQueryFilter(p => !p.IsDeleted);

            //Relacionamentos
            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.FormularioLeituraDicasEscrita)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);
                
            builder
                .HasIndex(x => x.TenantId)
                .IsUnique(false);

            builder
                .HasMany(c => c.FormularioLeituraDicaEscritaDicas)
                .WithOne(c => c.FormularioLeituraDicaEscrita)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasData(
                new FormularioLeituraPerguntaGrupo
                {
                    Id = Guid.Parse("8d7fb6ec-bcbf-4f94-ad0a-0f7154e8670b"),
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    Nome = "SENÃO E SE NÃO"
                }
            );
        }
    }
}