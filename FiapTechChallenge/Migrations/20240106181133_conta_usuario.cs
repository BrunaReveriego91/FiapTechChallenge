using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiapTechChallenge.API.Migrations
{
    /// <inheritdoc />
    public partial class conta_usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Usuario_UsuarioId",
                table: "Conta");

            migrationBuilder.DropIndex(
                name: "IX_Conta_UsuarioId",
                table: "Conta");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Conta");

            migrationBuilder.AddColumn<int>(
                name: "ContaId",
                table: "Usuario",
                type: "INT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdConta",
                table: "Usuario",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                table: "Conta",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ContaId", "IdConta" },
                values: new object[] { null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ContaId",
                table: "Usuario",
                column: "ContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Conta_ContaId",
                table: "Usuario",
                column: "ContaId",
                principalTable: "Conta",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Conta_ContaId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_ContaId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdConta",
                table: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                table: "Conta",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Conta",
                type: "INT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conta_UsuarioId",
                table: "Conta",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_Usuario_UsuarioId",
                table: "Conta",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }
    }
}
