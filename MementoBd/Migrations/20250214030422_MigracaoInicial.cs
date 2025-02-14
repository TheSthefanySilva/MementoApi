using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MementoBd.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Usuario_UsuarioId",
                table: "Categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_Lista_Usuario_UsuarioId",
                table: "Lista");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Categoria_UsuarioId",
                table: "Tarefa");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Lista_UsuarioId",
                table: "Tarefa");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Usuario_UsuarioId",
                table: "Categoria",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lista_Usuario_UsuarioId",
                table: "Lista",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Categoria_UsuarioId",
                table: "Tarefa",
                column: "UsuarioId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Lista_UsuarioId",
                table: "Tarefa",
                column: "UsuarioId",
                principalTable: "Lista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Usuario_UsuarioId",
                table: "Categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_Lista_Usuario_UsuarioId",
                table: "Lista");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Categoria_UsuarioId",
                table: "Tarefa");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Lista_UsuarioId",
                table: "Tarefa");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Usuario_UsuarioId",
                table: "Categoria",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lista_Usuario_UsuarioId",
                table: "Lista",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Categoria_UsuarioId",
                table: "Tarefa",
                column: "UsuarioId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Lista_UsuarioId",
                table: "Tarefa",
                column: "UsuarioId",
                principalTable: "Lista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
