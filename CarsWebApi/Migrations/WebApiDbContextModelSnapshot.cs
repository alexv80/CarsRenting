﻿// <auto-generated />
using System;
using CarsWebApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarsWebApi.Web.Migrations
{
    [DbContext(typeof(WebApiDbContext))]
    partial class WebApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarsWebApi.Database.Model.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Brand")
                        .HasColumnType("int");

                    b.Property<double>("Engine")
                        .HasColumnType("float");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Passengers")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Transmission")
                        .HasColumnType("int");

                    b.Property<int>("TypeEngine")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarsWebApi.Database.Model.Rent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("CarsWebApi.Database.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarsWebApi.Database.Model.Rent", b =>
                {
                    b.HasOne("CarsWebApi.Database.Model.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("CarsWebApi.Database.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Car");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
