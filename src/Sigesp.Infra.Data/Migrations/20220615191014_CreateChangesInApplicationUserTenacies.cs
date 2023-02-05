using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesInApplicationUserTenacies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMultiTenant",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "1e526008-75f7-4a01-9942-d178f2b38888",
                columns: new[] { "IsMultiTenant", "TenantId" },
                values: new object[] { true, new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "IsMultiTenant", "TenantId" },
                values: new object[] { true, new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4") });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 15, 16, 10, 13, 922, DateTimeKind.Local).AddTicks(3838), new DateTime(2022, 6, 15, 16, 10, 13, 923, DateTimeKind.Local).AddTicks(1259) });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "ApiKey", "CreatedAt", "CreatedBy", "IsDeleted", "Nome", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"), new Guid("bed67d28-49f5-4496-9d32-334cba103736"), new DateTime(2022, 6, 15, 16, 10, 13, 923, DateTimeKind.Local).AddTicks(2290), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), false, "Tenância Presídio Regional de Criciúma", new DateTime(2022, 6, 15, 16, 10, 13, 923, DateTimeKind.Local).AddTicks(2308), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") },
                    { new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"), new Guid("f2068a0f-2e70-47e2-a528-a54fececd877"), new DateTime(2022, 6, 15, 16, 10, 13, 923, DateTimeKind.Local).AddTicks(2335), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), false, "Tenância Penitenciária Sul", new DateTime(2022, 6, 15, 16, 10, 13, 923, DateTimeKind.Local).AddTicks(2337), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TenantId",
                table: "AspNetUsers",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tenants_TenantId",
                table: "AspNetUsers",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tenants_TenantId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TenantId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"));

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"));

            migrationBuilder.DropColumn(
                name: "IsMultiTenant",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 13, 17, 5, 17, 923, DateTimeKind.Local).AddTicks(306), new DateTime(2022, 6, 13, 17, 5, 17, 924, DateTimeKind.Local).AddTicks(789) });
        }
    }
}
