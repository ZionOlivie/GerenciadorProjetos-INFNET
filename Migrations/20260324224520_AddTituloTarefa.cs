using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorProjetos.Migrations
{
    /// <inheritdoc />
    public partial class AddTituloTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Tarefas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Tarefas");
        }
    }
}
