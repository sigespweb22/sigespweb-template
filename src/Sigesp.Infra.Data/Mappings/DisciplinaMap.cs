using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class DisciplinaMap : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.ToTable("Disciplinas");
            
            builder.Property(c => c.Nome)
                .HasMaxLength(255)
                .IsRequired();
            
            builder.Property(c => c.Fase)
                .IsRequired();
            
            builder.Property(c => c.HoraAula)
                .HasDefaultValue(0);
            
            builder.Property(c => c.CargaHoraria)
                .HasDefaultValue(0);
            
            builder.Property(c => c.Curso)
                .IsRequired();

            builder.Property(c => c.ProfessorId)
                .IsRequired();


            //Relacionamentos
            builder
                .HasOne(c => c.Professor)
                .WithMany(c => c.Disciplinas)
                .HasForeignKey(c => c.ProfessorId)
                .OnDelete(DeleteBehavior.Cascade);
                
            builder
                .HasIndex(c => c.ProfessorId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
            
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}