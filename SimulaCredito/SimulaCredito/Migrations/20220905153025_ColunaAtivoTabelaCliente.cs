using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimulaCredito.Migrations
{
    public partial class ColunaAtivoTabelaCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Cliente",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Cliente");
        }
    }
}
