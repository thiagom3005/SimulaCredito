using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimulaCredito.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoFinanciamento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Taxa = table.Column<double>(type: "float", nullable: false),
                    ValorMin = table.Column<double>(type: "float", nullable: false),
                    ValorMax = table.Column<double>(type: "float", nullable: false),
                    QtdMinParcelas = table.Column<int>(type: "int", nullable: false),
                    QtdMaxParcelas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoFinanciamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Financiamento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorTotal = table.Column<double>(type: "float", nullable: false),
                    UltimoVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTotalJuros = table.Column<double>(type: "float", nullable: false),
                    TotalJuros = table.Column<double>(type: "float", nullable: false),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false),
                    TipoFinanciamentoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financiamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Financiamento_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Financiamento_TipoFinanciamento_TipoFinanciamentoId",
                        column: x => x.TipoFinanciamentoId,
                        principalTable: "TipoFinanciamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Parcela",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroParcela = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ParcelamentoId = table.Column<long>(type: "bigint", nullable: false),
                    parcelaId = table.Column<long>(type: "bigint", nullable: false),
                    FinanciamentoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcela_Financiamento_FinanciamentoId",
                        column: x => x.FinanciamentoId,
                        principalTable: "Financiamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Parcela_Parcela_parcelaId",
                        column: x => x.parcelaId,
                        principalTable: "Parcela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Financiamento_ClienteId",
                table: "Financiamento",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Financiamento_TipoFinanciamentoId",
                table: "Financiamento",
                column: "TipoFinanciamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcela_FinanciamentoId",
                table: "Parcela",
                column: "FinanciamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcela_parcelaId",
                table: "Parcela",
                column: "parcelaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcela");

            migrationBuilder.DropTable(
                name: "Financiamento");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "TipoFinanciamento");
        }
    }
}
