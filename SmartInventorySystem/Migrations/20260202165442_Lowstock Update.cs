using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartInventorySystem.Migrations
{
    /// <inheritdoc />
    public partial class LowstockUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LowStockThreshold",
                table: "Products",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LowStockThreshold",
                table: "Products");
        }
    }
}
