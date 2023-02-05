using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class AlunoRedacaoDPUMap : IEntityTypeConfiguration<AlunoRedacaoDPU>
    {
        public void Configure(EntityTypeBuilder<AlunoRedacaoDPU> builder)
        {
            builder.ToTable("AlunosRedacaoDPU");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.InscricaoNumero)
                .IsRequired(false);
            
            builder.Property(c => c.IsPrivadoLiberdade)
                .HasDefaultValue(true);
            
            builder.Property(c => c.RedacaoImagem)
                .IsRequired(false);

            builder.Property(c => c.Media)
                .HasColumnType("decimal(5,2)");
            
            builder.Property(c => c.NotaCriatividade)
                .HasColumnType("decimal(5,2)");
            
            builder.Property(c => c.NotaConteudo)
                .HasColumnType("decimal(5,2)");
            
            builder.Property(c => c.NotaClareza)
                .HasColumnType("decimal(5,2)");
            
            builder.Property(c => c.NotaPertinencia)
                .HasColumnType("decimal(5,2)");

            builder.Property(c => c.CertificadoImagem)
                .IsRequired(false);
            
            builder.Property(c => c.ResultadoColocacao)
                .HasDefaultValue(0);
            
            
            //Relacionamentos
            builder
                .HasOne(c => c.Aluno)
                .WithMany(c => c.AlunosRedacaoDPU)
                .HasForeignKey(c => c.AlunoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasIndex(c => c.AlunoId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
            
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}