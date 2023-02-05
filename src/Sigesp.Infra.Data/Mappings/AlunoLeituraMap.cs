using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;
using Sigesp.Infra.Data.Extensions;

namespace Sigesp.Infra.Data.Mappings
{
    public class AlunoLeituraMap : IEntityTypeConfiguration<AlunoLeitura>
    {
        public void Configure(EntityTypeBuilder<AlunoLeitura> builder)
        {
            builder.ToTable("AlunosLeituras");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.ChaveLeitura)
                .IsRequired()
                .HasDefaultValue(0)
                .HasMaxLength(10);

            builder.Property(c => c.LeituraTipo)
                .IsRequired();
            
            builder.Property(c => c.DataInicio)
                .IsRequired();
            
            builder.Property(c => c.DataFim)
                .IsRequired();
            
            builder.Property(c => c.AvaliacaoConceito)
                .HasDefaultValue(AlunoLeituraAvaliacaoConceitoEnum.PENDENTE);
            
            builder.Property(c => c.AvaliacaoCriterio1)
                .HasDefaultValue(AlunoLeituraAvaliacaoCriterioEnum.PENDENTE);

            builder.Property(c => c.AvaliacaoCriterio2)
                .HasDefaultValue(AlunoLeituraAvaliacaoCriterioEnum.PENDENTE);
            
            builder.Property(c => c.AvaliacaoCriterio3)
                .HasDefaultValue(AlunoLeituraAvaliacaoCriterioEnum.PENDENTE);
            
            builder.Property(c => c.AvaliacaoCriterio4)
                .HasDefaultValue(AlunoLeituraAvaliacaoCriterioEnum.PENDENTE);
            
            builder.Property(c => c.AvaliacaoCriterio4)
                .HasDefaultValue(AlunoLeituraAvaliacaoCriterioEnum.PENDENTE);
            
            builder.Property(c => c.AvaliacaoCriterio5)
                .HasDefaultValue(AlunoLeituraAvaliacaoCriterioEnum.PENDENTE);

            builder.Property(c => c.AvaliacaoCriterio6)
                .HasDefaultValue(AlunoLeituraAvaliacaoCriterioEnum.PENDENTE);
            
            builder.Property(c => c.AvaliacaoCriterio7)
                .HasDefaultValue(AlunoLeituraAvaliacaoCriterioEnum.PENDENTE);
            
            builder.Property(c => c.IsAvaliado)
                .HasDefaultValue(false);
            
            //Relacionamentos
            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.AlunosLeituras)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(c => c.TenantId)
                .HasDefaultValue(new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"))
                .IsRequired();

            builder
                .HasOne(c => c.AlunoLeitor)
                .WithMany(c => c.AlunoLeituras)
                .HasForeignKey(c => c.AlunoLeitorId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasOne(c => c.Livro)
                .WithMany(c => c.AlunoLeituras)
                .HasForeignKey(c => c.LivroId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasOne(c => c.AlunoLeituraCronograma)
                .WithMany(c => c.AlunoLeituras)
                .HasForeignKey(c => c.AlunoLeituraCronogramaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(c => c.AlunoLeitorId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);

            builder
                .HasIndex(c => c.LivroId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
            
            builder
                .HasIndex(c => c.AlunoLeituraCronogramaId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
            
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}