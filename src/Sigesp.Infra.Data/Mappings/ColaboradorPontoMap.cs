using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Models;

namespace Sigesp.Infra.Data.Mappings
{
    public class ColaboradorPontoMap : IEntityTypeConfiguration<ColaboradorPonto>
    {
        public void Configure(EntityTypeBuilder<ColaboradorPonto> builder)
        {
            builder.ToTable("ColaboradoresPontos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.PeriodoReferencia)
                .HasMaxLength(9)
                .IsRequired(false);
            
            builder
                .HasOne(c => c.Colaborador)
                .WithMany(c => c.Pontos)
                .HasForeignKey(c => c.ColaboradorId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasOne(c => c.Colaborador)
                .WithMany(c => c.Pontos)
                .HasForeignKey(c => c.ColaboradorId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasOne(c => c.Edi)
                .WithMany(c => c.ColaboradoresPonto)
                .HasForeignKey(c => c.EdiId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasOne(c => c.EmpresaConvenio)
                .WithMany(c => c.ColaboradoresPonto)
                .HasForeignKey(c => c.EmpresaConvenioId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasMany(c => c.ColaboradorPontoApontamentos)
                .WithOne(c => c.ColaboradorPonto)
                .HasForeignKey(c => c.ColaboradorPontoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(c => c.ColaboradorId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
            
            builder
                .HasIndex(c => c.EdiId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);

            builder
                .HasIndex(c => c.EmpresaConvenioId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);

            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
    
}