using System.Reflection.Emit;
using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sigesp.Infra.Data.Mappings
{
    public class ContaCorrenteMap : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.ToTable("ContasCorrentes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Numero)
                .HasMaxLength(6)
                .IsRequired();
            
            builder
                .HasIndex(c => c.Numero)
                .IsUnique(false);
            
            builder.Property(c => c.Status)
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasMaxLength(255)
                .IsRequired(false);
            
            //Relacionamentos
            builder
                .HasMany(c => c.Lancamentos)
                .WithOne(d => d.ContaCorrente)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasOne(c => c.Colaborador)
                .WithOne(d => d.ContaCorrente)
                .HasForeignKey<ContaCorrente>(c => c.ColaboradorId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(c => c.Empresa)
                .WithMany(c => c.ContasCorrentes)
                .HasForeignKey(c => c.EmpresaId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(c => c.ColaboradorId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique();
            
            builder
                .HasIndex(c => c.EmpresaId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);

            builder.HasQueryFilter(p => !p.IsDeleted);
            
            //Seed for dev
            // builder.HasData(
            //     new ContaCorrente
            //     {
            //         Id = Guid.Parse("f2358763-f076-4178-8f40-c24eeadf3e96"),
            //         Numero = 234567,
            //         DataUltimoStatus = DateTime.Now,
            //         Status = (Domain.Enums.ContaCorrenteStatusEnum) 1,
            //         CreatedAt = DateTime.Now,
            //         CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
            //         UpdatedAt = DateTime.Now,
            //         UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
            //         ColaboradorId = Guid.Parse("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a")
            //     },
            //     new ContaCorrente
            //     {
            //         Id = Guid.Parse("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
            //         Numero = 123456,
            //         DataUltimoStatus = DateTime.Now,
            //         Status = (Domain.Enums.ContaCorrenteStatusEnum) 1,
            //         CreatedAt = DateTime.Now,
            //         CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
            //         UpdatedAt = DateTime.Now,
            //         UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
            //         ColaboradorId = Guid.Parse("08adda92-d549-4065-a9c1-14b1adc26ea8")
            //     }                  
            // );
        }
    }
}