//using Application;
//using Application.Products.Commands.CreateProduct;
//using Application.Products.Commands.Requests;
//using Application.Products.Models.Product;
//using Application.Products.Queries.GetProductsWithPagination;
//using Domain.Entities.Catalog;
//using Domain.Rss;
//using Domain;
//using Microsoft.AspNetCore.Mvc;
//using Web.Infrastructure;
//using Domain.Services.Catalog;
//using Domain.Services.Logging;
//using Domain.Services.Localization;

//namespace Web.Endpoints;

//public class CatalogApi
//{
//    public void Map(WebApplication app)
//    {
//        app.MapGroup("/catalog")
//            // You can uncomment the following line if you need authorization
//            //.RequireAuthorization()
//            .MapGet("/category/{categoryId:int}", GetCategory)
//            .MapGet("/category/products/{categoryId:int}", GetCategoryProducts)
//            .MapPost("/catalogRoot", GetCatalogRoot)
//            .MapPost("/catalogSubCategories/{id:int}", GetCatalogSubCategories)
//            .MapGet("/manufacturer/{manufacturerId:int}", GetManufacturer)
//            .MapGet("/manufacturer/products/{manufacturerId:int}", GetManufacturerProducts)
//            .MapGet("/manufacturer/all", GetAllManufacturers)
//            .MapGet("/vendor/{vendorId:int}", GetVendor)
//            .MapGet("/vendor/products/{vendorId:int}", GetVendorProducts)
//            .MapGet("/vendor/all", GetAllVendors)
//            .MapGet("/product/tag/{productTagId:int}", GetProductsByTag)
//            .MapGet("/product/tag/products/{tagId:int}", GetTagProducts)
//            .MapGet("/product/tag/all", GetAllProductTags)
//            .MapGet("/products/new", GetNewProducts)
//            .MapGet("/products/new/rss", GetNewProductsRss)
//            .MapPost("/search", SearchProducts)
//            .MapGet("/search/termAutoComplete", SearchTermAutoComplete);
//    }

//    private async Task<IResult> GetCategory(
//        [FromServices] ICategoryService categoryService,
//        [FromServices] ICatalogModelFactory catalogModelFactory,
//        [FromServices] IStoreContext storeContext,
//        [FromServices] ICustomerActivityService customerActivityService,
//        [FromServices] ILocalizationService localizationService,
//        int categoryId,
//        CatalogProductsCommand command)
//    {
//        var category = await categoryService.GetCategoryByIdAsync(categoryId);
//        if (category == null || !category.Published)
//        {
//            return Results.NotFound();
//        }

//        var store = await storeContext.GetCurrentStoreAsync();
//        var model = await catalogModelFactory.PrepareCategoryModelAsync(category, command);

//        // Log activity for viewing category
//        await customerActivityService.InsertActivityAsync("PublicStore.ViewCategory",
//            string.Format(await localizationService.GetResourceAsync("ActivityLog.PublicStore.ViewCategory"), category.Name), category);

//        return Results.Ok(model);
//    }

//    private async Task<IResult> GetCategoryProducts(
//        [FromServices] ICategoryService categoryService,
//        [FromServices] ICatalogModelFactory catalogModelFactory,
//        int categoryId, CatalogProductsCommand command)
//    {
//        var category = await categoryService.GetCategoryByIdAsync(categoryId);
//        if (category == null || !category.Published)
//        {
//            return Results.NotFound();
//        }

//        var model = await catalogModelFactory.PrepareCategoryProductsModelAsync(category, command);
//        return Results.Ok(model);
//    }

//    private async Task<IResult> GetCatalogRoot([FromServices] ICatalogModelFactory catalogModelFactory)
//    {
//        var model = await catalogModelFactory.PrepareRootCategoriesAsync();
//        return Results.Ok(model);
//    }

//    private async Task<IResult> GetCatalogSubCategories(
//        [FromServices] ICatalogModelFactory catalogModelFactory,
//        int id)
//    {
//        var model = await catalogModelFactory.PrepareSubCategoriesAsync(id);
//        return Results.Ok(model);
//    }

//    private async Task<IResult> GetManufacturer(
//        [FromServices] IManufacturerService manufacturerService,
//        [FromServices] ICatalogModelFactory catalogModelFactory,
//        int manufacturerId,
//        CatalogProductsCommand command)
//    {
//        var manufacturer = await manufacturerService.GetManufacturerByIdAsync(manufacturerId);
//        if (manufacturer == null || !manufacturer.Published)
//        {
//            return Results.NotFound();
//        }

//        var model = await catalogModelFactory.PrepareManufacturerModelAsync(manufacturer, command);
//        return Results.Ok(model);
//    }

//    private async Task<IResult> GetManufacturerProducts(
//        [FromServices] IManufacturerService manufacturerService,
//        [FromServices] ICatalogModelFactory catalogModelFactory,
//        int manufacturerId, CatalogProductsCommand command)
//    {
//        var manufacturer = await manufacturerService.GetManufacturerByIdAsync(manufacturerId);
//        if (manufacturer == null || !manufacturer.Published)
//        {
//            return Results.NotFound();
//        }

//        var model = await catalogModelFactory.PrepareManufacturerProductsModelAsync(manufacturer, command);
//        return Results.Ok(model);
//    }

//    private async Task<IResult> GetAllManufacturers(
//        [FromServices] ICatalogModelFactory catalogModelFactory)
//    {
//        var model = await catalogModelFactory.PrepareManufacturerAllModelsAsync();
//        return Results.Ok(model);
//    }

