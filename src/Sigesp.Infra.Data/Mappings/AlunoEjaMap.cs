using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class AlunoEjaMap : IEntityTypeConfiguration<AlunoEja>
    {
        public void Configure(EntityTypeBuilder<AlunoEja> builder)
        {
            builder.ToTable("AlunosEja");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.Curso)
                .HasDefaultValue(CursoEnum.NAO_INFORMADO);
            
            builder.Property(c => c.TurnoPeriodo)
                .HasDefaultValue(TurnoEnum.NAO_INFORMADO);
            
            builder.Property(c => c.EjaOcorrenciaDesistencia)
                .HasDefaultValue(AlunoLeitorOcorrenciaDesistenciaEnum.NENHUMA);
            

            builder
                .HasOne(x => x.Tenant)
                .WithMany(x => x.AlunosEja)
                .HasForeignKey(x => x.TenantId)
                .OnDelete(DeleteBehavior.SetNull);
                
            //Relacionamentos
            builder
                .HasOne(c => c.Aluno)
                .WithMany(c => c.AlunosEja)
                .HasForeignKey(c => c.AlunoId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasIndex(c => c.AlunoId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
            
            builder
                .HasIndex(c => c.TenantId)
                .IsUnique(false);
            
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}