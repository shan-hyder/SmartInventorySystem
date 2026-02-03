using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartInventorySystem.Migrations
{
    /// <inheritdoc />
    public partial class ProductEntityUpdateRemoveqty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Products_Productid",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_Productid",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Productid",
                table: "Stocks",
                newName: "ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Stocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Products_ProductId",
                table: "Stocks",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Products_ProductId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Stocks",
                newName: "Productid");

            migrationBuilder.AlterColumn<int>(
                name: "Productid",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Productid",
                table: "Stocks",
                column: "Productid");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Products_Productid",
                table: "Stocks",
                column: "Productid",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
