using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiapTechChallenge.API.Migrations
{
    /// <inheritdoc />
    public partial class Conta_cpf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Conta",
                type: "VARCHAR(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CPF",
                table: "Conta",
                type: "INT",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "VARCHAR(11)",
                oldNullable: true);
        }
    }
}
