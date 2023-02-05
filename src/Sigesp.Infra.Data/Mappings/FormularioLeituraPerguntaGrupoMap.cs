using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Models;

namespace Sigesp.Infra.Data.Mappings
{
    public class FormularioLeituraPerguntaGrupoMap : IEntityTypeConfiguration<FormularioLeituraPerguntaGrupo>
    {
        public void Configure(EntityTypeBuilder<FormularioLeituraPerguntaGrupo> builder)
        {
            builder.ToTable("FormularioLeituraPerguntasGrupos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.Nome)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(c => c.TenantId)
                .HasDefaultValue(new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"))
                .IsRequired();
            
            builder.HasQueryFilter(p => !p.IsDeleted);

            //Relacionamentos
            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.FormularioLeituraPerguntaGrupos)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);
                
            builder
                .HasIndex(x => x.TenantId)
                .IsUnique(false);

            builder
                .HasMany(c => c.FormularioLeituraPerguntas)
                .WithOne(c => c.FormularioLeituraPerguntaGrupo)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasData(
                new FormularioLeituraPerguntaGrupo
                {
                    Id = Guid.Parse("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    CreatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = Guid.Parse("1e526008-75f7-4a01-9942-d178f2b38888"),
                    Nome = "PERGUNTAS PARA CRONOGRAMA MAI/JUN"
                }
            );
        }
    }
}