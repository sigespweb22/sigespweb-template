using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateEntityDetentoSaidaTemporaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "STPrevista",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "STRetornoPrevisto",
                table: "Detentos");

            migrationBuilder.CreateTable(
                name: "DetentoSaidasTemporaria",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    SaidaPrevista = table.Column<DateTime>(nullable: false),
                    RetornoPrevisto = table.Column<DateTime>(nullable: false),
                    DetentoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetentoSaidasTemporaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetentoSaidasTemporaria_Detentos_DetentoId",
                        column: x => x.DetentoId,
                        principalTable: "Detentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetentoSaidasTemporaria_DetentoId",
                table: "DetentoSaidasTemporaria",
                column: "DetentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetentoSaidasTemporaria");

            migrationBuilder.AddColumn<DateTime[]>(
                name: "STPrevista",
                table: "Detentos",
                type: "timestamp without time zone[]",
                nullable: true);

            migrationBuilder.AddColumn<DateTime[]>(
                name: "STRetornoPrevisto",
                table: "Detentos",
                type: "timestamp without time zone[]",
                nullable: true);
        }
    }
}
