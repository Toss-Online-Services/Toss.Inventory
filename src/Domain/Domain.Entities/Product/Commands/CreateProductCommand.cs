namespace Domain.Entities.Product.Commands;

public record CreateProductCommand : ICommand<bool>
{
    /// <summary>
    /// Gets or sets the product type identifier
    /// </summary>
    public int ProductTypeId { get; init; }

    /// <summary>
    /// Gets or sets the parent product identifier. It's used to identify associated products (only with "grouped" products)
    /// </summary>
    public int ParentGroupedProductId { get; init; }

    /// <summary>
    /// Gets or sets the values indicating whether this product is visible in catalog or search results.
    /// It's used when this product is associated to some "grouped" one
    /// This way associated products could be accessed/added/etc only from a grouped product details page
    /// </summary>
    public bool VisibleIndividually { get; init; }

    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Gets or sets the short description
    /// </summary>
    public string ShortDescription { get; init; }

    /// <summary>
    /// Gets or sets the full description
    /// </summary>
    public string FullDescription { get; init; }

    /// <summary>
    /// Gets or sets the admin comment
    /// </summary>
    public string AdminComment { get; init; }

    /// <summary>
    /// Gets or sets a value of used product template identifier
    /// </summary>
    public int ProductTemplateId { get; init; }

