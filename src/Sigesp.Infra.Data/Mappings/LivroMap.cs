using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Mappings
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livros");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Titulo)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.Localizacao)
                .IsRequired();
            
            builder.Property(c => c.Propriedade)
                .HasMaxLength(255)
                .IsRequired();

            //Relacionamentos
            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.Livros)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .Property(c => c.TenantId)  
                .HasDefaultValue(new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            builder
                .HasOne(c => c.LivroAutor)
                .WithMany(c => c.Livros)
                .HasForeignKey(c => c.LivroAutorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(c => c.LivroGenero)
                .WithMany(c => c.Livros)
                .HasForeignKey(c => c.LivroGeneroId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            builder
                .HasIndex(c => c.LivroAutorId)
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