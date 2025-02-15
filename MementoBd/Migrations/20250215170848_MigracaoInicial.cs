using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MementoBd.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    Senha = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "Datetime", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "Varchar(500)", maxLength: 500, nullable: false),
                    UsuarioId = table.Column<int>(type: "Int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "Datetime", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categoria_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "Varchar(500)", maxLength: 500, nullable: false),
                    UsuarioId = table.Column<int>(type: "Int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "Datetime", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lista_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "Varchar(500)", maxLength: 500, nullable: false),
                    UsuarioId = table.Column<int>(type: "Int", nullable: false),
                    DataLimite = table.Column<DateTime>(type: "Datetime", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "Datetime", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefa_Categoria_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tarefa_Lista_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Lista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_UsuarioId",
                table: "Categoria",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Lista_UsuarioId",
                table: "Lista",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_UsuarioId",
                table: "Tarefa",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Lista");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
