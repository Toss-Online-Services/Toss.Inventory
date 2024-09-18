using Domain.Entities.Catalog;
using Domain.Services.Catalog;
using Microsoft.AspNetCore.Mvc;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        var productGroup = app.MapGroup("/api/products");

        productGroup.MapGet("/homepage", GetAllProductsDisplayedOnHomepage);
        productGroup.MapGet("/category/featured", GetCategoryFeaturedProducts);
        productGroup.MapGet("/manufacturer/featured", GetManufacturerFeaturedProducts);
        productGroup.MapGet("/new", GetProductsMarkedAsNew);
        productGroup.MapGet("/{productId}", GetProductById);
        productGroup.MapGet("/ids", GetProductsByIds);
        productGroup.MapPost("/", InsertProduct);
        productGroup.MapPut("/{productId}", UpdateProduct);
        productGroup.MapDelete("/{productId}", DeleteProduct);
        productGroup.MapDelete("/bulk", DeleteProducts);
    }

    private static async Task<IResult> GetAllProductsDisplayedOnHomepage([FromServices] IProductService productService)
    {
        var products = await productService.GetAllProductsDisplayedOnHomepageAsync();
        return Results.Ok(products);
    }

    private static async Task<IResult> GetCategoryFeaturedProducts([FromQuery] int categoryId, [FromQuery] int storeId, [FromServices] IProductService productService)
    {
        var products = await productService.GetCategoryFeaturedProductsAsync(categoryId, storeId);
        return Results.Ok(products);
    }

    private static async Task<IResult> GetManufacturerFeaturedProducts([FromQuery] int manufacturerId, [FromQuery] int storeId, [FromServices] IProductService productService)
    {
        var products = await productService.GetManufacturerFeaturedProductsAsync(manufacturerId, storeId);
        return Results.Ok(products);
    }

    private static async Task<IResult> GetProductsMarkedAsNew([FromQuery] int storeId, [FromQuery] int pageIndex, [FromQuery] int pageSize, [FromServices] IProductService productService)
    {
        var products = await productService.GetProductsMarkedAsNewAsync(storeId, pageIndex, pageSize);
        return Results.Ok(products);
    }

    private static async Task<IResult> GetProductById([FromRoute] int productId, [FromServices] IProductService productService)
    {
        var product = await productService.GetProductByIdAsync(productId);
        if (product == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(product);
    }

    private static async Task<IResult> GetProductsByIds([FromQuery] int[] productIds, [FromServices] IProductService productService)
    {
        var products = await productService.GetProductsByIdsAsync(productIds);
        return Results.Ok(products);
    }

    private static async Task<IResult> InsertProduct([FromBody] Product product, [FromServices] IProductService productService)
    {
        await productService.InsertProductAsync(product);
        return Results.Created($"/api/products/{product.Id}", product);
    }

    private static async Task<IResult> UpdateProduct([FromRoute] int productId, [FromBody] Product product, [FromServices] IProductService productService)
    {
        var existingProduct = await productService.GetProductByIdAsync(productId);
        if (existingProduct == null)
        {
            return Results.NotFound();
        }

        product.Id = productId;
        await productService.UpdateProductAsync(product);
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteProduct([FromRoute] int productId, [FromServices] IProductService productService)
    {
        var product = await productService.GetProductByIdAsync(productId);
        if (product == null)
        {
            return Results.NotFound();
        }

        await productService.DeleteProductAsync(product);
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteProducts([FromBody] int[] productIds, [FromServices] IProductService productService)
    {
        var products = await productService.GetProductsByIdsAsync(productIds);
        if (products == null || !products.Any())
        {
            return Results.NotFound();
        }

        await productService.DeleteProductsAsync(products);
        return Results.NoContent();
    }
}
