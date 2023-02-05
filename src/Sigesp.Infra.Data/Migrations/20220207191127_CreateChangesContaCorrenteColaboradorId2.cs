using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesContaCorrenteColaboradorId2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContasCorrentes_ColaboradorId",
                table: "ContasCorrentes");

            migrationBuilder.CreateIndex(
                name: "IX_ContasCorrentes_ColaboradorId",
                table: "ContasCorrentes",
                column: "ColaboradorId",
                unique: true,
                filter: "\"IsDeleted\"='0'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContasCorrentes_ColaboradorId",
                table: "ContasCorrentes");

            migrationBuilder.CreateIndex(
                name: "IX_ContasCorrentes_ColaboradorId",
                table: "ContasCorrentes",
                column: "ColaboradorId",
                filter: "\"IsDeleted\"='0'");
        }
    }
}
