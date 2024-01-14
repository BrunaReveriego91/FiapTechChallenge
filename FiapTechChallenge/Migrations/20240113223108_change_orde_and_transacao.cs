using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FiapTechChallenge.API.Migrations
{
    /// <inheritdoc />
    public partial class change_orde_and_transacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordem");

            migrationBuilder.DropColumn(
                name: "AtivoSimbolo",
                table: "Transacao");

            migrationBuilder.AddColumn<int>(
                name: "OrdemId",
                table: "Transacao",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Transacao",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Ordem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Simbolo = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    Nome = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    TipoOrdem = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordem", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Ordem",
                columns: new[] { "Id", "Nome", "Simbolo", "TipoOrdem" },
                values: new object[,]
                {
                    { 1, "Agilent", "A", "NYSE" },
                    { 2, "International Business Machines Corp", "IBM", "NYSE" },
                    { 3, "iShares iBonds Dec 2024 Term Muni Bond ETF", "IBMM", "BATS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_OrdemId",
                table: "Transacao",
                column: "OrdemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacao_Ordem_OrdemId",
                table: "Transacao",
                column: "OrdemId",
                principalTable: "Ordem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacao_Ordem_OrdemId",
                table: "Transacao");

            migrationBuilder.DropTable(
                name: "Ordem");

            migrationBuilder.DropIndex(
                name: "IX_Transacao_OrdemId",
                table: "Transacao");

            migrationBuilder.DropColumn(
                name: "OrdemId",
                table: "Transacao");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transacao");

            migrationBuilder.AddColumn<string>(
                name: "AtivoSimbolo",
                table: "Transacao",
                type: "VARCHAR(100)",
                nullable: true);
            migrationBuilder.CreateTable(
                name: "Ordem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoOrdem = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordem", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Ordem",
                columns: new[] { "Id", "Quantidade", "TipoOrdem" },
                values: new object[,]
                {
                    { 1, 99, "A Mercado" },
                    { 2, 49, "StartStop" }
                });
        }
    }
}
