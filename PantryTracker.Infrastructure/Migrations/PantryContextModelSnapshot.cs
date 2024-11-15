﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PantryTracker.Infrastructure;

#nullable disable

namespace PantryTracker.Infrastructure.Migrations
{
    [DbContext(typeof(PantryContext))]
    partial class PantryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("PantryTracker.Core.Models.FoodItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StorageLocation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FoodItems");
                });

            modelBuilder.Entity("PantryTracker.Core.Models.NutritionalInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Calories")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Carbohydrates")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Fat")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FoodItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Protein")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FoodItemId")
                        .IsUnique();

                    b.ToTable("NutritionalInfo");
                });

            modelBuilder.Entity("PantryTracker.Core.Models.NutritionalInfo", b =>
                {
                    b.HasOne("PantryTracker.Core.Models.FoodItem", "FoodItem")
                        .WithOne("NutritionalInfo")
                        .HasForeignKey("PantryTracker.Core.Models.NutritionalInfo", "FoodItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodItem");
                });

            modelBuilder.Entity("PantryTracker.Core.Models.FoodItem", b =>
                {
                    b.Navigation("NutritionalInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
