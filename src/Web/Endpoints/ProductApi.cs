using Domain.Entities.Catalog;
using Domain.Entities.Orders;
using Domain.Services.Catalog;
using Domain.Services.Messages;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Domain.Services.Logging;

public class ProductApi
{
    private readonly IProductService _productService;
    private readonly IProductModelFactory _productModelFactory;
    private readonly ICustomerActivityService _customerActivityService;

    public ProductApi(IProductService productService,
                             IProductModelFactory productModelFactory,
                             ICustomerActivityService customerActivityService)
    {
        _productService = productService;
        _productModelFactory = productModelFactory;
        _customerActivityService = customerActivityService;
    }
    public void Map(WebApplication app)
    {
        app.MapGroup("/product")
            //.RequireAuthorization()
            .MapGet("/{productId:int}", GetProductDetails)
            .MapPost("/estimate-shipping", EstimateShipping)
            .MapGet("/combinations/{productId:int}", GetProductCombinations)
            .MapGet("/recently-viewed", RecentlyViewedProducts)
            .MapPost("/reviews", AddProductReview)
            .MapPost("/reviews/helpfulness", SetProductReviewHelpfulness)
            .MapGet("/reviews/customer", CustomerProductReviews)
            .MapGet("/email-friend/{productId:int}", ProductEmailAFriend)
            .MapPost("/email-friend", ProductEmailAFriendSend)
            .MapPost("/compare/add/{productId:int}", AddProductToCompareList)
            .MapPost("/compare/remove/{productId:int}", RemoveProductFromCompareList)
            .MapGet("/compare", CompareProducts)
            .MapPost("/compare/clear", ClearCompareList)
            .MapGet(ProductDetails)
            .MapPost(AddProduct)
            .MapPut(UpdateProduct, "UpdateProduct/{id}")
            .MapPut(UpdateStockQuantity, "UpdateStockQuantity/{id}")
            .MapPut(UpdatePrice, "UpdatePrice/{id}")
            .MapPut(UpdateProductAvailability, "UpdateAvailability/{id}")
            .MapDelete(DeleteProduct, "DeleteProduct/{id}");
    }
    private async Task<IResult> ProductDetails(int productId)
    {
        var product = await _productService.GetProductByIdAsync(productId);
        if (product == null)
        {
            return Results.NotFound();
        }

        var model = await _productModelFactory.PrepareProductDetailsModelAsync(product);
        return Results.Ok(model);
    }

    private async Task<IResult> AddProduct(ProductModel model)
    {
        if (!ModelState.IsValid)
        {
            return Results.BadRequest();
        }

        var product = model.ToEntity();
        await _productService.InsertProductAsync(product);

        // Log activity
        await _customerActivityService.InsertActivityAsync("AddProduct", $"Product added: {product.Name}");

        return Results.Ok();
    }

