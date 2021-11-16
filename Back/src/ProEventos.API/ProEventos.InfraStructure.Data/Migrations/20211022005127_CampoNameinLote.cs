using Microsoft.EntityFrameworkCore.Migrations;

namespace ProEventos.InfraStructure.Data.Migrations
{
    public partial class CampoNameinLote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Lotes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Lotes");
        }
    }
}
