using System;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sigesp.Infra.Data.Mappings
{
    public class ApplicationRoleMap : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder
                .HasMany(c => c.ApplicationUserRoles)
                .WithOne(d => d.ApplicationRole)
                .HasForeignKey(c => c.RoleId)
                .IsRequired();

            //Seeding a  'Administrator' role to AspNetRoles table
            builder.HasData(
                new ApplicationRole
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", ConcurrencyStamp = "da8e4f70-8be9-4d8f-a684-5b97f19d252c", Name = "Master", NormalizedName = "MASTER".ToUpper() 
                },
                new ApplicationRole 
                {
                    Id = "b3a5b61d-7ff4-43cb-bad4-a945b150fc72", ConcurrencyStamp = "194c8eaf-4f2e-4d0e-9b45-ab664a763c1e", Name = "Usuarios_Todos", NormalizedName = "USUARIOS_TODOS".ToUpper() 
                },
                new ApplicationRole
                {
                    Id = "ef60969b-dc27-44dc-b0a8-3c03a522ec64", ConcurrencyStamp = "434a6e92-e432-430c-9587-36656d74f85c", Name = "Dashboard_Todos", NormalizedName = "DASHBOARD_TODOS".ToUpper() 
                },
                new ApplicationRole
                {
                    Id = "99f6b971-2602-4afb-a9cb-1cec1e7d16fd", ConcurrencyStamp = "f82753c8-86ab-4ee8-85e7-19b357d03eda", Name = "Detentos_Todos", NormalizedName = "DETENTOS_TODOS".ToUpper() 
                },
                new ApplicationRole 
                {
                    Id = "6d8717fd-2ef7-4b01-9302-a5b6e083e0e7", ConcurrencyStamp = "5450a7ae-ed7e-4b72-83b8-945104beed34", Name = "Empresas_Todos", NormalizedName = "EMPRESAS_TODOS".ToUpper() 
                },
                new ApplicationRole
                {
                    Id = "47d047d6-e7c6-409e-b53c-a9dc66004354", ConcurrencyStamp = "714f94eb-9d78-4e76-a03a-68ac6b5cdab1", Name = "Empresas-Convenios_Todos", NormalizedName = "EMPRESAS-CONVENIOS_TODOS".ToUpper() 
                },
                new ApplicationRole
                {
                    Id = "e2c6ef91-aa5a-4f30-857c-bd94db0ab240", ConcurrencyStamp = "a709e158-cc19-4db2-8bdb-750e5b3d727f", Name = "Colaboradores_Todos", NormalizedName = "COLABORADORES_TODOS".ToUpper() 
                },
                new ApplicationRole
                {
                    Id = "96a403a0-28c8-47f2-91e8-0f9df2da00c6", ConcurrencyStamp = "313479a6-94f2-4612-83da-b0850e0ad00e", Name = "Colaboradores_Relatorios", NormalizedName = "COLABORADORES_RELATORIOS".ToUpper() 
                },
                new ApplicationRole
                {
                    Id = "d9db904b-aee9-4474-9301-e731e7c79cbe", ConcurrencyStamp = "75966e0f-7709-40f4-9e76-938fbe188dd1", Name = "Lancamentos_Todos", NormalizedName = "LANCAMENTOS_TODOS".ToUpper() 
                },                
                new ApplicationRole
                {
                    Id = "e86df548-3cd5-4a3f-b82e-78842186f8d2", ConcurrencyStamp = "8e9bdf9b-04a5-452b-9269-208c99a17f2a", Name = "Contas-Correntes_Todos", NormalizedName = "CONTAS-CORRENTES_TODOS".ToUpper() 
                },
                new ApplicationRole
                {
                    Id = "dc50c49f-3cef-4dbe-83bb-5f1916ac8854", ConcurrencyStamp = "c98d36df-14df-4cda-ae90-61b30dc86a70", Name = "Contas-Correntes_Relatorios", NormalizedName = "CONTAS-CORRENTES_RELATORIOS".ToUpper() 
                },
                new ApplicationRole
                {
                    Id = "92c72070-3275-49e6-bd4a-f6c8e565b5bc", ConcurrencyStamp = "610041f7-1332-4769-8d11-7c92b7e90cb1", Name = "Edis_Todos", NormalizedName = "EDIS_TODOS".ToUpper() 
                },
                new ApplicationRole
                {
                    Id = "e060a6d2-6472-4294-9f68-22bd114867f9", ConcurrencyStamp = "77ea2caa-69a2-4ae4-bf76-cf87d8cef7f6", Name = "Andamento-Penal_Todos", NormalizedName = "ANDAMENTO-PENAL_TODOS".ToUpper() 
                },
                new ApplicationRole
                {
                    Id = "e6b7ff49-350c-4b89-a533-9eb923d8ba1b", ConcurrencyStamp = "0421080e-e52e-4337-a0e0-3630f83bb58d", Name = "Template", NormalizedName = "TEMPLATE".ToUpper() 
                },
                new ApplicationRole
                {
                    Id = "ba56983e-f96f-4009-afe1-96586b830a93", ConcurrencyStamp = "729acc13-9d1a-436b-bcea-2d0231b09c38", Name = "Usuarios_Perfil", NormalizedName = "USUARIOS_PERFIL".ToUpper() 
                },
                new ApplicationRole
                {
                    Id = "429b409b-b8b3-4410-8e0a-ad36b4f1a554", ConcurrencyStamp = "79729e9c-ca38-4de7-bf1b-e30e778c4def", Name = "Lista-Amarela_Todos", NormalizedName = "LISTA-AMARELA_TODOS".ToUpper() 
                },
                new ApplicationRole
                {
                    Id = "2238a399-29e0-4b50-971a-e42bf0dfb219", ConcurrencyStamp = "6b2bb02e-96e4-448a-855f-f480cd110f9f", Name = "Sequencias-Oficios_Todos", NormalizedName = "SEQUENCIAS-OFICIOS_TODOS".ToUpper() 
                }
            );
        }
    }
}