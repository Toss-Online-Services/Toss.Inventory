using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace Application.Product.Models;
public class ProductModel
{
    #region Properties

    //picture thumbnail
    public string PictureThumbnailUrl { get; set; }

    public int ProductTypeId { get; set; }

    public string ProductTypeName { get; set; }

    public int AssociatedToProductId { get; set; }

    public string AssociatedToProductName { get; set; }

    public bool VisibleIndividually { get; set; }

    public int ProductTemplateId { get; set; }
    public IList<string> AvailableProductTemplates { get; set; }

    //<product type ID, list of supported product template IDs>
   // public Dictionary<int, IList<string>> ProductsTypesSupportedByProductTemplates { get; set; }

    public string Name { get; set; }

    public string ShortDescription { get; set; }

    public string FullDescription { get; set; }

    public string AdminComment { get; set; }

    public bool ShowOnHomepage { get; set; }

    public string MetaKeywords { get; set; }

    public string MetaDescription { get; set; }

    public string MetaTitle { get; set; }

    public string SeName { get; set; }

    public bool AllowCustomerReviews { get; set; }

    public IList<string> AvailableProductTags { get; set; }

    public IList<string> SelectedProductTags { get; set; }

    public string Sku { get; set; }

    public string ManufacturerPartNumber { get; set; }

    public virtual string Gtin { get; set; }

    public bool IsGiftCard { get; set; }

    public int GiftCardTypeId { get; set; }

    [UIHint("DecimalNullable")]
    public decimal? OverriddenGiftCardAmount { get; set; }

    public bool RequireOtherProducts { get; set; }

    public string RequiredProductIds { get; set; }

    public bool AutomaticallyAddRequiredProducts { get; set; }

    public bool IsDownload { get; set; }

    public int DownloadId { get; set; }

    public bool UnlimitedDownloads { get; set; }

    public int MaxNumberOfDownloads { get; set; }

    [UIHint("Int32Nullable")]
    public int? DownloadExpirationDays { get; set; }

    public int DownloadActivationTypeId { get; set; }

    public bool HasSampleDownload { get; set; }

    public int SampleDownloadId { get; set; }

    public bool HasUserAgreement { get; set; }

    public string UserAgreementText { get; set; }

    public bool IsRecurring { get; set; }

    public int RecurringCycleLength { get; set; }

    public int RecurringCyclePeriodId { get; set; }

    public int RecurringTotalCycles { get; set; }

    public bool IsRental { get; set; }

    public int RentalPriceLength { get; set; }

    public int RentalPricePeriodId { get; set; }

    public bool IsShipEnabled { get; set; }

    public bool IsFreeShipping { get; set; }

    public bool ShipSeparately { get; set; }

    public decimal AdditionalShippingCharge { get; set; }

    public int DeliveryDateId { get; set; }
    public IList<string> AvailableDeliveryDates { get; set; }

    public bool IsTaxExempt { get; set; }

    public int TaxCategoryId { get; set; }
    public IList<string> AvailableTaxCategories { get; set; }

    public int ManageInventoryMethodId { get; set; }

    public int ProductAvailabilityRangeId { get; set; }
    public IList<string> AvailableProductAvailabilityRanges { get; set; }

    public bool UseMultipleWarehouses { get; set; }

    public int WarehouseId { get; set; }
    public IList<string> AvailableWarehouses { get; set; }

    public int StockQuantity { get; set; }

    public int LastStockQuantity { get; set; }

    public string StockQuantityStr { get; set; }

    public bool DisplayStockAvailability { get; set; }

    public bool DisplayStockQuantity { get; set; }

    public int MinStockQuantity { get; set; }

    public int LowStockActivityId { get; set; }

    public int NotifyAdminForQuantityBelow { get; set; }

    public int BackorderModeId { get; set; }

    public bool AllowBackInStockSubscriptions { get; set; }

    public int OrderMinimumQuantity { get; set; }

    public int OrderMaximumQuantity { get; set; }

    public string AllowedQuantities { get; set; }

    public bool AllowAddingOnlyExistingAttributeCombinations { get; set; }

    public bool DisplayAttributeCombinationImagesOnly { get; set; }

    public bool NotReturnable { get; set; }

    public bool DisableBuyButton { get; set; }

    public bool DisableWishlistButton { get; set; }

    public bool AvailableForPreOrder { get; set; }

