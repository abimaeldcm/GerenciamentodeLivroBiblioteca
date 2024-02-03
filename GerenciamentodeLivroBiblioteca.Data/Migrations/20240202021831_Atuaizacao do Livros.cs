using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentodeLivroBiblioteca.Infra.Data.Migrations
{
    public partial class AtuaizacaodoLivros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Livros_LivroId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_LivroId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "LivroId",
                table: "Usuarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LivroId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_LivroId",
                table: "Usuarios",
                column: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Livros_LivroId",
                table: "Usuarios",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id");
        }
    }
}
