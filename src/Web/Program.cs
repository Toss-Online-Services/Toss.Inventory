using System;
using AspNetCore.Swagger.Themes;
using Domain;
using Domain.Caching;
using Domain.Entities.Catalog;
using Domain.Entities.Common;
using Domain.Entities.Configuration;
using Domain.Entities.Customers;
using Domain.Entities.Directory;
using Domain.Entities.Orders;
using Domain.Events;
using Domain.Infrastructure;
using Domain.Services.Attributes;
using Domain.Services.Caching;
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
using Domain.Services.Media.RoxyFileman;
using Domain.Services.Messages;
using Domain.Services.Orders;
using Domain.Services.Plugins;
using Domain.Services.Security;
using Domain.Services.Seo;
using Domain.Services.Shipping.Date;
using Domain.Services.Stores;
using Domain.Services.Tax;
using Domain.Services.Vendors;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Infrastructure;
using Infrastructure.DataProviders;
using Infrastructure.Extensions;
using Infrastructure.Migrations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Nop.Core;
using Nop.Services.Media.RoxyFileman;
using Nop.Services.Seo;
using Toss.Extensions;
using Toss.ServiceDefaults;
using Web;
using Web.Framework;
using Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddInfrastructureServices();
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

//Get Settings
// Register configuration settings in DI

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<CatalogSettings>(builder.Configuration.GetSection("CatalogSettings"));
builder.Services.Configure<CurrencySettings>(builder.Configuration.GetSection("CurrencySettings"));
builder.Services.Configure<CommonSettings>(builder.Configuration.GetSection("CommonSettings"));
builder.Services.Configure<CustomerSettings>(builder.Configuration.GetSection("CustomerSettings"));
builder.Services.Configure<AddressSettings>(builder.Configuration.GetSection("AddressSettings"));

services.AddSingleton<AppSettings>();
services.Configure<DistributedCacheConfig>(builder.Configuration.GetSection("DistributedCacheConfig"));

//create default file provider
CommonHelper.DefaultFileProvider = new NopFileProvider(builder.Environment);


// Register the required services

services.AddTransient<IProductService, ProductService>();

services.AddScoped<IBackInStockSubscriptionService, BackInStockSubscriptionService>();
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
services.AddScoped<IMessageTemplateService, MessageTemplateService>();
services.AddScoped<IQueuedEmailService, QueuedEmailService>();
services.AddScoped<INewsLetterSubscriptionService, NewsLetterSubscriptionService>();
services.AddScoped<INotificationService, NotificationService>();
services.AddScoped<IEmailAccountService, EmailAccountService>();
services.AddScoped<IWorkflowMessageService, WorkflowMessageService>();
services.AddScoped<IMessageTokenProvider, MessageTokenProvider>();
services.AddScoped<ITokenizer, Tokenizer>();
services.AddScoped<ISmtpBuilder, SmtpBuilder>();
services.AddScoped<IEmailSender, EmailSender>();
services.AddScoped<IGiftCardService, GiftCardService>();
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
services.AddScoped<IBBCodeHelper, BBCodeHelper>();
services.AddScoped<IHtmlFormatter, HtmlFormatter>();
services.AddScoped<IVideoService, VideoService>();
services.AddScoped<INopDataProvider, PostgreSqlDataProvider>();


services.AddSingleton<ICacheKeyManager, CacheKeyManager>();
services.AddScoped<IShortTermCacheManager, PerRequestCacheManager>();

//file provider
services.AddScoped<INopFileProvider, NopFileProvider>();

services.AddScoped<ITaxPluginManager, TaxPluginManager>();

services.AddScoped<ICopyProductService, CopyProductService>();


services.AddScoped<IPictureService, PictureService>();

//roxy file manager
services.AddScoped<IRoxyFilemanService, RoxyFilemanService>();
services.AddScoped<IRoxyFilemanFileProvider, RoxyFilemanFileProvider>();

services.AddScoped<IStaticCacheManager, MemoryDistributedCacheManager>();
services.AddScoped<ICacheKeyService, MemoryDistributedCacheManager>();

//attribute services
services.AddScoped(typeof(IAttributeService<,>), typeof(AttributeService<,>));

//attribute parsers
services.AddScoped(typeof(IAttributeParser<,>), typeof(AttributeParser<,>));

//attribute formatter
services.AddScoped(typeof(IAttributeFormatter<,>), typeof(AttributeFormatter<,>));

// Add CatalogSettings to DI

services.AddSingleton<ICacheKeyManager, CacheKeyManager>();

services.AddTransient(typeof(IConcurrentCollection<>), typeof(ConcurrentTrie<>));

//work context
services.AddScoped<IWorkContext, WebWorkContext>();

//store context
services.AddScoped<IStoreContext, WebStoreContext>();

services.AddTransient<IWorkContext, WebWorkContext>();
services.AddTransient<Lazy<IWorkContext>>();


services.AddTransient<Lazy<IStoreContext>>();

//user agent helper
services.AddScoped<IUserAgentHelper, UserAgentHelper>();
services.AddScoped<ISearchPluginManager, SearchPluginManager>();

services.AddScoped<IEmailAccountService, EmailAccountService>();

services.AddScoped<IMessageTemplateService, MessageTemplateService>();
services.AddScoped<IMessageTokenProvider, MessageTokenProvider>();
services.AddScoped<IGiftCardService, GiftCardService>();
services.AddScoped<IDiscountPluginManager, DiscountPluginManager>();
services.AddScoped<IQueuedEmailService, QueuedEmailService>();

services.AddScoped<ITokenizer, Tokenizer>();
services.AddScoped<ISmtpBuilder, SmtpBuilder>();
services.AddScoped<IEmailSender, EmailSender>();



services.AddScoped<IExchangeRatePluginManager, ExchangeRatePluginManager>();

//plugins
services.AddScoped<IPluginService, PluginService>();

services.AddSingleton<IMigrationManager, MigrationManager>();

services.AddTransient(p => new Lazy<IVersionLoader>(p.GetRequiredService<IVersionLoader>()));

//web helper
services.AddScoped<IWebHelper, WebHelper>();

// Register IActionContextAccessor
services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

builder.Services.AddMigration<InventoryContext>();

var app = builder.Build();

app.MapDefaultEndpoints();

// Enable CORS before the endpoints are mapped
app.UseCors("AllowAngularClient");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    try
    {
        using (var scope = app.Services.CreateScope())
        {
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Migration failed: {ex.Message}");
    }
    // await app.InitialiseDatabaseAsync();
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


