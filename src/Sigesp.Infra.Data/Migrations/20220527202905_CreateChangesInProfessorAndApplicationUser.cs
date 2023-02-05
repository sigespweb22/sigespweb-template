using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesInProfessorAndApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Professores",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Galeria",
                table: "Professores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Professores_ApplicationUserId",
                table: "Professores",
                column: "ApplicationUserId",
                unique: true,
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_AspNetUsers_ApplicationUserId",
                table: "Professores",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_AspNetUsers_ApplicationUserId",
                table: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Professores_ApplicationUserId",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Galeria",
                table: "Professores");
        }
    }
}
