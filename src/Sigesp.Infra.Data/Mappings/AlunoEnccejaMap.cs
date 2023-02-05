using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class AlunoEnccejaMap : IEntityTypeConfiguration<AlunoEncceja>
    {
        public void Configure(EntityTypeBuilder<AlunoEncceja> builder)
        {
            builder.ToTable("AlunosEncceja");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.Curso)
                .HasDefaultValue(CursoEnum.NAO_INFORMADO);
            
            builder.Property(c => c.InscricaoNumero)
                .IsRequired(false);
            
            builder.Property(c => c.NotaAreaI)
                .HasColumnType("decimal(5,2)");
            
            builder.Property(c => c.NotaAreaII)
                .HasColumnType("decimal(5,2)");
            
            builder.Property(c => c.NotaAreaIII)
                .HasColumnType("decimal(5,2)");
            
            builder.Property(c => c.NotaAreaIV)
                .HasColumnType("decimal(5,2)");
            
            builder.Property(c => c.NotaRedacao)
                .HasColumnType("decimal(5,2)");
            
            builder.Property(c => c.Media)
                .HasColumnType("decimal(5,2)");
            
            builder.Property(c => c.HasCertificado)
                .HasDefaultValue(false);
            
            builder.Property(c => c.IsAprovado)
                .HasDefaultValue(false);
            

            //Relacionamentos
            builder
                .HasOne(c => c.Aluno)
                .WithMany(c => c.AlunosEncceja)
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