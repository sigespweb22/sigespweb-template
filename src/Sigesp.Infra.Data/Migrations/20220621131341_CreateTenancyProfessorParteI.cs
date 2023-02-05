using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateTenancyProfessorParteI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Professores",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Professores",
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
                values: new object[] { new DateTime(2022, 6, 21, 10, 13, 40, 446, DateTimeKind.Local).AddTicks(288), new DateTime(2022, 6, 21, 10, 13, 40, 446, DateTimeKind.Local).AddTicks(8344) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 21, 10, 13, 40, 446, DateTimeKind.Local).AddTicks(9456), new DateTime(2022, 6, 21, 10, 13, 40, 446, DateTimeKind.Local).AddTicks(9475) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 21, 10, 13, 40, 446, DateTimeKind.Local).AddTicks(9506), new DateTime(2022, 6, 21, 10, 13, 40, 446, DateTimeKind.Local).AddTicks(9508) });

            migrationBuilder.CreateIndex(
                name: "IX_Professores_Cpf",
                table: "Professores",
                column: "Cpf");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_TenantId",
                table: "Professores",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Tenants_TenantId",
                table: "Professores",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Tenants_TenantId",
                table: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Professores_Cpf",
                table: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Professores_TenantId",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Professores");

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
                values: new object[] { new DateTime(2022, 6, 21, 10, 3, 30, 645, DateTimeKind.Local).AddTicks(9554), new DateTime(2022, 6, 21, 10, 3, 30, 646, DateTimeKind.Local).AddTicks(7525) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 21, 10, 3, 30, 646, DateTimeKind.Local).AddTicks(8693), new DateTime(2022, 6, 21, 10, 3, 30, 646, DateTimeKind.Local).AddTicks(8712) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 6, 21, 10, 3, 30, 646, DateTimeKind.Local).AddTicks(8744), new DateTime(2022, 6, 21, 10, 3, 30, 646, DateTimeKind.Local).AddTicks(8747) });
        }
    }
}
