﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleCatalog.Data;

#nullable disable

namespace VehicleCatalog.Migrations
{
    [DbContext(typeof(VehicleCatalogDataContext))]
    [Migration("20231218210950_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VehicleCatalog.Models.VehicleMake", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Abrv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("VehicleCatalog.Models.VehicleModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Abrv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MakeIDID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MakeIDID");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("VehicleCatalog.Models.VehicleModel", b =>
                {
                    b.HasOne("VehicleCatalog.Models.VehicleMake", "MakeID")
                        .WithMany("Vehicles")
                        .HasForeignKey("MakeIDID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MakeID");
                });

            modelBuilder.Entity("VehicleCatalog.Models.VehicleMake", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}