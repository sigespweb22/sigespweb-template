using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateTenancyForLivrosAlunos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Livros",
                nullable: false,
                defaultValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Alunos",
                nullable: false,
                defaultValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "1e526008-75f7-4a01-9942-d178f2b38888",
                column: "TenantId",
                value: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "TenantId",
                value: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 16, 16, 48, 5, 944, DateTimeKind.Local).AddTicks(3651), new DateTime(2022, 6, 16, 16, 48, 5, 945, DateTimeKind.Local).AddTicks(1249) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 16, 16, 48, 5, 945, DateTimeKind.Local).AddTicks(2383), new DateTime(2022, 6, 16, 16, 48, 5, 945, DateTimeKind.Local).AddTicks(2401) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 16, 16, 48, 5, 945, DateTimeKind.Local).AddTicks(2429), new DateTime(2022, 6, 16, 16, 48, 5, 945, DateTimeKind.Local).AddTicks(2431) });

            migrationBuilder.CreateIndex(
                name: "IX_Livros_TenantId",
                table: "Livros",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TenantId",
                table: "Alunos",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Tenants_TenantId",
                table: "Alunos",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Tenants_TenantId",
                table: "Livros",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Tenants_TenantId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Tenants_TenantId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_TenantId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TenantId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Alunos");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "1e526008-75f7-4a01-9942-d178f2b38888",
                column: "TenantId",
                value: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "TenantId",
                value: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 16, 15, 2, 25, 738, DateTimeKind.Local).AddTicks(1290), new DateTime(2022, 6, 16, 15, 2, 25, 738, DateTimeKind.Local).AddTicks(9488) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 16, 15, 2, 25, 739, DateTimeKind.Local).AddTicks(595), new DateTime(2022, 6, 16, 15, 2, 25, 739, DateTimeKind.Local).AddTicks(615) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 16, 15, 2, 25, 739, DateTimeKind.Local).AddTicks(646), new DateTime(2022, 6, 16, 15, 2, 25, 739, DateTimeKind.Local).AddTicks(648) });
        }
    }
}
