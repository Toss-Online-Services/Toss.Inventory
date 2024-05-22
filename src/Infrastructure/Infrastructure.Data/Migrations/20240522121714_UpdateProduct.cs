using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace eShop.Catalog.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountProductMapping");

            migrationBuilder.DropTable(
                name: "ProductPicture");

            migrationBuilder.DropColumn(
                name: "AllowCustomerReviews",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ApprovedRatingSum",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ApprovedTotalReviews",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AutomaticallyAddRequiredProducts",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DisableBuyButton",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DisableWishlistButton",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DisplayStockAvailability",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DisplayStockQuantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Gtin",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HasDiscountsApplied",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HasTierPrices",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LimitedToStores",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ManufacturerPartNumber",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MarkAsNew",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NotApprovedRatingSum",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NotApprovedTotalReviews",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RequireOtherProducts",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RequiredProductIds",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShowOnHomepage",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Sku",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubjectToAcl",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UseMultipleWarehouses",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Width",
                table: "Products",
                newName: "PhysicalAttributes_Width");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Products",
                newName: "PhysicalAttributes_Weight");

            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                table: "Products",
                newName: "Inventory_WarehouseId");

            migrationBuilder.RenameColumn(
                name: "UserAgreementText",
                table: "Products",
                newName: "DownloadableProduct_UserAgreementText");

            migrationBuilder.RenameColumn(
                name: "UnlimitedDownloads",
                table: "Products",
                newName: "DownloadableProduct_UnlimitedDownloads");

            migrationBuilder.RenameColumn(
                name: "TaxCategoryId",
                table: "Products",
                newName: "Tax_TaxCategoryId");

            migrationBuilder.RenameColumn(
                name: "StockQuantity",
                table: "Products",
                newName: "Inventory_StockQuantity");

            migrationBuilder.RenameColumn(
                name: "ShipSeparately",
                table: "Products",
                newName: "Shipping_ShipSeparately");

            migrationBuilder.RenameColumn(
                name: "SampleDownloadId",
                table: "Products",
                newName: "DownloadableProduct_SampleDownloadId");

            migrationBuilder.RenameColumn(
                name: "RentalPricePeriodId",
                table: "Products",
                newName: "RentalProduct_RentalPricePeriodId");

            migrationBuilder.RenameColumn(
                name: "RentalPriceLength",
                table: "Products",
                newName: "RentalProduct_RentalPriceLength");

            migrationBuilder.RenameColumn(
                name: "RecurringTotalCycles",
                table: "Products",
                newName: "RecurringProduct_RecurringTotalCycles");

            migrationBuilder.RenameColumn(
                name: "RecurringCyclePeriodId",
                table: "Products",
                newName: "RecurringProduct_RecurringCyclePeriodId");

            migrationBuilder.RenameColumn(
                name: "RecurringCycleLength",
                table: "Products",
                newName: "RecurringProduct_RecurringCycleLength");

            migrationBuilder.RenameColumn(
                name: "ProductCost",
                table: "Products",
                newName: "Price_ProductCost");

            migrationBuilder.RenameColumn(
                name: "ProductAvailabilityRangeId",
                table: "Products",
                newName: "Availability_ProductAvailabilityRangeId");

            migrationBuilder.RenameColumn(
                name: "PreOrderAvailabilityStartDateTimeUtc",
                table: "Products",
                newName: "Availability_PreOrderAvailabilityStartDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "OverriddenGiftCardAmount",
                table: "Products",
                newName: "GiftCard_OverriddenGiftCardAmount");

            migrationBuilder.RenameColumn(
                name: "OrderMinimumQuantity",
                table: "Products",
                newName: "Inventory_OrderMinimumQuantity");

            migrationBuilder.RenameColumn(
                name: "OrderMaximumQuantity",
                table: "Products",
                newName: "Inventory_OrderMaximumQuantity");

            migrationBuilder.RenameColumn(
                name: "OldPrice",
                table: "Products",
                newName: "Price_OldPrice");

            migrationBuilder.RenameColumn(
                name: "NotifyAdminForQuantityBelow",
                table: "Products",
                newName: "Inventory_NotifyAdminForQuantityBelow");

            migrationBuilder.RenameColumn(
                name: "NotReturnable",
                table: "Products",
                newName: "ComplianceAndStandards_NotReturnable");

            migrationBuilder.RenameColumn(
                name: "MinimumCustomerEnteredPrice",
                table: "Products",
                newName: "Price_MinimumCustomerEnteredPrice");

            migrationBuilder.RenameColumn(
                name: "MinStockQuantity",
                table: "Products",
                newName: "Inventory_MinStockQuantity");

            migrationBuilder.RenameColumn(
                name: "MaximumCustomerEnteredPrice",
                table: "Products",
                newName: "Price_MaximumCustomerEnteredPrice");

            migrationBuilder.RenameColumn(
                name: "MaxNumberOfDownloads",
                table: "Products",
                newName: "DownloadableProduct_MaxNumberOfDownloads");

            migrationBuilder.RenameColumn(
                name: "ManageInventoryMethodId",
                table: "Products",
                newName: "Inventory_ManageInventoryMethodId");

            migrationBuilder.RenameColumn(
                name: "LowStockActivityId",
                table: "Products",
                newName: "Inventory_LowStockActivityId");

            migrationBuilder.RenameColumn(
                name: "Length",
                table: "Products",
                newName: "PhysicalAttributes_Length");

            migrationBuilder.RenameColumn(
                name: "IsTaxExempt",
                table: "Products",
                newName: "Tax_IsTaxExempt");

            migrationBuilder.RenameColumn(
                name: "IsShipEnabled",
                table: "Products",
                newName: "Shipping_IsShipEnabled");

            migrationBuilder.RenameColumn(
                name: "IsRental",
                table: "Products",
                newName: "RentalProduct_IsRental");

            migrationBuilder.RenameColumn(
                name: "IsRecurring",
                table: "Products",
                newName: "RecurringProduct_IsRecurring");

            migrationBuilder.RenameColumn(
                name: "IsGiftCard",
                table: "Products",
                newName: "GiftCard_IsGiftCard");

            migrationBuilder.RenameColumn(
                name: "IsFreeShipping",
                table: "Products",
                newName: "Shipping_IsFreeShipping");

            migrationBuilder.RenameColumn(
                name: "IsDownload",
                table: "Products",
                newName: "DownloadableProduct_IsDownload");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "Products",
                newName: "PhysicalAttributes_Height");

            migrationBuilder.RenameColumn(
                name: "HasUserAgreement",
                table: "Products",
                newName: "DownloadableProduct_HasUserAgreement");

            migrationBuilder.RenameColumn(
                name: "HasSampleDownload",
                table: "Products",
                newName: "DownloadableProduct_HasSampleDownload");

            migrationBuilder.RenameColumn(
                name: "GiftCardTypeId",
                table: "Products",
                newName: "GiftCard_GiftCardTypeId");

            migrationBuilder.RenameColumn(
                name: "DownloadId",
                table: "Products",
                newName: "DownloadableProduct_DownloadId");

            migrationBuilder.RenameColumn(
                name: "DownloadExpirationDays",
                table: "Products",
                newName: "DownloadableProduct_DownloadExpirationDays");

            migrationBuilder.RenameColumn(
                name: "DownloadActivationTypeId",
                table: "Products",
                newName: "DownloadableProduct_DownloadActivationTypeId");

            migrationBuilder.RenameColumn(
                name: "DisplayAttributeCombinationImagesOnly",
                table: "Products",
                newName: "Inventory_DisplayAttributeCombinationImagesOnly");

            migrationBuilder.RenameColumn(
                name: "DeliveryDateId",
                table: "Products",
                newName: "Availability_DeliveryDateId");

            migrationBuilder.RenameColumn(
                name: "CustomerEntersPrice",
                table: "Products",
                newName: "Price_CustomerEntersPrice");

            migrationBuilder.RenameColumn(
                name: "CallForPrice",
                table: "Products",
                newName: "Price_CallForPrice");

            migrationBuilder.RenameColumn(
                name: "BasepriceUnitId",
                table: "Products",
                newName: "Price_BasepriceUnitId");

            migrationBuilder.RenameColumn(
                name: "BasepriceEnabled",
                table: "Products",
                newName: "Price_BasepriceEnabled");

            migrationBuilder.RenameColumn(
                name: "BasepriceBaseUnitId",
                table: "Products",
                newName: "Price_BasepriceBaseUnitId");

            migrationBuilder.RenameColumn(
                name: "BasepriceBaseAmount",
                table: "Products",
                newName: "Price_BasepriceBaseAmount");

            migrationBuilder.RenameColumn(
                name: "BasepriceAmount",
                table: "Products",
                newName: "Price_BasepriceAmount");

            migrationBuilder.RenameColumn(
                name: "BackorderModeId",
                table: "Products",
                newName: "Inventory_BackorderModeId");

            migrationBuilder.RenameColumn(
                name: "AvailableStartDateTimeUtc",
                table: "Products",
                newName: "Availability_AvailableStartDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "AvailableForPreOrder",
                table: "Products",
                newName: "Availability_AvailableForPreOrder");

            migrationBuilder.RenameColumn(
                name: "AvailableEndDateTimeUtc",
                table: "Products",
                newName: "Availability_AvailableEndDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "AllowedQuantities",
                table: "Products",
                newName: "Inventory_AllowedQuantities");

            migrationBuilder.RenameColumn(
                name: "AllowBackInStockSubscriptions",
                table: "Products",
                newName: "Inventory_AllowBackInStockSubscriptions");

            migrationBuilder.RenameColumn(
                name: "AllowAddingOnlyExistingAttributeCombinations",
                table: "Products",
                newName: "Inventory_AllowAddingOnlyExistingAttributeCombinations");

            migrationBuilder.RenameColumn(
                name: "AdditionalShippingCharge",
                table: "Products",
                newName: "Shipping_AdditionalShippingCharge");

            migrationBuilder.RenameColumn(
                name: "MarkAsNewStartDateTimeUtc",
                table: "Products",
                newName: "Lifecycle_ManufactureDate");

            migrationBuilder.RenameColumn(
                name: "MarkAsNewEndDateTimeUtc",
                table: "Products",
                newName: "Lifecycle_ExpirationDate");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Products",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "character varying(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "FullDescription",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(4000)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdminComment",
                table: "Products",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(4000)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PhysicalAttributes_Width",
                table: "Products",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PhysicalAttributes_Weight",
                table: "Products",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Inventory_WarehouseId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "DownloadableProduct_UserAgreementText",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(4000)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "DownloadableProduct_UnlimitedDownloads",
                table: "Products",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "Tax_TaxCategoryId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Inventory_StockQuantity",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "Shipping_ShipSeparately",
                table: "Products",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "DownloadableProduct_SampleDownloadId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "RentalProduct_RentalPricePeriodId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "RentalProduct_RentalPriceLength",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "RecurringProduct_RecurringTotalCycles",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "RecurringProduct_RecurringCyclePeriodId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "RecurringProduct_RecurringCycleLength",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price_ProductCost",
                table: "Products",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Availability_ProductAvailabilityRangeId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "GiftCard_OverriddenGiftCardAmount",
                table: "Products",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Inventory_OrderMinimumQuantity",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Inventory_OrderMaximumQuantity",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price_OldPrice",
                table: "Products",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Inventory_NotifyAdminForQuantityBelow",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "ComplianceAndStandards_NotReturnable",
                table: "Products",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price_MinimumCustomerEnteredPrice",
                table: "Products",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Inventory_MinStockQuantity",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price_MaximumCustomerEnteredPrice",
                table: "Products",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "DownloadableProduct_MaxNumberOfDownloads",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Inventory_ManageInventoryMethodId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Inventory_LowStockActivityId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "PhysicalAttributes_Length",
                table: "Products",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<bool>(
                name: "Tax_IsTaxExempt",
                table: "Products",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "Shipping_IsShipEnabled",
                table: "Products",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "RentalProduct_IsRental",
                table: "Products",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "RecurringProduct_IsRecurring",
                table: "Products",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "GiftCard_IsGiftCard",
                table: "Products",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "Shipping_IsFreeShipping",
                table: "Products",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "DownloadableProduct_IsDownload",
                table: "Products",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<decimal>(
                name: "PhysicalAttributes_Height",
                table: "Products",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<bool>(
                name: "DownloadableProduct_HasUserAgreement",
                table: "Products",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "DownloadableProduct_HasSampleDownload",
                table: "Products",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "GiftCard_GiftCardTypeId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "DownloadableProduct_DownloadId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "DownloadableProduct_DownloadExpirationDays",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "DownloadableProduct_DownloadActivationTypeId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "Inventory_DisplayAttributeCombinationImagesOnly",
                table: "Products",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "Availability_DeliveryDateId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "Price_CustomerEntersPrice",
                table: "Products",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "Price_CallForPrice",
                table: "Products",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "Price_BasepriceUnitId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "Price_BasepriceEnabled",
                table: "Products",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "Price_BasepriceBaseUnitId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price_BasepriceBaseAmount",
                table: "Products",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price_BasepriceAmount",
                table: "Products",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Inventory_BackorderModeId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "Availability_AvailableForPreOrder",
                table: "Products",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "Inventory_AllowedQuantities",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Inventory_AllowBackInStockSubscriptions",
                table: "Products",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "Inventory_AllowAddingOnlyExistingAttributeCombinations",
                table: "Products",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<decimal>(
                name: "Shipping_AdditionalShippingCharge",
                table: "Products",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "Availability_Id",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplianceAndStandards_Certifications",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplianceAndStandards_EnvironmentalImpact",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComplianceAndStandards_Id",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplianceAndStandards_RecyclingInformation",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplianceAndStandards_RegulatoryApprovals",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplianceAndStandards_SafetyInformation",
                table: "Products",
                type: "text",
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

            migrationBuilder.AddColumn<string>(
                name: "Lifecycle_BatchNumber",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Lifecycle_Id",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lifecycle_SerialNumber",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAttributes_Color",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAttributes_Material",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAttributes_PackagingType",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAttributes_Size",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price_CurrentPrice",
                table: "Products",
                type: "numeric",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ComplianceAndStandards_Certifications",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ComplianceAndStandards_EnvironmentalImpact",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ComplianceAndStandards_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ComplianceAndStandards_RecyclingInformation",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ComplianceAndStandards_RegulatoryApprovals",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ComplianceAndStandards_SafetyInformation",
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
                name: "Lifecycle_BatchNumber",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Lifecycle_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Lifecycle_SerialNumber",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PhysicalAttributes_Color",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PhysicalAttributes_Material",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PhysicalAttributes_PackagingType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PhysicalAttributes_Size",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price_CurrentPrice",
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

            migrationBuilder.RenameColumn(
                name: "Tax_TaxCategoryId",
                table: "Products",
                newName: "TaxCategoryId");

            migrationBuilder.RenameColumn(
                name: "Tax_IsTaxExempt",
                table: "Products",
                newName: "IsTaxExempt");

            migrationBuilder.RenameColumn(
                name: "Shipping_ShipSeparately",
                table: "Products",
                newName: "ShipSeparately");

            migrationBuilder.RenameColumn(
                name: "Shipping_IsShipEnabled",
                table: "Products",
                newName: "IsShipEnabled");

            migrationBuilder.RenameColumn(
                name: "Shipping_IsFreeShipping",
                table: "Products",
                newName: "IsFreeShipping");

            migrationBuilder.RenameColumn(
                name: "Shipping_AdditionalShippingCharge",
                table: "Products",
                newName: "AdditionalShippingCharge");

            migrationBuilder.RenameColumn(
                name: "RentalProduct_RentalPricePeriodId",
                table: "Products",
                newName: "RentalPricePeriodId");

            migrationBuilder.RenameColumn(
                name: "RentalProduct_RentalPriceLength",
                table: "Products",
                newName: "RentalPriceLength");

            migrationBuilder.RenameColumn(
                name: "RentalProduct_IsRental",
                table: "Products",
                newName: "IsRental");

            migrationBuilder.RenameColumn(
                name: "RecurringProduct_RecurringTotalCycles",
                table: "Products",
                newName: "RecurringTotalCycles");

            migrationBuilder.RenameColumn(
                name: "RecurringProduct_RecurringCyclePeriodId",
                table: "Products",
                newName: "RecurringCyclePeriodId");

            migrationBuilder.RenameColumn(
                name: "RecurringProduct_RecurringCycleLength",
                table: "Products",
                newName: "RecurringCycleLength");

            migrationBuilder.RenameColumn(
                name: "RecurringProduct_IsRecurring",
                table: "Products",
                newName: "IsRecurring");

            migrationBuilder.RenameColumn(
                name: "Price_ProductCost",
                table: "Products",
                newName: "ProductCost");

            migrationBuilder.RenameColumn(
                name: "Price_OldPrice",
                table: "Products",
                newName: "OldPrice");

            migrationBuilder.RenameColumn(
                name: "Price_MinimumCustomerEnteredPrice",
                table: "Products",
                newName: "MinimumCustomerEnteredPrice");

            migrationBuilder.RenameColumn(
                name: "Price_MaximumCustomerEnteredPrice",
                table: "Products",
                newName: "MaximumCustomerEnteredPrice");

            migrationBuilder.RenameColumn(
                name: "Price_CustomerEntersPrice",
                table: "Products",
                newName: "CustomerEntersPrice");

            migrationBuilder.RenameColumn(
                name: "Price_CallForPrice",
                table: "Products",
                newName: "CallForPrice");

            migrationBuilder.RenameColumn(
                name: "Price_BasepriceUnitId",
                table: "Products",
                newName: "BasepriceUnitId");

            migrationBuilder.RenameColumn(
                name: "Price_BasepriceEnabled",
                table: "Products",
                newName: "BasepriceEnabled");

            migrationBuilder.RenameColumn(
                name: "Price_BasepriceBaseUnitId",
                table: "Products",
                newName: "BasepriceBaseUnitId");

            migrationBuilder.RenameColumn(
                name: "Price_BasepriceBaseAmount",
                table: "Products",
                newName: "BasepriceBaseAmount");

            migrationBuilder.RenameColumn(
                name: "Price_BasepriceAmount",
                table: "Products",
                newName: "BasepriceAmount");

            migrationBuilder.RenameColumn(
                name: "PhysicalAttributes_Width",
                table: "Products",
                newName: "Width");

            migrationBuilder.RenameColumn(
                name: "PhysicalAttributes_Weight",
                table: "Products",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "PhysicalAttributes_Length",
                table: "Products",
                newName: "Length");

            migrationBuilder.RenameColumn(
                name: "PhysicalAttributes_Height",
                table: "Products",
                newName: "Height");

            migrationBuilder.RenameColumn(
                name: "Inventory_WarehouseId",
                table: "Products",
                newName: "WarehouseId");

            migrationBuilder.RenameColumn(
                name: "Inventory_StockQuantity",
                table: "Products",
                newName: "StockQuantity");

            migrationBuilder.RenameColumn(
                name: "Inventory_OrderMinimumQuantity",
                table: "Products",
                newName: "OrderMinimumQuantity");

            migrationBuilder.RenameColumn(
                name: "Inventory_OrderMaximumQuantity",
                table: "Products",
                newName: "OrderMaximumQuantity");

            migrationBuilder.RenameColumn(
                name: "Inventory_NotifyAdminForQuantityBelow",
                table: "Products",
                newName: "NotifyAdminForQuantityBelow");

            migrationBuilder.RenameColumn(
                name: "Inventory_MinStockQuantity",
                table: "Products",
                newName: "MinStockQuantity");

            migrationBuilder.RenameColumn(
                name: "Inventory_ManageInventoryMethodId",
                table: "Products",
                newName: "ManageInventoryMethodId");

            migrationBuilder.RenameColumn(
                name: "Inventory_LowStockActivityId",
                table: "Products",
                newName: "LowStockActivityId");

            migrationBuilder.RenameColumn(
                name: "Inventory_DisplayAttributeCombinationImagesOnly",
                table: "Products",
                newName: "DisplayAttributeCombinationImagesOnly");

            migrationBuilder.RenameColumn(
                name: "Inventory_BackorderModeId",
                table: "Products",
                newName: "BackorderModeId");

            migrationBuilder.RenameColumn(
                name: "Inventory_AllowedQuantities",
                table: "Products",
                newName: "AllowedQuantities");

            migrationBuilder.RenameColumn(
                name: "Inventory_AllowBackInStockSubscriptions",
                table: "Products",
                newName: "AllowBackInStockSubscriptions");

            migrationBuilder.RenameColumn(
                name: "Inventory_AllowAddingOnlyExistingAttributeCombinations",
                table: "Products",
                newName: "AllowAddingOnlyExistingAttributeCombinations");

            migrationBuilder.RenameColumn(
                name: "GiftCard_OverriddenGiftCardAmount",
                table: "Products",
                newName: "OverriddenGiftCardAmount");

            migrationBuilder.RenameColumn(
                name: "GiftCard_IsGiftCard",
                table: "Products",
                newName: "IsGiftCard");

            migrationBuilder.RenameColumn(
                name: "GiftCard_GiftCardTypeId",
                table: "Products",
                newName: "GiftCardTypeId");

            migrationBuilder.RenameColumn(
                name: "DownloadableProduct_UserAgreementText",
                table: "Products",
                newName: "UserAgreementText");

            migrationBuilder.RenameColumn(
                name: "DownloadableProduct_UnlimitedDownloads",
                table: "Products",
                newName: "UnlimitedDownloads");

            migrationBuilder.RenameColumn(
                name: "DownloadableProduct_SampleDownloadId",
                table: "Products",
                newName: "SampleDownloadId");

            migrationBuilder.RenameColumn(
                name: "DownloadableProduct_MaxNumberOfDownloads",
                table: "Products",
                newName: "MaxNumberOfDownloads");

            migrationBuilder.RenameColumn(
                name: "DownloadableProduct_IsDownload",
                table: "Products",
                newName: "IsDownload");

            migrationBuilder.RenameColumn(
                name: "DownloadableProduct_HasUserAgreement",
                table: "Products",
                newName: "HasUserAgreement");

            migrationBuilder.RenameColumn(
                name: "DownloadableProduct_HasSampleDownload",
                table: "Products",
                newName: "HasSampleDownload");

            migrationBuilder.RenameColumn(
                name: "DownloadableProduct_DownloadId",
                table: "Products",
                newName: "DownloadId");

            migrationBuilder.RenameColumn(
                name: "DownloadableProduct_DownloadExpirationDays",
                table: "Products",
                newName: "DownloadExpirationDays");

            migrationBuilder.RenameColumn(
                name: "DownloadableProduct_DownloadActivationTypeId",
                table: "Products",
                newName: "DownloadActivationTypeId");

            migrationBuilder.RenameColumn(
                name: "ComplianceAndStandards_NotReturnable",
                table: "Products",
                newName: "NotReturnable");

            migrationBuilder.RenameColumn(
                name: "Availability_ProductAvailabilityRangeId",
                table: "Products",
                newName: "ProductAvailabilityRangeId");

            migrationBuilder.RenameColumn(
                name: "Availability_PreOrderAvailabilityStartDateTimeUtc",
                table: "Products",
                newName: "PreOrderAvailabilityStartDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "Availability_DeliveryDateId",
                table: "Products",
                newName: "DeliveryDateId");

            migrationBuilder.RenameColumn(
                name: "Availability_AvailableStartDateTimeUtc",
                table: "Products",
                newName: "AvailableStartDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "Availability_AvailableForPreOrder",
                table: "Products",
                newName: "AvailableForPreOrder");

            migrationBuilder.RenameColumn(
                name: "Availability_AvailableEndDateTimeUtc",
                table: "Products",
                newName: "AvailableEndDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "Lifecycle_ManufactureDate",
                table: "Products",
                newName: "MarkAsNewStartDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "Lifecycle_ExpirationDate",
                table: "Products",
                newName: "MarkAsNewEndDateTimeUtc");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Products",
                type: "character varying(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(400)",
                oldMaxLength: 400);

            migrationBuilder.AlterColumn<string>(
                name: "FullDescription",
                table: "Products",
                type: "character varying(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdminComment",
                table: "Products",
                type: "character varying(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TaxCategoryId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsTaxExempt",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ShipSeparately",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsShipEnabled",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsFreeShipping",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AdditionalShippingCharge",
                table: "Products",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RentalPricePeriodId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RentalPriceLength",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsRental",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecurringTotalCycles",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecurringCyclePeriodId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecurringCycleLength",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsRecurring",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductCost",
                table: "Products",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OldPrice",
                table: "Products",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MinimumCustomerEnteredPrice",
                table: "Products",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MaximumCustomerEnteredPrice",
                table: "Products",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CustomerEntersPrice",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CallForPrice",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BasepriceUnitId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "BasepriceEnabled",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BasepriceBaseUnitId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BasepriceBaseAmount",
                table: "Products",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BasepriceAmount",
                table: "Products",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Width",
                table: "Products",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Products",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Length",
                table: "Products",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "Products",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StockQuantity",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderMinimumQuantity",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderMaximumQuantity",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NotifyAdminForQuantityBelow",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MinStockQuantity",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ManageInventoryMethodId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LowStockActivityId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "DisplayAttributeCombinationImagesOnly",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BackorderModeId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AllowedQuantities",
                table: "Products",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AllowBackInStockSubscriptions",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AllowAddingOnlyExistingAttributeCombinations",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OverriddenGiftCardAmount",
                table: "Products",
                type: "numeric(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsGiftCard",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GiftCardTypeId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserAgreementText",
                table: "Products",
                type: "character varying(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "UnlimitedDownloads",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SampleDownloadId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxNumberOfDownloads",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDownload",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "HasUserAgreement",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "HasSampleDownload",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DownloadId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DownloadExpirationDays",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DownloadActivationTypeId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "NotReturnable",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductAvailabilityRangeId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryDateId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AvailableForPreOrder",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AllowCustomerReviews",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ApprovedRatingSum",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApprovedTotalReviews",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "AutomaticallyAddRequiredProducts",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "DisableBuyButton",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DisableWishlistButton",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DisplayStockAvailability",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DisplayStockQuantity",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Gtin",
                table: "Products",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasDiscountsApplied",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasTierPrices",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModified",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "LimitedToStores",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ManufacturerPartNumber",
                table: "Products",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MarkAsNew",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NotApprovedRatingSum",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NotApprovedTotalReviews",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "RequireOtherProducts",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RequiredProductIds",
                table: "Products",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowOnHomepage",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Sku",
                table: "Products",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SubjectToAcl",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UseMultipleWarehouses",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DiscountProductMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiscountId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountProductMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountProductMapping_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPicture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    PictureId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPicture_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscountProductMapping_ProductId",
                table: "DiscountProductMapping",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPicture_ProductId",
                table: "ProductPicture",
                column: "ProductId");
        }
    }
}
