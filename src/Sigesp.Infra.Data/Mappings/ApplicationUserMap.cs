using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace Sigesp.Infra.Data.Mappings
{
    public class ApplicationUserMap : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("UserId");

            builder
                .HasOne(c => c.ContaUsuario)
                .WithOne(d => d.ApplicationUser)
                .HasForeignKey<ContaUsuario>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasMany(c => c.ApplicationUserRoles)
                .WithOne(d => d.ApplicationUser)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            
            builder
                .HasMany(c => c.ApplicationUserClaims)
                .WithOne()
                .HasForeignKey(c => c.UserId)
                .IsRequired();
            
            builder
                .HasOne(c => c.Tenant)
                .WithMany(c => c.ApplicationUsers)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(c => c.TenantId)
                .HasDefaultValue(new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    ConcurrencyStamp = "ca431822-360a-4ee6-b978-66564d429fc7",
                    SecurityStamp = "c9514850-61dd-4cc1-b909-88b79b035643",
                    PasswordHash = "AQAAAAEAACcQAAAAEFGbgHKOKiDDs5fvXN8kHviorntHToMKurnVJNmsFQNInxhQOyZTwJ2w0SpbyCdZbA==",
                    TenantId = Guid.Parse("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                    IsMultiTenant = true
                },
                new ApplicationUser
                {
                    Id = "1e526008-75f7-4a01-9942-d178f2b38888", // primary key
                    UserName = "sistema@gmail.com",
                    NormalizedUserName = "SISTEMA@GMAIL.COM",
                    ConcurrencyStamp = "e627e3a3-d53a-4fc9-a87c-32e9ce8e1218",
                    SecurityStamp = "e90e63a1-e27d-4394-aa4f-3e2b0bbb9f90",
                    PasswordHash = "AQAAAAEAACcQAAAAEIW3u0VBTe5BgtXxXDBTs9pxnSdIslsYrAK8y9P4a3S6pT1cmvrWZMX6owmy7TmeAA==",
                    TenantId = Guid.Parse("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                    IsMultiTenant = true
                }
            );
        }
    }
}