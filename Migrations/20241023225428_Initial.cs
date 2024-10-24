using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalaxyControl.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "nave",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    codigo_rastreio = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_encontro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tamanho = table.Column<int>(type: "int", nullable: false),
                    cor = table.Column<int>(type: "int", nullable: false),
                    tipo_local_queda = table.Column<int>(type: "int", nullable: false),
                    local_queda = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    armamento = table.Column<int>(type: "int", nullable: false),
                    tipo_combustivel = table.Column<int>(type: "int", nullable: false),
                    tripulantes_feridos = table.Column<int>(type: "int", nullable: false),
                    tripulantes_saudaveis = table.Column<int>(type: "int", nullable: false),
                    tripulantes_sem_vida = table.Column<int>(type: "int", nullable: false),
                    grau_avaria = table.Column<int>(type: "int", nullable: false),
                    potencial_prospeccao_tecnologica = table.Column<int>(type: "int", nullable: false),
                    grau_periculosidade = table.Column<int>(type: "int", nullable: false),
                    classificacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nave", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    senha = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_cadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "id", "data_alteracao", "data_cadastro", "email", "nome", "senha" },
                values: new object[] { 1, null, new DateTime(2024, 10, 23, 19, 54, 28, 83, DateTimeKind.Local).AddTicks(4762), "galaxycontrol@outlook.com", "Admin", "7110eda4d09e062aa5e4a390b0a572ac0d2c0220" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nave");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
