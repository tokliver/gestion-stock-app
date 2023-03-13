using Microsoft.EntityFrameworkCore.Migrations;

namespace TickLive.Infrastructure.Data.Migrations
{
    public partial class init_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PrixVenteUnitaire",
                table: "Articles",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrixVenteUnitaire",
                table: "Articles");
        }
    }
}
