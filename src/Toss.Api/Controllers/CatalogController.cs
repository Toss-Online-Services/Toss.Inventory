using MailKit;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Vendors;
using Nop.Core.Rss;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Services.Stores;
using Nop.Services.Vendors;
using Nop.Web.Framework.Mvc.Routing;
using System.Threading.Tasks;
using Toss.Api.Factories;
using Toss.Api.Models.Catalog;

namespace Toss.Api.Controllers
{
    [Route("api/catalog")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        #region Fields

        protected readonly CatalogSettings _catalogSettings;
        protected readonly IAclService _aclService;
        protected readonly ICatalogModelFactory _catalogModelFactory;
        protected readonly ICategoryService _categoryService;
        protected readonly ICustomerActivityService _customerActivityService;
        protected readonly IGenericAttributeService _genericAttributeService;
        protected readonly ILocalizationService _localizationService;
        protected readonly IManufacturerService _manufacturerService;
        protected readonly INopUrlHelper _nopUrlHelper;
        protected readonly IPermissionService _permissionService;
        protected readonly IProductModelFactory _productModelFactory;
        protected readonly IProductService _productService;
        protected readonly IProductTagService _productTagService;
        protected readonly IStoreContext _storeContext;
        protected readonly IStoreMappingService _storeMappingService;
        protected readonly IUrlRecordService _urlRecordService;
        protected readonly IVendorService _vendorService;
        protected readonly IWebHelper _webHelper;
        protected readonly IWorkContext _workContext;
        protected readonly MediaSettings _mediaSettings;
        protected readonly VendorSettings _vendorSettings;

        #endregion

        #region Ctor

        public CatalogController(CatalogSettings catalogSettings,
            IAclService aclService,
            ICatalogModelFactory catalogModelFactory,
            ICategoryService categoryService,
            ICustomerActivityService customerActivityService,
            IGenericAttributeService genericAttributeService,
            ILocalizationService localizationService,
            IManufacturerService manufacturerService,
            INopUrlHelper nopUrlHelper,
            IPermissionService permissionService,
            IProductModelFactory productModelFactory,
            IProductService productService,
            IProductTagService productTagService,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            IUrlRecordService urlRecordService,
            IVendorService vendorService,
            IWebHelper webHelper,
            IWorkContext workContext,
            MediaSettings mediaSettings,
            VendorSettings vendorSettings)
        {
            _catalogSettings = catalogSettings;
            _aclService = aclService;
            _catalogModelFactory = catalogModelFactory;
            _categoryService = categoryService;
            _customerActivityService = customerActivityService;
            _genericAttributeService = genericAttributeService;
            _localizationService = localizationService;
            _manufacturerService = manufacturerService;
            _nopUrlHelper = nopUrlHelper;
            _permissionService = permissionService;
            _productModelFactory = productModelFactory;
            _productService = productService;
            _productTagService = productTagService;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            _urlRecordService = urlRecordService;
            _vendorService = vendorService;
            _webHelper = webHelper;
            _workContext = workContext;
            _mediaSettings = mediaSettings;
            _vendorSettings = vendorSettings;
        }

        #endregion

        #region Categories

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetCategory(int categoryId, [FromQuery] CatalogProductsCommand command)
        {
            var category = await _categoryService.GetCategoryByIdAsync(categoryId);
            if (!await CheckCategoryAvailabilityAsync(category))
                return NotFound("Category not available");

            var model = await _catalogModelFactory.PrepareCategoryModelAsync(category, command);
            return Ok(model);
        }

        [HttpGet("category/{categoryId}/products")]
        public async Task<IActionResult> GetCategoryProducts(int categoryId, [FromQuery] CatalogProductsCommand command)
        {
            var category = await _categoryService.GetCategoryByIdAsync(categoryId);
            if (!await CheckCategoryAvailabilityAsync(category))
                return NotFound("Category not available");

            var model = await _catalogModelFactory.PrepareCategoryProductsModelAsync(category, command);
            return Ok(model);
        }

        [HttpPost("catalog-root")]
        public async Task<IActionResult> GetCatalogRoot()
        {
            var model = await _catalogModelFactory.PrepareRootCategoriesAsync();
            return Ok(model);
        }

        [HttpPost("catalog-subcategories/{id}")]
        public async Task<IActionResult> GetCatalogSubCategories(int id)
        {
            var model = await _catalogModelFactory.PrepareSubCategoriesAsync(id);
            return Ok(model);
        }

        #endregion

        #region Manufacturers

        [HttpGet("manufacturer/{manufacturerId}")]
        public async Task<IActionResult> GetManufacturer(int manufacturerId, [FromQuery] CatalogProductsCommand command)
        {
            var manufacturer = await _manufacturerService.GetManufacturerByIdAsync(manufacturerId);
            if (!await CheckManufacturerAvailabilityAsync(manufacturer))
                return NotFound("Manufacturer not available");

            var model = await _catalogModelFactory.PrepareManufacturerModelAsync(manufacturer, command);
            return Ok(model);
        }

        [HttpGet("manufacturer/{manufacturerId}/products")]
        public async Task<IActionResult> GetManufacturerProducts(int manufacturerId, [FromQuery] CatalogProductsCommand command)
        {
            var manufacturer = await _manufacturerService.GetManufacturerByIdAsync(manufacturerId);
            if (!await CheckManufacturerAvailabilityAsync(manufacturer))
                return NotFound("Manufacturer not available");

            var model = await _catalogModelFactory.PrepareManufacturerProductsModelAsync(manufacturer, command);
            return Ok(model);
        }

        [HttpGet("manufacturers")]
        public async Task<IActionResult> GetAllManufacturers()
        {
            var model = await _catalogModelFactory.PrepareManufacturerAllModelsAsync();
            return Ok(model);
        }

        #endregion

        #region Vendors

        [HttpGet("vendor/{vendorId}")]
        public async Task<IActionResult> GetVendor(int vendorId, [FromQuery] CatalogProductsCommand command)
        {
            var vendor = await _vendorService.GetVendorByIdAsync(vendorId);
            if (!CheckVendorAvailabilityAsync(vendor))
                return NotFound("Vendor not available");

            var model = await _catalogModelFactory.PrepareVendorModelAsync(vendor, command);
            return Ok(model);
        }

        [HttpGet("vendor/{vendorId}/products")]
        public async Task<IActionResult> GetVendorProducts(int vendorId, [FromQuery] CatalogProductsCommand command)
        {
            var vendor = await _vendorService.GetVendorByIdAsync(vendorId);
            if (!CheckVendorAvailabilityAsync(vendor))
                return NotFound("Vendor not available");

            var model = await _catalogModelFactory.PrepareVendorProductsModelAsync(vendor, command);
            return Ok(model);
        }

        [HttpGet("vendors")]
        public async Task<IActionResult> GetAllVendors()
        {
            var model = await _catalogModelFactory.PrepareVendorAllModelsAsync();
            return Ok(model);
        }

        #endregion

        #region Product Tags

        [HttpGet("products/tag/{productTagId}")]
        public async Task<IActionResult> GetProductsByTag(int productTagId, [FromQuery] CatalogProductsCommand command)
        {
            var productTag = await _productTagService.GetProductTagByIdAsync(productTagId);
            if (productTag == null)
                return NotFound("Product tag not found");

            var model = await _catalogModelFactory.PrepareProductsByTagModelAsync(productTag, command);
            return Ok(model);
        }

        [HttpGet("products/tag/{tagId}/products")]
        public async Task<IActionResult> GetTagProducts(int tagId, [FromQuery] CatalogProductsCommand command)
        {
            var productTag = await _productTagService.GetProductTagByIdAsync(tagId);
            if (productTag == null)
                return NotFound("Product tag not found");

            var model = await _catalogModelFactory.PrepareTagProductsModelAsync(productTag, command);
            return Ok(model);
        }

        [HttpGet("products/tags")]
        public async Task<IActionResult> GetAllProductTags()
        {
            var model = await _catalogModelFactory.PreparePopularProductTagsModelAsync();
            return Ok(model);
        }

        #endregion

        #region New Products

        [HttpGet("products/new")]
        public async Task<IActionResult> GetNewProducts([FromQuery] CatalogProductsCommand command)
        {
            var model = await _catalogModelFactory.PrepareNewProductsModelAsync(command);
            return Ok(model);
        }

        [HttpGet("products/new/rss")]
        public async Task<IActionResult> GetNewProductsRss()
        {
            var store = await _storeContext.GetCurrentStoreAsync();
            var feed = new RssFeed(
                $"{await _localizationService.GetLocalizedAsync(store, x => x.Name)}: New products",
                "Information about products",
                new Uri(_webHelper.GetStoreLocation()),
                DateTime.UtcNow);

            var items = new List<RssItem>();
            var storeId = store.Id;
            var products = await _productService.GetProductsMarkedAsNewAsync(storeId: storeId);

            foreach (var product in products)
            {
                var seName = await _urlRecordService.GetSeNameAsync(product);
                var productUrl = await _nopUrlHelper.RouteGenericUrlAsync<Product>(new { SeName = seName });
                var productName = await _localizationService.GetLocalizedAsync(product, x => x.Name);
                var productDescription = await _localizationService.GetLocalizedAsync(product, x => x.ShortDescription);
                var item = new RssItem(productName, productDescription, new Uri(productUrl), $"urn:store:{store.Id}:newProducts:product:{product.Id}", product.CreatedOnUtc);
                items.Add(item);
            }
            feed.Items = items;

            return Ok(feed);
        }

        #endregion

        #region Search

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchModel model, [FromQuery] CatalogProductsCommand command)
        {
            model = await _catalogModelFactory.PrepareSearchModelAsync(model, command);
            return Ok(model);
        }

