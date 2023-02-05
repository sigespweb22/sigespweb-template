using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateChangesCriticousInEntitySERR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServidorEstadoReforcoRegras",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    DataPrimeiroPlantao = table.Column<DateTime>(nullable: false),
                    NomePrimeiroPlantao = table.Column<int>(nullable: false),
                    DataPrimeiraJanela = table.Column<DateTime>(nullable: false),
                    DataSegundaJanela = table.Column<DateTime>(nullable: false),
                    DataTerceiraJanela = table.Column<DateTime>(nullable: false),
                    MesRegra = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServidorEstadoReforcoRegras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServidorEstadoReforcoRegras_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
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
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 662, DateTimeKind.Local).AddTicks(715), new DateTime(2022, 8, 2, 15, 51, 49, 662, DateTimeKind.Local).AddTicks(727) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(9098), new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(9104) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(8185), new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(8198) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(9139), new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(9141) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(9145), new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(9147) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(9132), new DateTime(2022, 8, 2, 15, 51, 49, 663, DateTimeKind.Local).AddTicks(9134) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(2388), new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(2390) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(2381), new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(2383) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(2373), new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(2375) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(1307), new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(1326) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(2319), new DateTime(2022, 8, 2, 15, 51, 49, 667, DateTimeKind.Local).AddTicks(2324) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 665, DateTimeKind.Local).AddTicks(3108), new DateTime(2022, 8, 2, 15, 51, 49, 665, DateTimeKind.Local).AddTicks(3123) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 659, DateTimeKind.Local).AddTicks(5009), new DateTime(2022, 8, 2, 15, 51, 49, 660, DateTimeKind.Local).AddTicks(2911) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 660, DateTimeKind.Local).AddTicks(4374), new DateTime(2022, 8, 2, 15, 51, 49, 660, DateTimeKind.Local).AddTicks(4394) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 15, 51, 49, 660, DateTimeKind.Local).AddTicks(4432), new DateTime(2022, 8, 2, 15, 51, 49, 660, DateTimeKind.Local).AddTicks(4435) });

            migrationBuilder.CreateIndex(
                name: "IX_ServidorEstadoReforcoRegras_TenantId",
                table: "ServidorEstadoReforcoRegras",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServidorEstadoReforcoRegras");

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
                values: new object[] { new DateTime(2022, 7, 31, 17, 58, 26, 704, DateTimeKind.Local).AddTicks(9649), new DateTime(2022, 7, 31, 17, 58, 26, 704, DateTimeKind.Local).AddTicks(9674) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 31, 17, 58, 26, 708, DateTimeKind.Local).AddTicks(2653), new DateTime(2022, 7, 31, 17, 58, 26, 708, DateTimeKind.Local).AddTicks(2669) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 31, 17, 58, 26, 708, DateTimeKind.Local).AddTicks(986), new DateTime(2022, 7, 31, 17, 58, 26, 708, DateTimeKind.Local).AddTicks(1017) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 31, 17, 58, 26, 708, DateTimeKind.Local).AddTicks(2718), new DateTime(2022, 7, 31, 17, 58, 26, 708, DateTimeKind.Local).AddTicks(2720) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 31, 17, 58, 26, 708, DateTimeKind.Local).AddTicks(2724), new DateTime(2022, 7, 31, 17, 58, 26, 708, DateTimeKind.Local).AddTicks(2726) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 31, 17, 58, 26, 708, DateTimeKind.Local).AddTicks(2709), new DateTime(2022, 7, 31, 17, 58, 26, 708, DateTimeKind.Local).AddTicks(2712) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 31, 17, 58, 26, 732, DateTimeKind.Local).AddTicks(9794), new DateTime(2022, 7, 31, 17, 58, 26, 732, DateTimeKind.Local).AddTicks(9796) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 31, 17, 58, 26, 732, DateTimeKind.Local).AddTicks(9787), new DateTime(2022, 7, 31, 17, 58, 26, 732, DateTimeKind.Local).AddTicks(9789) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 31, 17, 58, 26, 732, DateTimeKind.Local).AddTicks(9780), new DateTime(2022, 7, 31, 17, 58, 26, 732, DateTimeKind.Local).AddTicks(9782) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 31, 17, 58, 26, 732, DateTimeKind.Local).AddTicks(8619), new DateTime(2022, 7, 31, 17, 58, 26, 732, DateTimeKind.Local).AddTicks(8657) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 31, 17, 58, 26, 732, DateTimeKind.Local).AddTicks(9745), new DateTime(2022, 7, 31, 17, 58, 26, 732, DateTimeKind.Local).AddTicks(9753) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 31, 17, 58, 26, 728, DateTimeKind.Local).AddTicks(9034), new DateTime(2022, 7, 31, 17, 58, 26, 728, DateTimeKind.Local).AddTicks(9069) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 31, 17, 58, 26, 700, DateTimeKind.Local).AddTicks(3576), new DateTime(2022, 7, 31, 17, 58, 26, 701, DateTimeKind.Local).AddTicks(5353) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 31, 17, 58, 26, 701, DateTimeKind.Local).AddTicks(7895), new DateTime(2022, 7, 31, 17, 58, 26, 701, DateTimeKind.Local).AddTicks(7924) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 31, 17, 58, 26, 701, DateTimeKind.Local).AddTicks(7969), new DateTime(2022, 7, 31, 17, 58, 26, 701, DateTimeKind.Local).AddTicks(7972) });
        }
    }
}
