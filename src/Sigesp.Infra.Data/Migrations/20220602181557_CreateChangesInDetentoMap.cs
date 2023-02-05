using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesInDetentoMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Detentos_Ipen",
                table: "Detentos");

            migrationBuilder.DropIndex(
                name: "IX_Detentos_MatriculaFamiliar",
                table: "Detentos");

            migrationBuilder.AlterColumn<int[]>(
                name: "AtividadesEducacionais",
                table: "Alunos",
                nullable: true,
                oldClrType: typeof(int[]),
                oldType: "integer[]");

            migrationBuilder.CreateIndex(
                name: "IX_Detentos_Ipen",
                table: "Detentos",
                column: "Ipen",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Detentos_MatriculaFamiliar",
                table: "Detentos",
                column: "MatriculaFamiliar",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Detentos_Ipen",
                table: "Detentos");

            migrationBuilder.DropIndex(
                name: "IX_Detentos_MatriculaFamiliar",
                table: "Detentos");

            migrationBuilder.AlterColumn<int[]>(
                name: "AtividadesEducacionais",
                table: "Alunos",
                type: "integer[]",
                nullable: false,
                oldClrType: typeof(int[]),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Detentos_Ipen",
                table: "Detentos",
                column: "Ipen",
                unique: true,
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_Detentos_MatriculaFamiliar",
                table: "Detentos",
                column: "MatriculaFamiliar",
                unique: true,
                filter: "\"IsDeleted\"='0'");
        }
    }
}
