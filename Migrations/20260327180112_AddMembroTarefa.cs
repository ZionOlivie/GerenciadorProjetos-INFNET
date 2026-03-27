using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorProjetos.Migrations
{
    /// <inheritdoc />
    public partial class AddMembroTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MembroResponsavelId",
                table: "Tarefas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_MembroResponsavelId",
                table: "Tarefas",
                column: "MembroResponsavelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios_MembroResponsavelId",
                table: "Tarefas",
                column: "MembroResponsavelId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios_MembroResponsavelId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_MembroResponsavelId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "MembroResponsavelId",
                table: "Tarefas");
        }
    }
}
