using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class AlunoLeitorMap : IEntityTypeConfiguration<AlunoLeitor>
    {
        public void Configure(EntityTypeBuilder<AlunoLeitor> builder)
        {
            builder.ToTable("AlunosLeitores");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.DataIngresso)
                .IsRequired();
            
            builder.Property(c => c.OcorrenciaDesistencia)
                .HasDefaultValue(AlunoLeitorOcorrenciaDesistenciaEnum.NENHUMA);
            
            builder.Property(c => c.DataOcorrenciaDesistencia)
                .HasDefaultValue("0001-01-01 00:00:00");

            //Relacionamentos
            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.AlunosLeitores)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(c => c.TenantId)
                .IsRequired();

            builder
                .HasOne(c => c.Aluno)
                .WithMany(c => c.AlunosLeitores)
                .HasForeignKey(c => c.AlunoId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasMany(c => c.AlunoLeituras)
                .WithOne(c => c.AlunoLeitor)
                .HasForeignKey(c => c.AlunoLeitorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(c => c.AlunoId)
                .IsUnique();

            builder
                .HasIndex(c => c.ProfessorId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
            
            builder
                .HasIndex(c => c.LivroGeneroId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
            
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}