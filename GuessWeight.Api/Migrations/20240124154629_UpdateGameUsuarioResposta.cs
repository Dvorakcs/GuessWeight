using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuessWeight.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGameUsuarioResposta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Resposta",
                table: "UsuarioRepostasPeso",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "ObjetoPeso",
                table: "Games",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Finaliza",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioWinNome",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finaliza",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UsuarioWinNome",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "Resposta",
                table: "UsuarioRepostasPeso",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "ObjetoPeso",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
