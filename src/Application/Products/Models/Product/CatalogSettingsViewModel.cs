namespace Application.Products.Models.Product;




















































































































/// <summary>
/// Catalog settings
/// </summary>
/// <param name="AllowViewUnpublishedProductPage"> Gets or sets a value indicating details pages of unpublished product details pages could be open (for SEO optimization) </param>
/// <param name="DisplayDiscontinuedMessageForUnpublishedProducts"> Gets or sets a value indicating customers should see "discontinued" message when visiting details pages of unpublished products (if "AllowViewUnpublishedProductPage" is "true) </param>
/// <param name="PublishBackProductWhenCancellingOrders"> Gets or sets a value indicating whether "Published" or "Disable buy/wishlist buttons" flags should be updated after order cancellation (deletion).
/// Of course, when qty > configured minimum stock level </param>
/// <param name="ShowSkuOnProductDetailsPage"> Gets or sets a value indicating whether to display product SKU on the product details page </param>
/// <param name="ShowSkuOnCatalogPages"> Gets or sets a value indicating whether to display product SKU on catalog pages </param>
/// <param name="ShowManufacturerPartNumber"> Gets or sets a value indicating whether to display manufacturer part number of a product </param>
/// <param name="ShowGtin"> Gets or sets a value indicating whether to display GTIN of a product </param>
/// <param name="ShowFreeShippingNotification"> Gets or sets a value indicating whether "Free shipping" icon should be displayed for products </param>
/// <param name="ShowShortDescriptionOnCatalogPages"> Gets or sets a value indicating whether short description should be displayed in product box </param>
/// <param name="AllowProductSorting"> Gets or sets a value indicating whether product sorting is enabled </param>
/// <param name="AllowProductViewModeChanging"> Gets or sets a value indicating whether customers are allowed to change product view mode </param>
/// <param name="DefaultViewMode"> Gets or sets a default view mode </param>
/// <param name="ShowProductsFromSubcategories"> Gets or sets a value indicating whether a category details page should include products from subcategories </param>
/// <param name="ShowCategoryProductNumber"> Gets or sets a value indicating whether number of products should be displayed beside each category </param>
/// <param name="ShowCategoryProductNumberIncludingSubcategories"> Gets or sets a value indicating whether we include subcategories (when 'ShowCategoryProductNumber' is 'true') </param>
/// <param name="CategoryBreadcrumbEnabled"> Gets or sets a value indicating whether category breadcrumb is enabled </param>
/// <param name="ShowShareButton"> Gets or sets a value indicating whether a 'Share button' is enabled </param>
/// <param name="PageShareCode"> Gets or sets a share code (e.g. ShareThis button code) </param>
/// <param name="ProductReviewsMustBeApproved"> Gets or sets a value indicating product reviews must be approved </param>
/// <param name="OneReviewPerProductFromCustomer"> Gets or sets a value indicating that customer can add only one review per product </param>
/// <param name="DefaultProductRatingValue"> Gets or sets a value indicating the default rating value of the product reviews </param>
/// <param name="AllowAnonymousUsersToReviewProduct"> Gets or sets a value indicating whether to allow anonymous users write product reviews. </param>
/// <param name="ProductReviewPossibleOnlyAfterPurchasing"> Gets or sets a value indicating whether product can be reviewed only by customer who have already ordered it </param>
/// <param name="NotifyStoreOwnerAboutNewProductReviews"> Gets or sets a value indicating whether notification of a store owner about new product reviews is enabled </param>
/// <param name="NotifyCustomerAboutProductReviewReply"> Gets or sets a value indicating whether customer notification about product review reply is enabled </param>
/// <param name="ShowProductReviewsPerStore"> Gets or sets a value indicating whether the product reviews will be filtered per store </param>
/// <param name="ShowProductReviewsTabOnAccountPage"> Gets or sets a show product reviews tab on account page </param>
/// <param name="ProductReviewsPageSizeOnAccountPage"> Gets or sets the page size for product reviews in account page </param>
/// <param name="ProductReviewsSortByCreatedDateAscending"> Gets or sets a value indicating whether the product reviews should be sorted by creation date as ascending </param>
/// <param name="EmailAFriendEnabled"> Gets or sets a value indicating whether product 'Email a friend' feature is enabled </param>
/// <param name="AllowAnonymousUsersToEmailAFriend"> Gets or sets a value indicating whether to allow anonymous users to email a friend. </param>
/// <param name="RecentlyViewedProductsNumber"> Gets or sets a number of "Recently viewed products" </param>
/// <param name="RecentlyViewedProductsEnabled"> Gets or sets a value indicating whether "Recently viewed products" feature is enabled </param>
/// <param name="NewProductsEnabled"> Gets or sets a value indicating whether "New products" page is enabled </param>
/// <param name="NewProductsPageSize"> Gets or sets a number of products on the "New products" page </param>
/// <param name="NewProductsAllowCustomersToSelectPageSize"> Gets or sets a value indicating whether customers are allowed to select page size on the "New products" page </param>
/// <param name="NewProductsPageSizeOptions"> Gets or sets the available customer selectable page size options on the "New products" page </param>
/// <param name="CompareProductsEnabled"> Gets or sets a value indicating whether "Compare products" feature is enabled </param>
/// <param name="CompareProductsNumber"> Gets or sets an allowed number of products to be compared </param>
/// <param name="ProductSearchAutoCompleteEnabled"> Gets or sets a value indicating whether autocomplete is enabled </param>
/// <param name="ProductSearchEnabled"> Gets or sets a value indicating whether the search box is displayed </param>
/// <param name="ProductSearchAutoCompleteNumberOfProducts"> Gets or sets a number of products to return when using "autocomplete" feature </param>
/// <param name="ShowProductImagesInSearchAutoComplete"> Gets or sets a value indicating whether to show product images in the auto complete search </param>
/// <param name="ShowLinkToAllResultInSearchAutoComplete"> Gets or sets a value indicating whether to show link to all result in the auto complete search </param>
/// <param name="ProductSearchTermMinimumLength"> Gets or sets a minimum search term length </param>
/// <param name="ShowBestsellersOnHomepage"> Gets or sets a value indicating whether to show bestsellers on home page </param>
/// <param name="NumberOfBestsellersOnHomepage"> Gets or sets a number of bestsellers on home page </param>
/// <param name="SearchPageProductsPerPage"> Gets or sets a number of products per page on the search products page </param>
/// <param name="SearchPageAllowCustomersToSelectPageSize"> Gets or sets a value indicating whether customers are allowed to select page size on the search products page </param>
/// <param name="SearchPagePageSizeOptions"> Gets or sets the available customer selectable page size options on the search products page </param>
/// <param name="SearchPagePriceRangeFiltering"> Gets or sets a value indicating whether the price range filtering is enabled on search page </param>
/// <param name="SearchPagePriceFrom"> Gets or sets the "from" price on search page </param>
/// <param name="SearchPagePriceTo"> Gets or sets the "to" price on search page </param>
/// <param name="SearchPageManuallyPriceRange"> Gets or sets a value indicating whether the price range should be entered manually on search page </param>
/// <param name="ProductsAlsoPurchasedEnabled"> Gets or sets "List of products purchased by other customers who purchased the above" option is enable </param>
/// <param name="ProductsAlsoPurchasedNumber"> Gets or sets a number of products also purchased by other customers to display </param>
/// <param name="AjaxProcessAttributeChange"> Gets or sets a value indicating whether we should process attribute change using AJAX. It's used for dynamical attribute change, SKU/GTIN update of combinations, conditional attributes </param>
/// <param name="NumberOfProductTags"> Gets or sets a number of product tags that appear in the tag cloud </param>
/// <param name="ProductsByTagPageSize"> Gets or sets a number of products per page on 'products by tag' page </param>
/// <param name="ProductsByTagAllowCustomersToSelectPageSize"> Gets or sets a value indicating whether customers can select the page size for 'products by tag' </param>
/// <param name="ProductsByTagPageSizeOptions"> Gets or sets the available customer selectable page size options for 'products by tag' </param>
/// <param name="ProductsByTagPriceRangeFiltering"> Gets or sets a value indicating whether the price range filtering is enabled on 'products by tag' page </param>
/// <param name="ProductsByTagPriceFrom"> Gets or sets the "from" price on 'products by tag' page </param>
/// <param name="ProductsByTagPriceTo"> Gets or sets the "to" price on 'products by tag' page </param>
/// <param name="ProductsByTagManuallyPriceRange"> Gets or sets a value indicating whether the price range should be entered manually on 'products by tag' page </param>
/// <param name="IncludeShortDescriptionInCompareProducts"> Gets or sets a value indicating whether to include "Short description" in compare products </param>
/// <param name="IncludeFullDescriptionInCompareProducts"> Gets or sets a value indicating whether to include "Full description" in compare products </param>
/// <param name="IncludeFeaturedProductsInNormalLists"> An option indicating whether products on category and manufacturer pages should include featured products as well </param>
/// <param name="UseLinksInRequiredProductWarnings"> Gets or sets a value indicating whether to render link to required products in "Require other products added to the cart" warning </param>
/// <param name="DisplayTierPricesWithDiscounts"> Gets or sets a value indicating whether tier prices should be displayed with applied discounts (if available) </param>
/// <param name="IgnoreDiscounts"> Gets or sets a value indicating whether to ignore discounts (side-wide). It can significantly improve performance when enabled. </param>
/// <param name="IgnoreFeaturedProducts"> Gets or sets a value indicating whether to ignore featured products (side-wide). It can significantly improve performance when enabled. </param>
/// <param name="IgnoreAcl"> Gets or sets a value indicating whether to ignore ACL rules (side-wide). It can significantly improve performance when enabled. </param>
/// <param name="IgnoreStoreLimitations"> Gets or sets a value indicating whether to ignore "limit per store" rules (side-wide). It can significantly improve performance when enabled. </param>
/// <param name="CacheProductPrices"> Gets or sets a value indicating whether to cache product prices. It can significantly improve performance when enabled. </param>
/// <param name="MaximumBackInStockSubscriptions"> Gets or sets a value indicating maximum number of 'back in stock' subscription </param>
/// <param name="ManufacturersBlockItemsToDisplay"> Gets or sets the value indicating how many manufacturers to display in manufacturers block </param>
/// <param name="DisplayTaxShippingInfoFooter"> Gets or sets a value indicating whether to display information about shipping and tax in the footer (used in Germany) </param>
/// <param name="DisplayTaxShippingInfoProductDetailsPage"> Gets or sets a value indicating whether to display information about shipping and tax on product details pages (used in Germany) </param>
/// <param name="DisplayTaxShippingInfoProductBoxes"> Gets or sets a value indicating whether to display information about shipping and tax in product boxes (used in Germany) </param>
/// <param name="DisplayTaxShippingInfoShoppingCart"> Gets or sets a value indicating whether to display information about shipping and tax on shopping cart page (used in Germany) </param>
/// <param name="DisplayTaxShippingInfoWishlist"> Gets or sets a value indicating whether to display information about shipping and tax on wishlist page (used in Germany) </param>
/// <param name="DisplayTaxShippingInfoOrderDetailsPage"> Gets or sets a value indicating whether to display information about shipping and tax on order details page (used in Germany) </param>
/// <param name="DefaultCategoryPageSizeOptions"> Gets or sets the default value to use for Category page size options (for new categories) </param>
/// <param name="DefaultCategoryPageSize"> Gets or sets the default value to use for Category page size (for new categories) </param>
/// <param name="DefaultManufacturerPageSizeOptions"> Gets or sets the default value to use for Manufacturer page size options (for new manufacturers) </param>
/// <param name="DefaultManufacturerPageSize"> Gets or sets the default value to use for Manufacturer page size (for new manufacturers) </param>
/// <param name="ProductSortingEnumDisabled"> Gets or sets a list of disabled values of ProductSortingEnum </param>
/// <param name="ProductSortingEnumDisplayOrder"> Gets or sets a display order of ProductSortingEnum values  </param>
/// <param name="ExportImportProductAttributes"> Gets or sets a value indicating whether the products need to be exported/imported with their attributes </param>
/// <param name="ExportImportProductUseLimitedToStores"> Gets or sets a value indicating whether need to use "limited to stores" property for exported/imported products </param>
/// <param name="ExportImportProductSpecificationAttributes"> Gets or sets a value indicating whether the products need to be exported/imported with their specification attributes </param>
/// <param name="ExportImportUseDropdownlistsForAssociatedEntities"> Gets or sets a value indicating whether need create dropdown list for export </param>
/// <param name="ExportImportProductCategoryBreadcrumb"> Gets or sets a value indicating whether the products should be exported/imported with a full category name including names of all its parents </param>
/// <param name="ExportImportCategoriesUsingCategoryName"> Gets or sets a value indicating whether the categories need to be exported/imported using name of category </param>
/// <param name="ExportImportAllowDownloadImages"> Gets or sets a value indicating whether the images can be downloaded from remote server </param>
/// <param name="ExportImportSplitProductsFile"> Gets or sets a value indicating whether products must be importing by separated files </param>
/// <param name="ExportImportProductsCountInOneFile"> Gets or sets a value of max products count in one file  </param>
/// <param name="RemoveRequiredProducts"> Gets or sets a value indicating whether to remove required products from the cart if the main one is removed </param>
/// <param name="ExportImportRelatedEntitiesByName"> Gets or sets a value indicating whether the related entities need to be exported/imported using name </param>
/// <param name="CountDisplayedYearsDatePicker"> Gets or sets count of displayed years for datepicker </param>
/// <param name="DisplayDatePreOrderAvailability"> Get or set a value indicating whether it's necessary to show the date for pre-order availability in a public store </param>
/// <param name="UseAjaxLoadMenu"> Get or set a value indicating whether to use a standard menu in public store or use Ajax to load a menu </param>
/// <param name="UseAjaxCatalogProductsLoading"> Get or set a value indicating whether to use standard or AJAX products loading (applicable to 'paging', 'filtering', 'view modes') in catalog </param>
/// <param name="EnableManufacturerFiltering"> Get or set a value indicating whether the manufacturer filtering is enabled on catalog pages </param>
/// <param name="EnablePriceRangeFiltering"> Get or set a value indicating whether the price range filtering is enabled on catalog pages </param>
/// <param name="EnableSpecificationAttributeFiltering"> Get or set a value indicating whether the specification attribute filtering is enabled on catalog pages </param>
/// <param name="DisplayFromPrices"> Get or set a value indicating whether the "From" prices (based on price adjustments of combinations and attributes) are displayed on catalog pages </param>
/// <param name="AttributeValueOutOfStockDisplayType"> Gets or sets the attribute value display type when out of stock </param>
/// <param name="AllowCustomersToSearchWithManufacturerName"> Gets or sets a value indicating whether customer can search with manufacturer name </param>
/// <param name="AllowCustomersToSearchWithCategoryName"> Gets or sets a value indicating whether customer can search with category name </param>
/// <param name="DisplayAllPicturesOnCatalogPages"> Gets or sets a value indicating whether all pictures will be displayed on catalog pages </param>
/// <param name="ProductUrlStructureTypeId"> Gets or sets the identifier of product URL structure type (e.g. '/category-seo-name/product-seo-name' or '/product-seo-name') </param>
/// <param name="ActiveSearchProviderSystemName"> Gets or sets an system name of active search provider </param>
/// <param name="UseStandardSearchWhenSearchProviderThrowsException"> Gets or sets a value indicating whether standard search will be used when the search provider throws an exception </param>
public record CatalogSettingsViewModel(bool AllowViewUnpublishedProductPage, bool DisplayDiscontinuedMessageForUnpublishedProducts, bool PublishBackProductWhenCancellingOrders, bool ShowSkuOnProductDetailsPage, bool ShowSkuOnCatalogPages, bool ShowManufacturerPartNumber, bool ShowGtin, bool ShowFreeShippingNotification, bool ShowShortDescriptionOnCatalogPages, bool AllowProductSorting, bool AllowProductViewModeChanging, string DefaultViewMode, bool ShowProductsFromSubcategories, bool ShowCategoryProductNumber, bool ShowCategoryProductNumberIncludingSubcategories, bool CategoryBreadcrumbEnabled, bool ShowShareButton, string PageShareCode, bool ProductReviewsMustBeApproved, bool OneReviewPerProductFromCustomer, int DefaultProductRatingValue, bool AllowAnonymousUsersToReviewProduct, bool ProductReviewPossibleOnlyAfterPurchasing, bool NotifyStoreOwnerAboutNewProductReviews, bool NotifyCustomerAboutProductReviewReply, bool ShowProductReviewsPerStore, bool ShowProductReviewsTabOnAccountPage, int ProductReviewsPageSizeOnAccountPage, bool ProductReviewsSortByCreatedDateAscending, bool EmailAFriendEnabled, bool AllowAnonymousUsersToEmailAFriend, int RecentlyViewedProductsNumber, bool RecentlyViewedProductsEnabled, bool NewProductsEnabled, int NewProductsPageSize, bool NewProductsAllowCustomersToSelectPageSize, string NewProductsPageSizeOptions, bool CompareProductsEnabled, int CompareProductsNumber, bool ProductSearchAutoCompleteEnabled, bool ProductSearchEnabled, int ProductSearchAutoCompleteNumberOfProducts, bool ShowProductImagesInSearchAutoComplete, bool ShowLinkToAllResultInSearchAutoComplete, int ProductSearchTermMinimumLength, bool ShowBestsellersOnHomepage, int NumberOfBestsellersOnHomepage, int SearchPageProductsPerPage, bool SearchPageAllowCustomersToSelectPageSize, string SearchPagePageSizeOptions, bool SearchPagePriceRangeFiltering, decimal SearchPagePriceFrom, decimal SearchPagePriceTo, bool SearchPageManuallyPriceRange, bool ProductsAlsoPurchasedEnabled, int ProductsAlsoPurchasedNumber, bool AjaxProcessAttributeChange, int NumberOfProductTags, int ProductsByTagPageSize, bool ProductsByTagAllowCustomersToSelectPageSize, string ProductsByTagPageSizeOptions, bool ProductsByTagPriceRangeFiltering, decimal ProductsByTagPriceFrom, decimal ProductsByTagPriceTo, bool ProductsByTagManuallyPriceRange, bool IncludeShortDescriptionInCompareProducts, bool IncludeFullDescriptionInCompareProducts, bool IncludeFeaturedProductsInNormalLists, bool UseLinksInRequiredProductWarnings, bool DisplayTierPricesWithDiscounts, bool IgnoreDiscounts, bool IgnoreFeaturedProducts, bool IgnoreAcl, bool IgnoreStoreLimitations, bool CacheProductPrices, int MaximumBackInStockSubscriptions, int ManufacturersBlockItemsToDisplay, bool DisplayTaxShippingInfoFooter, bool DisplayTaxShippingInfoProductDetailsPage, bool DisplayTaxShippingInfoProductBoxes, bool DisplayTaxShippingInfoShoppingCart, bool DisplayTaxShippingInfoWishlist, bool DisplayTaxShippingInfoOrderDetailsPage, string DefaultCategoryPageSizeOptions, int DefaultCategoryPageSize, string DefaultManufacturerPageSizeOptions, int DefaultManufacturerPageSize, List<int> ProductSortingEnumDisabled, Dictionary<int, int> ProductSortingEnumDisplayOrder, bool ExportImportProductAttributes, bool ExportImportProductUseLimitedToStores, bool ExportImportProductSpecificationAttributes, bool ExportImportUseDropdownlistsForAssociatedEntities, bool ExportImportProductCategoryBreadcrumb, bool ExportImportCategoriesUsingCategoryName, bool ExportImportAllowDownloadImages, bool ExportImportSplitProductsFile, int ExportImportProductsCountInOneFile, bool RemoveRequiredProducts, bool ExportImportRelatedEntitiesByName, int CountDisplayedYearsDatePicker, bool DisplayDatePreOrderAvailability, bool UseAjaxLoadMenu, bool UseAjaxCatalogProductsLoading, bool EnableManufacturerFiltering, bool EnablePriceRangeFiltering, bool EnableSpecificationAttributeFiltering, bool DisplayFromPrices, AttributeValueOutOfStockDisplayType AttributeValueOutOfStockDisplayType, bool AllowCustomersToSearchWithManufacturerName, bool AllowCustomersToSearchWithCategoryName, bool DisplayAllPicturesOnCatalogPages, int ProductUrlStructureTypeId, string ActiveSearchProviderSystemName, bool UseStandardSearchWhenSearchProviderThrowsException)
{
    public CatalogSettingsViewModel() : this(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, new List<int>(), new Dictionary<int, int>(), default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default)
    {
    }
}
