namespace Application.Products.Models.Product;




























































/// <summary>
/// Product editor settings
/// </summary>
/// <param name="ProductType"> Gets or sets a value indicating whether 'Product type' field is shown </param>
/// <param name="VisibleIndividually"> Gets or sets a value indicating whether 'Visible individually' field is shown </param>
/// <param name="ProductTemplate"> Gets or sets a value indicating whether 'Product template' field is shown </param>
/// <param name="AdminComment"> Gets or sets a value indicating whether 'Admin comment' field is shown </param>
/// <param name="Vendor"> Gets or sets a value indicating whether 'Vendor' field is shown </param>
/// <param name="Stores"> Gets or sets a value indicating whether 'Stores' field is shown </param>
/// <param name="ACL"> Gets or sets a value indicating whether 'ACL' field is shown </param>
/// <param name="ShowOnHomepage"> Gets or sets a value indicating whether 'Show on home page' field is shown </param>
/// <param name="AllowCustomerReviews"> Gets or sets a value indicating whether 'Allow customer reviews' field is shown </param>
/// <param name="ProductTags"> Gets or sets a value indicating whether 'Product tags' field is shown </param>
/// <param name="ManufacturerPartNumber"> Gets or sets a value indicating whether 'Manufacturer part number' field is shown </param>
/// <param name="GTIN"> Gets or sets a value indicating whether 'GTIN' field is shown </param>
/// <param name="ProductCost"> Gets or sets a value indicating whether 'Product cost' field is shown </param>
/// <param name="TierPrices"> Gets or sets a value indicating whether 'Tier prices' field is shown </param>
/// <param name="Discounts"> Gets or sets a value indicating whether 'Discounts' field is shown </param>
/// <param name="DisableBuyButton"> Gets or sets a value indicating whether 'Disable buy button' field is shown </param>
/// <param name="DisableWishlistButton"> Gets or sets a value indicating whether 'Disable wishlist button' field is shown </param>
/// <param name="AvailableForPreOrder"> Gets or sets a value indicating whether 'Available for pre-order' field is shown </param>
/// <param name="CallForPrice"> Gets or sets a value indicating whether 'Call for price' field is shown </param>
/// <param name="OldPrice"> Gets or sets a value indicating whether 'Old price' field is shown </param>
/// <param name="CustomerEntersPrice"> Gets or sets a value indicating whether 'Customer enters price' field is shown </param>
/// <param name="PAngV"> Gets or sets a value indicating whether 'PAngV' field is shown </param>
/// <param name="RequireOtherProductsAddedToCart"> Gets or sets a value indicating whether 'Require other products added to the cart' field is shown </param>
/// <param name="IsGiftCard"> Gets or sets a value indicating whether 'Is gift card' field is shown </param>
/// <param name="DownloadableProduct"> Gets or sets a value indicating whether 'Downloadable product' field is shown </param>
/// <param name="RecurringProduct"> Gets or sets a value indicating whether 'Recurring product' field is shown </param>
/// <param name="IsRental"> Gets or sets a value indicating whether 'Is rental' field is shown </param>
/// <param name="FreeShipping"> Gets or sets a value indicating whether 'Free shipping' field is shown </param>
/// <param name="ShipSeparately"> Gets or sets a value indicating whether 'Ship separately' field is shown </param>
/// <param name="AdditionalShippingCharge"> Gets or sets a value indicating whether 'Additional shipping charge' field is shown </param>
/// <param name="DeliveryDate"> Gets or sets a value indicating whether 'Delivery date' field is shown </param>
/// <param name="ProductAvailabilityRange"> Gets or sets a value indicating whether 'Product availability range' field is shown </param>
/// <param name="UseMultipleWarehouses"> Gets or sets a value indicating whether 'Use multiple warehouses' field is shown </param>
/// <param name="Warehouse"> Gets or sets a value indicating whether 'Warehouse' field is shown </param>
/// <param name="DisplayStockAvailability"> Gets or sets a value indicating whether 'Display stock availability' field is shown </param>
/// <param name="MinimumStockQuantity"> Gets or sets a value indicating whether 'Minimum stock quantity' field is shown </param>
/// <param name="LowStockActivity"> Gets or sets a value indicating whether 'Low stock activity' field is shown </param>
/// <param name="NotifyAdminForQuantityBelow"> Gets or sets a value indicating whether 'Notify admin for quantity below' field is shown </param>
/// <param name="Backorders"> Gets or sets a value indicating whether 'Backorders' field is shown </param>
/// <param name="AllowBackInStockSubscriptions"> Gets or sets a value indicating whether 'Allow back in stock subscriptions' field is shown </param>
/// <param name="MinimumCartQuantity"> Gets or sets a value indicating whether 'Minimum cart quantity' field is shown </param>
/// <param name="MaximumCartQuantity"> Gets or sets a value indicating whether 'Maximum cart quantity' field is shown </param>
/// <param name="AllowedQuantities"> Gets or sets a value indicating whether 'Allowed quantities' field is shown </param>
/// <param name="AllowAddingOnlyExistingAttributeCombinations"> Gets or sets a value indicating whether 'Allow only existing attribute combinations' field is shown </param>
/// <param name="DisplayAttributeCombinationImagesOnly"> Gets or sets a value indicating whether to display attribute combination images only </param>
/// <param name="NotReturnable"> Gets or sets a value indicating whether 'Not returnable' field is shown </param>
/// <param name="Weight"> Gets or sets a value indicating whether 'Weight' field is shown </param>
/// <param name="Dimensions"> Gets or sets a value indicating whether 'Dimension' fields (height, length, width) are shown </param>
/// <param name="AvailableStartDate"> Gets or sets a value indicating whether 'Available start date' field is shown </param>
/// <param name="AvailableEndDate"> Gets or sets a value indicating whether 'Available end date' field is shown </param>
/// <param name="MarkAsNew"> Gets or sets a value indicating whether 'Mark as new' field is shown </param>
/// <param name="Published"> Gets or sets a value indicating whether 'Published' field is shown </param>
/// <param name="RelatedProducts"> Gets or sets a value indicating whether 'Related products' block is shown </param>
/// <param name="CrossSellsProducts"> Gets or sets a value indicating whether 'Cross-sells products' block is shown </param>
/// <param name="Seo"> Gets or sets a value indicating whether 'SEO' tab is shown </param>
/// <param name="PurchasedWithOrders"> Gets or sets a value indicating whether 'Purchased with orders' tab is shown </param>
/// <param name="ProductAttributes"> Gets or sets a value indicating whether 'Product attributes' tab is shown </param>
/// <param name="SpecificationAttributes"> Gets or sets a value indicating whether 'Specification attributes' tab is shown </param>
/// <param name="Manufacturers"> Gets or sets a value indicating whether 'Manufacturers' field is shown </param>
/// <param name="StockQuantityHistory"> Gets or sets a value indicating whether 'Stock quantity history' tab is shown </param>
public record ProductEditorSettingsViewModel(bool ProductType, bool VisibleIndividually, bool ProductTemplate, bool AdminComment, bool Vendor, bool Stores, bool ACL, bool ShowOnHomepage, bool AllowCustomerReviews, bool ProductTags, bool ManufacturerPartNumber, bool GTIN, bool ProductCost, bool TierPrices, bool Discounts, bool DisableBuyButton, bool DisableWishlistButton, bool AvailableForPreOrder, bool CallForPrice, bool OldPrice, bool CustomerEntersPrice, bool PAngV, bool RequireOtherProductsAddedToCart, bool IsGiftCard, bool DownloadableProduct, bool RecurringProduct, bool IsRental, bool FreeShipping, bool ShipSeparately, bool AdditionalShippingCharge, bool DeliveryDate, bool ProductAvailabilityRange, bool UseMultipleWarehouses, bool Warehouse, bool DisplayStockAvailability, bool MinimumStockQuantity, bool LowStockActivity, bool NotifyAdminForQuantityBelow, bool Backorders, bool AllowBackInStockSubscriptions, bool MinimumCartQuantity, bool MaximumCartQuantity, bool AllowedQuantities, bool AllowAddingOnlyExistingAttributeCombinations, bool DisplayAttributeCombinationImagesOnly, bool NotReturnable, bool Weight, bool Dimensions, bool AvailableStartDate, bool AvailableEndDate, bool MarkAsNew, bool Published, bool RelatedProducts, bool CrossSellsProducts, bool Seo, bool PurchasedWithOrders, bool ProductAttributes, bool SpecificationAttributes, bool Manufacturers, bool StockQuantityHistory);
