using Domain.Entities.Events;

namespace Application.Products.Models.Product;
























// Identification
// Descriptions
// Metadata
// Branding and Vendor
// Display order
// Status
// Pricing
// Availability
// Inventory
// Shipping
// Tax
// Downloadable products
// Gift cards
// Recurring products
// Rental products
// Physical attributes
// Compliance and Standards
// Lifecycle
// Enum Mappings
/// <param name="Components"></param>
/// <param name="SubjectToAcl"></param>
/// <param name="LimitedToStores"></param>
/// <param name="ProductId"></param>
/// <param name="ProductTypeId"></param>
/// <param name="ParentGroupedProductId"></param>
/// <param name="VisibleIndividually"></param>
/// <param name="Name"></param>
/// <param name="Description"></param>
/// <param name="Sku"></param>
/// <param name="Gtin"></param>
/// <param name="ManufacturerPartNumber"></param>
/// <param name="VendorPartNumber"></param>
/// <param name="ShortDescription"></param>
/// <param name="FullDescription"></param>
/// <param name="AdminComment"></param>
/// <param name="MetaKeywords"></param>
/// <param name="MetaDescription"></param>
/// <param name="MetaTitle"></param>
/// <param name="ProductTemplateId"></param>
/// <param name="VendorId"></param>
/// <param name="DisplayOrder"></param>
/// <param name="Published"></param>
/// <param name="Deleted"></param>
/// <param name="RequiredProductIds"> Gets or sets a required product identifiers (comma separated) </param>
/// <param name="AllowedQuantities"> Gets or sets the comma separated list of allowed quantities. null or empty if any quantity is allowed </param>
/// <param name="Price"></param>
/// <param name="Availability"></param>
/// <param name="Inventory"></param>
/// <param name="Shipping"></param>
/// <param name="Tax"></param>
/// <param name="DownloadableProduct"></param>
/// <param name="GiftCard"></param>
/// <param name="RecurringProduct"></param>
/// <param name="RentalProduct"></param>
/// <param name="PhysicalAttributes"></param>
/// <param name="ComplianceAndStandards"></param>
/// <param name="Lifecycle"></param>
/// <param name="ProductType"></param>
/// <param name="BackorderMode"></param>
/// <param name="DownloadActivationType"></param>
/// <param name="GiftCardType"></param>
/// <param name="LowStockActivity"></param>
/// <param name="ManageInventoryMethod"></param>
/// <param name="RecurringCyclePeriod"></param>
/// <param name="RentalPricePeriod"></param>
public sealed record ProductViewModel(List<ProductComponentViewModel> Components, bool SubjectToAcl, bool LimitedToStores, Guid ProductId, int ProductTypeId, int ParentGroupedProductId, bool VisibleIndividually, string Name, string Description, string Sku, string Gtin, string ManufacturerPartNumber, string VendorPartNumber, string ShortDescription, string FullDescription, string AdminComment, string MetaKeywords, string MetaDescription, string MetaTitle, int ProductTemplateId, int VendorId, int DisplayOrder, bool Published, bool Deleted, string RequiredProductIds, string AllowedQuantities, PriceViewModel Price, AvailabilityViewModel Availability, InventoryViewModel Inventory, ShippingViewModel Shipping, TaxViewModel Tax, DownloadableProductViewModel DownloadableProduct, GiftCardViewModel GiftCard, RecurringProductViewModel RecurringProduct, RentalProductViewModel RentalProduct, PhysicalAttributesViewModel PhysicalAttributes, ComplianceAndStandardsViewModel ComplianceAndStandards, LifecycleViewModel Lifecycle, ProductType ProductType, BackorderMode BackorderMode, DownloadActivationType DownloadActivationType, GiftCardType GiftCardType, LowStockActivity LowStockActivity, ManageInventoryMethod ManageInventoryMethod, RecurringProductCyclePeriod RecurringCyclePeriod, RentalPricePeriod RentalPricePeriod)
{
    public List<ProductComponentViewModel> Components { get; private set; } = Components;
    public bool SubjectToAcl { get; private set; } = SubjectToAcl;
    public bool LimitedToStores { get; private set; } = LimitedToStores;
    public int ProductTypeId { get; private set; } = ProductTypeId;
    public int ParentGroupedProductId { get; private set; } = ParentGroupedProductId;
    public bool VisibleIndividually { get; private set; } = VisibleIndividually;
    public string Name { get; private set; } = Name;
    public string Description { get; private set; } = Description;


    // Descriptions
    public string ShortDescription { get; private set; } = ShortDescription;
    public string FullDescription { get; private set; } = FullDescription;
    public string AdminComment { get; private set; } = AdminComment;

    // Metadata
    public string MetaKeywords { get; private set; } = MetaKeywords;
    public string MetaDescription { get; private set; } = MetaDescription;
    public string MetaTitle { get; private set; } = MetaTitle;

    // Branding and Vendor
    public int ProductTemplateId { get; private set; } = ProductTemplateId;
    public int VendorId { get; private set; } = VendorId;

    // Display order
    public int DisplayOrder { get; private set; } = DisplayOrder;

    // Status
    public bool Published { get; private set; } = Published;
    public bool Deleted { get; private set; } = Deleted;

    // Pricing
    public PriceViewModel Price { get; private set; } = Price;

    // Availability
    public AvailabilityViewModel Availability { get; private set; } = Availability;

    // Inventory
    public InventoryViewModel Inventory { get; private set; } = Inventory;

    // Shipping
    public ShippingViewModel Shipping { get; private set; } = Shipping;

    // Tax
    public TaxViewModel Tax { get; private set; } = Tax;

    // Downloadable products
    public DownloadableProductViewModel DownloadableProduct { get; private set; } = DownloadableProduct;

    // Gift cards
    public GiftCardViewModel GiftCard { get; private set; } = GiftCard;

    // Recurring products
    public RecurringProductViewModel RecurringProduct { get; private set; } = RecurringProduct;

    // Rental products
    public RentalProductViewModel RentalProduct { get; private set; } = RentalProduct;

    // Physical attributes
    public PhysicalAttributesViewModel PhysicalAttributes { get; private set; } = PhysicalAttributes;

    // Compliance and Standards
    public ComplianceAndStandardsViewModel ComplianceAndStandards { get; private set; } = ComplianceAndStandards;

    // Lifecycle
    public LifecycleViewModel Lifecycle { get; private set; } = Lifecycle;

    // Enum Mappings
    public ProductType ProductType { get; private set; } = ProductType;
    public BackorderMode BackorderMode { get; private set; } = BackorderMode;
    public DownloadActivationType DownloadActivationType { get; private set; } = DownloadActivationType;
    public GiftCardType GiftCardType { get; private set; } = GiftCardType;
    public LowStockActivity LowStockActivity { get; private set; } = LowStockActivity;
    public ManageInventoryMethod ManageInventoryMethod { get; private set; } = ManageInventoryMethod;
    public RecurringProductCyclePeriod RecurringCyclePeriod { get; private set; } = RecurringCyclePeriod;
    public RentalPricePeriod RentalPricePeriod { get; private set; } = RentalPricePeriod;
}
