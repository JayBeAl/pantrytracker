using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PantryTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProductCache : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCache",
                columns: table => new
                {
                    Barcode = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    ServingSize = table.Column<string>(type: "TEXT", nullable: false),
                    EnergyKcal = table.Column<decimal>(type: "TEXT", nullable: true),
                    Proteins = table.Column<decimal>(type: "TEXT", nullable: true),
                    Carbohydrates = table.Column<decimal>(type: "TEXT", nullable: true),
                    Fat = table.Column<decimal>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCache", x => x.Barcode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCache");
        }
    }
}
