using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pgvector;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Prodct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:vector", ",,");

            migrationBuilder.CreateSequence(
                name: "productseq",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "CatalogBrand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntegrationEventLog",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventTypeName = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    TimesSent = table.Column<int>(type: "integer", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationEventLog", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    SubjectToAcl = table.Column<bool>(type: "boolean", nullable: false),
                    LimitedToStores = table.Column<bool>(type: "boolean", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductTypeId = table.Column<int>(type: "integer", nullable: false),
                    ParentGroupedProductId = table.Column<int>(type: "integer", nullable: false),
                    VisibleIndividually = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Sku = table.Column<string>(type: "text", nullable: true),
                    Gtin = table.Column<string>(type: "text", nullable: true),
                    ManufacturerPartNumber = table.Column<string>(type: "text", nullable: true),
                    VendorPartNumber = table.Column<string>(type: "text", nullable: true),
                    ShortDescription = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    FullDescription = table.Column<string>(type: "text", nullable: true),
                    AdminComment = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    MetaKeywords = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    MetaDescription = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    MetaTitle = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    ProductTemplateId = table.Column<int>(type: "integer", nullable: false),
                    VendorId = table.Column<int>(type: "integer", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    Published = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    RequiredProductIds = table.Column<string>(type: "text", nullable: true),
                    AllowedQuantities = table.Column<string>(type: "text", nullable: true),
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
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    PictureFileName = table.Column<string>(type: "text", nullable: true),
                    CatalogTypeId = table.Column<int>(type: "integer", nullable: false),
                    CatalogBrandId = table.Column<int>(type: "integer", nullable: false),
                    AvailableStock = table.Column<int>(type: "integer", nullable: false),
                    RestockThreshold = table.Column<int>(type: "integer", nullable: false),
                    MaxStockThreshold = table.Column<int>(type: "integer", nullable: false),
                    Embedding = table.Column<Vector>(type: "vector(384)", nullable: true),
                    OnReorder = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogBrand_CatalogBrandId",
                        column: x => x.CatalogBrandId,
                        principalTable: "CatalogBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogType_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalTable: "CatalogType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "ProductComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ComponentId = table.Column<int>(type: "integer", nullable: true),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductComponent_Products_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Products",
                        principalColumn: "Id");
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
                    DisplayAttributeCombinationImagesOnly = table.Column<bool>(type: "boolean", nullable: false),
                    UseMultipleWarehouses = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayStockAvailability = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayStockQuantity = table.Column<bool>(type: "boolean", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogBrandId",
                table: "Catalog",
                column: "CatalogBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogTypeId",
                table: "Catalog",
                column: "CatalogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Name",
                table: "Catalog",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComponent_ComponentId",
                table: "ProductComponent",
                column: "ComponentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.DropTable(
                name: "IntegrationEventLog");

            migrationBuilder.DropTable(
                name: "ProductAvailabilities");

            migrationBuilder.DropTable(
                name: "ProductCompliances");

            migrationBuilder.DropTable(
                name: "ProductComponent");

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

            migrationBuilder.DropTable(
                name: "CatalogBrand");

            migrationBuilder.DropTable(
                name: "CatalogType");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropSequence(
                name: "productseq");
        }
    }
}
