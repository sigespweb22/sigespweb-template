using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class AlunoEnemMap : IEntityTypeConfiguration<AlunoEnem>
    {
        public void Configure(EntityTypeBuilder<AlunoEnem> builder)
        {
            builder.ToTable("AlunosEnem");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.LinguaEstrangeira)
                .HasDefaultValue(LinguaEstrangeiraEnum.NAO_INFORMADO);
            
            builder.Property(c => c.InscricaoNumero)
                .IsRequired(false);
            
            builder.Property(c => c.NotaCN)
                .HasColumnType("decimal(5,2)");
            
            builder.Property(c => c.NotaCH)
                .HasColumnType("decimal(5,2)");
            
            builder.Property(c => c.NotaLC)
                .HasColumnType("decimal(5,2)");
            
            builder.Property(c => c.NotaMT)
                .HasColumnType("decimal(5,2)");
            
            builder.Property(c => c.NotaRedacao)
                .HasColumnType("decimal(5,2)");
            
            builder.Property(c => c.Media)
                .HasColumnType("decimal(5,2)");
            
            builder.Property(c => c.HasMediaMinima)
                .HasDefaultValue(false);
            

            //Relacionamentos
            builder
                .HasOne(c => c.Aluno)
                .WithMany(c => c.AlunosEnem)
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