        [HttpGet("search/autocomplete")]
        public async Task<IActionResult> SearchAutoComplete([FromQuery] string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return BadRequest("Search term is required");

            term = term.Trim();
            if (term.Length < _catalogSettings.ProductSearchTermMinimumLength)
                return BadRequest("Search term is too short");

            var store = await _storeContext.GetCurrentStoreAsync();
            var products = await _productService.SearchProductsAsync(0,
                storeId: store.Id,
                keywords: term,
                languageId: (await _workContext.GetWorkingLanguageAsync()).Id,
                visibleIndividuallyOnly: true,
                pageSize: 10);

            var models = await _productModelFactory.PrepareProductOverviewModelsAsync(products);
            return Ok(models);
        }

        #endregion

        #region Utilities

        private async Task<bool> CheckCategoryAvailabilityAsync(Category category)
        {
            return category != null && !category.Deleted && category.Published &&
                await _aclService.AuthorizeAsync(category) &&
                await _storeMappingService.AuthorizeAsync(category);
        }

        private async Task<bool> CheckManufacturerAvailabilityAsync(Manufacturer manufacturer)
        {
            return manufacturer != null && !manufacturer.Deleted && manufacturer.Published &&
                await _aclService.AuthorizeAsync(manufacturer) &&
                await _storeMappingService.AuthorizeAsync(manufacturer);
        }

        private bool CheckVendorAvailabilityAsync(Vendor vendor)
        {
            return vendor != null && !vendor.Deleted && vendor.Active;
        }

        #endregion
    }
}
