# PowerShell script to generate query handlers using CommandResult model in a Clean Architecture-based project

# Define the base command for creating use cases in Clean Architecture
$baseCommand = "dotnet new ca-usecase --feature-name Products"

# Define queries with specific return types encapsulated in CommandResult
$queries = @(
    "GetProductById --usecase-type query --return-type 'CommandResult<Product>'",
    "GetProductsByIds --usecase-type query --return-type 'CommandResult<List<Product>>'",
    "GetAllProductsDisplayedOnHomepage --usecase-type query --return-type 'CommandResult<List<Product>>'",
    "GetCategoryFeaturedProducts --usecase-type query --return-type 'CommandResult<List<Product>>'",
    "GetManufacturerFeaturedProducts --usecase-type query --return-type 'CommandResult<List<Product>>'",
    "GetProductsMarkedAsNew --usecase-type query --return-type 'CommandResult<List<Product>>'",
    "SearchProducts --usecase-type query --return-type 'CommandResult<IPagedList<Product>>'",
    "GetLowStockProducts --usecase-type query --return-type 'CommandResult<IPagedList<Product>>'",
    "GetAssociatedProducts --usecase-type query --return-type 'CommandResult<List<Product>>'",
    "GetProductBySku --usecase-type query --return-type 'CommandResult<Product>'",
    "GetProductsBySku --usecase-type query --return-type 'CommandResult<List<Product>>'",
    "GetNumberOfProductsInCategory --usecase-type query --return-type 'CommandResult<int>'",
    "GetNumberOfProductsByVendorId --usecase-type query --return-type 'CommandResult<int>'",
    "GetAllProductReviews --usecase-type query --return-type 'CommandResult<IPagedList<ProductReview>>'",
    "GetProductReviewById --usecase-type query --return-type 'CommandResult<ProductReview>'",
    "GetProductReviewsByIds --usecase-type query --return-type 'CommandResult<List<ProductReview>>'",
    "CanAddReview --usecase-type query --return-type 'CommandResult<bool>'",
    "GetAllProductWarehouseInventoryRecords --usecase-type query --return-type 'CommandResult<List<ProductWarehouseInventory>>'",
    "GetStockQuantityHistory --usecase-type query --return-type 'CommandResult<IPagedList<StockQuantityHistory>>'",
    "GetTierPrices --usecase-type query --return-type 'CommandResult<List<TierPrice>>'",
    "GetTierPricesByProduct --usecase-type query --return-type 'CommandResult<List<TierPrice>>'",
    "GetPreferredTierPrice --usecase-type query --return-type 'CommandResult<TierPrice>'",
    "GetProductPicturesByProductId --usecase-type query --return-type 'CommandResult<List<ProductPicture>>'",
    "GetProductPictureById --usecase-type query --return-type 'CommandResult<ProductPicture>'",
    "GetProductsWithAppliedDiscount --usecase-type query --return-type 'CommandResult<IPagedList<Product>>'",
    "GetProductVideosByProductId --usecase-type query --return-type 'CommandResult<List<ProductVideo>>'",
    "GetProductVideoById --usecase-type query --return-type 'CommandResult<ProductVideo>'"
)

# Execute each command to generate the use cases
foreach ($query in $queries) {
    Write-Host "Generating query for: $query"
    Invoke-Expression "$baseCommand --name $query"
    Write-Host "Generated successfully.`n"
}