    /// <summary>
    /// Gets or sets a vendor identifier
    /// </summary>
    public int VendorId { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether to show the product on home page
    /// </summary>
    public bool ShowOnHomepage { get; init; }

    /// <summary>
    /// Gets or sets the meta keywords
    /// </summary>
    public string MetaKeywords { get; init; }

    /// <summary>
    /// Gets or sets the meta description
    /// </summary>
    public string MetaDescription { get; init; }

    /// <summary>
    /// Gets or sets the meta title
    /// </summary>
    public string MetaTitle { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the product allows customer reviews
    /// </summary>
    public bool AllowCustomerReviews { get; init; }

    /// <summary>
    /// Gets or sets the rating sum (approved reviews)
    /// </summary>
    public int ApprovedRatingSum { get; init; }

    /// <summary>
    /// Gets or sets the rating sum (not approved reviews)
    /// </summary>
    public int NotApprovedRatingSum { get; init; }

    /// <summary>
    /// Gets or sets the total rating votes (approved reviews)
    /// </summary>
    public int ApprovedTotalReviews { get; init; }

    /// <summary>
    /// Gets or sets the total rating votes (not approved reviews)
    /// </summary>
    public int NotApprovedTotalReviews { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is subject to ACL
    /// </summary>
    public bool SubjectToAcl { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
    /// </summary>
    public bool LimitedToStores { get; init; }

    /// <summary>
    /// Gets or sets the SKU
    /// </summary>
    public string Sku { get; init; }

    /// <summary>
    /// Gets or sets the manufacturer part number
    /// </summary>
    public string ManufacturerPartNumber { get; init; }

    /// <summary>
    /// Gets or sets the Global Trade Item Number (GTIN). These identifiers include UPC (in North America), EAN (in Europe), JAN (in Japan), and ISBN (for books).
    /// </summary>
    public string Gtin { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is gift card
    /// </summary>
    public bool IsGiftCard { get; init; }

    /// <summary>
    /// Gets or sets the gift card type identifier
    /// </summary>
    public int GiftCardTypeId { get; init; }

    /// <summary>
    /// Gets or sets gift card amount that can be used after purchase. If not specified, then product price will be used.
    /// </summary>
    public decimal? OverriddenGiftCardAmount { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the product requires that other products are added to the cart (Product X requires Product Y)
    /// </summary>
    public bool RequireOtherProducts { get; init; }

    /// <summary>
    /// Gets or sets a required product identifiers (comma separated)
    /// </summary>
    public string RequiredProductIds { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether required products are automatically added to the cart
    /// </summary>
    public bool AutomaticallyAddRequiredProducts { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is download
    /// </summary>
    public bool IsDownload { get; init; }

    /// <summary>
    /// Gets or sets the download identifier
    /// </summary>
    public int DownloadId { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether this downloadable product can be downloaded unlimited number of times
    /// </summary>
    public bool UnlimitedDownloads { get; init; }

    /// <summary>
    /// Gets or sets the maximum number of downloads
    /// </summary>
    public int MaxNumberOfDownloads { get; init; }

    /// <summary>
    /// Gets or sets the number of days during customers keeps access to the file.
    /// </summary>
    public int? DownloadExpirationDays { get; init; }

    /// <summary>
    /// Gets or sets the download activation type
    /// </summary>
    public int DownloadActivationTypeId { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the product has a sample download file
    /// </summary>
    public bool HasSampleDownload { get; init; }

    /// <summary>
    /// Gets or sets the sample download identifier
    /// </summary>
    public int SampleDownloadId { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the product has user agreement
    /// </summary>
    public bool HasUserAgreement { get; init; }

    /// <summary>
    /// Gets or sets the text of license agreement
    /// </summary>
    public string UserAgreementText { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is recurring
    /// </summary>
    public bool IsRecurring { get; init; }

    /// <summary>
    /// Gets or sets the cycle length
    /// </summary>
    public int RecurringCycleLength { get; init; }

    /// <summary>
    /// Gets or sets the cycle period
    /// </summary>
    public int RecurringCyclePeriodId { get; init; }

    /// <summary>
    /// Gets or sets the total cycles
    /// </summary>
    public int RecurringTotalCycles { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is rental
    /// </summary>
    public bool IsRental { get; init; }

    /// <summary>
    /// Gets or sets the rental length for some period (price for this period)
    /// </summary>
    public int RentalPriceLength { get; init; }

    /// <summary>
    /// Gets or sets the rental period (price for this period)
    /// </summary>
    public int RentalPricePeriodId { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is ship enabled
    /// </summary>
    public bool IsShipEnabled { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is free shipping
    /// </summary>
    public bool IsFreeShipping { get; init; }

    /// <summary>
    /// Gets or sets a value this product should be shipped separately (each item)
    /// </summary>
    public bool ShipSeparately { get; init; }

    /// <summary>
    /// Gets or sets the additional shipping charge
    /// </summary>
    public decimal AdditionalShippingCharge { get; init; }

    /// <summary>
    /// Gets or sets a delivery date identifier
    /// </summary>
    public int DeliveryDateId { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is marked as tax exempt
    /// </summary>
    public bool IsTaxExempt { get; init; }

    /// <summary>
    /// Gets or sets the tax category identifier
    /// </summary>
    public int TaxCategoryId { get; init; }

    /// <summary>
    /// Gets or sets a value indicating how to manage inventory
    /// </summary>
    public int ManageInventoryMethodId { get; init; }

    /// <summary>
    /// Gets or sets a product availability range identifier
    /// </summary>
    public int ProductAvailabilityRangeId { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether multiple warehouses are used for this product
    /// </summary>
    public bool UseMultipleWarehouses { get; init; }

    /// <summary>
    /// Gets or sets a warehouse identifier
    /// </summary>
    public int WarehouseId { get; init; }

    /// <summary>
    /// Gets or sets the stock quantity
    /// </summary>
    public int StockQuantity { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether to display stock availability
    /// </summary>
    public bool DisplayStockAvailability { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether to display stock quantity
    /// </summary>
    public bool DisplayStockQuantity { get; init; }

    /// <summary>
    /// Gets or sets the minimum stock quantity
    /// </summary>
    public int MinStockQuantity { get; init; }

    /// <summary>
    /// Gets or sets the low stock activity identifier
    /// </summary>
    public int LowStockActivityId { get; init; }

    /// <summary>
    /// Gets or sets the quantity when admin should be notified
    /// </summary>
    public int NotifyAdminForQuantityBelow { get; init; }

    /// <summary>
    /// Gets or sets a value backorder mode identifier
    /// </summary>
    public int BackorderModeId { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether to back in stock subscriptions are allowed
    /// </summary>
    public bool AllowBackInStockSubscriptions { get; init; }

    /// <summary>
    /// Gets or sets the order minimum quantity
    /// </summary>
    public int OrderMinimumQuantity { get; init; }

    /// <summary>
    /// Gets or sets the order maximum quantity
    /// </summary>
    public int OrderMaximumQuantity { get; init; }

    /// <summary>
    /// Gets or sets the comma separated list of allowed quantities. null or empty if any quantity is allowed
    /// </summary>
    public string AllowedQuantities { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether we allow adding to the cart/wishlist only attribute combinations that exist and have stock greater than zero.
    /// This option is used only when we have "manage inventory" set to "track inventory by product attributes"
    /// </summary>
    public bool AllowAddingOnlyExistingAttributeCombinations { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether to display attribute combination images only
    /// </summary>
    public bool DisplayAttributeCombinationImagesOnly { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether this product is returnable (a customer is allowed to submit return request with this product)
    /// </summary>
    public bool NotReturnable { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether to disable buy (Add to cart) button
    /// </summary>
    public bool DisableBuyButton { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether to disable "Add to wishlist" button
    /// </summary>
    public bool DisableWishlistButton { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether this item is available for Pre-Order
    /// </summary>
    public bool AvailableForPreOrder { get; init; }

    /// <summary>
    /// Gets or sets the start date and time of the product availability (for pre-order products)
    /// </summary>
    public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; init; }


    public bool MarkAsNew { get; init; }

    /// <summary>
    /// Gets or sets the start date and time of the new product (set product as "New" from date). Leave empty to ignore this property
    /// </summary>
    public DateTime? MarkAsNewStartDateTimeUtc { get; init; }

    /// <summary>
    /// Gets or sets the end date and time of the new product (set product as "New" to date). Leave empty to ignore this property
    /// </summary>
    public DateTime? MarkAsNewEndDateTimeUtc { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether this product has tier prices configured
    /// <remarks>The same as if we run TierPrices.Count > 0
    /// We use this property for performance optimization:
    /// if this property is set to false, then we do not need to load tier prices navigation property
    /// </remarks>
    /// </summary>
    public bool HasTierPrices { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether this product has discounts applied
    /// <remarks>The same as if we run AppliedDiscounts.Count > 0
    /// We use this property for performance optimization:
    /// if this property is set to false, then we do not need to load Applied Discounts navigation property
    /// </remarks>
    /// </summary>
    public bool HasDiscountsApplied { get; init; }

    /// <summary>
    /// Gets or sets the weight
    /// </summary>
    public decimal Weight { get; init; }

    /// <summary>
    /// Gets or sets the length
    /// </summary>
    public decimal Length { get; init; }

    /// <summary>
    /// Gets or sets the width
    /// </summary>
    public decimal Width { get; init; }

    /// <summary>
    /// Gets or sets the height
    /// </summary>
    public decimal Height { get; init; }

    /// <summary>
    /// Gets or sets the available start date and time
    /// </summary>
    public DateTime? AvailableStartDateTimeUtc { get; init; }

    /// <summary>
    /// Gets or sets the available end date and time
    /// </summary>
    public DateTime? AvailableEndDateTimeUtc { get; init; }

    /// <summary>
    /// Gets or sets a display order.
    /// This value is used when sorting associated products (used with "grouped" products)
    /// This value is used when sorting home page products
    /// </summary>
    public int DisplayOrder { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is published
    /// </summary>
    public bool Published { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity has been deleted
    /// </summary>
    public bool Deleted { get; init; }

    /// <summary>
    /// Gets or sets the date and time of product creation
    /// </summary>
    public DateTime CreatedOnUtc { get; init; }

    /// <summary>
    /// Gets or sets the date and time of product update
    /// </summary>
    public DateTime UpdatedOnUtc { get; init; }

    public UpdatePriceCommand Price { get; init; }
    public UpdateAvailabilityCommand Availability { get; init; }
    public UpdateInventoryCommand Inventory { get; init; }
    public UpdateShippingCommand Shipping { get; init; }
    public UpdateTaxCommand Tax { get; init; }
    public UpdateDownloadableProductCommand DownloadableProduct { get; init; }
    public UpdateGiftCardCommand GiftCard { get; init; }
    public UpdateRecurringProductCommand RecurringProduct { get; init; }
    public UpdateRentalProductCommand RentalProduct { get; init; }
    public UpdatePhysicalAttributesCommand PhysicalAttributes { get; init; }
    public UpdateComplianceAndStandardsCommand ComplianceAndStandards { get; init; }
    public UpdateLifecycleCommand Lifecycle { get; init; }

}
