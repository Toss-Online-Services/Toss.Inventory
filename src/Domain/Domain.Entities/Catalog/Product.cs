using Domain.Entities.Catalog.Commands;
using Domain.Entities.Catalog.Events;
using Domain.Entities.Discounts;
using Domain.Entities.Events;
using Domain.Infrastructure;

namespace Domain.Entities.Catalog;
public class Product
    : BaseAuditableEntity, IAggregateRoot
{
    private readonly List<DiscountProductMapping> _discounts;
    private readonly List<ProductPicture> _pictures;

    public Product()
    {
        _pictures = new List<ProductPicture>();
        _discounts = new List<DiscountProductMapping>();
    }


    public IReadOnlyCollection<ProductPicture> Pictures => _pictures.AsReadOnly();
    public IReadOnlyCollection<DiscountProductMapping> Discounts => _discounts.AsReadOnly();

    /// <summary>
    /// Gets or sets the product type identifier
    /// </summary>
    public int ProductTypeId { get; private set; }

    /// <summary>
    /// Gets or sets the parent product identifier. It's used to identify associated products (only with "grouped" products)
    /// </summary>
    public int ParentGroupedProductId { get; private set; }

    /// <summary>
    /// Gets or sets the values indicating whether this product is visible in catalog or search results.
    /// It's used when this product is associated to some "grouped" one
    /// This way associated products could be accessed/added/etc only from a grouped product details page
    /// </summary>
    public bool VisibleIndividually { get; private set; }

    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets or sets the short description
    /// </summary>
    public string ShortDescription { get; private set; }

    /// <summary>
    /// Gets or sets the full description
    /// </summary>
    public string FullDescription { get; private set; }

    /// <summary>
    /// Gets or sets the admin comment
    /// </summary>
    public string AdminComment { get; private set; }

    /// <summary>
    /// Gets or sets a value of used product template identifier
    /// </summary>
    public int ProductTemplateId { get; private set; }

    /// <summary>
    /// Gets or sets a vendor identifier
    /// </summary>
    public int VendorId { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether to show the product on home page
    /// </summary>
    public bool ShowOnHomepage { get; private set; }

    /// <summary>
    /// Gets or sets the meta keywords
    /// </summary>
    public string MetaKeywords { get; private set; }

    /// <summary>
    /// Gets or sets the meta description
    /// </summary>
    public string MetaDescription { get; private set; }

    /// <summary>
    /// Gets or sets the meta title
    /// </summary>
    public string MetaTitle { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product allows customer reviews
    /// </summary>
    public bool AllowCustomerReviews { get; private set; }

    /// <summary>
    /// Gets or sets the rating sum (approved reviews)
    /// </summary>
    public int ApprovedRatingSum { get; private set; }

    /// <summary>
    /// Gets or sets the rating sum (not approved reviews)
    /// </summary>
    public int NotApprovedRatingSum { get; private set; }

    /// <summary>
    /// Gets or sets the total rating votes (approved reviews)
    /// </summary>
    public int ApprovedTotalReviews { get; private set; }

    /// <summary>
    /// Gets or sets the total rating votes (not approved reviews)
    /// </summary>
    public int NotApprovedTotalReviews { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is subject to ACL
    /// </summary>
    public bool SubjectToAcl { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
    /// </summary>
    public bool LimitedToStores { get; private set; }

    /// <summary>
    /// Gets or sets the SKU
    /// </summary>
    public string Sku { get; private set; }

    /// <summary>
    /// Gets or sets the manufacturer part number
    /// </summary>
    public string ManufacturerPartNumber { get; private set; }

    /// <summary>
    /// Gets or sets the Global Trade Item Number (GTIN). These identifiers include UPC (in North America), EAN (in Europe), JAN (in Japan), and ISBN (for books).
    /// </summary>
    public string Gtin { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is gift card
    /// </summary>
    public bool IsGiftCard { get; private set; }

    /// <summary>
    /// Gets or sets the gift card type identifier
    /// </summary>
    public int GiftCardTypeId { get; private set; }

    /// <summary>
    /// Gets or sets gift card amount that can be used after purchase. If not specified, then product price will be used.
    /// </summary>
    public decimal? OverriddenGiftCardAmount { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product requires that other products are added to the cart (Product X requires Product Y)
    /// </summary>
    public bool RequireOtherProducts { get; private set; }

    /// <summary>
    /// Gets or sets a required product identifiers (comma separated)
    /// </summary>
    public string RequiredProductIds { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether required products are automatically added to the cart
    /// </summary>
    public bool AutomaticallyAddRequiredProducts { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is download
    /// </summary>
    public bool IsDownload { get; private set; }

    /// <summary>
    /// Gets or sets the download identifier
    /// </summary>
    public int DownloadId { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether this downloadable product can be downloaded unlimited number of times
    /// </summary>
    public bool UnlimitedDownloads { get; private set; }

    /// <summary>
    /// Gets or sets the maximum number of downloads
    /// </summary>
    public int MaxNumberOfDownloads { get; private set; }

    /// <summary>
    /// Gets or sets the number of days during customers keeps access to the file.
    /// </summary>
    public int? DownloadExpirationDays { get; private set; }

    /// <summary>
    /// Gets or sets the download activation type
    /// </summary>
    public int DownloadActivationTypeId { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product has a sample download file
    /// </summary>
    public bool HasSampleDownload { get; private set; }

    /// <summary>
    /// Gets or sets the sample download identifier
    /// </summary>
    public int SampleDownloadId { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product has user agreement
    /// </summary>
    public bool HasUserAgreement { get; private set; }

    /// <summary>
    /// Gets or sets the text of license agreement
    /// </summary>
    public string UserAgreementText { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is recurring
    /// </summary>
    public bool IsRecurring { get; private set; }

    /// <summary>
    /// Gets or sets the cycle length
    /// </summary>
    public int RecurringCycleLength { get; private set; }

    /// <summary>
    /// Gets or sets the cycle period
    /// </summary>
    public int RecurringCyclePeriodId { get; private set; }

    /// <summary>
    /// Gets or sets the total cycles
    /// </summary>
    public int RecurringTotalCycles { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is rental
    /// </summary>
    public bool IsRental { get; private set; }

    /// <summary>
    /// Gets or sets the rental length for some period (price for this period)
    /// </summary>
    public int RentalPriceLength { get; private set; }

    /// <summary>
    /// Gets or sets the rental period (price for this period)
    /// </summary>
    public int RentalPricePeriodId { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is ship enabled
    /// </summary>
    public bool IsShipEnabled { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is free shipping
    /// </summary>
    public bool IsFreeShipping { get; private set; }

    /// <summary>
    /// Gets or sets a value this product should be shipped separately (each item)
    /// </summary>
    public bool ShipSeparately { get; private set; }

    /// <summary>
    /// Gets or sets the additional shipping charge
    /// </summary>
    public decimal AdditionalShippingCharge { get; private set; }

    /// <summary>
    /// Gets or sets a delivery date identifier
    /// </summary>
    public int DeliveryDateId { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is marked as tax exempt
    /// </summary>
    public bool IsTaxExempt { get; private set; }

    /// <summary>
    /// Gets or sets the tax category identifier
    /// </summary>
    public int TaxCategoryId { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating how to manage inventory
    /// </summary>
    public int ManageInventoryMethodId { get; private set; }

    /// <summary>
    /// Gets or sets a product availability range identifier
    /// </summary>
    public int ProductAvailabilityRangeId { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether multiple warehouses are used for this product
    /// </summary>
    public bool UseMultipleWarehouses { get; private set; }

    /// <summary>
    /// Gets or sets a warehouse identifier
    /// </summary>
    public int WarehouseId { get; private set; }

    /// <summary>
    /// Gets or sets the stock quantity
    /// </summary>
    public int StockQuantity { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether to display stock availability
    /// </summary>
    public bool DisplayStockAvailability { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether to display stock quantity
    /// </summary>
    public bool DisplayStockQuantity { get; private set; }

    /// <summary>
    /// Gets or sets the minimum stock quantity
    /// </summary>
    public int MinStockQuantity { get; private set; }

    /// <summary>
    /// Gets or sets the low stock activity identifier
    /// </summary>
    public int LowStockActivityId { get; private set; }

    /// <summary>
    /// Gets or sets the quantity when admin should be notified
    /// </summary>
    public int NotifyAdminForQuantityBelow { get; private set; }

    /// <summary>
    /// Gets or sets a value backorder mode identifier
    /// </summary>
    public int BackorderModeId { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether to back in stock subscriptions are allowed
    /// </summary>
    public bool AllowBackInStockSubscriptions { get; private set; }

    /// <summary>
    /// Gets or sets the order minimum quantity
    /// </summary>
    public int OrderMinimumQuantity { get; private set; }

    /// <summary>
    /// Gets or sets the order maximum quantity
    /// </summary>
    public int OrderMaximumQuantity { get; private set; }

    /// <summary>
    /// Gets or sets the comma separated list of allowed quantities. null or empty if any quantity is allowed
    /// </summary>
    public string AllowedQuantities { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether we allow adding to the cart/wishlist only attribute combinations that exist and have stock greater than zero.
    /// This option is used only when we have "manage inventory" set to "track inventory by product attributes"
    /// </summary>
    public bool AllowAddingOnlyExistingAttributeCombinations { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether to display attribute combination images only
    /// </summary>
    public bool DisplayAttributeCombinationImagesOnly { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether this product is returnable (a customer is allowed to submit return request with this product)
    /// </summary>
    public bool NotReturnable { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether to disable buy (Add to cart) button
    /// </summary>
    public bool DisableBuyButton { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether to disable "Add to wishlist" button
    /// </summary>
    public bool DisableWishlistButton { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether this item is available for Pre-Order
    /// </summary>
    public bool AvailableForPreOrder { get; private set; }

    /// <summary>
    /// Gets or sets the start date and time of the product availability (for pre-order products)
    /// </summary>
    public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether to show "Call for Pricing" or "Call for quote" instead of price
    /// </summary>
    public bool CallForPrice { get; private set; }

    /// <summary>
    /// Gets or sets the price
    /// </summary>
    public decimal Price { get; private set; }

    /// <summary>
    /// Gets or sets the old price
    /// </summary>
    public decimal OldPrice { get; private set; }

    /// <summary>
    /// Gets or sets the product cost
    /// </summary>
    public decimal ProductCost { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether a customer enters price
    /// </summary>
    public bool CustomerEntersPrice { get; private set; }

    /// <summary>
    /// Gets or sets the minimum price entered by a customer
    /// </summary>
    public decimal MinimumCustomerEnteredPrice { get; private set; }

    /// <summary>
    /// Gets or sets the maximum price entered by a customer
    /// </summary>
    public decimal MaximumCustomerEnteredPrice { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether base price (PAngV) is enabled. Used by German users.
    /// </summary>
    public bool BasepriceEnabled { get; private set; }

    /// <summary>
    /// Gets or sets an amount in product for PAngV
    /// </summary>
    public decimal BasepriceAmount { get; private set; }

    /// <summary>
    /// Gets or sets a unit of product for PAngV (MeasureWeight entity)
    /// </summary>
    public int BasepriceUnitId { get; private set; }

    /// <summary>
    /// Gets or sets a reference amount for PAngV
    /// </summary>
    public decimal BasepriceBaseAmount { get; private set; }

    /// <summary>
    /// Gets or sets a reference unit for PAngV (MeasureWeight entity)
    /// </summary>
    public int BasepriceBaseUnitId { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether this product is marked as new
    /// </summary>
    public bool MarkAsNew { get; private set; }

    /// <summary>
    /// Gets or sets the start date and time of the new product (set product as "New" from date). Leave empty to ignore this property
    /// </summary>
    public DateTime? MarkAsNewStartDateTimeUtc { get; private set; }

    /// <summary>
    /// Gets or sets the end date and time of the new product (set product as "New" to date). Leave empty to ignore this property
    /// </summary>
    public DateTime? MarkAsNewEndDateTimeUtc { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether this product has tier prices configured
    /// <remarks>The same as if we run TierPrices.Count > 0
    /// We use this property for performance optimization:
    /// if this property is set to false, then we do not need to load tier prices navigation property
    /// </remarks>
    /// </summary>
    public bool HasTierPrices { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether this product has discounts applied
    /// <remarks>The same as if we run AppliedDiscounts.Count > 0
    /// We use this property for performance optimization:
    /// if this property is set to false, then we do not need to load Applied Discounts navigation property
    /// </remarks>
    /// </summary>
    public bool HasDiscountsApplied { get; private set; }

    /// <summary>
    /// Gets or sets the weight
    /// </summary>
    public decimal Weight { get; private set; }

    /// <summary>
    /// Gets or sets the length
    /// </summary>
    public decimal Length { get; private set; }

    /// <summary>
    /// Gets or sets the width
    /// </summary>
    public decimal Width { get; private set; }

    /// <summary>
    /// Gets or sets the height
    /// </summary>
    public decimal Height { get; private set; }

    /// <summary>
    /// Gets or sets the available start date and time
    /// </summary>
    public DateTime? AvailableStartDateTimeUtc { get; private set; }

    /// <summary>
    /// Gets or sets the available end date and time
    /// </summary>
    public DateTime? AvailableEndDateTimeUtc { get; private set; }

    /// <summary>
    /// Gets or sets a display order.
    /// This value is used when sorting associated products (used with "grouped" products)
    /// This value is used when sorting home page products
    /// </summary>
    public int DisplayOrder { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is published
    /// </summary>
    public bool Published { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity has been deleted
    /// </summary>
    public bool Deleted { get; private set; }

    /// <summary>
    /// Gets or sets the date and time of product creation
    /// </summary>
    public DateTime CreatedOnUtc { get; private set; }

    /// <summary>
    /// Gets or sets the date and time of product update
    /// </summary>
    public DateTime UpdatedOnUtc { get; private set; }

    /// <summary>
    /// Gets or sets the product type
    /// </summary>
    public ProductType ProductType
    {
        get => (ProductType)ProductTypeId;
        set => ProductTypeId = (int)value;
    }

    /// <summary>
    /// Gets or sets the backorder mode
    /// </summary>
    public BackorderMode BackorderMode
    {
        get => (BackorderMode)BackorderModeId;
        set => BackorderModeId = (int)value;
    }

    /// <summary>
    /// Gets or sets the download activation type
    /// </summary>
    public DownloadActivationType DownloadActivationType
    {
        get => (DownloadActivationType)DownloadActivationTypeId;
        set => DownloadActivationTypeId = (int)value;
    }

    /// <summary>
    /// Gets or sets the gift card type
    /// </summary>
    public GiftCardType GiftCardType
    {
        get => (GiftCardType)GiftCardTypeId;
        set => GiftCardTypeId = (int)value;
    }

    /// <summary>
    /// Gets or sets the low stock activity
    /// </summary>
    public LowStockActivity LowStockActivity
    {
        get => (LowStockActivity)LowStockActivityId;
        set => LowStockActivityId = (int)value;
    }

    /// <summary>
    /// Gets or sets the value indicating how to manage inventory
    /// </summary>
    public ManageInventoryMethod ManageInventoryMethod
    {
        get => (ManageInventoryMethod)ManageInventoryMethodId;
        set => ManageInventoryMethodId = (int)value;
    }

    /// <summary>
    /// Gets or sets the cycle period for recurring products
    /// </summary>
    public RecurringProductCyclePeriod RecurringCyclePeriod
    {
        get => (RecurringProductCyclePeriod)RecurringCyclePeriodId;
        set => RecurringCyclePeriodId = (int)value;
    }

    /// <summary>
    /// Gets or sets the period for rental products
    /// </summary>
    public RentalPricePeriod RentalPricePeriod
    {
        get => (RentalPricePeriod)RentalPricePeriodId;
        set => RentalPricePeriodId = (int)value;
    }


    public Product (CreateProductCommand command)
    {

        ProductTypeId = command.ProductTypeId;
        ParentGroupedProductId = command.ParentGroupedProductId;
        VisibleIndividually = command.VisibleIndividually;
        Name = command.Name;

        // Add the ProductCreatedEvent to the domain events collection 
        // to be raised/dispatched when committing changes into the Database [ After DbContext.SaveChanges() ]
        this.AddDomainEvent(new ProductCreatedDomainEvent(this));
    }

    

    public void UpdateProductDetails(string newName, string newShortDescription, string newFullDescription)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Product name cannot be empty.", nameof(newName));

        Name = newName;
        ShortDescription = newShortDescription;
        FullDescription = newFullDescription;
        UpdatedOnUtc = DateTime.UtcNow;

        // Raise domain event to signal product update
        AddDomainEvent(new ProductUpdatedDomainEvent(this));
    }

    public void ActivateProduct()
    {
        if (Deleted)
            throw new InvalidOperationException("Cannot activate a deleted product.");

        Published = true;
        AddDomainEvent(new ProductActivatedDomainEvent(this));
    }

    public void ApplyDiscount(DiscountProductMapping discount)
    {
        if (discount == null)
            throw new ArgumentNullException(nameof(discount));

        _discounts.Add(discount);
        AddDomainEvent(new ProductDiscountAppliedDomainEvent(this, discount));
    }

    public void AddPicture(ProductPicture picture)
    {
        _pictures.Add(picture ?? throw new ArgumentNullException(nameof(picture)));
        AddDomainEvent(new ProductPictureAddedDomainEvent(this, picture));
    }

    // Implement other domain behaviors similar to these examples


    // Ensure to clear events once they are dispatched
    public void ClearEvents()
    {
        // Implementation to clear all pending events
    }
}
