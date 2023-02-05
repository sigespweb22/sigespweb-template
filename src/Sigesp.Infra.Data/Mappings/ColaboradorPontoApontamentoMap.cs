using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Models;

namespace Sigesp.Infra.Data.Mappings
{
    public class ColaboradorPontoApontamentoMap : IEntityTypeConfiguration<ColaboradorPontoApontamento>
    {
        public void Configure(EntityTypeBuilder<ColaboradorPontoApontamento> builder)
        {
            builder.ToTable("ColaboradoresPontosApontamentos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder
                .HasOne(c => c.ColaboradorPonto)
                .WithMany(c => c.ColaboradorPontoApontamentos)
                .HasForeignKey(c => c.ColaboradorPontoId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasIndex(c => c.ColaboradorPontoId)
                .HasFilter("\"IsDeleted\"=" + "\'" + 0 + "\'")
                .IsUnique(false);
            
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}