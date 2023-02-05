using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesMicellanious : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Galeria",
                table: "ServidoresEstado",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicioGozo",
                table: "ServidoresEstado",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFimGozo",
                table: "ServidoresEstado",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "1e526008-75f7-4a01-9942-d178f2b38888",
                column: "TenantId",
                value: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "TenantId",
                value: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscrita",
                keyColumn: "Id",
                keyValue: new Guid("8d7fb6ec-bcbf-4f94-ad0a-0f7154e8670b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 11, DateTimeKind.Local).AddTicks(7360), new DateTime(2022, 9, 25, 14, 10, 29, 11, DateTimeKind.Local).AddTicks(7389) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 14, DateTimeKind.Local).AddTicks(540), new DateTime(2022, 9, 25, 14, 10, 29, 14, DateTimeKind.Local).AddTicks(560) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 13, DateTimeKind.Local).AddTicks(9018), new DateTime(2022, 9, 25, 14, 10, 29, 13, DateTimeKind.Local).AddTicks(9050) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 14, DateTimeKind.Local).AddTicks(607), new DateTime(2022, 9, 25, 14, 10, 29, 14, DateTimeKind.Local).AddTicks(610) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 14, DateTimeKind.Local).AddTicks(616), new DateTime(2022, 9, 25, 14, 10, 29, 14, DateTimeKind.Local).AddTicks(618) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 14, DateTimeKind.Local).AddTicks(599), new DateTime(2022, 9, 25, 14, 10, 29, 14, DateTimeKind.Local).AddTicks(602) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(7714), new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(7716) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(7708), new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(7710) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(7700), new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(7703) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(6653), new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(6680) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(7657), new DateTime(2022, 9, 25, 14, 10, 29, 17, DateTimeKind.Local).AddTicks(7670) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 15, DateTimeKind.Local).AddTicks(7644), new DateTime(2022, 9, 25, 14, 10, 29, 15, DateTimeKind.Local).AddTicks(7674) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 8, DateTimeKind.Local).AddTicks(6587), new DateTime(2022, 9, 25, 14, 10, 29, 9, DateTimeKind.Local).AddTicks(4959) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 9, DateTimeKind.Local).AddTicks(6315), new DateTime(2022, 9, 25, 14, 10, 29, 9, DateTimeKind.Local).AddTicks(6334) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 14, 10, 29, 9, DateTimeKind.Local).AddTicks(6372), new DateTime(2022, 9, 25, 14, 10, 29, 9, DateTimeKind.Local).AddTicks(6374) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Galeria",
                table: "ServidoresEstado",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicioGozo",
                table: "ServidoresEstado",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFimGozo",
                table: "ServidoresEstado",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "1e526008-75f7-4a01-9942-d178f2b38888",
                column: "TenantId",
                value: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "UserId",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "TenantId",
                value: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"));

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscrita",
                keyColumn: "Id",
                keyValue: new Guid("8d7fb6ec-bcbf-4f94-ad0a-0f7154e8670b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 13, 17, 30, 581, DateTimeKind.Local).AddTicks(7985), new DateTime(2022, 9, 25, 13, 17, 30, 581, DateTimeKind.Local).AddTicks(8010) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 13, 17, 30, 583, DateTimeKind.Local).AddTicks(5570), new DateTime(2022, 9, 25, 13, 17, 30, 583, DateTimeKind.Local).AddTicks(5576) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 13, 17, 30, 583, DateTimeKind.Local).AddTicks(4701), new DateTime(2022, 9, 25, 13, 17, 30, 583, DateTimeKind.Local).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 13, 17, 30, 583, DateTimeKind.Local).AddTicks(5608), new DateTime(2022, 9, 25, 13, 17, 30, 583, DateTimeKind.Local).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 13, 17, 30, 583, DateTimeKind.Local).AddTicks(5615), new DateTime(2022, 9, 25, 13, 17, 30, 583, DateTimeKind.Local).AddTicks(5617) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 13, 17, 30, 583, DateTimeKind.Local).AddTicks(5601), new DateTime(2022, 9, 25, 13, 17, 30, 583, DateTimeKind.Local).AddTicks(5604) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 13, 17, 30, 586, DateTimeKind.Local).AddTicks(5769), new DateTime(2022, 9, 25, 13, 17, 30, 586, DateTimeKind.Local).AddTicks(5771) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 13, 17, 30, 586, DateTimeKind.Local).AddTicks(5763), new DateTime(2022, 9, 25, 13, 17, 30, 586, DateTimeKind.Local).AddTicks(5765) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 13, 17, 30, 586, DateTimeKind.Local).AddTicks(5756), new DateTime(2022, 9, 25, 13, 17, 30, 586, DateTimeKind.Local).AddTicks(5758) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 13, 17, 30, 586, DateTimeKind.Local).AddTicks(4857), new DateTime(2022, 9, 25, 13, 17, 30, 586, DateTimeKind.Local).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 13, 17, 30, 586, DateTimeKind.Local).AddTicks(5721), new DateTime(2022, 9, 25, 13, 17, 30, 586, DateTimeKind.Local).AddTicks(5727) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 13, 17, 30, 584, DateTimeKind.Local).AddTicks(8731), new DateTime(2022, 9, 25, 13, 17, 30, 584, DateTimeKind.Local).AddTicks(8743) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 13, 17, 30, 578, DateTimeKind.Local).AddTicks(7656), new DateTime(2022, 9, 25, 13, 17, 30, 579, DateTimeKind.Local).AddTicks(8365) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 13, 17, 30, 579, DateTimeKind.Local).AddTicks(9696), new DateTime(2022, 9, 25, 13, 17, 30, 579, DateTimeKind.Local).AddTicks(9716) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 25, 13, 17, 30, 579, DateTimeKind.Local).AddTicks(9752), new DateTime(2022, 9, 25, 13, 17, 30, 579, DateTimeKind.Local).AddTicks(9754) });
        }
    }
}
