using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigesp.Domain.Models;

namespace Sigesp.Infra.Data.Mappings
{
    public class ApplicationUserRoleMap : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            //Seeding the relation between our user and role to AspNetUserRoles table
            builder.HasData(
                //ROLES USER ADM

                //ROLE MASTER
                new ApplicationUserRole
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                },
                //ROLE TEMPLATE
                new ApplicationUserRole
                {
                    RoleId = "e6b7ff49-350c-4b89-a533-9eb923d8ba1b",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                },

                //ROLES USER SISTEMA
                //ROLE MASTER
                new ApplicationUserRole
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "1e526008-75f7-4a01-9942-d178f2b38888"
                }              
            );
        }
    }
}