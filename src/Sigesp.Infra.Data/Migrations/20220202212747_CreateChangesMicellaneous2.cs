using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesMicellaneous2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desconto",
                table: "Lancamentos");

            migrationBuilder.DropColumn(
                name: "ValorBruto",
                table: "Lancamentos");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodoDataInicio",
                table: "Lancamentos",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodoDataFim",
                table: "Lancamentos",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Responsavel",
                table: "EmpresasConvenios",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsRenovacaoAutomatica",
                table: "EmpresasConvenios",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "Cep",
                table: "Empresas",
                maxLength: 8,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 8);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PeriodoDataInicio",
                table: "Lancamentos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PeriodoDataFim",
                table: "Lancamentos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Desconto",
                table: "Lancamentos",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorBruto",
                table: "Lancamentos",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Responsavel",
                table: "EmpresasConvenios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsRenovacaoAutomatica",
                table: "EmpresasConvenios",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Cep",
                table: "Empresas",
                type: "integer",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 8,
                oldDefaultValue: 0);
        }
    }
}
