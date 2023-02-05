using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Sigesp.Infra.Data.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Detentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Ipen = table.Column<int>(maxLength: 6, nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Galeria = table.Column<string>(maxLength: 2, nullable: true),
                    Cela = table.Column<int>(maxLength: 2, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: true),
                    Rg = table.Column<string>(nullable: true),
                    Nascimento = table.Column<DateTime>(nullable: false),
                    Pec = table.Column<string>(nullable: true),
                    IsProvisorio = table.Column<bool>(nullable: false),
                    IsSaidaTemporaria = table.Column<bool>(nullable: false),
                    Situacao = table.Column<int>(nullable: false),
                    SaidaTemporaria = table.Column<DateTime>(nullable: false),
                    RetornoSaidaTemporaria = table.Column<DateTime>(nullable: false),
                    MatriculaFamiliar = table.Column<string>(maxLength: 6, nullable: false),
                    NomeFamiliar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 255, nullable: true),
                    NomeFantasia = table.Column<string>(maxLength: 255, nullable: true),
                    Cnpj = table.Column<long>(maxLength: 14, nullable: false),
                    Cep = table.Column<int>(maxLength: 8, nullable: false),
                    Cidade = table.Column<string>(maxLength: 50, nullable: true),
                    Estado = table.Column<string>(maxLength: 50, nullable: true),
                    Logradouro = table.Column<string>(maxLength: 150, nullable: true),
                    Numero = table.Column<string>(maxLength: 10, nullable: true),
                    Bairro = table.Column<string>(maxLength: 50, nullable: true),
                    Responsavel = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    TelefoneFixo = table.Column<string>(maxLength: 14, nullable: true),
                    TelefoneCelular = table.Column<string>(maxLength: 14, nullable: true),
                    WhatsApp = table.Column<string>(maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContaUsuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    PerfilFoto = table.Column<byte[]>(nullable: true),
                    Setor = table.Column<int>(nullable: false),
                    Funcao = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaUsuarios_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmpresasConvenios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 255, nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    DataEncerramento = table.Column<DateTime>(nullable: false),
                    MotivoEncerramento = table.Column<string>(maxLength: 255, nullable: true),
                    IsRenovacaoAutomatica = table.Column<bool>(nullable: false),
                    TermosGerais = table.Column<string>(maxLength: 255, nullable: true),
                    Responsavel = table.Column<string>(nullable: true),
                    Situacao = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresasConvenios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpresasConvenios_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Situacao = table.Column<int>(nullable: false),
                    DataUltimaSituacao = table.Column<DateTime>(nullable: false),
                    LocalTrabalho = table.Column<string>(maxLength: 255, nullable: true),
                    IsTrabalhoInterno = table.Column<bool>(nullable: false),
                    IsRemunerado = table.Column<bool>(nullable: false),
                    Remuneracao = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    FamiliarAutorizadoRetirada = table.Column<string>(maxLength: 255, nullable: true),
                    Desconto = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    DescontoOutro = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    DiaPagamento = table.Column<int>(maxLength: 2, nullable: false),
                    TipoPagamento = table.Column<int>(nullable: false),
                    JornadaInicio = table.Column<string>(maxLength: 5, nullable: true),
                    JornadaFim = table.Column<string>(maxLength: 5, nullable: true),
                    BancoNumero = table.Column<int>(maxLength: 4, nullable: false),
                    BancoAgencia = table.Column<string>(maxLength: 6, nullable: true),
                    BancoConta = table.Column<string>(maxLength: 6, nullable: true),
                    TipoConta = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 255, nullable: true),
                    EmpresaConvenioId = table.Column<Guid>(nullable: false),
                    DetentoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaboradores_Detentos_DetentoId",
                        column: x => x.DetentoId,
                        principalTable: "Detentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaboradores_EmpresasConvenios_EmpresaConvenioId",
                        column: x => x.EmpresaConvenioId,
                        principalTable: "EmpresasConvenios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContasCorrentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Numero = table.Column<int>(maxLength: 6, nullable: false),
                    DataUltimoStatus = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ColaboradorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasCorrentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasCorrentes_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lancamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    DataLiquidacao = table.Column<DateTime>(nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ValorBruto = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    ValorLiquido = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    PeriodoDataInicio = table.Column<int>(nullable: false),
                    PeriodoDataFim = table.Column<int>(nullable: false),
                    DataUltimoStatus = table.Column<DateTime>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 255, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PeriodoReferencia = table.Column<int>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    ContaCorrenteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lancamentos_ContasCorrentes_ContaCorrenteId",
                        column: x => x.ContaCorrenteId,
                        principalTable: "ContasCorrentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "da8e4f70-8be9-4d8f-a684-5b97f19d252c", "Master", "MASTER" },
                    { "e6b7ff49-350c-4b89-a533-9eb923d8ba1b", "0421080e-e52e-4337-a0e0-3630f83bb58d", "Template", "TEMPLATE" },
                    { "e060a6d2-6472-4294-9f68-22bd114867f9", "77ea2caa-69a2-4ae4-bf76-cf87d8cef7f6", "Andamento-Penal_Todos", "ANDAMENTO-PENAL_TODOS" },
                    { "92c72070-3275-49e6-bd4a-f6c8e565b5bc", "610041f7-1332-4769-8d11-7c92b7e90cb1", "Edis_Todos", "EDIS_TODOS" },
                    { "dc50c49f-3cef-4dbe-83bb-5f1916ac8854", "c98d36df-14df-4cda-ae90-61b30dc86a70", "Contas-Correntes_Relatorios", "CONTAS-CORRENTES_RELATORIOS" },
                    { "d9db904b-aee9-4474-9301-e731e7c79cbe", "75966e0f-7709-40f4-9e76-938fbe188dd1", "Lancamentos_Todos", "LANCAMENTOS_TODOS" },
                    { "96a403a0-28c8-47f2-91e8-0f9df2da00c6", "313479a6-94f2-4612-83da-b0850e0ad00e", "Colaboradores_Relatorios", "COLABORADORES_RELATORIOS" },
                    { "e86df548-3cd5-4a3f-b82e-78842186f8d2", "8e9bdf9b-04a5-452b-9269-208c99a17f2a", "Contas-Correntes_Todos", "CONTAS-CORRENTES_TODOS" },
                    { "47d047d6-e7c6-409e-b53c-a9dc66004354", "714f94eb-9d78-4e76-a03a-68ac6b5cdab1", "Empresas-Convenios_Todos", "EMPRESAS-CONVENIOS_TODOS" },
                    { "6d8717fd-2ef7-4b01-9302-a5b6e083e0e7", "5450a7ae-ed7e-4b72-83b8-945104beed34", "Empresas_Todos", "EMPRESAS_TODOS" },
                    { "99f6b971-2602-4afb-a9cb-1cec1e7d16fd", "f82753c8-86ab-4ee8-85e7-19b357d03eda", "Detentos_Todos", "DETENTOS_TODOS" },
                    { "ef60969b-dc27-44dc-b0a8-3c03a522ec64", "434a6e92-e432-430c-9587-36656d74f85c", "Dashboard_Todos", "DASHBOARD_TODOS" },
                    { "b3a5b61d-7ff4-43cb-bad4-a945b150fc72", "194c8eaf-4f2e-4d0e-9b45-ab664a763c1e", "Usuarios_Todos", "USUARIOS_TODOS" },
                    { "e2c6ef91-aa5a-4f30-857c-bd94db0ab240", "a709e158-cc19-4db2-8bdb-750e5b3d727f", "Colaboradores_Todos", "COLABORADORES_TODOS" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "UserId", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "ca431822-360a-4ee6-b978-66564d429fc7", null, false, false, null, null, "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEFGbgHKOKiDDs5fvXN8kHviorntHToMKurnVJNmsFQNInxhQOyZTwJ2w0SpbyCdZbA==", null, false, "c9514850-61dd-4cc1-b909-88b79b035643", false, "admin@gmail.com" },
                    { "1e526008-75f7-4a01-9942-d178f2b38888", 0, "e627e3a3-d53a-4fc9-a87c-32e9ce8e1218", null, false, false, null, null, "SISTEMA@GMAIL.COM", "AQAAAAEAACcQAAAAEIW3u0VBTe5BgtXxXDBTs9pxnSdIslsYrAK8y9P4a3S6pT1cmvrWZMX6owmy7TmeAA==", null, false, "e90e63a1-e27d-4394-aa4f-3e2b0bbb9f90", false, "sistema@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Detentos",
                columns: new[] { "Id", "Cela", "Cpf", "CreatedAt", "CreatedBy", "Galeria", "Ipen", "IsDeleted", "IsProvisorio", "IsSaidaTemporaria", "MatriculaFamiliar", "Nascimento", "Nome", "NomeFamiliar", "Pec", "RetornoSaidaTemporaria", "Rg", "SaidaTemporaria", "Situacao", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"), 2, null, new DateTime(2021, 12, 3, 10, 38, 32, 976, DateTimeKind.Local).AddTicks(7963), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), "A", 123456, false, false, true, "000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Detento 1", "Maria de Lourdes", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2021, 12, 3, 10, 38, 32, 977, DateTimeKind.Local).AddTicks(5481), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") },
                    { new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"), 10, null, new DateTime(2021, 12, 3, 10, 38, 32, 977, DateTimeKind.Local).AddTicks(6134), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), "D", 234567, false, true, false, "000002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Detento 2", "Carlos Amarildo de Souza", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2021, 12, 3, 10, 38, 32, 977, DateTimeKind.Local).AddTicks(6155), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") }
                });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "Id", "Bairro", "Cep", "Cidade", "Cnpj", "CreatedAt", "CreatedBy", "Email", "Estado", "IsDeleted", "Logradouro", "NomeFantasia", "Numero", "RazaoSocial", "Responsavel", "TelefoneCelular", "TelefoneFixo", "UpdatedAt", "UpdatedBy", "WhatsApp" },
                values: new object[,]
                {
                    { new Guid("00e08a3e-da29-4493-8786-65c67a98970f"), "Comerciário", 12345678, "Criciúma", 12345678912345L, new DateTime(2021, 12, 3, 10, 38, 32, 980, DateTimeKind.Local).AddTicks(7706), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), null, "Santa Catarina", false, "Rua teste", "RBX", "10", "RBX Alimentos", "João da silva", "12345678912345", "12345678912345", new DateTime(2021, 12, 3, 10, 38, 32, 980, DateTimeKind.Local).AddTicks(7723), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), "12345678912345" },
                    { new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"), "Urussanguinha", 12345678, "Urussanga", 12345678912345L, new DateTime(2021, 12, 3, 10, 38, 32, 980, DateTimeKind.Local).AddTicks(7834), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), null, "Santa Catarina", false, "Rua teste", "ESAF", "20", "ESAF Ferragens", "Geraldo Fornazza", "12345678912345", "12345678912345", new DateTime(2021, 12, 3, 10, 38, 32, 980, DateTimeKind.Local).AddTicks(7838), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), "12345678912345" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "2c5e174e-3b0e-446f-86af-483d56fd7210" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "e6b7ff49-350c-4b89-a533-9eb923d8ba1b" },
                    { "1e526008-75f7-4a01-9942-d178f2b38888", "2c5e174e-3b0e-446f-86af-483d56fd7210" }
                });

            migrationBuilder.InsertData(
                table: "EmpresasConvenios",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DataEncerramento", "DataFim", "DataInicio", "EmpresaId", "IsDeleted", "IsRenovacaoAutomatica", "MotivoEncerramento", "Nome", "Responsavel", "Situacao", "TermosGerais", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"), new DateTime(2021, 12, 3, 10, 38, 32, 983, DateTimeKind.Local).AddTicks(6265), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 3, 10, 38, 32, 983, DateTimeKind.Local).AddTicks(4933), new DateTime(2021, 12, 3, 10, 38, 32, 983, DateTimeKind.Local).AddTicks(4636), new Guid("00e08a3e-da29-4493-8786-65c67a98970f"), false, true, null, "Convenio RBX", "Amilton luiz", 1, "Conforme acordado em contrato", new DateTime(2021, 12, 3, 10, 38, 32, 983, DateTimeKind.Local).AddTicks(6277), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") },
                    { new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 3, 10, 38, 32, 983, DateTimeKind.Local).AddTicks(6312), new DateTime(2021, 12, 3, 10, 38, 32, 983, DateTimeKind.Local).AddTicks(6305), new Guid("6ba1a56a-e931-4ccd-baf0-bdf907aa8b61"), false, true, null, "Convenio ESAF", "José luiz datena", 2, "Termos acertados no contrato", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") }
                });

            migrationBuilder.InsertData(
                table: "Colaboradores",
                columns: new[] { "Id", "BancoAgencia", "BancoConta", "BancoNumero", "CreatedAt", "CreatedBy", "DataUltimaSituacao", "Desconto", "DescontoOutro", "DetentoId", "DiaPagamento", "EmpresaConvenioId", "FamiliarAutorizadoRetirada", "IsDeleted", "IsRemunerado", "IsTrabalhoInterno", "JornadaFim", "JornadaInicio", "LocalTrabalho", "Observacao", "Remuneracao", "Situacao", "TipoConta", "TipoPagamento", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"), "897654", "456789", 1, new DateTime(2021, 12, 3, 10, 38, 32, 987, DateTimeKind.Local).AddTicks(7814), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), new DateTime(2021, 12, 3, 10, 38, 32, 987, DateTimeKind.Local).AddTicks(7684), 25m, 33m, new Guid("12fab6de-0f9a-4667-abdf-fe216bb0441f"), 5, new Guid("87f95ebb-8ee3-4585-a0a5-dc230d036a18"), "Teste 1", false, true, false, "14:00", "07:30", "Fábrica do conveniado", "Nenhuma observação 2", 1000.20m, 2, 3, 2, new DateTime(2021, 12, 3, 10, 38, 32, 987, DateTimeKind.Local).AddTicks(7817), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") },
                    { new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"), "654321", "123456", 341, new DateTime(2021, 12, 3, 10, 38, 32, 987, DateTimeKind.Local).AddTicks(7648), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), new DateTime(2021, 12, 3, 10, 38, 32, 987, DateTimeKind.Local).AddTicks(3703), 25m, 33m, new Guid("533ef31e-407a-4da2-a416-53a50ec0da0e"), 10, new Guid("af1f8d4d-6b2d-413d-8407-9ff99537dad5"), "Teste", false, true, true, "17:00", "08:00", "GALERIA", "Nenhuma observação", 1000.20m, 1, 2, 1, new DateTime(2021, 12, 3, 10, 38, 32, 987, DateTimeKind.Local).AddTicks(7656), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") }
                });

            migrationBuilder.InsertData(
                table: "ContasCorrentes",
                columns: new[] { "Id", "ColaboradorId", "CreatedAt", "CreatedBy", "DataUltimoStatus", "IsDeleted", "Numero", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("7c656707-a8e5-41ac-be05-4b03ea5c1692"), new Guid("08adda92-d549-4065-a9c1-14b1adc26ea8"), new DateTime(2021, 12, 3, 10, 38, 32, 990, DateTimeKind.Local).AddTicks(3491), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), new DateTime(2021, 12, 3, 10, 38, 32, 990, DateTimeKind.Local).AddTicks(3471), false, 123456, 1, new DateTime(2021, 12, 3, 10, 38, 32, 990, DateTimeKind.Local).AddTicks(3494), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") },
                    { new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"), new Guid("a8cf3741-5bad-49ef-9e94-0e2dbb48ab3a"), new DateTime(2021, 12, 3, 10, 38, 32, 990, DateTimeKind.Local).AddTicks(3138), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), new DateTime(2021, 12, 3, 10, 38, 32, 990, DateTimeKind.Local).AddTicks(2630), false, 234567, 1, new DateTime(2021, 12, 3, 10, 38, 32, 990, DateTimeKind.Local).AddTicks(3150), new Guid("1e526008-75f7-4a01-9942-d178f2b38888") }
                });

            migrationBuilder.InsertData(
                table: "Lancamentos",
                columns: new[] { "Id", "ContaCorrenteId", "CreatedAt", "CreatedBy", "DataLiquidacao", "DataUltimoStatus", "Desconto", "Descricao", "IsDeleted", "Observacao", "PeriodoDataFim", "PeriodoDataInicio", "PeriodoReferencia", "Status", "Tipo", "UpdatedAt", "UpdatedBy", "ValorBruto", "ValorLiquido" },
                values: new object[,]
                {
                    { new Guid("0af820ce-7131-45de-a98d-947f972c2a84"), new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"), new DateTime(2021, 12, 3, 10, 38, 32, 992, DateTimeKind.Local).AddTicks(3283), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), new DateTime(2021, 12, 3, 10, 38, 32, 992, DateTimeKind.Local).AddTicks(909), new DateTime(2021, 12, 3, 10, 38, 32, 992, DateTimeKind.Local).AddTicks(2347), 100.25m, "Pagamento mensal 1", false, "Informações teste registro 1", 31, 1, 1, 1, 1, new DateTime(2021, 12, 3, 10, 38, 32, 992, DateTimeKind.Local).AddTicks(3295), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), 1000.20m, 900.10m },
                    { new Guid("f9ccef5e-d217-485f-91de-97cd93efca3a"), new Guid("f2358763-f076-4178-8f40-c24eeadf3e96"), new DateTime(2021, 12, 3, 10, 38, 32, 992, DateTimeKind.Local).AddTicks(3646), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), new DateTime(2021, 12, 3, 10, 38, 32, 992, DateTimeKind.Local).AddTicks(3560), new DateTime(2021, 12, 3, 10, 38, 32, 992, DateTimeKind.Local).AddTicks(3598), 255.70m, "Pagamento mensal 2", false, "Informações teste registro 2", 31, 1, 4, 2, 1, new DateTime(2021, 12, 3, 10, 38, 32, 992, DateTimeKind.Local).AddTicks(3649), new Guid("1e526008-75f7-4a01-9942-d178f2b38888"), 1000.20m, 600.44m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_DetentoId",
                table: "Colaboradores",
                column: "DetentoId",
                unique: true,
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_EmpresaConvenioId",
                table: "Colaboradores",
                column: "EmpresaConvenioId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_ContasCorrentes_ColaboradorId",
                table: "ContasCorrentes",
                column: "ColaboradorId",
                unique: true,
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_ContasCorrentes_Numero",
                table: "ContasCorrentes",
                column: "Numero");

            migrationBuilder.CreateIndex(
                name: "IX_ContaUsuarios_UserId",
                table: "ContaUsuarios",
                column: "UserId",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_EmpresasConvenios_EmpresaId",
                table: "EmpresasConvenios",
                column: "EmpresaId",
                filter: "\"IsDeleted\"='0'");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_ContaCorrenteId",
                table: "Lancamentos",
                column: "ContaCorrenteId",
                filter: "\"IsDeleted\"='0'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ContaUsuarios");

            migrationBuilder.DropTable(
                name: "Lancamentos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ContasCorrentes");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Detentos");

            migrationBuilder.DropTable(
                name: "EmpresasConvenios");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
