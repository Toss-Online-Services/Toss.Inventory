using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Vendors;
using Nop.Core.Http;
using Nop.Core.Infrastructure;
using Nop.Core;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Customers;
using Nop.Services.Discounts;
using Nop.Services.ExportImport;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Orders;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Services.Shipping;
using Toss.Api.Admin.Models.Catalog;
using Toss.Api.Admin.Factories;
using Nop.Core.Domain.Customers;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Nop.Data.Extensions;

namespace Toss.Api.Admin.Controllers.ProductCatalog
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttributeCombinationsController : ControllerBase
    {
        #region Fields

        protected readonly IAclService _aclService;
        protected readonly IBackInStockSubscriptionService _backInStockSubscriptionService;
        protected readonly ICategoryService _categoryService;
        protected readonly ICopyProductService _copyProductService;
        protected readonly ICustomerActivityService _customerActivityService;
        protected readonly ICustomerService _customerService;
        protected readonly IDiscountService _discountService;
        protected readonly IDownloadService _downloadService;
        protected readonly IExportManager _exportManager;
        protected readonly IGenericAttributeService _genericAttributeService;
        protected readonly IHttpClientFactory _httpClientFactory;
        protected readonly IImportManager _importManager;
        protected readonly ILanguageService _languageService;
        protected readonly ILocalizationService _localizationService;
        protected readonly ILocalizedEntityService _localizedEntityService;
        protected readonly IManufacturerService _manufacturerService;
        protected readonly INopFileProvider _fileProvider;
        protected readonly INotificationService _notificationService;
        protected readonly IPdfService _pdfService;
        protected readonly IPermissionService _permissionService;
        protected readonly IPictureService _pictureService;
        protected readonly IProductAttributeFormatter _productAttributeFormatter;
        protected readonly IProductAttributeParser _productAttributeParser;
        protected readonly IProductAttributeService _productAttributeService;
        protected readonly IProductModelFactory _productModelFactory;
        protected readonly IProductService _productService;
        protected readonly IProductTagService _productTagService;
        protected readonly ISettingService _settingService;
        protected readonly IShippingService _shippingService;
        protected readonly IShoppingCartService _shoppingCartService;
        protected readonly ISpecificationAttributeService _specificationAttributeService;
        protected readonly IStoreContext _storeContext;
        protected readonly IUrlRecordService _urlRecordService;
        protected readonly IVideoService _videoService;
        protected readonly IWebHelper _webHelper;
        protected readonly IWorkContext _workContext;
        protected readonly VendorSettings _vendorSettings;
        private static readonly char[] _separator = [','];

        #endregion

        #region Ctor

        public ProductAttributeCombinationsController(IAclService aclService,
            IBackInStockSubscriptionService backInStockSubscriptionService,
            ICategoryService categoryService,
            ICopyProductService copyProductService,
            ICustomerActivityService customerActivityService,
            ICustomerService customerService,
            IDiscountService discountService,
            IDownloadService downloadService,
            IExportManager exportManager,
            IGenericAttributeService genericAttributeService,
            IHttpClientFactory httpClientFactory,
            IImportManager importManager,
            ILanguageService languageService,
            ILocalizationService localizationService,
            ILocalizedEntityService localizedEntityService,
            IManufacturerService manufacturerService,
            INopFileProvider fileProvider,
            INotificationService notificationService,
            IPdfService pdfService,
            IPermissionService permissionService,
            IPictureService pictureService,
            IProductAttributeFormatter productAttributeFormatter,
            IProductAttributeParser productAttributeParser,
            IProductAttributeService productAttributeService,
            IProductModelFactory productModelFactory,
            IProductService productService,
            IProductTagService productTagService,
            ISettingService settingService,
            IShippingService shippingService,
            IShoppingCartService shoppingCartService,
            ISpecificationAttributeService specificationAttributeService,
            IStoreContext storeContext,
            IUrlRecordService urlRecordService,
            IVideoService videoService,
            IWebHelper webHelper,
            IWorkContext workContext,
            VendorSettings vendorSettings)
        {
            _aclService = aclService;
            _backInStockSubscriptionService = backInStockSubscriptionService;
            _categoryService = categoryService;
            _copyProductService = copyProductService;
            _customerActivityService = customerActivityService;
            _customerService = customerService;
            _discountService = discountService;
            _downloadService = downloadService;
            _exportManager = exportManager;
            _genericAttributeService = genericAttributeService;
            _httpClientFactory = httpClientFactory;
            _importManager = importManager;
            _languageService = languageService;
            _localizationService = localizationService;
            _localizedEntityService = localizedEntityService;
            _manufacturerService = manufacturerService;
            _fileProvider = fileProvider;
            _notificationService = notificationService;
            _pdfService = pdfService;
            _permissionService = permissionService;
            _pictureService = pictureService;
            _productAttributeFormatter = productAttributeFormatter;
            _productAttributeParser = productAttributeParser;
            _productAttributeService = productAttributeService;
            _productModelFactory = productModelFactory;
            _productService = productService;
            _productTagService = productTagService;
            _settingService = settingService;
            _shippingService = shippingService;
            _shoppingCartService = shoppingCartService;
            _specificationAttributeService = specificationAttributeService;
            _storeContext = storeContext;
            _urlRecordService = urlRecordService;
            _videoService = videoService;
            _webHelper = webHelper;
            _workContext = workContext;
            _vendorSettings = vendorSettings;
        }

        #endregion

        #region Utilities

        protected virtual async Task UpdateLocalesAsync(Product product, ProductModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(product,
                    x => x.Name,
                    localized.Name,
                    localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(product,
                    x => x.ShortDescription,
                    localized.ShortDescription,
                    localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(product,
                    x => x.FullDescription,
                    localized.FullDescription,
                    localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(product,
                    x => x.MetaKeywords,
                    localized.MetaKeywords,
                    localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(product,
                    x => x.MetaDescription,
                    localized.MetaDescription,
                    localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(product,
                    x => x.MetaTitle,
                    localized.MetaTitle,
                    localized.LanguageId);

                //search engine name
                var seName = await _urlRecordService.ValidateSeNameAsync(product, localized.SeName, localized.Name, false);
                await _urlRecordService.SaveSlugAsync(product, seName, localized.LanguageId);
            }
        }

        protected virtual async Task UpdateLocalesAsync(ProductTag productTag, ProductTagModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(productTag,
                    x => x.Name,
                    localized.Name,
                    localized.LanguageId);

                var seName = await _urlRecordService.ValidateSeNameAsync(productTag, string.Empty, localized.Name, false);
                await _urlRecordService.SaveSlugAsync(productTag, seName, localized.LanguageId);
            }
        }

        protected virtual async Task UpdateLocalesAsync(ProductAttributeMapping pam, ProductAttributeMappingModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(pam,
                    x => x.TextPrompt,
                    localized.TextPrompt,
                    localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(pam,
                    x => x.DefaultValue,
                    localized.DefaultValue,
                    localized.LanguageId);
            }
        }

        protected virtual async Task UpdateLocalesAsync(ProductAttributeValue pav, ProductAttributeValueModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(pav,
                    x => x.Name,
                    localized.Name,
                    localized.LanguageId);
            }
        }

        protected virtual async Task UpdatePictureSeoNamesAsync(Product product)
        {
            foreach (var pp in await _productService.GetProductPicturesByProductIdAsync(product.Id))
                await _pictureService.SetSeoFilenameAsync(pp.PictureId, await _pictureService.GetPictureSeNameAsync(product.Name));
        }

        protected virtual async Task SaveCategoryMappingsAsync(Product product, ProductModel model)
        {
            var existingProductCategories = await _categoryService.GetProductCategoriesByProductIdAsync(product.Id, true);

            //delete categories
            foreach (var existingProductCategory in existingProductCategories)
                if (!model.SelectedCategoryIds.Contains(existingProductCategory.CategoryId))
                    await _categoryService.DeleteProductCategoryAsync(existingProductCategory);

            //add categories
            foreach (var categoryId in model.SelectedCategoryIds)
            {
                if (_categoryService.FindProductCategory(existingProductCategories, product.Id, categoryId) == null)
                {
                    //find next display order
                    var displayOrder = 1;
                    var existingCategoryMapping = await _categoryService.GetProductCategoriesByCategoryIdAsync(categoryId, showHidden: true);
                    if (existingCategoryMapping.Any())
                        displayOrder = existingCategoryMapping.Max(x => x.DisplayOrder) + 1;
                    await _categoryService.InsertProductCategoryAsync(new ProductCategory
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId,
                        DisplayOrder = displayOrder
                    });
                }
            }
        }

        protected virtual async Task SaveManufacturerMappingsAsync(Product product, ProductModel model)
        {
            var existingProductManufacturers = await _manufacturerService.GetProductManufacturersByProductIdAsync(product.Id, true);

            //delete manufacturers
            foreach (var existingProductManufacturer in existingProductManufacturers)
                if (!model.SelectedManufacturerIds.Contains(existingProductManufacturer.ManufacturerId))
                    await _manufacturerService.DeleteProductManufacturerAsync(existingProductManufacturer);

            //add manufacturers
            foreach (var manufacturerId in model.SelectedManufacturerIds)
            {
                if (_manufacturerService.FindProductManufacturer(existingProductManufacturers, product.Id, manufacturerId) == null)
                {
                    //find next display order
                    var displayOrder = 1;
                    var existingManufacturerMapping = await _manufacturerService.GetProductManufacturersByManufacturerIdAsync(manufacturerId, showHidden: true);
                    if (existingManufacturerMapping.Any())
                        displayOrder = existingManufacturerMapping.Max(x => x.DisplayOrder) + 1;
                    await _manufacturerService.InsertProductManufacturerAsync(new ProductManufacturer
                    {
                        ProductId = product.Id,
                        ManufacturerId = manufacturerId,
                        DisplayOrder = displayOrder
                    });
                }
            }
        }

        protected virtual async Task SaveDiscountMappingsAsync(Product product, ProductModel model)
        {
            var allDiscounts = await _discountService.GetAllDiscountsAsync(DiscountType.AssignedToSkus, showHidden: true, isActive: null);

            foreach (var discount in allDiscounts)
            {
                if (model.SelectedDiscountIds != null && model.SelectedDiscountIds.Contains(discount.Id))
                {
                    //new discount
                    if (await _productService.GetDiscountAppliedToProductAsync(product.Id, discount.Id) is null)
                        await _productService.InsertDiscountProductMappingAsync(new DiscountProductMapping { EntityId = product.Id, DiscountId = discount.Id });
                }
                else
                {
                    //remove discount
                    if (await _productService.GetDiscountAppliedToProductAsync(product.Id, discount.Id) is DiscountProductMapping discountProductMapping)
                        await _productService.DeleteDiscountProductMappingAsync(discountProductMapping);
                }
            }

            await _productService.UpdateProductAsync(product);
        }

        protected virtual async Task<string> GetAttributesXmlForProductAttributeCombinationAsync(IFormCollection form, List<string> warnings, int productId)
        {
            var attributesXml = string.Empty;

            //get product attribute mappings (exclude non-combinable attributes)
            var attributes = (await _productAttributeService.GetProductAttributeMappingsByProductIdAsync(productId))
                .Where(productAttributeMapping => !productAttributeMapping.IsNonCombinable()).ToList();

            foreach (var attribute in attributes)
            {
                var controlId = $"{NopCatalogDefaults.ProductAttributePrefix}{attribute.Id}";
                StringValues ctrlAttributes;

                switch (attribute.AttributeControlType)
                {
                    case AttributeControlType.DropdownList:
                    case AttributeControlType.RadioList:
                    case AttributeControlType.ColorSquares:
                    case AttributeControlType.ImageSquares:
                        ctrlAttributes = form[controlId];
                        if (!string.IsNullOrEmpty(ctrlAttributes))
                        {
                            var selectedAttributeId = int.Parse(ctrlAttributes);
                            if (selectedAttributeId > 0)
                                attributesXml = _productAttributeParser.AddProductAttribute(attributesXml,
                                    attribute, selectedAttributeId.ToString());
                        }

                        break;
                    case AttributeControlType.Checkboxes:
                        var cblAttributes = form[controlId].ToString();
                        if (!string.IsNullOrEmpty(cblAttributes))
                        {
                            foreach (var item in cblAttributes.Split(_separator,
                                         StringSplitOptions.RemoveEmptyEntries))
                            {
                                var selectedAttributeId = int.Parse(item);
                                if (selectedAttributeId > 0)
                                    attributesXml = _productAttributeParser.AddProductAttribute(attributesXml,
                                        attribute, selectedAttributeId.ToString());
                            }
                        }

                        break;
                    case AttributeControlType.ReadonlyCheckboxes:
                        //load read-only (already server-side selected) values
                        var attributeValues = await _productAttributeService.GetProductAttributeValuesAsync(attribute.Id);
                        foreach (var selectedAttributeId in attributeValues
                                     .Where(v => v.IsPreSelected)
                                     .Select(v => v.Id)
                                     .ToList())
                        {
                            attributesXml = _productAttributeParser.AddProductAttribute(attributesXml,
                                attribute, selectedAttributeId.ToString());
                        }

                        break;
                    case AttributeControlType.TextBox:
                    case AttributeControlType.MultilineTextbox:
                        ctrlAttributes = form[controlId];
                        if (!string.IsNullOrEmpty(ctrlAttributes))
                        {
                            var enteredText = ctrlAttributes.ToString().Trim();
                            attributesXml = _productAttributeParser.AddProductAttribute(attributesXml,
                                attribute, enteredText);
                        }

                        break;
                    case AttributeControlType.Datepicker:
                        var date = form[controlId + "_day"];
                        var month = form[controlId + "_month"];
                        var year = form[controlId + "_year"];
                        DateTime? selectedDate = null;
                        try
                        {
                            selectedDate = new DateTime(int.Parse(year), int.Parse(month), int.Parse(date));
                        }
                        catch
                        {
                            //ignore any exception
                        }

                        if (selectedDate.HasValue)
                        {
                            attributesXml = _productAttributeParser.AddProductAttribute(attributesXml,
                                attribute, selectedDate.Value.ToString("D"));
                        }

                        break;
                    case AttributeControlType.FileUpload:
                        var requestForm = await Request.ReadFormAsync();
                        var httpPostedFile = requestForm.Files[controlId];
                        if (!string.IsNullOrEmpty(httpPostedFile?.FileName))
                        {
                            var fileSizeOk = true;
                            if (attribute.ValidationFileMaximumSize.HasValue)
                            {
                                //compare in bytes
                                var maxFileSizeBytes = attribute.ValidationFileMaximumSize.Value * 1024;
                                if (httpPostedFile.Length > maxFileSizeBytes)
                                {
                                    warnings.Add(string.Format(
                                        await _localizationService.GetResourceAsync("ShoppingCart.MaximumUploadedFileSize"),
                                        attribute.ValidationFileMaximumSize.Value));
                                    fileSizeOk = false;
                                }
                            }

                            if (fileSizeOk)
                            {
                                //save an uploaded file
                                var download = new Download
                                {
                                    DownloadGuid = Guid.NewGuid(),
                                    UseDownloadUrl = false,
                                    DownloadUrl = string.Empty,
                                    DownloadBinary = await _downloadService.GetDownloadBitsAsync(httpPostedFile),
                                    ContentType = httpPostedFile.ContentType,
                                    Filename = _fileProvider.GetFileNameWithoutExtension(httpPostedFile.FileName),
                                    Extension = _fileProvider.GetFileExtension(httpPostedFile.FileName),
                                    IsNew = true
                                };
                                await _downloadService.InsertDownloadAsync(download);

                                //save attribute
                                attributesXml = _productAttributeParser.AddProductAttribute(attributesXml,
                                    attribute, download.DownloadGuid.ToString());
                            }
                        }

                        break;
                    default:
                        break;
                }
            }

            //validate conditional attributes (if specified)
            foreach (var attribute in attributes)
            {
                var conditionMet = await _productAttributeParser.IsConditionMetAsync(attribute, attributesXml);
                if (conditionMet.HasValue && !conditionMet.Value)
                {
                    attributesXml = _productAttributeParser.RemoveProductAttribute(attributesXml, attribute);
                }
            }

            return attributesXml;
        }

        protected virtual async Task SaveProductWarehouseInventoryAsync(Product product, ProductModel model)
        {
            ArgumentNullException.ThrowIfNull(product);

            if (model.ManageInventoryMethodId != (int)ManageInventoryMethod.ManageStock)
                return;

            if (!model.UseMultipleWarehouses)
                return;

            var warehouses = await _shippingService.GetAllWarehousesAsync();

            var form = await Request.ReadFormAsync();
            var formData = form.ToDictionary(x => x.Key, x => x.Value.ToString());

            foreach (var warehouse in warehouses)
            {
                //parse stock quantity
                var stockQuantity = 0;
                foreach (var formKey in formData.Keys)
                {
                    if (!formKey.Equals($"warehouse_qty_{warehouse.Id}", StringComparison.InvariantCultureIgnoreCase))
                        continue;

                    _ = int.TryParse(formData[formKey], out stockQuantity);
                    break;
                }

                //parse reserved quantity
                var reservedQuantity = 0;
                foreach (var formKey in formData.Keys)
                    if (formKey.Equals($"warehouse_reserved_{warehouse.Id}", StringComparison.InvariantCultureIgnoreCase))
                    {
                        _ = int.TryParse(formData[formKey], out reservedQuantity);
                        break;
                    }

                //parse "used" field
                var used = false;
                foreach (var formKey in formData.Keys)
                    if (formKey.Equals($"warehouse_used_{warehouse.Id}", StringComparison.InvariantCultureIgnoreCase))
                    {
                        _ = int.TryParse(formData[formKey], out var tmp);
                        used = tmp == warehouse.Id;
                        break;
                    }

                //quantity change history message
                var message = $"{await _localizationService.GetResourceAsync("Admin.StockQuantityHistory.Messages.MultipleWarehouses")} {await _localizationService.GetResourceAsync("Admin.StockQuantityHistory.Messages.Edit")}";

                var existingPwI = (await _productService.GetAllProductWarehouseInventoryRecordsAsync(product.Id)).FirstOrDefault(x => x.WarehouseId == warehouse.Id);
                if (existingPwI != null)
                {
                    if (used)
                    {
                        var previousStockQuantity = existingPwI.StockQuantity;

                        //update existing record
                        existingPwI.StockQuantity = stockQuantity;
                        existingPwI.ReservedQuantity = reservedQuantity;
                        await _productService.UpdateProductWarehouseInventoryAsync(existingPwI);

                        //quantity change history
                        await _productService.AddStockQuantityHistoryEntryAsync(product, existingPwI.StockQuantity - previousStockQuantity, existingPwI.StockQuantity,
                            existingPwI.WarehouseId, message);
                    }
                    else
                    {
                        //delete. no need to store record for qty 0
                        await _productService.DeleteProductWarehouseInventoryAsync(existingPwI);

                        //quantity change history
                        await _productService.AddStockQuantityHistoryEntryAsync(product, -existingPwI.StockQuantity, 0, existingPwI.WarehouseId, message);
                    }
                }
                else
                {
                    if (!used)
                        continue;

                    //no need to insert a record for qty 0
                    existingPwI = new ProductWarehouseInventory
                    {
                        WarehouseId = warehouse.Id,
                        ProductId = product.Id,
                        StockQuantity = stockQuantity,
                        ReservedQuantity = reservedQuantity
                    };

                    await _productService.InsertProductWarehouseInventoryAsync(existingPwI);

                    //quantity change history
                    await _productService.AddStockQuantityHistoryEntryAsync(product, existingPwI.StockQuantity, existingPwI.StockQuantity,
                        existingPwI.WarehouseId, message);
                }
            }
        }

        protected virtual async Task SaveConditionAttributesAsync(ProductAttributeMapping productAttributeMapping,
            ProductAttributeConditionModel model, IFormCollection form)
        {
            string attributesXml = null;
            if (model.EnableCondition)
            {
                var attribute = await _productAttributeService.GetProductAttributeMappingByIdAsync(model.SelectedProductAttributeId);
                if (attribute != null)
                {
                    var controlId = $"{NopCatalogDefaults.ProductAttributePrefix}{attribute.Id}";
                    switch (attribute.AttributeControlType)
                    {
                        case AttributeControlType.DropdownList:
                        case AttributeControlType.RadioList:
                        case AttributeControlType.ColorSquares:
                        case AttributeControlType.ImageSquares:
                            var ctrlAttributes = form[controlId];
                            if (!StringValues.IsNullOrEmpty(ctrlAttributes))
                            {
                                var selectedAttributeId = int.Parse(ctrlAttributes);
                                //for conditions we should empty values save even when nothing is selected
                                //otherwise "attributesXml" will be empty
                                //hence we won't be able to find a selected attribute
                                attributesXml = _productAttributeParser.AddProductAttribute(null, attribute,
                                    selectedAttributeId > 0 ? selectedAttributeId.ToString() : string.Empty);
                            }
                            else
                            {
                                //for conditions we should empty values save even when nothing is selected
                                //otherwise "attributesXml" will be empty
                                //hence we won't be able to find a selected attribute
                                attributesXml = _productAttributeParser.AddProductAttribute(null,
                                    attribute, string.Empty);
                            }

                            break;
                        case AttributeControlType.Checkboxes:
                            var cblAttributes = form[controlId];
                            if (!StringValues.IsNullOrEmpty(cblAttributes))
                            {
                                var anyValueSelected = false;
                                foreach (var item in cblAttributes.ToString()
                                             .Split(_separator, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    var selectedAttributeId = int.Parse(item);
                                    if (selectedAttributeId <= 0)
                                        continue;

                                    attributesXml = _productAttributeParser.AddProductAttribute(attributesXml,
                                        attribute, selectedAttributeId.ToString());
                                    anyValueSelected = true;
                                }

                                if (!anyValueSelected)
                                {
                                    //for conditions we should save empty values even when nothing is selected
                                    //otherwise "attributesXml" will be empty
                                    //hence we won't be able to find a selected attribute
                                    attributesXml = _productAttributeParser.AddProductAttribute(null,
                                        attribute, string.Empty);
                                }
                            }
                            else
                            {
                                //for conditions we should save empty values even when nothing is selected
                                //otherwise "attributesXml" will be empty
                                //hence we won't be able to find a selected attribute
                                attributesXml = _productAttributeParser.AddProductAttribute(null,
                                    attribute, string.Empty);
                            }

                            break;
                        case AttributeControlType.ReadonlyCheckboxes:
                        case AttributeControlType.TextBox:
                        case AttributeControlType.MultilineTextbox:
                        case AttributeControlType.Datepicker:
                        case AttributeControlType.FileUpload:
                        default:
                            //these attribute types are supported as conditions
                            break;
                    }
                }
            }

            productAttributeMapping.ConditionAttributeXml = attributesXml;
            await _productAttributeService.UpdateProductAttributeMappingAsync(productAttributeMapping);
        }

        protected virtual async Task GenerateAttributeCombinationsAsync(Product product, IList<int> allowedAttributeIds = null)
        {
            var allAttributesXml = await _productAttributeParser.GenerateAllCombinationsAsync(product, true, allowedAttributeIds);
            foreach (var attributesXml in allAttributesXml)
            {
                var existingCombination = await _productAttributeParser.FindProductAttributeCombinationAsync(product, attributesXml);

                //already exists?
                if (existingCombination != null)
                    continue;

                //new one
                var warnings = new List<string>();
                warnings.AddRange(await _shoppingCartService.GetShoppingCartItemAttributeWarningsAsync(await _workContext.GetCurrentCustomerAsync(),
                    ShoppingCartType.ShoppingCart, product, 1, attributesXml, true, true, true));
                if (warnings.Any())
                    continue;

                //save combination
                var combination = new ProductAttributeCombination
                {
                    ProductId = product.Id,
                    AttributesXml = attributesXml,
                    StockQuantity = 0,
                    AllowOutOfStockOrders = false,
                    Sku = null,
                    ManufacturerPartNumber = null,
                    Gtin = null,
                    OverriddenPrice = null,
                    NotifyAdminForQuantityBelow = 1
                };
                await _productAttributeService.InsertProductAttributeCombinationAsync(combination);
            }
        }

        protected virtual async Task PingVideoUrlAsync(string videoUrl)
        {
            var path = videoUrl.StartsWith("/")
                ? $"{_webHelper.GetStoreLocation()}{videoUrl.TrimStart('/')}"
                : videoUrl;

            var client = _httpClientFactory.CreateClient(NopHttpDefaults.DefaultHttpClient);
            await client.GetStringAsync(path);
        }

        protected virtual async Task SaveAttributeCombinationPicturesAsync(Product product, ProductAttributeCombination combination, ProductAttributeCombinationModel model)
        {
            var existingCombinationPictures = await _productAttributeService.GetProductAttributeCombinationPicturesAsync(combination.Id);
            var productPictureIds = (await _pictureService.GetPicturesByProductIdAsync(product.Id)).Select(p => p.Id).ToList();

            //delete manufacturers
            foreach (var existingCombinationPicture in existingCombinationPictures)
                if (!model.PictureIds.Contains(existingCombinationPicture.PictureId) || !productPictureIds.Contains(existingCombinationPicture.PictureId))
                    await _productAttributeService.DeleteProductAttributeCombinationPictureAsync(existingCombinationPicture);

            //add manufacturers
            foreach (var pictureId in model.PictureIds)
            {
                if (!productPictureIds.Contains(pictureId))
                    continue;

                if (_productAttributeService.FindProductAttributeCombinationPicture(existingCombinationPictures, combination.Id, pictureId) == null)
                {
                    await _productAttributeService.InsertProductAttributeCombinationPictureAsync(new ProductAttributeCombinationPicture
                    {
                        ProductAttributeCombinationId = combination.Id,
                        PictureId = pictureId
                    });
                }
            }
        }

        protected virtual async Task SaveAttributeValuePicturesAsync(Product product, ProductAttributeValue value, ProductAttributeValueModel model)
        {
            var existingValuePictures = await _productAttributeService.GetProductAttributeValuePicturesAsync(value.Id);
            var productPictureIds = (await _pictureService.GetPicturesByProductIdAsync(product.Id)).Select(p => p.Id).ToList();

            //delete manufacturers
            foreach (var existingValuePicture in existingValuePictures)
                if (!model.PictureIds.Contains(existingValuePicture.PictureId) || !productPictureIds.Contains(existingValuePicture.PictureId))
                    await _productAttributeService.DeleteProductAttributeValuePictureAsync(existingValuePicture);

            //add manufacturers
            foreach (var pictureId in model.PictureIds)
            {
                if (!productPictureIds.Contains(pictureId))
                    continue;

                if (_productAttributeService.FindProductAttributeValuePicture(existingValuePictures, value.Id, pictureId) == null)
                {
                    await _productAttributeService.InsertProductAttributeValuePictureAsync(new ProductAttributeValuePicture
                    {
                        ProductAttributeValueId = value.Id,
                        PictureId = pictureId
                    });
                }
            }
        }

        #endregion

        #region Product attribute combinations

        [HttpPost("create-list")]
        [CheckPermission(StandardPermission.Catalog.PRODUCT_ATTRIBUTES_VIEW)]
        public virtual async Task<IActionResult> ProductAttributeCombinationList(ProductAttributeCombinationSearchModel searchModel)
        {
            //try to get a product with the specified id
            var product = await _productService.GetProductByIdAsync(searchModel.ProductId)
                ?? throw new ArgumentException("No product found with the specified id");

            //a vendor should have access only to his products
            var currentVendor = await _workContext.GetCurrentVendorAsync();
            if (currentVendor != null && product.VendorId != currentVendor.Id)
                return Content("This is not your product");

            //prepare model
            var model = await _productModelFactory.PrepareProductAttributeCombinationListModelAsync(searchModel, product);

            return Ok(model);
        }

        [HttpDelete("delete")]
        [CheckPermission(StandardPermission.Catalog.PRODUCT_ATTRIBUTES_CREATE_EDIT_DELETE)]
        public virtual async Task<IActionResult> ProductAttributeCombinationDelete(int id)
        {
            //try to get a combination with the specified id
            var combination = await _productAttributeService.GetProductAttributeCombinationByIdAsync(id)
                ?? throw new ArgumentException("No product attribute combination found with the specified id");

            //try to get a product with the specified id
            var product = await _productService.GetProductByIdAsync(combination.ProductId)
                ?? throw new ArgumentException("No product found with the specified id");

            //a vendor should have access only to his products
            var currentVendor = await _workContext.GetCurrentVendorAsync();
            if (currentVendor != null && product.VendorId != currentVendor.Id)
                return Content("This is not your product");

            await _productAttributeService.DeleteProductAttributeCombinationAsync(combination);

            return Ok();
        }

        [HttpGet("{productId}")]
        [CheckPermission(StandardPermission.Catalog.PRODUCT_ATTRIBUTES_CREATE_EDIT_DELETE)]
        public virtual async Task<IActionResult> ProductAttributeCombinationCreatePopup(int productId)
        {
            //try to get a product with the specified id
            var product = await _productService.GetProductByIdAsync(productId);
            if (product == null)
                return RedirectToAction("List", "Product");

            //a vendor should have access only to his products
            var currentVendor = await _workContext.GetCurrentVendorAsync();
            if (currentVendor != null && product.VendorId != currentVendor.Id)
                return RedirectToAction("List", "Product");

            //prepare model
            var model = await _productModelFactory.PrepareProductAttributeCombinationModelAsync(new ProductAttributeCombinationModel(), product, null);

            return Ok(model);
        }

        [HttpPost("create-popup")]
        [CheckPermission(StandardPermission.Catalog.PRODUCT_ATTRIBUTES_CREATE_EDIT_DELETE)]
        public virtual async Task<IActionResult> ProductAttributeCombinationCreatePopup(int productId, ProductAttributeCombinationModel model, IFormCollection form)
        {
            //try to get a product with the specified id
            var product = await _productService.GetProductByIdAsync(productId);
            if (product == null)
                return RedirectToAction("List", "Product");

            //a vendor should have access only to his products
            var currentVendor = await _workContext.GetCurrentVendorAsync();
            if (currentVendor != null && product.VendorId != currentVendor.Id)
                return RedirectToAction("List", "Product");

            //attributes
            var warnings = new List<string>();
            var attributesXml = await GetAttributesXmlForProductAttributeCombinationAsync(form, warnings, product.Id);

            //check whether the attribute value is specified
            if (string.IsNullOrEmpty(attributesXml))
                warnings.Add(await _localizationService.GetResourceAsync("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Alert.FailedValue"));

            warnings.AddRange(await _shoppingCartService.GetShoppingCartItemAttributeWarningsAsync(await _workContext.GetCurrentCustomerAsync(),
                ShoppingCartType.ShoppingCart, product, 1, attributesXml, true));

            //check whether the same attribute combination already exists
            var existingCombination = await _productAttributeParser.FindProductAttributeCombinationAsync(product, attributesXml);
            if (existingCombination != null)
                warnings.Add(await _localizationService.GetResourceAsync("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.AlreadyExists"));

            if (!warnings.Any())
            {
                //save combination
                var combination = model.ToEntity<ProductAttributeCombination>();

                //fill attributes
                combination.AttributesXml = attributesXml;

                await _productAttributeService.InsertProductAttributeCombinationAsync(combination);

                await SaveAttributeCombinationPicturesAsync(product, combination, model);

                //quantity change history
                await _productService.AddStockQuantityHistoryEntryAsync(product, combination.StockQuantity, combination.StockQuantity,
                    message: await _localizationService.GetResourceAsync("Admin.StockQuantityHistory.Messages.Combination.Edit"), combinationId: combination.Id);



                return Ok(model);
            }

            //prepare model
            model = await _productModelFactory.PrepareProductAttributeCombinationModelAsync(model, product, null, true);
            model.Warnings = warnings;

            //if we got this far, something failed, redisplay form
            return Ok(model);
        }

        [HttpGet("get-popup/{productId}")]
        [CheckPermission(StandardPermission.Catalog.PRODUCTS_CREATE_EDIT_DELETE)]
        [CheckPermission(StandardPermission.Catalog.PRODUCT_ATTRIBUTES_VIEW)]
        public virtual async Task<IActionResult> ProductAttributeCombinationGeneratePopup(int productId)
        {
            //try to get a product with the specified id
            var product = await _productService.GetProductByIdAsync(productId);
            if (product == null)
                return RedirectToAction("List", "Product");

            //a vendor should have access only to his products
            var currentVendor = await _workContext.GetCurrentVendorAsync();
            if (currentVendor != null && product.VendorId != currentVendor.Id)
                return RedirectToAction("List", "Product");

            //prepare model
            var model = await _productModelFactory.PrepareProductAttributeCombinationModelAsync(new ProductAttributeCombinationModel(), product, null);

            return Ok(model);
        }

        [HttpPost("generate-popup")]
        [CheckPermission(StandardPermission.Catalog.PRODUCTS_CREATE_EDIT_DELETE)]
        [CheckPermission(StandardPermission.Catalog.PRODUCT_ATTRIBUTES_VIEW)]
        public virtual async Task<IActionResult> ProductAttributeCombinationGeneratePopup(IFormCollection form, ProductAttributeCombinationModel model)
        {
            //try to get a product with the specified id
            var product = await _productService.GetProductByIdAsync(model.ProductId) ?? throw new ArgumentException("No product found with the specified id");

            var allowedAttributeIds = form.Keys.Where(key => key.Contains("attribute_value_"))
                .Select(key => int.TryParse(form[key], out var id) ? id : 0).Where(id => id > 0).ToList();

            var requiredAttributeNames = await (await _productAttributeService.GetProductAttributeMappingsByProductIdAsync(product.Id))
                .Where(pam => pam.IsRequired)
                .Where(pam => !pam.IsNonCombinable())
                .WhereAwait(async pam => !(await _productAttributeService.GetProductAttributeValuesAsync(pam.Id)).Any(v => allowedAttributeIds.Any(id => id == v.Id)))
                .SelectAwait(async pam => (await _productAttributeService.GetProductAttributeByIdAsync(pam.ProductAttributeId)).Name).ToListAsync();

            if (requiredAttributeNames.Any())
            {
                model = await _productModelFactory.PrepareProductAttributeCombinationModelAsync(model, product, null, true);
                var pavModels = model.ProductAttributes.SelectMany(pa => pa.Values)
                    .Where(v => allowedAttributeIds.Any(id => id == v.Id))
                    .ToList();
                foreach (var pavModel in pavModels)
                {
                    pavModel.Checked = "checked";
                }

                model.Warnings.Add(string.Format(await _localizationService.GetResourceAsync("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.SelectRequiredAttributes"), string.Join(", ", requiredAttributeNames)));

                return Ok(model);
            }

            await GenerateAttributeCombinationsAsync(product, allowedAttributeIds);



            return Ok(new ProductAttributeCombinationModel());
        }

        [HttpPut("edit-popup/{id}")]
        [CheckPermission(StandardPermission.Catalog.PRODUCTS_VIEW)]
        [CheckPermission(StandardPermission.Catalog.PRODUCT_ATTRIBUTES_VIEW)]
        public virtual async Task<IActionResult> ProductAttributeCombinationEditPopup(int id)
        {
            //try to get a combination with the specified id
            var combination = await _productAttributeService.GetProductAttributeCombinationByIdAsync(id);
            if (combination == null)
                return RedirectToAction("List", "Product");

            //try to get a product with the specified id
            var product = await _productService.GetProductByIdAsync(combination.ProductId);
            if (product == null)
                return RedirectToAction("List", "Product");

            //a vendor should have access only to his products
            var currentVendor = await _workContext.GetCurrentVendorAsync();
            if (currentVendor != null && product.VendorId != currentVendor.Id)
                return RedirectToAction("List", "Product");

            //prepare model
            var model = await _productModelFactory.PrepareProductAttributeCombinationModelAsync(null, product, combination);

            return Ok(model);
        }

        [HttpPut("edit-popup")]
        [CheckPermission(StandardPermission.Catalog.PRODUCTS_CREATE_EDIT_DELETE)]
        [CheckPermission(StandardPermission.Catalog.PRODUCT_ATTRIBUTES_VIEW)]
        public virtual async Task<IActionResult> ProductAttributeCombinationEditPopup(ProductAttributeCombinationModel model, IFormCollection form)
        {
            //try to get a combination with the specified id
            var combination = await _productAttributeService.GetProductAttributeCombinationByIdAsync(model.Id);
            if (combination == null)
                return RedirectToAction("List", "Product");

            //try to get a product with the specified id
            var product = await _productService.GetProductByIdAsync(combination.ProductId);
            if (product == null)
                return RedirectToAction("List", "Product");

            //a vendor should have access only to his products
            var currentVendor = await _workContext.GetCurrentVendorAsync();
            if (currentVendor != null && product.VendorId != currentVendor.Id)
                return RedirectToAction("List", "Product");

            //attributes
            var warnings = new List<string>();
            var attributesXml = await GetAttributesXmlForProductAttributeCombinationAsync(form, warnings, product.Id);

            //check whether the attribute value is specified
            if (string.IsNullOrEmpty(attributesXml))
                warnings.Add(await _localizationService.GetResourceAsync("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Alert.FailedValue"));

            warnings.AddRange(await _shoppingCartService.GetShoppingCartItemAttributeWarningsAsync(await _workContext.GetCurrentCustomerAsync(),
                ShoppingCartType.ShoppingCart, product, 1, attributesXml, true));

            //check whether the same attribute combination already exists
            var existingCombination = await _productAttributeParser.FindProductAttributeCombinationAsync(product, attributesXml);
            if (existingCombination != null && existingCombination.Id != model.Id && existingCombination.AttributesXml.Equals(attributesXml))
                warnings.Add(await _localizationService.GetResourceAsync("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.AlreadyExists"));

            if (!warnings.Any() && ModelState.IsValid)
            {
                var previousStockQuantity = combination.StockQuantity;

                //save combination
                //fill entity from model
                combination = model.ToEntity(combination);
                combination.AttributesXml = attributesXml;

                await _productAttributeService.UpdateProductAttributeCombinationAsync(combination);

                await SaveAttributeCombinationPicturesAsync(product, combination, model);

                //quantity change history
                await _productService.AddStockQuantityHistoryEntryAsync(product, combination.StockQuantity - previousStockQuantity, combination.StockQuantity,
                    message: await _localizationService.GetResourceAsync("Admin.StockQuantityHistory.Messages.Combination.Edit"), combinationId: combination.Id);



                return Ok(model);
            }

            //prepare model
            model = await _productModelFactory.PrepareProductAttributeCombinationModelAsync(model, product, combination, true);
            model.Warnings = warnings;

            //if we got this far, something failed, redisplay form
            return Ok(model);
        }

        [HttpPost("combinations/{productId}")]
        [CheckPermission(StandardPermission.Catalog.PRODUCTS_CREATE_EDIT_DELETE)]
        [CheckPermission(StandardPermission.Catalog.PRODUCT_ATTRIBUTES_VIEW)]
        public virtual async Task<IActionResult> GenerateAllAttributeCombinations(int productId)
        {
            //try to get a product with the specified id
            var product = await _productService.GetProductByIdAsync(productId)
                ?? throw new ArgumentException("No product found with the specified id");

            //a vendor should have access only to his products
            var currentVendor = await _workContext.GetCurrentVendorAsync();
            if (currentVendor != null && product.VendorId != currentVendor.Id)
                return Content("This is not your product");

            await GenerateAttributeCombinationsAsync(product);

            return Ok(new { Success = true });
        }

        #endregion
    }
}
