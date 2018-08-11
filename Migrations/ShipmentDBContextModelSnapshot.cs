﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Shipment_Agent.Models;

namespace Shipment_Agent.Migrations
{
    [DbContext(typeof(ShipmentDBContext))]
    partial class ShipmentDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Shipment_Agent.Models.Shipment", b =>
                {
                    b.Property<int>("ShipmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientID");

                    b.Property<int>("ClientReference1");

                    b.Property<int>("ClientReference2");

                    b.Property<int>("ClientReference3");

                    b.Property<string>("DestinationAddress");

                    b.Property<string>("DestinationCity");

                    b.Property<string>("DestinationCompany");

                    b.Property<string>("DestinationCountry");

                    b.Property<string>("DestinationInstructions");

                    b.Property<string>("DestinationName");

                    b.Property<string>("DestinationPhone");

                    b.Property<string>("DestinationReference");

                    b.Property<string>("DestinationZip");

                    b.Property<string>("PickupAddress");

                    b.Property<string>("PickupCity");

                    b.Property<string>("PickupCompany");

                    b.Property<string>("PickupCountry");

                    b.Property<string>("PickupInstructions");

                    b.Property<string>("PickupName");

                    b.Property<string>("PickupPhone");

                    b.Property<string>("PickupReference");

                    b.Property<string>("PickupZip");

                    b.HasKey("ShipmentID");

                    b.ToTable("Shipments");
                });
#pragma warning restore 612, 618
        }
    }
}
