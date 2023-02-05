using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesContasCorrentes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "ContasCorrentes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "ContasCorrentes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "ContasCorrentes");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "ContasCorrentes");
        }
    }
}
