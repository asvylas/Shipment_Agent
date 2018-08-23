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

            modelBuilder.Entity("Shipment_Agent.Models.ClientAuth", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20);

                    b.Property<string>("HASH")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("SALT")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("ID");

                    b.HasIndex("NAME")
                        .IsUnique();

                    b.ToTable("ClientAuths");
                });

            modelBuilder.Entity("Shipment_Agent.Models.Shipment", b =>
                {
                    b.Property<string>("ShipmentID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(256);

                    b.Property<int>("ClientID");

                    b.Property<int>("ClientReference1");

                    b.Property<int>("ClientReference2");

                    b.Property<int>("ClientReference3");

                    b.Property<string>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("DestinationAddress")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("DestinationCity")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("DestinationCompany")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("DestinationCountry")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("DestinationInstructions")
                        .HasMaxLength(40);

                    b.Property<string>("DestinationName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("DestinationPhone")
                        .HasMaxLength(40);

                    b.Property<string>("DestinationReference")
                        .HasMaxLength(40);

                    b.Property<string>("DestinationZip")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("PickupAddress")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("PickupCity")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("PickupCompany")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("PickupCountry")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("PickupInstructions")
                        .HasMaxLength(40);

                    b.Property<string>("PickupName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("PickupPhone")
                        .HasMaxLength(40);

                    b.Property<string>("PickupReference")
                        .HasMaxLength(40);

                    b.Property<string>("PickupZip")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("ShipmentID");

                    b.ToTable("Shipments");
                });
#pragma warning restore 612, 618
        }
    }
}
