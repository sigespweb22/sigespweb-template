using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateFieldsContaCorrente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaId",
                table: "ContasCorrentes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContasCorrentes_EmpresaId",
                table: "ContasCorrentes",
                column: "EmpresaId",
                unique: true,
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.AddForeignKey(
                name: "FK_ContasCorrentes_Empresas_EmpresaId",
                table: "ContasCorrentes",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContasCorrentes_Empresas_EmpresaId",
                table: "ContasCorrentes");

            migrationBuilder.DropIndex(
                name: "IX_ContasCorrentes_EmpresaId",
                table: "ContasCorrentes");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "ContasCorrentes");
        }
    }
}
