using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Catalog.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OwnedProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ComplianceAndStandards_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DownloadableProduct_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GiftCard_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Inventory_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Lifecycle_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RecurringProduct_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RentalProduct_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Shipping_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Tax_Id",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Availability_Id",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComplianceAndStandards_Id",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DownloadableProduct_Id",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GiftCard_Id",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Inventory_Id",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Lifecycle_Id",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price_Id",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecurringProduct_Id",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RentalProduct_Id",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Shipping_Id",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tax_Id",
                table: "Products",
                type: "integer",
                nullable: true);
        }
    }
}
