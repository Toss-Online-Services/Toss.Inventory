using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Catalog.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedProd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedOnUtc",
                table: "Products",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                table: "Products",
                newName: "Created");

            migrationBuilder.AddColumn<bool>(
                name: "LimitedToStores",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SubjectToAcl",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LimitedToStores",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubjectToAcl",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "Products",
                newName: "UpdatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Products",
                newName: "CreatedOnUtc");
        }
    }
}
