using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateNewEntityToServidorEstado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServidorEstadoReforcoRegraVagasDia",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Dia = table.Column<string>(nullable: true),
                    TotalVagas = table.Column<int>(nullable: false),
                    ServidorEstadoReforcoRegraId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServidorEstadoReforcoRegraVagasDia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServidorEstadoReforcoRegraVagasDia_ServidorEstadoReforcoReg~",
                        column: x => x.ServidorEstadoReforcoRegraId,
                        principalTable: "ServidorEstadoReforcoRegras",
                        principalColumn: "Id");
                });

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
                values: new object[] { new DateTime(2022, 9, 7, 14, 45, 11, 98, DateTimeKind.Local).AddTicks(1351), new DateTime(2022, 9, 7, 14, 45, 11, 98, DateTimeKind.Local).AddTicks(1363) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 7, 14, 45, 11, 99, DateTimeKind.Local).AddTicks(9455), new DateTime(2022, 9, 7, 14, 45, 11, 99, DateTimeKind.Local).AddTicks(9461) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 7, 14, 45, 11, 99, DateTimeKind.Local).AddTicks(8585), new DateTime(2022, 9, 7, 14, 45, 11, 99, DateTimeKind.Local).AddTicks(8599) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 7, 14, 45, 11, 99, DateTimeKind.Local).AddTicks(9494), new DateTime(2022, 9, 7, 14, 45, 11, 99, DateTimeKind.Local).AddTicks(9496) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 7, 14, 45, 11, 99, DateTimeKind.Local).AddTicks(9501), new DateTime(2022, 9, 7, 14, 45, 11, 99, DateTimeKind.Local).AddTicks(9503) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 7, 14, 45, 11, 99, DateTimeKind.Local).AddTicks(9488), new DateTime(2022, 9, 7, 14, 45, 11, 99, DateTimeKind.Local).AddTicks(9490) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 7, 14, 45, 11, 103, DateTimeKind.Local).AddTicks(3384), new DateTime(2022, 9, 7, 14, 45, 11, 103, DateTimeKind.Local).AddTicks(3386) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 7, 14, 45, 11, 103, DateTimeKind.Local).AddTicks(3377), new DateTime(2022, 9, 7, 14, 45, 11, 103, DateTimeKind.Local).AddTicks(3379) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 7, 14, 45, 11, 103, DateTimeKind.Local).AddTicks(3370), new DateTime(2022, 9, 7, 14, 45, 11, 103, DateTimeKind.Local).AddTicks(3372) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 7, 14, 45, 11, 103, DateTimeKind.Local).AddTicks(2352), new DateTime(2022, 9, 7, 14, 45, 11, 103, DateTimeKind.Local).AddTicks(2368) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 7, 14, 45, 11, 103, DateTimeKind.Local).AddTicks(3336), new DateTime(2022, 9, 7, 14, 45, 11, 103, DateTimeKind.Local).AddTicks(3342) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 7, 14, 45, 11, 101, DateTimeKind.Local).AddTicks(4978), new DateTime(2022, 9, 7, 14, 45, 11, 101, DateTimeKind.Local).AddTicks(4997) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 7, 14, 45, 11, 95, DateTimeKind.Local).AddTicks(8104), new DateTime(2022, 9, 7, 14, 45, 11, 96, DateTimeKind.Local).AddTicks(5537) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 7, 14, 45, 11, 96, DateTimeKind.Local).AddTicks(6840), new DateTime(2022, 9, 7, 14, 45, 11, 96, DateTimeKind.Local).AddTicks(6859) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 7, 14, 45, 11, 96, DateTimeKind.Local).AddTicks(6896), new DateTime(2022, 9, 7, 14, 45, 11, 96, DateTimeKind.Local).AddTicks(6898) });

            migrationBuilder.CreateIndex(
                name: "IX_ServidorEstadoReforcoRegraVagasDia_ServidorEstadoReforcoReg~",
                table: "ServidorEstadoReforcoRegraVagasDia",
                column: "ServidorEstadoReforcoRegraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServidorEstadoReforcoRegraVagasDia");

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
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 517, DateTimeKind.Local).AddTicks(7429), new DateTime(2022, 9, 3, 16, 54, 39, 517, DateTimeKind.Local).AddTicks(7445) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(6100), new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(6107) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(5180), new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(5196) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(6144), new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(6146) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(6151), new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(6152) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(6137), new DateTime(2022, 9, 3, 16, 54, 39, 519, DateTimeKind.Local).AddTicks(6139) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(2184), new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(2187) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(2178), new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(2180) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(2171), new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(2173) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(1211), new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(1232) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(2138), new DateTime(2022, 9, 3, 16, 54, 39, 523, DateTimeKind.Local).AddTicks(2144) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 521, DateTimeKind.Local).AddTicks(3238), new DateTime(2022, 9, 3, 16, 54, 39, 521, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 515, DateTimeKind.Local).AddTicks(1681), new DateTime(2022, 9, 3, 16, 54, 39, 515, DateTimeKind.Local).AddTicks(9714) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 516, DateTimeKind.Local).AddTicks(1002), new DateTime(2022, 9, 3, 16, 54, 39, 516, DateTimeKind.Local).AddTicks(1020) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 3, 16, 54, 39, 516, DateTimeKind.Local).AddTicks(1060), new DateTime(2022, 9, 3, 16, 54, 39, 516, DateTimeKind.Local).AddTicks(1062) });
        }
    }
}
