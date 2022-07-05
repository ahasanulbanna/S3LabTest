﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Problem2.Database;

namespace Problem2.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210329155800_UpdateReadingTable")]
    partial class UpdateReadingTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Problem2.Database.Model.Building", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Building");
                });

            modelBuilder.Entity("Problem2.Database.Model.DataField", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("DataField");
                });

            modelBuilder.Entity("Problem2.Database.Model.Objects", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Object");
                });

            modelBuilder.Entity("Problem2.Database.Model.Reading", b =>
                {
                    b.Property<short>("BuildingId")
                        .HasColumnType("smallint");

                    b.Property<byte>("DataFieldId")
                        .HasColumnType("tinyint");

                    b.Property<byte>("ObjectId")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("Reading");
                });
#pragma warning restore 612, 618
        }
    }
}