    private async Task<IResult> UpdateProduct(int id, ProductModel model)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return Results.NotFound();
        }

        product = model.ToEntity(product);
        await _productService.UpdateProductAsync(product);

        return Results.Ok();
    }

    private async Task<IResult> UpdateStockQuantity(int id, int quantity)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return Results.NotFound();
        }

        product.StockQuantity = quantity;
        await _productService.UpdateProductAsync(product);

        return Results.Ok();
    }

    private async Task<IResult> UpdatePrice(int id, decimal price)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return Results.NotFound();
        }

        product.Price = price;
        await _productService.UpdateProductAsync(product);

        return Results.Ok();
    }

    private async Task<IResult> UpdateProductAvailability(int id, bool isAvailable)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return Results.NotFound();
        }

        product.Published = isAvailable;
        await _productService.UpdateProductAsync(product);

        return Results.Ok();
    }

    private async Task<IResult> DeleteProduct(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return Results.NotFound();
        }

        await _productService.DeleteProductAsync(product);

        return Results.Ok();
    }

    private async Task<IResult> GetProductDetails(
        [FromServices] IProductService productService,
        [FromServices] IProductModelFactory productModelFactory,
        [FromServices] IShoppingCartService shoppingCartService,
        [FromServices] IStoreContext storeContext,
        [FromServices] IWorkContext workContext,
        int productId, int updatecartitemid = 0)
    {
        var product = await productService.GetProductByIdAsync(productId);
        if (product == null || product.Deleted)
            return Results.NotFound();

        var store = await storeContext.GetCurrentStoreAsync();
        var customer = await workContext.GetCurrentCustomerAsync();
        var cart = await shoppingCartService.GetShoppingCartAsync(customer, storeId: store.Id);

        // model
        var model = await productModelFactory.PrepareProductDetailsModelAsync(product, null, false);
        return Results.Ok(model);
    }

    private async Task<IResult> EstimateShipping(
        [FromServices] IProductService productService,
        [FromServices] IShoppingCartService shoppingCartService,
        [FromServices] IShoppingCartModelFactory shoppingCartModelFactory,
        [FromServices] IWorkContext workContext,
        [FromServices] IStoreContext storeContext,
        ProductDetailsModel.ProductEstimateShippingModel model, IFormCollection form)
    {
        if (model == null) return Results.BadRequest();

        var product = await productService.GetProductByIdAsync(model.ProductId);
        if (product == null || product.Deleted) return Results.NotFound();

        var store = await storeContext.GetCurrentStoreAsync();
        var customer = await workContext.GetCurrentCustomerAsync();
        var wrappedProduct = new ShoppingCartItem { StoreId = store.Id, ProductId = product.Id };

        // prepare model
        var result = await shoppingCartModelFactory.PrepareEstimateShippingResultModelAsync(new[] { wrappedProduct }, model, false);
        return Results.Ok(result);
    }

    private async Task<IResult> GetProductCombinations(
        [FromServices] IProductService productService,
        [FromServices] IProductModelFactory productModelFactory,
        int productId)
    {
        var product = await productService.GetProductByIdAsync(productId);
        if (product == null) return Results.NotFound();

        var model = await productModelFactory.PrepareProductCombinationModelsAsync(product);
        return Results.Ok(model);
    }

    private async Task<IResult> RecentlyViewedProducts(
        [FromServices] IRecentlyViewedProductsService recentlyViewedProductsService,
        [FromServices] IProductModelFactory productModelFactory)
    {
        var products = await recentlyViewedProductsService.GetRecentlyViewedProductsAsync(10); // Example
        var model = await productModelFactory.PrepareProductOverviewModelsAsync(products);
        return Results.Ok(model);
    }

    private async Task<IResult> AddProductReview(
        [FromServices] IProductService productService,
        [FromServices] IProductModelFactory productModelFactory,
        ProductReviewsModel model)
    {
        var product = await productService.GetProductByIdAsync(model.ProductId);
        if (product == null) return Results.NotFound();

        await productService.InsertProductReviewAsync(new ProductReview
        {
            ProductId = model.ProductId,
            ReviewText = model.AddProductReview.ReviewText,
            Rating = model.AddProductReview.Rating
        });

        return Results.Ok(model);
    }

    private async Task<IResult> SetProductReviewHelpfulness(
        [FromServices] IProductService productService,
        int productReviewId, bool washelpful)
    {
        var review = await productService.GetProductReviewByIdAsync(productReviewId);
        if (review == null) return Results.NotFound();

        await productService.SetProductReviewHelpfulnessAsync(review, washelpful);
        return Results.Ok();
    }

    private async Task<IResult> CustomerProductReviews(
        [FromServices] IProductModelFactory productModelFactory,
        int? pageNumber)
    {
        var model = await productModelFactory.PrepareCustomerProductReviewsModelAsync(pageNumber);
        return Results.Ok(model);
    }

    private async Task<IResult> ProductEmailAFriend(
        [FromServices] IProductService productService,
        [FromServices] IProductModelFactory productModelFactory,
        int productId)
    {
        var product = await productService.GetProductByIdAsync(productId);
        if (product == null) return Results.NotFound();

        var model = await productModelFactory.PrepareProductEmailAFriendModelAsync(new ProductEmailAFriendModel(), product, false);
        return Results.Ok(model);
    }

    private async Task<IResult> ProductEmailAFriendSend(
        [FromServices] IProductService productService,
        [FromServices] IWorkflowMessageService workflowMessageService,
        ProductEmailAFriendModel model)
    {
        var product = await productService.GetProductByIdAsync(model.ProductId);
        if (product == null) return Results.NotFound();

        await workflowMessageService.SendProductEmailAFriendMessageAsync(
            customer: null, languageId: 1, product: product, model.YourEmailAddress, model.FriendEmail, model.PersonalMessage);
        return Results.Ok("Email sent");
    }

    private async Task<IResult> AddProductToCompareList(
        [FromServices] ICompareProductsService compareProductsService,
        [FromServices] IProductService productService,
        int productId)
    {
        var product = await productService.GetProductByIdAsync(productId);
        if (product == null) return Results.NotFound();

        await compareProductsService.AddProductToCompareListAsync(productId);
        return Results.Ok("Product added to compare list");
    }

    private async Task<IResult> RemoveProductFromCompareList(
        [FromServices] ICompareProductsService compareProductsService,
        [FromServices] IProductService productService,
        int productId)
    {
        var product = await productService.GetProductByIdAsync(productId);
        if (product == null) return Results.NotFound();

        await compareProductsService.RemoveProductFromCompareListAsync(productId);
        return Results.Ok("Product removed from compare list");
    }

    private async Task<IResult> CompareProducts(
        [FromServices] ICompareProductsService compareProductsService,
        [FromServices] IProductModelFactory productModelFactory)
    {
        var products = await compareProductsService.GetComparedProductsAsync();
        var model = await productModelFactory.PrepareProductOverviewModelsAsync(products);
        return Results.Ok(model);
    }

    private IResult ClearCompareList([FromServices] ICompareProductsService compareProductsService)
    {
        compareProductsService.ClearCompareProducts();
        return Results.Ok("Compare list cleared");
    }
}
