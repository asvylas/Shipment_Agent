using Microsoft.EntityFrameworkCore.Migrations;

namespace Shipment_Agent.Migrations
{
    public partial class ClientandShipmentChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ClientAuths",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ClientAuths");
        }
    }
}
