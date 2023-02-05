using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class ColaboradorMap : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.ToTable("Colaboradores");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Situacao)
                .IsRequired();

            builder.Property(c => c.LocalTrabalho)
                .HasDefaultValue(null)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(c => c.Remuneracao)
                .HasDefaultValue(0)
                .HasColumnType("decimal(7,3)");

            builder.Property(c => c.FamiliarAutorizadoRetirada)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(c => c.Desconto)
                .HasDefaultValue(0)
                .HasColumnType("decimal(4,2)");

            builder.Property(c => c.DescontoOutro)
                .HasDefaultValue(0)
                .HasColumnType("decimal(4,2)");

            builder.Property(c => c.DiaPagamento)
                .HasDefaultValue(0)
                .HasMaxLength(2);

            builder.Property(c => c.JornadaInicio)
                .IsRequired(false)
                .HasMaxLength(5);
            
            builder.Property(c => c.JornadaFim)
                .IsRequired(false)
                .HasMaxLength(5);

            builder.Property(c => c.BancoNumero)
                .HasDefaultValue(0)
                .HasMaxLength(25);

            builder.Property(c => c.BancoAgencia)
                .IsRequired(false)
                .HasMaxLength(25); 

            builder.Property(c => c.BancoConta)
                .IsRequired(false)
                .HasMaxLength(25);
            
            builder.Property(c => c.Observacao)
                .IsRequired(false)
                .HasMaxLength(255);
            
            builder.Property(c => c.TipoConta)
                .HasDefaultValue(TipoContaEnum.NENHUM);

            builder.Property(c => c.Folga)
                .IsRequired(false)
                .HasDefaultValue(null)
                .HasMaxLength(255);

            //Relacionamentos
            builder
                .HasOne(c => c.ContaCorrente)
                .WithOne(c => c.Colaborador)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(c => c.EmpresaConvenio)
                .WithMany(d => d.Colaboradores)
                .HasForeignKey(d => d.EmpresaConvenioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(c => c.Detento)
                .WithMany(d => d.Colaboradores)
                .HasForeignKey(d => d.DetentoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(c => c.Pontos)
                .WithOne(c => c.Colaborador)
                .HasForeignKey(c => c.ColaboradorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(c => c.DetentoId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
            
            builder
                .HasIndex(c => c.EmpresaConvenioId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
            
            builder.HasQueryFilter(p => !p.IsDeleted);
            
            //Seed for dev
            // builder.HasData(
            //     new Colaborador
            //     {
            //         Id = Guid.Parse("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
            //         Situacao = (Domain.Enums.ColaboradorSituacaoEnum)1,
            //         DataUltimaSituacao = DateTime.Now,
            //         LocalTrabalho = "GALERIA",
            //         IsTrabalhoInterno = true,
            //         IsRemunerado = true,
            //         Remuneracao = 1000.20M,
            //         FamiliarAutorizadoRetirada = "Teste",
            //         Desconto = 25,
            //         DescontoOutro = 33,
            //         DiaPagamento = 10,
            //         TipoPagamento = (Domain.Enums.TipoPagamentoEnum) 1,
            //         JornadaInicio = "08:00",
            //         JornadaFim = "17:00",
            //         BancoNumero = 341,
            //         BancoAgencia = "654321",
            //         BancoConta = "123456",
            //         TipoConta = (Domain.Enums.TipoContaEnum) 2,
            //         Observacao = "Nenhuma observação",
            //         EmpresaConvenioId = Guid.Parse("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
            //         DetentoId = Guid.Parse("533ef31e-407a-4da2-a416-53a50ec0da0e"),
            //         CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
            //         CreatedAt = DateTime.Now,
            //         UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
            //         UpdatedAt = DateTime.Now
            //     },
            //     new Colaborador
            //     {
            //         Id = Guid.Parse("08adda92-d549-4065-a9c1-14b1adc26ea8"),
            //         Situacao = (Domain.Enums.ColaboradorSituacaoEnum)2,
            //         DataUltimaSituacao = DateTime.Now,
            //         LocalTrabalho = "Fábrica do conveniado",
            //         IsTrabalhoInterno = false,
            //         IsRemunerado = true,
            //         Remuneracao = 1000.20M,
            //         FamiliarAutorizadoRetirada = "Teste 1",
            //         Desconto = 25,
            //         DescontoOutro = 33,
            //         DiaPagamento = 05,
            //         TipoPagamento = (Domain.Enums.TipoPagamentoEnum) 2,
            //         JornadaInicio = "07:30",
            //         JornadaFim = "14:00",
            //         BancoNumero = 1,
            //         BancoAgencia = "897654",
            //         BancoConta = "456789",
            //         TipoConta = (Domain.Enums.TipoContaEnum) 3,
            //         Observacao = "Nenhuma observação 2",
            //         EmpresaConvenioId = Guid.Parse("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
            //         DetentoId = Guid.Parse("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
            //         CreatedAt = DateTime.Now,
            //         CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
            //         UpdatedAt = DateTime.Now,
            //         UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888")
            //     }                  
            // );
        }
    }
}