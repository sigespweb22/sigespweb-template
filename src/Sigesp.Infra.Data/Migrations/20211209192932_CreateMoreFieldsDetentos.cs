using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateMoreFieldsDetentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:instrumento_prisao_tipo_enum", "nenhum,nota_culpa,mandado_prisao,transferencia,recaptura,medida_disciplinar");

            migrationBuilder.AddColumn<string>(
                name: "AcaoPenal",
                table: "Detentos",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Artigos",
                table: "Detentos",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comarca",
                table: "Detentos",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CondenacaoTipo",
                table: "Detentos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPrevisaoBeneficio",
                table: "Detentos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPrisao",
                table: "Detentos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataProgressao",
                table: "Detentos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "DiasMedidaDisciplinar",
                table: "Detentos",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<List<InstrumentoPrisaoTipoEnum>>(
                name: "InstrumentosPrisao",
                table: "Detentos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PenaAno",
                table: "Detentos",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PenaDia",
                table: "Detentos",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PenaMes",
                table: "Detentos",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrevisaoBeneficioObservacao",
                table: "Detentos",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RevisaoIpenData",
                table: "Detentos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RevisaoIpenObservacao",
                table: "Detentos",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "TipoConta", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 579, DateTimeKind.Local).AddTicks(3387), new DateTime(2021, 12, 9, 16, 29, 31, 579, DateTimeKind.Local).AddTicks(3181), 3, new DateTime(2021, 12, 9, 16, 29, 31, 579, DateTimeKind.Local).AddTicks(3391) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "TipoConta", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 579, DateTimeKind.Local).AddTicks(3132), new DateTime(2021, 12, 9, 16, 29, 31, 578, DateTimeKind.Local).AddTicks(7730), 2, new DateTime(2021, 12, 9, 16, 29, 31, 579, DateTimeKind.Local).AddTicks(3145) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 583, DateTimeKind.Local).AddTicks(809), new DateTime(2021, 12, 9, 16, 29, 31, 583, DateTimeKind.Local).AddTicks(770), new DateTime(2021, 12, 9, 16, 29, 31, 583, DateTimeKind.Local).AddTicks(813) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 583, DateTimeKind.Local).AddTicks(67), new DateTime(2021, 12, 9, 16, 29, 31, 582, DateTimeKind.Local).AddTicks(9042), new DateTime(2021, 12, 9, 16, 29, 31, 583, DateTimeKind.Local).AddTicks(104) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 564, DateTimeKind.Local).AddTicks(4432), "Maria de Lourdes", new DateTime(2021, 12, 9, 16, 29, 31, 565, DateTimeKind.Local).AddTicks(4821) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 565, DateTimeKind.Local).AddTicks(5678), "Carlos Amarildo de Souza", new DateTime(2021, 12, 9, 16, 29, 31, 565, DateTimeKind.Local).AddTicks(5700) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 569, DateTimeKind.Local).AddTicks(2896), new DateTime(2021, 12, 9, 16, 29, 31, 569, DateTimeKind.Local).AddTicks(2924) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 569, DateTimeKind.Local).AddTicks(3100), new DateTime(2021, 12, 9, 16, 29, 31, 569, DateTimeKind.Local).AddTicks(3104) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 573, DateTimeKind.Local).AddTicks(1688), new DateTime(2021, 12, 9, 16, 29, 31, 572, DateTimeKind.Local).AddTicks(9908), new DateTime(2021, 12, 9, 16, 29, 31, 572, DateTimeKind.Local).AddTicks(9458), new DateTime(2021, 12, 9, 16, 29, 31, 573, DateTimeKind.Local).AddTicks(1702) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 573, DateTimeKind.Local).AddTicks(1755), new DateTime(2021, 12, 9, 16, 29, 31, 573, DateTimeKind.Local).AddTicks(1744) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 585, DateTimeKind.Local).AddTicks(7503), new DateTime(2021, 12, 9, 16, 29, 31, 585, DateTimeKind.Local).AddTicks(4442), new DateTime(2021, 12, 9, 16, 29, 31, 585, DateTimeKind.Local).AddTicks(6308), new DateTime(2021, 12, 9, 16, 29, 31, 585, DateTimeKind.Local).AddTicks(7516) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 9, 16, 29, 31, 585, DateTimeKind.Local).AddTicks(7983), new DateTime(2021, 12, 9, 16, 29, 31, 585, DateTimeKind.Local).AddTicks(7861), new DateTime(2021, 12, 9, 16, 29, 31, 585, DateTimeKind.Local).AddTicks(7912), new DateTime(2021, 12, 9, 16, 29, 31, 585, DateTimeKind.Local).AddTicks(7987) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcaoPenal",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "Artigos",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "Comarca",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "CondenacaoTipo",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "DataPrevisaoBeneficio",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "DataPrisao",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "DataProgressao",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "DiasMedidaDisciplinar",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "InstrumentosPrisao",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "PenaAno",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "PenaDia",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "PenaMes",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "PrevisaoBeneficioObservacao",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "RevisaoIpenData",
                table: "Detentos");

            migrationBuilder.DropColumn(
                name: "RevisaoIpenObservacao",
                table: "Detentos");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:instrumento_prisao_tipo_enum", "nenhum,nota_culpa,mandado_prisao,transferencia,recaptura,medida_disciplinar");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "TipoConta", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 735, DateTimeKind.Local).AddTicks(6710), new DateTime(2021, 12, 7, 13, 41, 35, 735, DateTimeKind.Local).AddTicks(6532), 3, new DateTime(2021, 12, 7, 13, 41, 35, 735, DateTimeKind.Local).AddTicks(6713) });

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"),
                columns: new[] { "CreatedAt", "DataUltimaSituacao", "TipoConta", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 735, DateTimeKind.Local).AddTicks(6482), new DateTime(2021, 12, 7, 13, 41, 35, 735, DateTimeKind.Local).AddTicks(1118), 2, new DateTime(2021, 12, 7, 13, 41, 35, 735, DateTimeKind.Local).AddTicks(6492) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 739, DateTimeKind.Local).AddTicks(8593), new DateTime(2021, 12, 7, 13, 41, 35, 739, DateTimeKind.Local).AddTicks(8559), new DateTime(2021, 12, 7, 13, 41, 35, 739, DateTimeKind.Local).AddTicks(8602) });

            migrationBuilder.UpdateData(
                table: "ContasCorrentes",
                keyColumn: "Id",
                keyValue: new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"),
                columns: new[] { "CreatedAt", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 739, DateTimeKind.Local).AddTicks(7873), new DateTime(2021, 12, 7, 13, 41, 35, 739, DateTimeKind.Local).AddTicks(6803), new DateTime(2021, 12, 7, 13, 41, 35, 739, DateTimeKind.Local).AddTicks(7903) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 720, DateTimeKind.Local).AddTicks(9935), "Maria de Lourdes", new DateTime(2021, 12, 7, 13, 41, 35, 722, DateTimeKind.Local).AddTicks(596) });

            migrationBuilder.UpdateData(
                table: "Detentos",
                keyColumn: "Id",
                keyValue: new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"),
                columns: new[] { "CreatedAt", "NomeFamiliar", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 722, DateTimeKind.Local).AddTicks(1482), "Carlos Amarildo de Souza", new DateTime(2021, 12, 7, 13, 41, 35, 722, DateTimeKind.Local).AddTicks(1504) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("00e08a3e-da29-4493-8786-65c67a98970f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 726, DateTimeKind.Local).AddTicks(2446), new DateTime(2021, 12, 7, 13, 41, 35, 726, DateTimeKind.Local).AddTicks(2480) });

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 726, DateTimeKind.Local).AddTicks(2640), new DateTime(2021, 12, 7, 13, 41, 35, 726, DateTimeKind.Local).AddTicks(2644) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"),
                columns: new[] { "CreatedAt", "DataFim", "DataInicio", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 729, DateTimeKind.Local).AddTicks(8760), new DateTime(2021, 12, 7, 13, 41, 35, 729, DateTimeKind.Local).AddTicks(6959), new DateTime(2021, 12, 7, 13, 41, 35, 729, DateTimeKind.Local).AddTicks(6579), new DateTime(2021, 12, 7, 13, 41, 35, 729, DateTimeKind.Local).AddTicks(8776) });

            migrationBuilder.UpdateData(
                table: "EmpresasConvenios",
                keyColumn: "Id",
                keyValue: new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"),
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 729, DateTimeKind.Local).AddTicks(8827), new DateTime(2021, 12, 7, 13, 41, 35, 729, DateTimeKind.Local).AddTicks(8814) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("0af820ce-7131-45de-a98d-947f972c2a84"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 743, DateTimeKind.Local).AddTicks(7509), new DateTime(2021, 12, 7, 13, 41, 35, 743, DateTimeKind.Local).AddTicks(3992), new DateTime(2021, 12, 7, 13, 41, 35, 743, DateTimeKind.Local).AddTicks(6071), new DateTime(2021, 12, 7, 13, 41, 35, 743, DateTimeKind.Local).AddTicks(7529) });

            migrationBuilder.UpdateData(
                table: "Lancamentos",
                keyColumn: "Id",
                keyValue: new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"),
                columns: new[] { "CreatedAt", "DataLiquidacao", "DataUltimoStatus", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 41, 35, 743, DateTimeKind.Local).AddTicks(8056), new DateTime(2021, 12, 7, 13, 41, 35, 743, DateTimeKind.Local).AddTicks(7905), new DateTime(2021, 12, 7, 13, 41, 35, 743, DateTimeKind.Local).AddTicks(7973), new DateTime(2021, 12, 7, 13, 41, 35, 743, DateTimeKind.Local).AddTicks(8061) });
        }
    }
}
