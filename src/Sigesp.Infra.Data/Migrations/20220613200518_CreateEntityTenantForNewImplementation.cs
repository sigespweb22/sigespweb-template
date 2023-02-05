using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateEntityTenantForNewImplementation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AlunosLeitores_AlunoId",
                table: "AlunosLeitores");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Detentos",
                nullable: false,
                defaultValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    ApiKey = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "ApiKey", "CreatedAt", "CreatedBy", "IsDeleted", "Nome", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"), new Guid("06b5fb02-57cb-126b-3ab2-a05f805f1e97"), new DateTime(2022, 6, 13, 17, 5, 17, 923, DateTimeKind.Local).AddTicks(306), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), false, "Tenância Master", new DateTime(2022, 6, 13, 17, 5, 17, 924, DateTimeKind.Local).AddTicks(789), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") });

            migrationBuilder.CreateIndex(
                name: "IX_Detentos_TenantId",
                table: "Detentos",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeitores_AlunoId",
                table: "AlunosLeitores",
                column: "AlunoId",
                unique: true,
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ApiKey",
                table: "Tenants",
                column: "ApiKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Detentos_Tenants_TenantId",
                table: "Detentos",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detentos_Tenants_TenantId",
                table: "Detentos");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Detentos_TenantId",
                table: "Detentos");

            migrationBuilder.DropIndex(
                name: "IX_AlunosLeitores_AlunoId",
                table: "AlunosLeitores");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Detentos");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLeitores_AlunoId",
                table: "AlunosLeitores",
                column: "AlunoId");
        }
    }
}
