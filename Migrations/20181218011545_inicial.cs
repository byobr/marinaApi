using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webApiMarina.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoriaAlimentos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nomeCategoria = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriaAlimentos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: false),
                    dataNascimento = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    endereco = table.Column<string>(nullable: false),
                    telefoneResidencial = table.Column<string>(nullable: true),
                    telefoneComercial = table.Column<string>(nullable: true),
                    telefoneCelular = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "consultas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    clienteid = table.Column<int>(nullable: true),
                    dataHora = table.Column<DateTime>(nullable: false),
                    peso = table.Column<double>(nullable: false),
                    porcentualGordura = table.Column<double>(nullable: false),
                    sensacaoFisica = table.Column<string>(maxLength: 150, nullable: true),
                    restricoesAlimentares = table.Column<string>(nullable: true),
                    metaCalorias = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consultas", x => x.id);
                    table.ForeignKey(
                        name: "FK_consultas_clientes_clienteid",
                        column: x => x.clienteid,
                        principalTable: "clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "consultaAlimentos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    consultaid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consultaAlimentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_consultaAlimentos_consultas_consultaid",
                        column: x => x.consultaid,
                        principalTable: "consultas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "alimentos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(maxLength: 120, nullable: false),
                    calorias = table.Column<int>(nullable: false),
                    categoriaid = table.Column<int>(nullable: false),
                    ConsultaAlimentosid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alimentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_alimentos_consultaAlimentos_ConsultaAlimentosid",
                        column: x => x.ConsultaAlimentosid,
                        principalTable: "consultaAlimentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_alimentos_categoriaAlimentos_categoriaid",
                        column: x => x.categoriaid,
                        principalTable: "categoriaAlimentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alimentos_ConsultaAlimentosid",
                table: "alimentos",
                column: "ConsultaAlimentosid");

            migrationBuilder.CreateIndex(
                name: "IX_alimentos_categoriaid",
                table: "alimentos",
                column: "categoriaid");

            migrationBuilder.CreateIndex(
                name: "IX_consultaAlimentos_consultaid",
                table: "consultaAlimentos",
                column: "consultaid");

            migrationBuilder.CreateIndex(
                name: "IX_consultas_clienteid",
                table: "consultas",
                column: "clienteid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alimentos");

            migrationBuilder.DropTable(
                name: "consultaAlimentos");

            migrationBuilder.DropTable(
                name: "categoriaAlimentos");

            migrationBuilder.DropTable(
                name: "consultas");

            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
