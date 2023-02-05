using System.Data;
using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sigesp.Infra.Data.Mappings
{
    public class EmpresaConvenioMap : IEntityTypeConfiguration<EmpresaConvenio>
    {
        public void Configure(EntityTypeBuilder<EmpresaConvenio> builder)
        {
            builder.ToTable("EmpresasConvenios");

            builder
                .HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.Nome)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .HasOne(c => c.Empresa)
                .WithMany(d => d.EmpresaConvenios)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasMany(c => c.Colaboradores)
                .WithOne(d => d.EmpresaConvenio)
                .HasForeignKey(c => c.EmpresaConvenioId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasMany(c => c.ColaboradoresPonto)
                .WithOne(c => c.EmpresaConvenio)
                .HasForeignKey(c => c.EmpresaConvenioId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasIndex(c => c.EmpresaId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);

            builder.Property(c => c.Responsavel)
                .HasMaxLength(150)
                .IsRequired(false);
            
            builder.Property(c => c.IsRenovacaoAutomatica)
                .HasDefaultValue(false);

            builder.Property(c => c.MotivoEncerramento)
                .IsRequired(false)
                .HasMaxLength(255);
            
            builder.Property(c => c.TermosGerais)
                .IsRequired(false)
                .HasMaxLength(255);
            
            builder.HasQueryFilter(p => !p.IsDeleted);
            
            //Seed for dev
            // builder.HasData(
            //     new EmpresaConvenio
            //     {
            //         Id = Guid.Parse("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
            //         Nome = "Convenio RBX",
            //         DataInicio = DateTime.Now,
            //         DataFim = DateTime.Now,
            //         IsRenovacaoAutomatica = true,
            //         TermosGerais = "Conforme acordado em contrato",
            //         Responsavel = "Amilton luiz",
            //         Situacao = (Domain.Enums.ConvenioSituacaoEnum)1,
            //         EmpresaId = Guid.Parse("00e08a3e-da29-4493-8786-65c67a98970f"),
            //         CreatedAt = DateTime.Now,
            //         CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
            //         UpdatedAt = DateTime.Now,
            //         UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888")
            //     },
            //     new EmpresaConvenio
            //     {
            //         Id = Guid.Parse("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
            //         Nome = "Convenio ESAF",
            //         DataInicio = DateTime.Now,
            //         DataFim = DateTime.Now,
            //         IsRenovacaoAutomatica = true,
            //         TermosGerais = "Termos acertados no contrato",
            //         Responsavel = "José luiz datena",
            //         Situacao = (Domain.Enums.ConvenioSituacaoEnum)2,
            //         EmpresaId = Guid.Parse("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
            //         CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
            //         UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888")
            //     }
            // );
        }
    }
}