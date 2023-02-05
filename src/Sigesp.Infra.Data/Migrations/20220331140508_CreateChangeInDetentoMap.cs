using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangeInDetentoMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Detentos_DetentoId",
                table: "Alunos");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Detentos_DetentoId",
                table: "Alunos",
                column: "DetentoId",
                principalTable: "Detentos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Detentos_DetentoId",
                table: "Alunos");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Detentos_DetentoId",
                table: "Alunos",
                column: "DetentoId",
                principalTable: "Detentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
