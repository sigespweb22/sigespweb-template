using System.Data;
using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class LancamentoMap : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.ToTable("Lancamentos");

            builder
                .HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.ValorLiquido)
                .HasColumnType("decimal(10,2)");
            
            builder.Property(c => c.Observacao)
                .HasMaxLength(255)
                .IsRequired(false);
            
            builder.Property(c => c.PeriodoReferencia)
                .HasDefaultValue(LancamentoPeriodoReferenciaEnum.NENHUM);

            builder.Property(c => c.PeriodoDataInicio)
                .HasDefaultValue(0);

            builder.Property(c => c.PeriodoDataFim)
                .HasDefaultValue(0);
                
            builder
                .HasOne(c => c.ContaCorrente)
                .WithMany(d => d.Lancamentos)
                .HasForeignKey(c => c.ContaCorrenteId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(c => c.ContabilEvento)
                .WithMany(c => c.Lancamentos)
                .HasForeignKey(c => c.ContabilEventoId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .Property(c => c.ContabilEventoId)
                .HasDefaultValue(null);

            builder
                .HasIndex(c => c.ContabilEventoId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);

            builder
                .HasIndex(c => c.ContaCorrenteId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
            
            builder.HasQueryFilter(p => !p.IsDeleted);
            
            //Seed for dev
            // builder.HasData(
            //     n2ew Lancamento
            //     {
            //         Id = Guid.Parse("0af820ce-7131-45de-a98d-947f972c2a84"),
            //         Descricao = "Pagamento mensal 1",
            //         DataLiquidacao = DateTime.Now,
            //         Desconto = 100.25M,
            //         ValorBruto = 1000.20M,
            //         ValorLiquido = 900.10M,
            //         PeriodoDataInicio = 01,
            //         PeriodoDataFim = 31,
            //         DataUltimoStatus = DateTime.Now,
            //         Observacao = "Informações teste registro 1",
            //         Status = (Domain.Enums.LancamentoStatusEnum)1,
            //         PeriodoReferencia = (Domain.Enums.LancamentoPeriodoReferenciaEnum)1,
            //         Tipo = (Domain.Enums.LancamentoTipoEnum)1,
            //         CreatedAt = DateTime.Now,
            //         CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
            //         UpdatedAt = DateTime.Now,
            //         UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
            //         ContaCorrenteId = Guid.Parse("f2358763-f076-4178-8f40-c24eeadf3e96")
            //     },
            //     new Lancamento
            //     {
            //         Id = Guid.Parse("f9ccef5e-d217-485f-91de-97cd93efca3a"),
            //         Descricao = "Pagamento mensal 2",
            //         DataLiquidacao = DateTime.Now,
            //         Desconto = 255.70M,
            //         ValorBruto = 1000.20M,
            //         ValorLiquido = 600.44M,
            //         PeriodoDataInicio = 01,
            //         PeriodoDataFim = 31,
            //         DataUltimoStatus = DateTime.Now,
            //         Observacao = "Informações teste registro 2",
            //         Status = (Domain.Enums.LancamentoStatusEnum)2,
            //         PeriodoReferencia = (Domain.Enums.LancamentoPeriodoReferenciaEnum)4,
            //         Tipo = (Domain.Enums.LancamentoTipoEnum)1,
            //         CreatedAt = DateTime.Now,
            //         CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
            //         UpdatedAt = DateTime.Now,
            //         UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
            //         ContaCorrenteId = Guid.Parse("f2358763-f076-4178-8f40-c24eeadf3e96")
            //     }
            // );
        }
    }
}