    [UIHint("DateTimeNullable")]
    public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }

    public bool CallForPrice { get; set; }

    public decimal Price { get; set; }

    public decimal OldPrice { get; set; }

    public decimal ProductCost { get; set; }

    public bool CustomerEntersPrice { get; set; }

    public decimal MinimumCustomerEnteredPrice { get; set; }

    public decimal MaximumCustomerEnteredPrice { get; set; }

    public bool BasepriceEnabled { get; set; }

    public decimal BasepriceAmount { get; set; }

    public int BasepriceUnitId { get; set; }
    public IList<string> AvailableBasepriceUnits { get; set; }

    public decimal BasepriceBaseAmount { get; set; }

    public int BasepriceBaseUnitId { get; set; }
    public IList<string> AvailableBasepriceBaseUnits { get; set; }

    public bool MarkAsNew { get; set; }

    [UIHint("DateTimeNullable")]
    public DateTime? MarkAsNewStartDateTimeUtc { get; set; }

    [UIHint("DateTimeNullable")]
    public DateTime? MarkAsNewEndDateTimeUtc { get; set; }

    public decimal Weight { get; set; }

    public decimal Length { get; set; }

    public decimal Width { get; set; }

    public decimal Height { get; set; }

    [UIHint("DateTimeNullable")]
    public DateTime? AvailableStartDateTimeUtc { get; set; }

    [UIHint("DateTimeNullable")]
    public DateTime? AvailableEndDateTimeUtc { get; set; }

    public int DisplayOrder { get; set; }

    public bool Published { get; set; }

    public string PrimaryStoreCurrencyCode { get; set; }

    public string BaseDimensionIn { get; set; }

    public string BaseWeightIn { get; set; }

    public IList<ProductLocalizedModel> Locales { get; set; }

    //ACL (customer roles)
    public IList<int> SelectedCustomerRoleIds { get; set; }
    public IList<string> AvailableCustomerRoles { get; set; }

    //store mapping
    public IList<int> SelectedStoreIds { get; set; }
    public IList<string> AvailableStores { get; set; }

    //categories
    public IList<int> SelectedCategoryIds { get; set; }
    public IList<string> AvailableCategories { get; set; }

    //manufacturers
    public IList<int> SelectedManufacturerIds { get; set; }
    public IList<string> AvailableManufacturers { get; set; }

    //vendors
    public int VendorId { get; set; }
    public IList<string> AvailableVendors { get; set; }

    //discounts
    public IList<int> SelectedDiscountIds { get; set; }
    public IList<string> AvailableDiscounts { get; set; }

    public bool IsLoggedInAsVendor { get; set; }

    //pictures
    public ProductPictureModel AddPictureModel { get; set; }
    public IList<ProductPictureModel> ProductPictureModels { get; set; }

    //videos
    public ProductVideoModel AddVideoModel { get; set; }
    public IList<ProductVideoModel> ProductVideoModels { get; set; }

    //product attributes
    public bool ProductAttributesExist { get; set; }
    public bool CanCreateCombinations { get; set; }

    //multiple warehouses
    public IList<ProductWarehouseInventoryModel> ProductWarehouseInventoryModels { get; set; }

    //specification attributes
    public bool HasAvailableSpecificationAttributes { get; set; }

    //copy product
    public CopyProductModel CopyProductModel { get; set; }

    //editor settings
    public ProductEditorSettingsModel ProductEditorSettingsModel { get; set; }

    //stock quantity history
    public StockQuantityHistoryModel StockQuantityHistory { get; set; }

    public RelatedProductSearchModel RelatedProductSearchModel { get; set; }

    public CrossSellProductSearchModel CrossSellProductSearchModel { get; set; }

    public AssociatedProductSearchModel AssociatedProductSearchModel { get; set; }

    public ProductPictureSearchModel ProductPictureSearchModel { get; set; }

    public ProductVideoSearchModel ProductVideoSearchModel { get; set; }

    public ProductSpecificationAttributeSearchModel ProductSpecificationAttributeSearchModel { get; set; }

    public ProductOrderSearchModel ProductOrderSearchModel { get; set; }

    public TierPriceSearchModel TierPriceSearchModel { get; set; }

    public StockQuantityHistorySearchModel StockQuantityHistorySearchModel { get; set; }

    public ProductAttributeMappingSearchModel ProductAttributeMappingSearchModel { get; set; }

    public ProductAttributeCombinationSearchModel ProductAttributeCombinationSearchModel { get; set; }

    #endregion
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.Catalog.Product, ProductModel>().ReverseMap();
        }
    }
}
