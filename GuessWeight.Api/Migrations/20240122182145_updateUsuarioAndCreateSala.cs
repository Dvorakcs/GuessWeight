using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuessWeight.Api.Migrations
{
    /// <inheritdoc />
    public partial class updateUsuarioAndCreateSala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalaId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalaId",
                table: "Usuarios");
        }
    }
}
