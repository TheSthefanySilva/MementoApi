using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MementoBd.Migrations
{
    public partial class CorrigindoTarefa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Categoria_UsuarioId",
                table: "Tarefa");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Lista_UsuarioId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_UsuarioId",
                table: "Tarefa");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Tarefa",
                newName: "Prioridade");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Tarefa",
                newName: "Titulo");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Tarefa",
                type: "Int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ListaId",
                table: "Tarefa",
                type: "Int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Tarefa",
                type: "Varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_CategoriaId",
                table: "Tarefa",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_ListaId",
                table: "Tarefa",
                column: "ListaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Categoria_CategoriaId",
                table: "Tarefa",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Lista_ListaId",
                table: "Tarefa",
                column: "ListaId",
                principalTable: "Lista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Categoria_CategoriaId",
                table: "Tarefa");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Lista_ListaId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_CategoriaId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_ListaId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "ListaId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tarefa");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Tarefa",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Prioridade",
                table: "Tarefa",
                newName: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_UsuarioId",
                table: "Tarefa",
                column: "UsuarioId");

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
    }
}
