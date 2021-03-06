﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModaUltimo.Models;

namespace ModaUltimo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20181006135858_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932");

            modelBuilder.Entity("ModaUltimo.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Desc");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ModaUltimo.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InventoryName");

                    b.Property<DateTime?>("Manufacture_date");

                    b.Property<int>("ProductID");

                    b.Property<int>("Quantity");

                    b.Property<int>("StoreID");

                    b.HasKey("Id");

                    b.HasIndex("ProductID");

                    b.HasIndex("StoreID");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("ModaUltimo.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryID");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<string>("Size");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ModaUltimo.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<DateTime?>("Close_Date");

                    b.Property<DateTime>("Open_date");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<int>("Zip");

                    b.HasKey("Id");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("ModaUltimo.Models.Inventory", b =>
                {
                    b.HasOne("ModaUltimo.Models.Product", "Product")
                        .WithMany("Inventories")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ModaUltimo.Models.Store", "Store")
                        .WithMany("Inventories")
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ModaUltimo.Models.Product", b =>
                {
                    b.HasOne("ModaUltimo.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
