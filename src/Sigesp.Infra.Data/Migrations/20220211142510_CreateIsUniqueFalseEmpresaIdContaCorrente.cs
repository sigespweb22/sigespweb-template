using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateIsUniqueFalseEmpresaIdContaCorrente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContasCorrentes_EmpresaId",
                table: "ContasCorrentes");

            migrationBuilder.CreateIndex(
                name: "IX_ContasCorrentes_EmpresaId",
                table: "ContasCorrentes",
                column: "EmpresaId",
                filter: "\"IsDeleted\"='0'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContasCorrentes_EmpresaId",
                table: "ContasCorrentes");

            migrationBuilder.CreateIndex(
                name: "IX_ContasCorrentes_EmpresaId",
                table: "ContasCorrentes",
                column: "EmpresaId",
                unique: true,
                filter: "\"IsDeleted\"='0'");
        }
    }
}
