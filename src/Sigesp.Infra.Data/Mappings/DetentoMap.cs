using System.Reflection.Emit;
using System.Collections.Immutable;
using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class DetentoMap : IEntityTypeConfiguration<Detento>
    {
        public void Configure(EntityTypeBuilder<Detento> builder)
        {
            builder.ToTable("Detentos");

            builder
                .HasKey(c => c.Id);

            builder.Property(c => c.Ipen)
                .HasMaxLength(6)
                .IsRequired();

            builder
                .HasIndex(c => c.Ipen)
                .IsUnique();
            
            builder.Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Galeria)
                .IsRequired(false)
                .HasMaxLength(2);   

            builder.Property(c => c.Cela)
                .HasDefaultValue(0)
                .HasMaxLength(2);

            builder.Property(c => c.Cep)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(c => c.Rg)
                .IsRequired(false)
                .HasDefaultValue(null);
            
            builder.Property(c => c.Cpf)
                .IsRequired(false)
                .HasDefaultValue(null)
                .HasMaxLength(11);

            builder.Property(c => c.Pec)
                .IsRequired(false)
                .HasDefaultValue(null);

            builder.Property(c => c.NomeFamiliar)
                .IsRequired(false)
                .HasDefaultValue(null);

            builder.Property(c => c.IsProvisorio)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(c => c.IsSaidaTemporaria)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(c => c.Regime)
                .HasDefaultValue(DetentoRegimeEnum.NENHUM);
            
            builder.Property(c => c.MatriculaFamiliar)
                .IsRequired(false)
                .HasMaxLength(6)
                .IsRequired();
            
            builder.Property(c => c.TransferenciaLocal)
                .IsRequired(false);
            
            builder.Property(c => c.TransferenciaTipo)
                .HasDefaultValue(TransferenciaTipoEnum.NENHUM);

            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.Detentos)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(c => c.TenantId)
                .HasDefaultValue(new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"))
                .IsRequired();

            builder
                .HasMany(c => c.Colaboradores)
                .WithOne(c => c.Detento)
                .HasForeignKey(c => c.DetentoId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(c => c.AndamentoPenal)
                .WithOne(c => c.Detento)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(c => c.ListaAmarela)
                .WithOne(c => c.Detento)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(c => c.Aluno)
                .WithOne(c => c.Detento)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasIndex(c => c.MatriculaFamiliar)
                .IsUnique(false);
 
            builder.HasIndex(x => x.Ipen)
                .IsUnique();

            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}