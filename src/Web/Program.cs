using AspNetCore.Swagger.Themes;
using Domain;
using Domain.Caching;
using Domain.Entities.Catalog;
using Domain.Events;
using Domain.Services.Catalog;
using Domain.Services.Common;
using Domain.Services.Configuration;
using Domain.Services.Customers;
using Domain.Services.Directory;
using Domain.Services.Discounts;
using Domain.Services.Events;
using Domain.Services.Helpers;
using Domain.Services.Html;
using Domain.Services.Localization;
using Domain.Services.Logging;
using Domain.Services.Media;
using Domain.Services.Messages;
using Domain.Services.Security;
using Domain.Services.Seo;
using Domain.Services.Shipping.Date;
using Domain.Services.Stores;
using Domain.Services.Tax;
using Domain.Services.Vendors;
using Infrastructure;
using Infrastructure.Caching;
using Nop.Services.Seo;
using Toss.ServiceDefaults;
using Web;
using Web.Framework;
using Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddProblemDetails();
builder.Services.AddWebServices();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient",
        builder => builder
            .WithOrigins("http://localhost:4200") // Allow requests from the Angular client
            .AllowAnyMethod()                      // Allow any HTTP methods (GET, POST, etc.)
            .AllowAnyHeader()                      // Allow any headers
            .AllowCredentials());                  // Allow credentials if needed
});

// Add the authentication services to DI
builder.AddDefaultAuthentication();

var withApiVersioning = builder.Services.AddApiVersioning();

builder.AddDefaultOpenApi(withApiVersioning);

var services = builder.Services;
// Register the repositories
services.AddScoped(typeof(IRepository<>), typeof(EntityRepository<>));

// Register the required services
services.AddScoped<IBackInStockSubscriptionService, BackInStockSubscriptionService>();
services.AddScoped<INopDataProvider, NopDataProvider>();
services.AddScoped<ICategoryService, CategoryService>();
services.AddScoped<ICompareProductsService, CompareProductsService>();
services.AddScoped<IRecentlyViewedProductsService, RecentlyViewedProductsService>();
services.AddScoped<IManufacturerService, ManufacturerService>();
services.AddScoped<IPriceFormatter, PriceFormatter>();
services.AddScoped<IProductAttributeFormatter, ProductAttributeFormatter>();
services.AddScoped<IProductAttributeParser, ProductAttributeParser>();
services.AddScoped<IProductAttributeService, ProductAttributeService>();
services.AddScoped<IProductService, ProductService>();
services.AddScoped<ICopyProductService, CopyProductService>();
services.AddScoped<ISpecificationAttributeService, SpecificationAttributeService>();
services.AddScoped<IProductTemplateService, ProductTemplateService>();
services.AddScoped<ICategoryTemplateService, CategoryTemplateService>();
services.AddScoped<IManufacturerTemplateService, ManufacturerTemplateService>();
services.AddScoped<IProductTagService, ProductTagService>();
services.AddScoped<IAddressService, AddressService>();
services.AddScoped<IVendorService, VendorService>();
services.AddScoped<ISearchTermService, SearchTermService>();
services.AddScoped<IGenericAttributeService, GenericAttributeService>();
services.AddScoped<IMaintenanceService, MaintenanceService>();
services.AddScoped<ICustomerService, CustomerService>();
services.AddScoped<IAclService, AclService>();
services.AddScoped<IPriceCalculationService, PriceCalculationService>();
services.AddScoped<IGeoLookupService, GeoLookupService>();
services.AddScoped<ICountryService, CountryService>();
services.AddScoped<ICurrencyService, CurrencyService>();
services.AddScoped<IMeasureService, MeasureService>();
services.AddScoped<IStateProvinceService, StateProvinceService>();
services.AddScoped<IStoreService, StoreService>();
services.AddScoped<IStoreMappingService, StoreMappingService>();
services.AddScoped<IDiscountService, DiscountService>();
services.AddScoped<ILocalizationService, LocalizationService>();
services.AddScoped<ILocalizedEntityService, LocalizedEntityService>();
services.AddScoped<ILanguageService, LanguageService>();
services.AddScoped<IDownloadService, DownloadService>();
services.AddScoped<IWorkflowMessageService, WorkflowMessageService>();
services.AddScoped<IUrlRecordService, UrlRecordService>();
services.AddScoped<IDateRangeService, DateRangeService>();
services.AddScoped<ITaxCategoryService, TaxCategoryService>();
services.AddScoped<ICheckVatService, CheckVatService>();
services.AddScoped<ITaxService, TaxService>();
services.AddScoped<Domain.Services.Logging.ILogger, DefaultLogger>();
services.AddScoped<ICustomerActivityService, CustomerActivityService>();
services.AddScoped<IDateTimeHelper, DateTimeHelper>();
services.AddScoped<IReviewTypeService, ReviewTypeService>();
services.AddSingleton<IEventPublisher, EventPublisher>();
services.AddScoped<ISettingService, SettingService>();
services.AddScoped<IHtmlFormatter, HtmlFormatter>();
services.AddScoped<IVideoService, VideoService>();
services.AddScoped<IWorkContext, WebWorkContext>();

// Add CatalogSettings to DI
services.Configure<CatalogSettings>(builder.Configuration.GetSection("CatalogSettings"));

var app = builder.Build();

// Enable CORS before the endpoints are mapped
app.UseCors("AllowAngularClient");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //await app.InitialiseDatabaseAsync();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwaggerUi(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.UseSwaggerUI(ModernStyle.Dark);

app.MapFallbackToFile("index.html");

app.UseExceptionHandler(options => { });

app.Map("/", () => Results.Redirect("/api"));

// Register the product endpoints
app.MapProductEndpoints();

app.MapEndpoints();

app.Run();