//    private async Task<IResult> GetVendor(
//        [FromServices] IVendorService vendorService,
//        [FromServices] ICatalogModelFactory catalogModelFactory,
//        int vendorId,
//        CatalogProductsCommand command)
//    {
//        var vendor = await vendorService.GetVendorByIdAsync(vendorId);
//        if (vendor == null || !vendor.Active)
//        {
//            return Results.NotFound();
//        }

//        var model = await catalogModelFactory.PrepareVendorModelAsync(vendor, command);
//        return Results.Ok(model);
//    }

//    private async Task<IResult> GetVendorProducts(
//        [FromServices] IVendorService vendorService,
//        [FromServices] ICatalogModelFactory catalogModelFactory,
//        int vendorId, CatalogProductsCommand command)
//    {
//        var vendor = await vendorService.GetVendorByIdAsync(vendorId);
//        if (vendor == null || !vendor.Active)
//        {
//            return Results.NotFound();
//        }

//        var model = await catalogModelFactory.PrepareVendorProductsModelAsync(vendor, command);
//        return Results.Ok(model);
//    }

//    private async Task<IResult> GetAllVendors(
//        [FromServices] ICatalogModelFactory catalogModelFactory)
//    {
//        var model = await catalogModelFactory.PrepareVendorAllModelsAsync();
//        return Results.Ok(model);
//    }

//    private async Task<IResult> GetProductsByTag(
//        [FromServices] IProductTagService productTagService,
//        [FromServices] ICatalogModelFactory catalogModelFactory,
//        int productTagId, CatalogProductsCommand command)
//    {
//        var productTag = await productTagService.GetProductTagByIdAsync(productTagId);
//        if (productTag == null)
//        {
//            return Results.NotFound();
//        }

//        var model = await catalogModelFactory.PrepareProductsByTagModelAsync(productTag, command);
//        return Results.Ok(model);
//    }

//    private async Task<IResult> GetTagProducts(
//        [FromServices] IProductTagService productTagService,
//        [FromServices] ICatalogModelFactory catalogModelFactory,
//        int tagId, CatalogProductsCommand command)
//    {
//        var productTag = await productTagService.GetProductTagByIdAsync(tagId);
//        if (productTag == null)
//        {
//            return Results.NotFound();
//        }

//        var model = await catalogModelFactory.PrepareTagProductsModelAsync(productTag, command);
//        return Results.Ok(model);
//    }

//    private async Task<IResult> GetAllProductTags(
//        [FromServices] ICatalogModelFactory catalogModelFactory)
//    {
//        var model = await catalogModelFactory.PreparePopularProductTagsModelAsync();
//        return Results.Ok(model);
//    }

//    private async Task<IResult> GetNewProducts(
//        [FromServices] ICatalogModelFactory catalogModelFactory,
//        CatalogProductsCommand command)
//    {
//        var model = await catalogModelFactory.PrepareNewProductsModelAsync(command);
//        return Results.Ok(model);
//    }

//    private async Task<IResult> GetNewProductsRss(
//        [FromServices] IStoreContext storeContext,
//        [FromServices] IProductService productService,
//        [FromServices] IUrlRecordService urlRecordService,
//        [FromServices] ICatalogModelFactory catalogModelFactory,
//        [FromServices] ILocalizationService localizationService,
//        [FromServices] IWebHelper webHelper)
//    {
//        var store = await storeContext.GetCurrentStoreAsync();
//        var feed = new RssFeed(
//            $"{await localizationService.GetLocalizedAsync(store, x => x.Name)}: New products",
//            "Information about products",
//            new Uri(webHelper.GetStoreLocation()),
//            DateTime.UtcNow);

//        var storeId = store.Id;
//        var products = await productService.GetProductsMarkedAsNewAsync(storeId: storeId);
//        var items = new List<RssItem>();

//        foreach (var product in products)
//        {
//            var seName = await urlRecordService.GetSeNameAsync(product);
//            var productUrl = await webHelper.RouteGenericUrlAsync<Product>(new { SeName = seName });
//            var productName = await localizationService.GetLocalizedAsync(product, x => x.Name);
//            var productDescription = await localizationService.GetLocalizedAsync(product, x => x.ShortDescription);
//            items.Add(new RssItem(productName, productDescription, new Uri(productUrl), $"urn:store:{store.Id}:newProducts:product:{product.Id}", product.CreatedOnUtc));
//        }

//        feed.Items = items;
//        return Results.Ok(feed);
//    }

//    private async Task<IResult> SearchProducts(
//        [FromServices] ICatalogModelFactory catalogModelFactory,
//        SearchModel searchModel, CatalogProductsCommand command)
//    {
//        var model = await catalogModelFactory.PrepareSearchProductsModelAsync(searchModel, command);
//        return Results.Ok(model);
//    }

//    private async Task<IResult> SearchTermAutoComplete(
//        [FromServices] IProductService productService,
//        [FromServices] ICatalogModelFactory catalogModelFactory,
//        string term)
//    {
//        if (string.IsNullOrWhiteSpace(term))
//        {
//            return Results.Content("");
//        }

//        term = term.Trim();
//        var products = await productService.SearchProductsAsync(0, keywords: term);
//        var models = await catalogModelFactory.PrepareProductOverviewModelsAsync(products);
//        return Results.Ok(models);
//    }
//}

