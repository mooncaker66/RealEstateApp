﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstateApp.Entities;

namespace RealEstateApp.Migrations
{
    [DbContext(typeof(RealEstateDbContext))]
    partial class RealEstateDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RealEstateApp.Entities.House", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Baths")
                        .HasColumnType("int");

                    b.Property<int>("Beds")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasBasement")
                        .HasColumnType("bit");

                    b.Property<bool>("HasParking")
                        .HasColumnType("bit");

                    b.Property<bool>("HasPool")
                        .HasColumnType("bit");

                    b.Property<string>("PropertyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SquareFeet")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearBuilt")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Houses");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Baths = 2,
                            Beds = 3,
                            City = "tampa",
                            HasBasement = false,
                            HasParking = true,
                            HasPool = true,
                            PropertyType = "condo",
                            SquareFeet = 3000,
                            State = "FL",
                            Street = "1234 low St",
                            YearBuilt = 1996,
                            ZipCode = "33510"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}