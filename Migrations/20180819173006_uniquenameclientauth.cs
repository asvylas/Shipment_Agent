using Microsoft.EntityFrameworkCore.Migrations;

namespace Shipment_Agent.Migrations
{
    public partial class uniquenameclientauth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ClientAuths_NAME",
                table: "ClientAuths",
                column: "NAME",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClientAuths_NAME",
                table: "ClientAuths");
        }
    }
}
