using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PantryTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEnergyToNutritionalInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Protein",
                table: "NutritionalInfo",
                newName: "Proteins");

            migrationBuilder.RenameColumn(
                name: "Calories",
                table: "NutritionalInfo",
                newName: "Energy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Proteins",
                table: "NutritionalInfo",
                newName: "Protein");

            migrationBuilder.RenameColumn(
                name: "Energy",
                table: "NutritionalInfo",
                newName: "Calories");
        }
    }
}
