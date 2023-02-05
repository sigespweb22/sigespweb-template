using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateFielsdsEnderecoTelefoneInAndamentoPenal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnderecoCompleto",
                table: "AndamentoPenal",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "AndamentoPenal",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnderecoCompleto",
                table: "AndamentoPenal");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "AndamentoPenal");
        }
    }
}
