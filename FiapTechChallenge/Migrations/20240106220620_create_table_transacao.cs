using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiapTechChallenge.API.Migrations
{
    /// <inheritdoc />
    public partial class create_table_transacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtivoSimbolo = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Quantidade = table.Column<int>(type: "INT", nullable: false),
                    PrecoCompra = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    DataTransacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    TipoTransacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_UsuarioId",
                table: "Transacao",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacao");
        }
    }
}
