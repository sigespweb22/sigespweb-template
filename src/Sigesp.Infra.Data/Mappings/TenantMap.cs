using System.Reflection.Emit;
using System.Collections.Immutable;
using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class TenantMap : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.ToTable("Tenants");

            builder
                .HasKey(c => c.Id);

            builder.Property(c => c.ApiKey)
                .IsRequired();

            builder
                .HasIndex(c => c.ApiKey)
                .IsUnique();
            
            builder.Property(c => c.Nome)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.OficioLeituraAssinaturaNome)
                .HasMaxLength(500)
                .IsRequired(false);
            
            builder.Property(c => c.OficioLeituraAssinaturaCargo)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(c => c.OficioLeituraAssinaturaMatricula)
                .HasMaxLength(500)
                .IsRequired(false);
            
            builder.Property(c => c.EnderecoLogradouro)
                .HasMaxLength(500)
                .IsRequired(false);
            
            builder.Property(c => c.EnderecoLogradouro)
                .IsRequired(false);
            
            builder.Property(c => c.EnderecoLogradouroNumero)
                .HasMaxLength(10)
                .IsRequired(false);
            
            builder.Property(c => c.EnderecoCidade)
                .HasMaxLength(50)
                .IsRequired(false);
            
            builder.Property(c => c.EnderecoEstado)
                .HasMaxLength(25)
                .IsRequired(false);
            
            builder.Property(c => c.EnderecoCEP)
                .HasMaxLength(10)
                .IsRequired(false);
            
            builder.Property(c => c.OficioLeituraVocativo1)
                .HasMaxLength(50)
                .IsRequired(false);
            
            builder.Property(c => c.OficioLeituraVocativo2)
                .HasMaxLength(500)
                .IsRequired(false);
            
            builder.Property(c => c.OficioLeituraVocativo3)
                .HasMaxLength(500)
                .IsRequired(false);
            
            builder.Property(c => c.TelefoneDDD)
                .HasMaxLength(2)
                .IsRequired(false);
            
            builder.Property(c => c.TelefoneNumero)
                .HasMaxLength(12)
                .IsRequired(false);

            builder.Property(c => c.EmailPrincipal)
                .IsRequired(false);

            builder
                .HasMany(c => c.Detentos)
                .WithOne(c => c.Tenant)
                .OnDelete(DeleteBehavior.NoAction);
 
            builder.HasQueryFilter(p => !p.IsDeleted);

            //Seed for dev
            builder.HasData(
                new Tenant
                {
                    Id = Guid.Parse("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    ApiKey = Guid.Parse("06b5fb02-57cb-126b-3ab2-a05f805f1e97"),
                    Nome = "Tenância Presídio Regional de Criciúma",
                    NomeExibicao = "PRESÍDIO REGIONAL CRICIÚMA"                   
                },
                new Tenant
                {
                    Id = Guid.Parse("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    ApiKey = Guid.Parse("bed67d28-49f5-4496-9d32-334cba103736"),
                    Nome = "Tenância Master",
                    NomeExibicao = "TODAS UNIDADES"
                },
                new Tenant
                {
                    Id = Guid.Parse("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    ApiKey = Guid.Parse("f2068a0f-2e70-47e2-a528-a54fececd877"),
                    Nome = "Tenância Penitenciária Sul",
                    NomeExibicao = "PENITENCIÁRIA SUL"
                }
            );
        }
    }
}