using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Shipment_Agent.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientAuths",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NAME = table.Column<string>(nullable: true),
                    HASH = table.Column<string>(nullable: true),
                    SALT = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAuths", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    ShipmentID = table.Column<string>(nullable: false),
                    ClientID = table.Column<int>(nullable: false),
                    ClientReference1 = table.Column<int>(nullable: false),
                    ClientReference2 = table.Column<int>(nullable: false),
                    ClientReference3 = table.Column<int>(nullable: false),
                    PickupCountry = table.Column<string>(nullable: true),
                    PickupCity = table.Column<string>(nullable: true),
                    PickupAddress = table.Column<string>(nullable: true),
                    PickupZip = table.Column<string>(nullable: true),
                    PickupCompany = table.Column<string>(nullable: true),
                    PickupName = table.Column<string>(nullable: true),
                    PickupPhone = table.Column<string>(nullable: true),
                    PickupReference = table.Column<string>(nullable: true),
                    PickupInstructions = table.Column<string>(nullable: true),
                    DestinationCountry = table.Column<string>(nullable: true),
                    DestinationCity = table.Column<string>(nullable: true),
                    DestinationAddress = table.Column<string>(nullable: true),
                    DestinationZip = table.Column<string>(nullable: true),
                    DestinationCompany = table.Column<string>(nullable: true),
                    DestinationName = table.Column<string>(nullable: true),
                    DestinationPhone = table.Column<string>(nullable: true),
                    DestinationReference = table.Column<string>(nullable: true),
                    DestinationInstructions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.ShipmentID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientAuths");

            migrationBuilder.DropTable(
                name: "Shipments");
        }
    }
}
