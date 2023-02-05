using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateColaboradorPontoColaboradorPontoApontamentoUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorPonto_Colaboradores_ColaboradorId",
                table: "ColaboradorPonto");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorPonto_Edis_EdiId",
                table: "ColaboradorPonto");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorPonto_EmpresasConvenios_EmpresaConvenioId",
                table: "ColaboradorPonto");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorPontoApontamento_ColaboradorPonto_ColaboradorPon~",
                table: "ColaboradorPontoApontamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColaboradorPontoApontamento",
                table: "ColaboradorPontoApontamento");

            migrationBuilder.DropIndex(
                name: "IX_ColaboradorPontoApontamento_ColaboradorPontoId",
                table: "ColaboradorPontoApontamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColaboradorPonto",
                table: "ColaboradorPonto");

            migrationBuilder.DropIndex(
                name: "IX_ColaboradorPonto_ColaboradorId",
                table: "ColaboradorPonto");

            migrationBuilder.DropIndex(
                name: "IX_ColaboradorPonto_EdiId",
                table: "ColaboradorPonto");

            migrationBuilder.DropIndex(
                name: "IX_ColaboradorPonto_EmpresaConvenioId",
                table: "ColaboradorPonto");

            migrationBuilder.RenameTable(
                name: "ColaboradorPontoApontamento",
                newName: "ColaboradoresPontosApontamentos");

            migrationBuilder.RenameTable(
                name: "ColaboradorPonto",
                newName: "ColaboradoresPontos");

            migrationBuilder.AlterColumn<string>(
                name: "PeriodoReferencia",
                table: "ColaboradoresPontos",
                maxLength: 9,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColaboradoresPontosApontamentos",
                table: "ColaboradoresPontosApontamentos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColaboradoresPontos",
                table: "ColaboradoresPontos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradoresPontosApontamentos_ColaboradorPontoId",
                table: "ColaboradoresPontosApontamentos",
                column: "ColaboradorPontoId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradoresPontos_ColaboradorId",
                table: "ColaboradoresPontos",
                column: "ColaboradorId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradoresPontos_EdiId",
                table: "ColaboradoresPontos",
                column: "EdiId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradoresPontos_EmpresaConvenioId",
                table: "ColaboradoresPontos",
                column: "EmpresaConvenioId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradoresPontos_Colaboradores_ColaboradorId",
                table: "ColaboradoresPontos",
                column: "ColaboradorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradoresPontos_Edis_EdiId",
                table: "ColaboradoresPontos",
                column: "EdiId",
                principalTable: "Edis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradoresPontos_EmpresasConvenios_EmpresaConvenioId",
                table: "ColaboradoresPontos",
                column: "EmpresaConvenioId",
                principalTable: "EmpresasConvenios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradoresPontosApontamentos_ColaboradoresPontos_Colabor~",
                table: "ColaboradoresPontosApontamentos",
                column: "ColaboradorPontoId",
                principalTable: "ColaboradoresPontos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradoresPontos_Colaboradores_ColaboradorId",
                table: "ColaboradoresPontos");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradoresPontos_Edis_EdiId",
                table: "ColaboradoresPontos");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradoresPontos_EmpresasConvenios_EmpresaConvenioId",
                table: "ColaboradoresPontos");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradoresPontosApontamentos_ColaboradoresPontos_Colabor~",
                table: "ColaboradoresPontosApontamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColaboradoresPontosApontamentos",
                table: "ColaboradoresPontosApontamentos");

            migrationBuilder.DropIndex(
                name: "IX_ColaboradoresPontosApontamentos_ColaboradorPontoId",
                table: "ColaboradoresPontosApontamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColaboradoresPontos",
                table: "ColaboradoresPontos");

            migrationBuilder.DropIndex(
                name: "IX_ColaboradoresPontos_ColaboradorId",
                table: "ColaboradoresPontos");

            migrationBuilder.DropIndex(
                name: "IX_ColaboradoresPontos_EdiId",
                table: "ColaboradoresPontos");

            migrationBuilder.DropIndex(
                name: "IX_ColaboradoresPontos_EmpresaConvenioId",
                table: "ColaboradoresPontos");

            migrationBuilder.RenameTable(
                name: "ColaboradoresPontosApontamentos",
                newName: "ColaboradorPontoApontamento");

            migrationBuilder.RenameTable(
                name: "ColaboradoresPontos",
                newName: "ColaboradorPonto");

            migrationBuilder.AlterColumn<string>(
                name: "PeriodoReferencia",
                table: "ColaboradorPonto",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 9,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColaboradorPontoApontamento",
                table: "ColaboradorPontoApontamento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColaboradorPonto",
                table: "ColaboradorPonto",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorPontoApontamento_ColaboradorPontoId",
                table: "ColaboradorPontoApontamento",
                column: "ColaboradorPontoId");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorPonto_ColaboradorId",
                table: "ColaboradorPonto",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorPonto_EdiId",
                table: "ColaboradorPonto",
                column: "EdiId");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorPonto_EmpresaConvenioId",
                table: "ColaboradorPonto",
                column: "EmpresaConvenioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorPonto_Colaboradores_ColaboradorId",
                table: "ColaboradorPonto",
                column: "ColaboradorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorPonto_Edis_EdiId",
                table: "ColaboradorPonto",
                column: "EdiId",
                principalTable: "Edis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorPonto_EmpresasConvenios_EmpresaConvenioId",
                table: "ColaboradorPonto",
                column: "EmpresaConvenioId",
                principalTable: "EmpresasConvenios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorPontoApontamento_ColaboradorPonto_ColaboradorPon~",
                table: "ColaboradorPontoApontamento",
                column: "ColaboradorPontoId",
                principalTable: "ColaboradorPonto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
