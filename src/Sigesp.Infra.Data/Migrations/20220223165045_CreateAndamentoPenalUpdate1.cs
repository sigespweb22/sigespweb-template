using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateAndamentoPenalUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AndamentoPenal_DetentoId",
                table: "AndamentoPenal");

            migrationBuilder.CreateIndex(
                name: "IX_AndamentoPenal_DetentoId",
                table: "AndamentoPenal",
                column: "DetentoId",
                unique: true,
                filter: "\"IsDeleted\"='0'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AndamentoPenal_DetentoId",
                table: "AndamentoPenal");

            migrationBuilder.CreateIndex(
                name: "IX_AndamentoPenal_DetentoId",
                table: "AndamentoPenal",
                column: "DetentoId");
        }
    }
}
