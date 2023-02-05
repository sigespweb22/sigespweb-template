using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesForChaveLeitura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdSequencial",
                table: "AlunosLeituras");

            migrationBuilder.AddColumn<long>(
                name: "ChaveLeitura",
                table: "AlunosLeituras",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChaveLeitura",
                table: "AlunosLeituras");

            migrationBuilder.AddColumn<long>(
                name: "IdSequencial",
                table: "AlunosLeituras",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
