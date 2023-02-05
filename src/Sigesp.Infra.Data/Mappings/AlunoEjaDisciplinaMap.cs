using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class AlunoEjaDisciplinaMap : IEntityTypeConfiguration<AlunoEjaDisciplina>
    {
        public void Configure(EntityTypeBuilder<AlunoEjaDisciplina> builder)
        {
            //Tabela intermediaria
            builder.ToTable("AlunoEjaDisciplinas");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Conceito)
                .IsRequired();
            
            builder
                .Property(x => x.Nome)
                .IsRequired();
            
            builder
                .HasIndex(c => c.AlunoEjaId)
                .IsUnique(false);
        }
    }
}