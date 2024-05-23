using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace eShop.Catalog.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Prduc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductTypeId = table.Column<int>(type: "integer", nullable: false),
                    ParentGroupedProductId = table.Column<int>(type: "integer", nullable: false),
                    VisibleIndividually = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ShortDescription = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    FullDescription = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    AdminComment = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    ProductTemplateId = table.Column<int>(type: "integer", nullable: false),
                    VendorId = table.Column<int>(type: "integer", nullable: false),
                    ShowOnHomepage = table.Column<bool>(type: "boolean", nullable: false),
                    MetaKeywords = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    MetaDescription = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    MetaTitle = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    AllowCustomerReviews = table.Column<bool>(type: "boolean", nullable: false),
                    ApprovedRatingSum = table.Column<int>(type: "integer", nullable: false),
                    NotApprovedRatingSum = table.Column<int>(type: "integer", nullable: false),
                    ApprovedTotalReviews = table.Column<int>(type: "integer", nullable: false),
                    NotApprovedTotalReviews = table.Column<int>(type: "integer", nullable: false),
                    SubjectToAcl = table.Column<bool>(type: "boolean", nullable: false),
                    LimitedToStores = table.Column<bool>(type: "boolean", nullable: false),
                    Sku = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    ManufacturerPartNumber = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Gtin = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    IsGiftCard = table.Column<bool>(type: "boolean", nullable: false),
                    GiftCardTypeId = table.Column<int>(type: "integer", nullable: false),
                    OverriddenGiftCardAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    RequireOtherProducts = table.Column<bool>(type: "boolean", nullable: false),
                    RequiredProductIds = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    AutomaticallyAddRequiredProducts = table.Column<bool>(type: "boolean", nullable: false),
                    IsDownload = table.Column<bool>(type: "boolean", nullable: false),
                    DownloadId = table.Column<int>(type: "integer", nullable: false),
                    UnlimitedDownloads = table.Column<bool>(type: "boolean", nullable: false),
                    MaxNumberOfDownloads = table.Column<int>(type: "integer", nullable: false),
                    DownloadExpirationDays = table.Column<int>(type: "integer", nullable: false),
                    DownloadActivationTypeId = table.Column<int>(type: "integer", nullable: false),
                    HasSampleDownload = table.Column<bool>(type: "boolean", nullable: false),
                    SampleDownloadId = table.Column<int>(type: "integer", nullable: false),
                    HasUserAgreement = table.Column<bool>(type: "boolean", nullable: false),
                    UserAgreementText = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    IsRecurring = table.Column<bool>(type: "boolean", nullable: false),
                    RecurringCycleLength = table.Column<int>(type: "integer", nullable: false),
                    RecurringCyclePeriodId = table.Column<int>(type: "integer", nullable: false),
                    RecurringTotalCycles = table.Column<int>(type: "integer", nullable: false),
                    IsRental = table.Column<bool>(type: "boolean", nullable: false),
                    RentalPriceLength = table.Column<int>(type: "integer", nullable: false),
                    RentalPricePeriodId = table.Column<int>(type: "integer", nullable: false),
                    IsShipEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsFreeShipping = table.Column<bool>(type: "boolean", nullable: false),
                    ShipSeparately = table.Column<bool>(type: "boolean", nullable: false),
                    AdditionalShippingCharge = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DeliveryDateId = table.Column<int>(type: "integer", nullable: false),
                    IsTaxExempt = table.Column<bool>(type: "boolean", nullable: false),
                    TaxCategoryId = table.Column<int>(type: "integer", nullable: false),
                    ManageInventoryMethodId = table.Column<int>(type: "integer", nullable: false),
                    ProductAvailabilityRangeId = table.Column<int>(type: "integer", nullable: false),
                    UseMultipleWarehouses = table.Column<bool>(type: "boolean", nullable: false),
                    WarehouseId = table.Column<int>(type: "integer", nullable: false),
                    StockQuantity = table.Column<int>(type: "integer", nullable: false),
                    DisplayStockAvailability = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayStockQuantity = table.Column<bool>(type: "boolean", nullable: false),
                    MinStockQuantity = table.Column<int>(type: "integer", nullable: false),
                    LowStockActivityId = table.Column<int>(type: "integer", nullable: false),
                    NotifyAdminForQuantityBelow = table.Column<int>(type: "integer", nullable: false),
                    BackorderModeId = table.Column<int>(type: "integer", nullable: false),
                    AllowBackInStockSubscriptions = table.Column<bool>(type: "boolean", nullable: false),
                    OrderMinimumQuantity = table.Column<int>(type: "integer", nullable: false),
                    OrderMaximumQuantity = table.Column<int>(type: "integer", nullable: false),
                    AllowedQuantities = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    AllowAddingOnlyExistingAttributeCombinations = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayAttributeCombinationImagesOnly = table.Column<bool>(type: "boolean", nullable: false),
                    NotReturnable = table.Column<bool>(type: "boolean", nullable: false),
                    DisableBuyButton = table.Column<bool>(type: "boolean", nullable: false),
                    DisableWishlistButton = table.Column<bool>(type: "boolean", nullable: false),
                    AvailableForPreOrder = table.Column<bool>(type: "boolean", nullable: false),
                    PreOrderAvailabilityStartDateTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CallForPrice = table.Column<bool>(type: "boolean", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    OldPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ProductCost = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CustomerEntersPrice = table.Column<bool>(type: "boolean", nullable: false),
                    MinimumCustomerEnteredPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    MaximumCustomerEnteredPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    BasepriceEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    BasepriceAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    BasepriceUnitId = table.Column<int>(type: "integer", nullable: false),
                    BasepriceBaseAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    BasepriceBaseUnitId = table.Column<int>(type: "integer", nullable: false),
                    MarkAsNew = table.Column<bool>(type: "boolean", nullable: false),
                    MarkAsNewStartDateTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MarkAsNewEndDateTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    HasTierPrices = table.Column<bool>(type: "boolean", nullable: false),
                    HasDiscountsApplied = table.Column<bool>(type: "boolean", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Length = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Width = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Height = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    AvailableStartDateTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AvailableEndDateTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    Published = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProductType = table.Column<int>(type: "integer", nullable: false),
                    BackorderMode = table.Column<int>(type: "integer", nullable: false),
                    DownloadActivationType = table.Column<int>(type: "integer", nullable: false),
                    GiftCardType = table.Column<int>(type: "integer", nullable: false),
                    LowStockActivity = table.Column<int>(type: "integer", nullable: false),
                    ManageInventoryMethod = table.Column<int>(type: "integer", nullable: false),
                    RecurringCyclePeriod = table.Column<int>(type: "integer", nullable: false),
                    RentalPricePeriod = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountProductMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    DiscountId = table.Column<int>(type: "integer", nullable: false)
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
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    PictureId = table.Column<int>(type: "integer", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountProductMapping");

            migrationBuilder.DropTable(
                name: "ProductPicture");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
