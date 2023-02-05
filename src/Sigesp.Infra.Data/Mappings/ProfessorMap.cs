using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professores");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .HasMaxLength(255)
                .IsRequired();
            
            builder.Property(c => c.Cpf)
                .IsRequired(false)
                .HasMaxLength(11);
            
            builder
                .HasIndex(c => c.Cpf)
                .IsUnique();
            
            builder
                .Property(c => c.ApplicationUserId)
                .IsRequired();
                
            //Relacionamentos

            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.Professores)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(c => c.TenantId)
                .HasDefaultValue(new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"))
                .IsRequired();
            
            builder
                .HasOne(c => c.ApplicationUser)
                .WithOne(c => c.Professor)
                .HasForeignKey<Professor>(c => c.ApplicationUserId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasIndex(c => c.ApplicationUserId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique();
            
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}