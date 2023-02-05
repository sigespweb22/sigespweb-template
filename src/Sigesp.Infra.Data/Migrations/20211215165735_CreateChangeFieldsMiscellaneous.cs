using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangeFieldsMiscellaneous : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Situacao",
                table: "Detentos",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "IsSaidaTemporaria",
                table: "Detentos",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsProvisorio",
                table: "Detentos",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "Cela",
                table: "Detentos",
                maxLength: 2,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "LocalTrabalho",
                table: "Colaboradores",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiaPagamento",
                table: "Colaboradores",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "DescontoOutro",
                table: "Colaboradores",
                type: "decimal(4,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Desconto",
                table: "Colaboradores",
                type: "decimal(4,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)");

            migrationBuilder.AlterColumn<int>(
                name: "BancoNumero",
                table: "Colaboradores",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 25);

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "TipoConta", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2021, 12, 15, 13, 57, 34, 234, DateTimeKind.Local).AddTicks(7623), new DateTime(2021, 12, 15, 13, 57, 34, 234, DateTimeKind.Local).AddTicks(7449), 25m, 33m, 5, "Fábrica do conveniado", 3, new DateTime(2021, 12, 15, 13, 57, 34, 234, DateTimeKind.Local).AddTicks(7627) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "BancoNumero", "CreatedAt", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DiaPagamento", "LocalTrabalho", "TipoConta", "UpdatedAt" },
                values: new object[] { 341, new DateTime(2021, 12, 15, 13, 57, 34, 234, DateTimeKind.Local).AddTicks(7245), new DateTime(2021, 12, 15, 13, 57, 34, 234, DateTimeKind.Local).AddTicks(1490), 25m, 33m, 10, "GALERIA", 2, new DateTime(2021, 12, 15, 13, 57, 34, 234, DateTimeKind.Local).AddTicks(7255) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "Funcao", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 212, DateTimeKind.Local).AddTicks(8203), "CHEFE_LABORAL", new DateTime(2021, 12, 15, 13, 57, 34, 212, DateTimeKind.Local).AddTicks(8232) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 211, DateTimeKind.Local).AddTicks(6841), new DateTime(2021, 12, 15, 13, 57, 34, 212, DateTimeKind.Local).AddTicks(7064) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 238, DateTimeKind.Local).AddTicks(6361), new DateTime(2021, 12, 15, 13, 57, 34, 238, DateTimeKind.Local).AddTicks(6342), new DateTime(2021, 12, 15, 13, 57, 34, 238, DateTimeKind.Local).AddTicks(6365) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 238, DateTimeKind.Local).AddTicks(5907), new DateTime(2021, 12, 15, 13, 57, 34, 238, DateTimeKind.Local).AddTicks(5200), new DateTime(2021, 12, 15, 13, 57, 34, 238, DateTimeKind.Local).AddTicks(5922) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "Cela", "CreatedAt", "IsSaidaTemporaria", "NomeFamiliar", "Situacao", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2021, 12, 15, 13, 57, 34, 219, DateTimeKind.Local).AddTicks(7565), true, "Maria de Lourdes", 7, new DateTime(2021, 12, 15, 13, 57, 34, 219, DateTimeKind.Local).AddTicks(7600) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "Cela", "CreatedAt", "IsProvisorio", "NomeFamiliar", "Situacao", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2021, 12, 15, 13, 57, 34, 219, DateTimeKind.Local).AddTicks(7714), true, "Carlos Amarildo de Souza", 8, new DateTime(2021, 12, 15, 13, 57, 34, 219, DateTimeKind.Local).AddTicks(7717) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 224, DateTimeKind.Local).AddTicks(7844), new DateTime(2021, 12, 15, 13, 57, 34, 224, DateTimeKind.Local).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 224, DateTimeKind.Local).AddTicks(8070), new DateTime(2021, 12, 15, 13, 57, 34, 224, DateTimeKind.Local).AddTicks(8074) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 228, DateTimeKind.Local).AddTicks(5051), new DateTime(2021, 12, 15, 13, 57, 34, 228, DateTimeKind.Local).AddTicks(3365), new DateTime(2021, 12, 15, 13, 57, 34, 228, DateTimeKind.Local).AddTicks(2968), new DateTime(2021, 12, 15, 13, 57, 34, 228, DateTimeKind.Local).AddTicks(5067) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 228, DateTimeKind.Local).AddTicks(5116), new DateTime(2021, 12, 15, 13, 57, 34, 228, DateTimeKind.Local).AddTicks(5107) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 241, DateTimeKind.Local).AddTicks(3417), new DateTime(2021, 12, 15, 13, 57, 34, 240, DateTimeKind.Local).AddTicks(9995), new DateTime(2021, 12, 15, 13, 57, 34, 241, DateTimeKind.Local).AddTicks(2102), new DateTime(2021, 12, 15, 13, 57, 34, 241, DateTimeKind.Local).AddTicks(3436) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 15, 13, 57, 34, 241, DateTimeKind.Local).AddTicks(3930), new DateTime(2021, 12, 15, 13, 57, 34, 241, DateTimeKind.Local).AddTicks(3794), new DateTime(2021, 12, 15, 13, 57, 34, 241, DateTimeKind.Local).AddTicks(3896), new DateTime(2021, 12, 15, 13, 57, 34, 241, DateTimeKind.Local).AddTicks(3933) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Situacao",
                table: "Detentos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsSaidaTemporaria",
                table: "Detentos",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsProvisorio",
                table: "Detentos",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Cela",
                table: "Detentos",
                type: "integer",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 2,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LocalTrabalho",
                table: "Colaboradores",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiaPagamento",
                table: "Colaboradores",
                type: "integer",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "DescontoOutro",
                table: "Colaboradores",
                type: "decimal(4,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Desconto",
                table: "Colaboradores",
                type: "decimal(4,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)");

            migrationBuilder.AlterColumn<int>(
                name: "BancoNumero",
                table: "Colaboradores",
                type: "integer",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 25);

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "TipoConta", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 203, DateTimeKind.Local).AddTicks(8150), new DateTime(2021, 12, 13, 10, 57, 56, 203, DateTimeKind.Local).AddTicks(7974), 3, new DateTime(2021, 12, 13, 10, 57, 56, 203, DateTimeKind.Local).AddTicks(8154) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "TipoConta", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 203, DateTimeKind.Local).AddTicks(7916), new DateTime(2021, 12, 13, 10, 57, 56, 203, DateTimeKind.Local).AddTicks(2676), 2, new DateTime(2021, 12, 13, 10, 57, 56, 203, DateTimeKind.Local).AddTicks(7926) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("4ec0a5df-0807-468b-a874-5c8017d6e737"),
                columns: new[] { "CreatedAt", "Funcao", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 183, DateTimeKind.Local).AddTicks(3390), "CHEFE_PECULIO", new DateTime(2021, 12, 13, 10, 57, 56, 183, DateTimeKind.Local).AddTicks(3413) });

            migrationBuilder.UpdateData(
                table: "ContaUsuarios",
                keyColumn: "Id",
                keyValue: new Guid("cdf3d102-b621-46ff-ae30-bc9bab859ceb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 182, DateTimeKind.Local).AddTicks(1639), new DateTime(2021, 12, 13, 10, 57, 56, 183, DateTimeKind.Local).AddTicks(2238) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 207, DateTimeKind.Local).AddTicks(970), new DateTime(2021, 12, 13, 10, 57, 56, 207, DateTimeKind.Local).AddTicks(949), new DateTime(2021, 12, 13, 10, 57, 56, 207, DateTimeKind.Local).AddTicks(975) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 207, DateTimeKind.Local).AddTicks(518), new DateTime(2021, 12, 13, 10, 57, 56, 206, DateTimeKind.Local).AddTicks(9799), new DateTime(2021, 12, 13, 10, 57, 56, 207, DateTimeKind.Local).AddTicks(533) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 190, DateTimeKind.Local).AddTicks(481), "Maria de Lourdes", new DateTime(2021, 12, 13, 10, 57, 56, 190, DateTimeKind.Local).AddTicks(516) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 190, DateTimeKind.Local).AddTicks(624), "Carlos Amarildo de Souza", new DateTime(2021, 12, 13, 10, 57, 56, 190, DateTimeKind.Local).AddTicks(628) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 194, DateTimeKind.Local).AddTicks(1683), new DateTime(2021, 12, 13, 10, 57, 56, 194, DateTimeKind.Local).AddTicks(1722) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 194, DateTimeKind.Local).AddTicks(1884), new DateTime(2021, 12, 13, 10, 57, 56, 194, DateTimeKind.Local).AddTicks(1889) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 197, DateTimeKind.Local).AddTicks(9487), new DateTime(2021, 12, 13, 10, 57, 56, 197, DateTimeKind.Local).AddTicks(7825), new DateTime(2021, 12, 13, 10, 57, 56, 197, DateTimeKind.Local).AddTicks(7428), new DateTime(2021, 12, 13, 10, 57, 56, 197, DateTimeKind.Local).AddTicks(9501) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 197, DateTimeKind.Local).AddTicks(9548), new DateTime(2021, 12, 13, 10, 57, 56, 197, DateTimeKind.Local).AddTicks(9538) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 210, DateTimeKind.Local).AddTicks(6909), new DateTime(2021, 12, 13, 10, 57, 56, 210, DateTimeKind.Local).AddTicks(3527), new DateTime(2021, 12, 13, 10, 57, 56, 210, DateTimeKind.Local).AddTicks(5636), new DateTime(2021, 12, 13, 10, 57, 56, 210, DateTimeKind.Local).AddTicks(6935) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 13, 10, 57, 56, 210, DateTimeKind.Local).AddTicks(7469), new DateTime(2021, 12, 13, 10, 57, 56, 210, DateTimeKind.Local).AddTicks(7310), new DateTime(2021, 12, 13, 10, 57, 56, 210, DateTimeKind.Local).AddTicks(7432), new DateTime(2021, 12, 13, 10, 57, 56, 210, DateTimeKind.Local).AddTicks(7475) });
        }
    }
}
