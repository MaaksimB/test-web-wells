﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebWellsMVC.WellDb.DBContext;

#nullable disable

namespace WebWellsMVC.Migrations
{
    [DbContext(typeof(WellsDbContext))]
    [Migration("20241030232600_WellDb_V0")]
    partial class WellDb_V0
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebWellsMVC.WellDb.DbModels.Users", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_Users");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebWellsMVC.WellDb.DbModels.Wells", b =>
                {
                    b.Property<int>("UWI")
                        .HasColumnType("int")
                        .HasColumnName("UWI");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UWI"));

                    b.Property<string>("Bush")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UWI")
                        .HasName("PK_Wells");

                    b.ToTable("Wells");

                    b.HasData(
                        new
                        {
                            UWI = 1,
                            Bush = "Первый куст",
                            Date = new DateTime(2022, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified),
                            Name = "Скважина_001",
                            OpMethod = "фонтанный",
                            Stage = "эксплуатация",
                            Type = "газовая"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
