using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiapTechChallenge.API.Migrations
{
    /// <inheritdoc />
    public partial class conta_usuario_07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Conta_ContaId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_ContaId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdConta",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Conta");

            migrationBuilder.AlterColumn<int>(
                name: "ContaId",
                table: "Usuario",
                type: "INT",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "ContaId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ContaId",
                table: "Usuario",
                column: "ContaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Conta_ContaId",
                table: "Usuario",
                column: "ContaId",
                principalTable: "Conta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AlterColumn<int>(
                name: "ContaId",
                table: "Usuario",
                type: "INT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AddColumn<int>(
                name: "IdConta",
                table: "Usuario",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Conta",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
