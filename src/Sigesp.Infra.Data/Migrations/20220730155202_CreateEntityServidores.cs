using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateEntityServidores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServidoresEstado",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 255, nullable: false),
                    Matricula = table.Column<string>(maxLength: 50, nullable: false),
                    PlantaoNome = table.Column<int>(nullable: false, defaultValue: 0),
                    Galeria = table.Column<int>(nullable: false, defaultValue: 0),
                    HasPrioridadeMarcacaoReforco = table.Column<bool>(nullable: false, defaultValue: false),
                    IsExpediente = table.Column<bool>(nullable: false, defaultValue: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServidoresEstado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServidoresEstado_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "ServidoresEstadoReforcos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    DataPrevista = table.Column<DateTime>(nullable: false),
                    DiaSemana = table.Column<string>(maxLength: 25, nullable: false),
                    HorarioInicio = table.Column<string>(maxLength: 5, nullable: true),
                    HorarioFim = table.Column<string>(maxLength: 5, nullable: true),
                    MesExtenso = table.Column<string>(nullable: false),
                    MesNumeral = table.Column<int>(nullable: false),
                    ReforcoSituacao = table.Column<int>(nullable: false),
                    ServidorEstadoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServidoresEstadoReforcos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServidoresEstadoReforcos_ServidoresEstado_ServidorEstadoId",
                        column: x => x.ServidorEstadoId,
                        principalTable: "ServidoresEstado",
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
                values: new object[] { new DateTime(2022, 7, 30, 12, 52, 2, 2, DateTimeKind.Local).AddTicks(575), new DateTime(2022, 7, 30, 12, 52, 2, 2, DateTimeKind.Local).AddTicks(601) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 30, 12, 52, 2, 4, DateTimeKind.Local).AddTicks(1729), new DateTime(2022, 7, 30, 12, 52, 2, 4, DateTimeKind.Local).AddTicks(1736) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 30, 12, 52, 2, 4, DateTimeKind.Local).AddTicks(725), new DateTime(2022, 7, 30, 12, 52, 2, 4, DateTimeKind.Local).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 30, 12, 52, 2, 4, DateTimeKind.Local).AddTicks(1777), new DateTime(2022, 7, 30, 12, 52, 2, 4, DateTimeKind.Local).AddTicks(1779) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 30, 12, 52, 2, 4, DateTimeKind.Local).AddTicks(1784), new DateTime(2022, 7, 30, 12, 52, 2, 4, DateTimeKind.Local).AddTicks(1786) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 30, 12, 52, 2, 4, DateTimeKind.Local).AddTicks(1769), new DateTime(2022, 7, 30, 12, 52, 2, 4, DateTimeKind.Local).AddTicks(1772) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 30, 12, 52, 2, 7, DateTimeKind.Local).AddTicks(9266), new DateTime(2022, 7, 30, 12, 52, 2, 7, DateTimeKind.Local).AddTicks(9268) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 30, 12, 52, 2, 7, DateTimeKind.Local).AddTicks(9259), new DateTime(2022, 7, 30, 12, 52, 2, 7, DateTimeKind.Local).AddTicks(9261) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 30, 12, 52, 2, 7, DateTimeKind.Local).AddTicks(9252), new DateTime(2022, 7, 30, 12, 52, 2, 7, DateTimeKind.Local).AddTicks(9254) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 30, 12, 52, 2, 7, DateTimeKind.Local).AddTicks(8259), new DateTime(2022, 7, 30, 12, 52, 2, 7, DateTimeKind.Local).AddTicks(8285) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 30, 12, 52, 2, 7, DateTimeKind.Local).AddTicks(9219), new DateTime(2022, 7, 30, 12, 52, 2, 7, DateTimeKind.Local).AddTicks(9225) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 30, 12, 52, 2, 5, DateTimeKind.Local).AddTicks(9238), new DateTime(2022, 7, 30, 12, 52, 2, 5, DateTimeKind.Local).AddTicks(9268) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 30, 12, 52, 1, 999, DateTimeKind.Local).AddTicks(3932), new DateTime(2022, 7, 30, 12, 52, 2, 0, DateTimeKind.Local).AddTicks(2230) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 30, 12, 52, 2, 0, DateTimeKind.Local).AddTicks(3599), new DateTime(2022, 7, 30, 12, 52, 2, 0, DateTimeKind.Local).AddTicks(3623) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 30, 12, 52, 2, 0, DateTimeKind.Local).AddTicks(3661), new DateTime(2022, 7, 30, 12, 52, 2, 0, DateTimeKind.Local).AddTicks(3664) });

            migrationBuilder.CreateIndex(
                name: "IX_ServidoresEstado_UserId",
                table: "ServidoresEstado",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServidoresEstadoReforcos_ServidorEstadoId",
                table: "ServidoresEstadoReforcos",
                column: "ServidorEstadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServidoresEstadoReforcos");

            migrationBuilder.DropTable(
                name: "ServidoresEstado");

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
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 939, DateTimeKind.Local).AddTicks(5945), new DateTime(2022, 7, 27, 19, 31, 42, 939, DateTimeKind.Local).AddTicks(5958) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(4163), new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(4169) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(3255), new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(3267) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(4204), new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(4205) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(4210), new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(4212) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(4197), new DateTime(2022, 7, 27, 19, 31, 42, 941, DateTimeKind.Local).AddTicks(4199) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(5708), new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(5710) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(5702), new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(5704) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(5696), new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(5698) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(4804), new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(4818) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(5657), new DateTime(2022, 7, 27, 19, 31, 42, 944, DateTimeKind.Local).AddTicks(5663) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 942, DateTimeKind.Local).AddTicks(7365), new DateTime(2022, 7, 27, 19, 31, 42, 942, DateTimeKind.Local).AddTicks(7375) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 937, DateTimeKind.Local).AddTicks(2300), new DateTime(2022, 7, 27, 19, 31, 42, 937, DateTimeKind.Local).AddTicks(9965) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 938, DateTimeKind.Local).AddTicks(1244), new DateTime(2022, 7, 27, 19, 31, 42, 938, DateTimeKind.Local).AddTicks(1263) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 31, 42, 938, DateTimeKind.Local).AddTicks(1301), new DateTime(2022, 7, 27, 19, 31, 42, 938, DateTimeKind.Local).AddTicks(1303) });
        }
    }
}
