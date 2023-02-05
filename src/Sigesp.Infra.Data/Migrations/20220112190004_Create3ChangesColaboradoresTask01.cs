using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class Create3ChangesColaboradoresTask01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Colaboradores_DetentoId",
                table: "Colaboradores");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_DetentoId",
                table: "Colaboradores",
                column: "DetentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Colaboradores_DetentoId",
                table: "Colaboradores");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_DetentoId",
                table: "Colaboradores",
                column: "DetentoId",
                filter: "\"IsDeleted\"='0'");
        }
    }
}
