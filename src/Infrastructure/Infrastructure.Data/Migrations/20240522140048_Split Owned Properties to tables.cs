using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Catalog.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SplitOwnedPropertiestotables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability_AvailableEndDateTimeUtc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Availability_AvailableForPreOrder",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Availability_AvailableStartDateTimeUtc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Availability_DeliveryDateId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Availability_PreOrderAvailabilityStartDateTimeUtc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Availability_ProductAvailabilityRangeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ComplianceAndStandards_Certifications",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ComplianceAndStandards_EnvironmentalImpact",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ComplianceAndStandards_NotReturnable",
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
                name: "DownloadableProduct_DownloadActivationTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DownloadableProduct_DownloadExpirationDays",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DownloadableProduct_DownloadId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DownloadableProduct_HasSampleDownload",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DownloadableProduct_HasUserAgreement",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DownloadableProduct_IsDownload",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DownloadableProduct_MaxNumberOfDownloads",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DownloadableProduct_SampleDownloadId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DownloadableProduct_UnlimitedDownloads",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DownloadableProduct_UserAgreementText",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GiftCard_GiftCardTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GiftCard_IsGiftCard",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GiftCard_OverriddenGiftCardAmount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Inventory_AllowAddingOnlyExistingAttributeCombinations",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Inventory_AllowBackInStockSubscriptions",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Inventory_AllowedQuantities",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Inventory_BackorderModeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Inventory_DisplayAttributeCombinationImagesOnly",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Inventory_LowStockActivityId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Inventory_ManageInventoryMethodId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Inventory_MinStockQuantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Inventory_NotifyAdminForQuantityBelow",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Inventory_OrderMaximumQuantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Inventory_OrderMinimumQuantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Inventory_StockQuantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Inventory_WarehouseId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Lifecycle_BatchNumber",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Lifecycle_ExpirationDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Lifecycle_ManufactureDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Lifecycle_SerialNumber",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PhysicalAttributes_Color",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PhysicalAttributes_Height",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PhysicalAttributes_Length",
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
                name: "PhysicalAttributes_Weight",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PhysicalAttributes_Width",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price_BasepriceAmount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price_BasepriceBaseAmount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price_BasepriceBaseUnitId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price_BasepriceEnabled",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price_BasepriceUnitId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price_CallForPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price_CurrentPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price_CustomerEntersPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price_MaximumCustomerEnteredPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price_MinimumCustomerEnteredPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price_OldPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price_ProductCost",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RecurringProduct_IsRecurring",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RecurringProduct_RecurringCycleLength",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RecurringProduct_RecurringCyclePeriodId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RecurringProduct_RecurringTotalCycles",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RentalProduct_IsRental",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RentalProduct_RentalPriceLength",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RentalProduct_RentalPricePeriodId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Shipping_AdditionalShippingCharge",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Shipping_IsFreeShipping",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Shipping_IsShipEnabled",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Shipping_ShipSeparately",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Tax_IsTaxExempt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Tax_TaxCategoryId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductAvailabilities",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    AvailableStartDateTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AvailableEndDateTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AvailableForPreOrder = table.Column<bool>(type: "boolean", nullable: false),
                    PreOrderAvailabilityStartDateTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ProductAvailabilityRangeId = table.Column<int>(type: "integer", nullable: false),
                    DeliveryDateId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAvailabilities", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductAvailabilities_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCompliances",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    NotReturnable = table.Column<bool>(type: "boolean", nullable: false),
                    Certifications = table.Column<string>(type: "text", nullable: true),
                    RegulatoryApprovals = table.Column<string>(type: "text", nullable: true),
                    SafetyInformation = table.Column<string>(type: "text", nullable: true),
                    EnvironmentalImpact = table.Column<string>(type: "text", nullable: true),
                    RecyclingInformation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCompliances", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductCompliances_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDownloadables",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    IsDownload = table.Column<bool>(type: "boolean", nullable: false),
                    DownloadId = table.Column<int>(type: "integer", nullable: false),
                    UnlimitedDownloads = table.Column<bool>(type: "boolean", nullable: false),
                    MaxNumberOfDownloads = table.Column<int>(type: "integer", nullable: false),
                    DownloadExpirationDays = table.Column<int>(type: "integer", nullable: true),
                    DownloadActivationTypeId = table.Column<int>(type: "integer", nullable: false),
                    HasSampleDownload = table.Column<bool>(type: "boolean", nullable: false),
                    SampleDownloadId = table.Column<int>(type: "integer", nullable: false),
                    HasUserAgreement = table.Column<bool>(type: "boolean", nullable: false),
                    UserAgreementText = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDownloadables", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductDownloadables_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductGiftCards",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    IsGiftCard = table.Column<bool>(type: "boolean", nullable: false),
                    GiftCardTypeId = table.Column<int>(type: "integer", nullable: false),
                    OverriddenGiftCardAmount = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGiftCards", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductGiftCards_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInventories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ManageInventoryMethodId = table.Column<int>(type: "integer", nullable: false),
                    WarehouseId = table.Column<int>(type: "integer", nullable: false),
                    StockQuantity = table.Column<int>(type: "integer", nullable: false),
                    MinStockQuantity = table.Column<int>(type: "integer", nullable: false),
                    LowStockActivityId = table.Column<int>(type: "integer", nullable: false),
                    NotifyAdminForQuantityBelow = table.Column<int>(type: "integer", nullable: false),
                    BackorderModeId = table.Column<int>(type: "integer", nullable: false),
                    AllowBackInStockSubscriptions = table.Column<bool>(type: "boolean", nullable: false),
                    OrderMinimumQuantity = table.Column<int>(type: "integer", nullable: false),
                    OrderMaximumQuantity = table.Column<int>(type: "integer", nullable: false),
                    AllowedQuantities = table.Column<string>(type: "text", nullable: true),
                    AllowAddingOnlyExistingAttributeCombinations = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayAttributeCombinationImagesOnly = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventories", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductInventories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductLifecycles",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BatchNumber = table.Column<string>(type: "text", nullable: true),
                    SerialNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLifecycles", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductLifecycles_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPhysicalAttributes",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: false),
                    Length = table.Column<decimal>(type: "numeric", nullable: false),
                    Width = table.Column<decimal>(type: "numeric", nullable: false),
                    Height = table.Column<decimal>(type: "numeric", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: true),
                    Material = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    PackagingType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPhysicalAttributes", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductPhysicalAttributes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrices",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    OldPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    ProductCost = table.Column<decimal>(type: "numeric", nullable: false),
                    CustomerEntersPrice = table.Column<bool>(type: "boolean", nullable: false),
                    MinimumCustomerEnteredPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    MaximumCustomerEnteredPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    BasepriceEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    BasepriceAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    BasepriceUnitId = table.Column<int>(type: "integer", nullable: false),
                    BasepriceBaseAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    BasepriceBaseUnitId = table.Column<int>(type: "integer", nullable: false),
                    CallForPrice = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrices", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductRecurrings",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    IsRecurring = table.Column<bool>(type: "boolean", nullable: false),
                    RecurringCycleLength = table.Column<int>(type: "integer", nullable: false),
                    RecurringCyclePeriodId = table.Column<int>(type: "integer", nullable: false),
                    RecurringTotalCycles = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRecurrings", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductRecurrings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductRentals",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    IsRental = table.Column<bool>(type: "boolean", nullable: false),
                    RentalPriceLength = table.Column<int>(type: "integer", nullable: false),
                    RentalPricePeriodId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRentals", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductRentals_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductShippings",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    IsShipEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsFreeShipping = table.Column<bool>(type: "boolean", nullable: false),
                    ShipSeparately = table.Column<bool>(type: "boolean", nullable: false),
                    AdditionalShippingCharge = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShippings", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductShippings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTaxes",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    IsTaxExempt = table.Column<bool>(type: "boolean", nullable: false),
                    TaxCategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTaxes", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductTaxes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAvailabilities");

            migrationBuilder.DropTable(
                name: "ProductCompliances");

            migrationBuilder.DropTable(
                name: "ProductDownloadables");

            migrationBuilder.DropTable(
                name: "ProductGiftCards");

            migrationBuilder.DropTable(
                name: "ProductInventories");

            migrationBuilder.DropTable(
                name: "ProductLifecycles");

            migrationBuilder.DropTable(
                name: "ProductPhysicalAttributes");

            migrationBuilder.DropTable(
                name: "ProductPrices");

            migrationBuilder.DropTable(
                name: "ProductRecurrings");

            migrationBuilder.DropTable(
                name: "ProductRentals");

            migrationBuilder.DropTable(
                name: "ProductShippings");

            migrationBuilder.DropTable(
                name: "ProductTaxes");

            migrationBuilder.AddColumn<DateTime>(
                name: "Availability_AvailableEndDateTimeUtc",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Availability_AvailableForPreOrder",
                table: "Products",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Availability_AvailableStartDateTimeUtc",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Availability_DeliveryDateId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Availability_PreOrderAvailabilityStartDateTimeUtc",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Availability_ProductAvailabilityRangeId",
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

            migrationBuilder.AddColumn<bool>(
                name: "ComplianceAndStandards_NotReturnable",
                table: "Products",
                type: "boolean",
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
                name: "DownloadableProduct_DownloadActivationTypeId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DownloadableProduct_DownloadExpirationDays",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DownloadableProduct_DownloadId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DownloadableProduct_HasSampleDownload",
                table: "Products",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DownloadableProduct_HasUserAgreement",
                table: "Products",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DownloadableProduct_IsDownload",
                table: "Products",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DownloadableProduct_MaxNumberOfDownloads",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DownloadableProduct_SampleDownloadId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DownloadableProduct_UnlimitedDownloads",
                table: "Products",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DownloadableProduct_UserAgreementText",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GiftCard_GiftCardTypeId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GiftCard_IsGiftCard",
                table: "Products",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GiftCard_OverriddenGiftCardAmount",
                table: "Products",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Inventory_AllowAddingOnlyExistingAttributeCombinations",
                table: "Products",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Inventory_AllowBackInStockSubscriptions",
                table: "Products",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Inventory_AllowedQuantities",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Inventory_BackorderModeId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Inventory_DisplayAttributeCombinationImagesOnly",
                table: "Products",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Inventory_LowStockActivityId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Inventory_ManageInventoryMethodId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Inventory_MinStockQuantity",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Inventory_NotifyAdminForQuantityBelow",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Inventory_OrderMaximumQuantity",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Inventory_OrderMinimumQuantity",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Inventory_StockQuantity",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Inventory_WarehouseId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lifecycle_BatchNumber",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Lifecycle_ExpirationDate",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Lifecycle_ManufactureDate",
                table: "Products",
                type: "timestamp with time zone",
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

            migrationBuilder.AddColumn<decimal>(
                name: "PhysicalAttributes_Height",
                table: "Products",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PhysicalAttributes_Length",
                table: "Products",
                type: "numeric",
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
                name: "PhysicalAttributes_Weight",
                table: "Products",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PhysicalAttributes_Width",
                table: "Products",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price_BasepriceAmount",
                table: "Products",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price_BasepriceBaseAmount",
                table: "Products",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price_BasepriceBaseUnitId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Price_BasepriceEnabled",
                table: "Products",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price_BasepriceUnitId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Price_CallForPrice",
                table: "Products",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price_CurrentPrice",
                table: "Products",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Price_CustomerEntersPrice",
                table: "Products",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price_MaximumCustomerEnteredPrice",
                table: "Products",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price_MinimumCustomerEnteredPrice",
                table: "Products",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price_OldPrice",
                table: "Products",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price_ProductCost",
                table: "Products",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RecurringProduct_IsRecurring",
                table: "Products",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecurringProduct_RecurringCycleLength",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecurringProduct_RecurringCyclePeriodId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecurringProduct_RecurringTotalCycles",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RentalProduct_IsRental",
                table: "Products",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RentalProduct_RentalPriceLength",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RentalProduct_RentalPricePeriodId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Shipping_AdditionalShippingCharge",
                table: "Products",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Shipping_IsFreeShipping",
                table: "Products",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Shipping_IsShipEnabled",
                table: "Products",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Shipping_ShipSeparately",
                table: "Products",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Tax_IsTaxExempt",
                table: "Products",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tax_TaxCategoryId",
                table: "Products",
                type: "integer",
                nullable: true);
        }
    }
}
