using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateApplicationNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Scope = table.Column<int>(nullable: false, defaultValue: 0),
                    SenderUser = table.Column<string>(maxLength: 32, nullable: true),
                    IsRead = table.Column<bool>(nullable: false, defaultValue: false),
                    MessageTitle = table.Column<string>(maxLength: 150, nullable: false),
                    MessageBody = table.Column<string>(maxLength: 255, nullable: false),
                    MessageDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: false, defaultValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationNotifications_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationNotifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId");
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
                values: new object[] { new DateTime(2022, 9, 18, 16, 20, 32, 254, DateTimeKind.Local).AddTicks(1256), new DateTime(2022, 9, 18, 16, 20, 32, 254, DateTimeKind.Local).AddTicks(1268) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 20, 32, 255, DateTimeKind.Local).AddTicks(9274), new DateTime(2022, 9, 18, 16, 20, 32, 255, DateTimeKind.Local).AddTicks(9281) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 20, 32, 255, DateTimeKind.Local).AddTicks(8383), new DateTime(2022, 9, 18, 16, 20, 32, 255, DateTimeKind.Local).AddTicks(8395) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 20, 32, 255, DateTimeKind.Local).AddTicks(9316), new DateTime(2022, 9, 18, 16, 20, 32, 255, DateTimeKind.Local).AddTicks(9318) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 20, 32, 255, DateTimeKind.Local).AddTicks(9322), new DateTime(2022, 9, 18, 16, 20, 32, 255, DateTimeKind.Local).AddTicks(9324) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 20, 32, 255, DateTimeKind.Local).AddTicks(9309), new DateTime(2022, 9, 18, 16, 20, 32, 255, DateTimeKind.Local).AddTicks(9311) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 20, 32, 259, DateTimeKind.Local).AddTicks(2505), new DateTime(2022, 9, 18, 16, 20, 32, 259, DateTimeKind.Local).AddTicks(2507) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 20, 32, 259, DateTimeKind.Local).AddTicks(2499), new DateTime(2022, 9, 18, 16, 20, 32, 259, DateTimeKind.Local).AddTicks(2501) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 20, 32, 259, DateTimeKind.Local).AddTicks(2492), new DateTime(2022, 9, 18, 16, 20, 32, 259, DateTimeKind.Local).AddTicks(2495) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 20, 32, 259, DateTimeKind.Local).AddTicks(1531), new DateTime(2022, 9, 18, 16, 20, 32, 259, DateTimeKind.Local).AddTicks(1555) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 20, 32, 259, DateTimeKind.Local).AddTicks(2458), new DateTime(2022, 9, 18, 16, 20, 32, 259, DateTimeKind.Local).AddTicks(2464) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 20, 32, 257, DateTimeKind.Local).AddTicks(2826), new DateTime(2022, 9, 18, 16, 20, 32, 257, DateTimeKind.Local).AddTicks(2838) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 20, 32, 251, DateTimeKind.Local).AddTicks(6812), new DateTime(2022, 9, 18, 16, 20, 32, 252, DateTimeKind.Local).AddTicks(4512) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 20, 32, 252, DateTimeKind.Local).AddTicks(5948), new DateTime(2022, 9, 18, 16, 20, 32, 252, DateTimeKind.Local).AddTicks(5967) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 18, 16, 20, 32, 252, DateTimeKind.Local).AddTicks(6005), new DateTime(2022, 9, 18, 16, 20, 32, 252, DateTimeKind.Local).AddTicks(6007) });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationNotifications_TenantId",
                table: "ApplicationNotifications",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationNotifications_UserId",
                table: "ApplicationNotifications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationNotifications");

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
                values: new object[] { new DateTime(2022, 9, 11, 17, 2, 23, 970, DateTimeKind.Local).AddTicks(8997), new DateTime(2022, 9, 11, 17, 2, 23, 970, DateTimeKind.Local).AddTicks(9008) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("0b0aac0b-805d-4ed5-b6cf-d7a03a4e77f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 17, 2, 23, 972, DateTimeKind.Local).AddTicks(9804), new DateTime(2022, 9, 11, 17, 2, 23, 972, DateTimeKind.Local).AddTicks(9810) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("1b82c38c-5fa9-484c-ba40-c2aa8183652e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 17, 2, 23, 972, DateTimeKind.Local).AddTicks(8898), new DateTime(2022, 9, 11, 17, 2, 23, 972, DateTimeKind.Local).AddTicks(8916) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("38b52b32-6e69-438d-bce7-e9b75fda6cf3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 17, 2, 23, 972, DateTimeKind.Local).AddTicks(9844), new DateTime(2022, 9, 11, 17, 2, 23, 972, DateTimeKind.Local).AddTicks(9846) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("e98df615-1bfd-4eb6-8f89-a91c3378db22"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 17, 2, 23, 972, DateTimeKind.Local).AddTicks(9850), new DateTime(2022, 9, 11, 17, 2, 23, 972, DateTimeKind.Local).AddTicks(9852) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraDicasEscritaDicas",
                keyColumn: "Id",
                keyValue: new Guid("f312ed91-b8a1-4a23-9c57-f24dac794089"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 17, 2, 23, 972, DateTimeKind.Local).AddTicks(9837), new DateTime(2022, 9, 11, 17, 2, 23, 972, DateTimeKind.Local).AddTicks(9839) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("6f119f2e-09c7-449a-b4cc-801cf66d1b19"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 17, 2, 23, 976, DateTimeKind.Local).AddTicks(1663), new DateTime(2022, 9, 11, 17, 2, 23, 976, DateTimeKind.Local).AddTicks(1665) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("82c15cda-87f5-4f8a-835e-26b8d45d2b03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 17, 2, 23, 976, DateTimeKind.Local).AddTicks(1656), new DateTime(2022, 9, 11, 17, 2, 23, 976, DateTimeKind.Local).AddTicks(1658) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c1e37ce0-4d59-48da-869f-b0dd59562f26"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 17, 2, 23, 976, DateTimeKind.Local).AddTicks(1650), new DateTime(2022, 9, 11, 17, 2, 23, 976, DateTimeKind.Local).AddTicks(1652) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("c503712d-6177-45c1-94d6-4be7cb00e4d8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 17, 2, 23, 976, DateTimeKind.Local).AddTicks(709), new DateTime(2022, 9, 11, 17, 2, 23, 976, DateTimeKind.Local).AddTicks(724) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntas",
                keyColumn: "Id",
                keyValue: new Guid("e94b5df4-379c-482d-99e0-10e35760d580"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 17, 2, 23, 976, DateTimeKind.Local).AddTicks(1619), new DateTime(2022, 9, 11, 17, 2, 23, 976, DateTimeKind.Local).AddTicks(1626) });

            migrationBuilder.UpdateData(
                table: "FormularioLeituraPerguntasGrupos",
                keyColumn: "Id",
                keyValue: new Guid("b6da5dc4-2f08-4dc7-81df-8b1915bfab06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 17, 2, 23, 974, DateTimeKind.Local).AddTicks(3780), new DateTime(2022, 9, 11, 17, 2, 23, 974, DateTimeKind.Local).AddTicks(3790) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("206c645a-2966-4ad9-19a3-dced7c201bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 17, 2, 23, 968, DateTimeKind.Local).AddTicks(4755), new DateTime(2022, 9, 11, 17, 2, 23, 969, DateTimeKind.Local).AddTicks(2584) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("522eb3d9-e64d-4585-8776-e80f90cd9a0c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 17, 2, 23, 969, DateTimeKind.Local).AddTicks(3844), new DateTime(2022, 9, 11, 17, 2, 23, 969, DateTimeKind.Local).AddTicks(3862) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("c959c0e8-24c9-4714-929f-5536bcd5dc0a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 9, 11, 17, 2, 23, 969, DateTimeKind.Local).AddTicks(3901), new DateTime(2022, 9, 11, 17, 2, 23, 969, DateTimeKind.Local).AddTicks(3903) });
        }
    }
}
