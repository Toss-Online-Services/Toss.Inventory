using System.Text;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Discounts;
using Nop.Services.Catalog;
using Nop.Services.Customers;
using Nop.Services.Discounts;
using Nop.Services.ExportImport;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Services.Stores;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Catalog;

namespace Toss.Api.Admin.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public partial class ManufacturerController : ControllerBase
{
    #region Fields

    private readonly IAclService _aclService;
    private readonly ICustomerActivityService _customerActivityService;
    private readonly ICustomerService _customerService;
    private readonly IDiscountService _discountService;
    private readonly IExportManager _exportManager;
    private readonly IImportManager _importManager;
    private readonly ILocalizationService _localizationService;
    private readonly ILocalizedEntityService _localizedEntityService;
    private readonly IManufacturerModelFactory _manufacturerModelFactory;
    private readonly IManufacturerService _manufacturerService;
    private readonly INotificationService _notificationService;
    private readonly IPermissionService _permissionService;
    private readonly IPictureService _pictureService;
    private readonly IProductService _productService;
    private readonly IStoreMappingService _storeMappingService;
    private readonly IStoreService _storeService;
    private readonly IUrlRecordService _urlRecordService;
    private readonly IWorkContext _workContext;

    #endregion

    #region Constructor

    public ManufacturerController(
        IAclService aclService,
        ICustomerActivityService customerActivityService,
        ICustomerService customerService,
        IDiscountService discountService,
        IExportManager exportManager,
        IImportManager importManager,
        ILocalizationService localizationService,
        ILocalizedEntityService localizedEntityService,
        IManufacturerModelFactory manufacturerModelFactory,
        IManufacturerService manufacturerService,
        INotificationService notificationService,
        IPermissionService permissionService,
        IPictureService pictureService,
        IProductService productService,
        IStoreMappingService storeMappingService,
        IStoreService storeService,
        IUrlRecordService urlRecordService,
        IWorkContext workContext)
    {
        _aclService = aclService;
        _customerActivityService = customerActivityService;
        _customerService = customerService;
        _discountService = discountService;
        _exportManager = exportManager;
        _importManager = importManager;
        _localizationService = localizationService;
        _localizedEntityService = localizedEntityService;
        _manufacturerModelFactory = manufacturerModelFactory;
        _manufacturerService = manufacturerService;
        _notificationService = notificationService;
        _permissionService = permissionService;
        _pictureService = pictureService;
        _productService = productService;
        _storeMappingService = storeMappingService;
        _storeService = storeService;
        _urlRecordService = urlRecordService;
        _workContext = workContext;
    }

    #endregion

    #region List

    [HttpGet("list")]
    [CheckPermission(StandardPermission.Catalog.MANUFACTURER_VIEW)]
    public async Task<IActionResult> List()
    {
        var model = await _manufacturerModelFactory.PrepareManufacturerSearchModelAsync(new ManufacturerSearchModel());
        return Ok(model);
    }

    [HttpPost("search")]
    [CheckPermission(StandardPermission.Catalog.MANUFACTURER_VIEW)]
    public async Task<IActionResult> Search([FromBody] ManufacturerSearchModel searchModel)
    {
        var model = await _manufacturerModelFactory.PrepareManufacturerListModelAsync(searchModel);
        return Ok(model);
    }

    #endregion

    #region Create / Edit / Delete

    [HttpGet("create")]
    [CheckPermission(StandardPermission.Catalog.MANUFACTURER_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Create()
    {
        var model = await _manufacturerModelFactory.PrepareManufacturerModelAsync(new ManufacturerModel(), null);
        return Ok(model);
    }

    [HttpPost("create")]
    [CheckPermission(StandardPermission.Catalog.MANUFACTURER_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Create([FromBody] ManufacturerModel model, bool continueEditing)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var manufacturer = model.ToEntity<Manufacturer>();
        manufacturer.CreatedOnUtc = DateTime.UtcNow;
        manufacturer.UpdatedOnUtc = DateTime.UtcNow;
        await _manufacturerService.InsertManufacturerAsync(manufacturer);

        model.SeName = await _urlRecordService.ValidateSeNameAsync(manufacturer, model.SeName, manufacturer.Name, true);
        await _urlRecordService.SaveSlugAsync(manufacturer, model.SeName, 0);

        await UpdateLocalesAsync(manufacturer, model);
        await ApplyDiscountsAsync(manufacturer, model);
        await SaveStoreMappingsAsync(manufacturer, model);
        await UpdatePictureSeoNamesAsync(manufacturer);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Manufacturers.Added"));
        return Ok(new { manufacturer.Id });
    }

    [HttpGet("edit/{id:int}")]
    [CheckPermission(StandardPermission.Catalog.MANUFACTURER_VIEW)]
    public async Task<IActionResult> Edit(int id)
    {
        var manufacturer = await _manufacturerService.GetManufacturerByIdAsync(id);
        if (manufacturer == null || manufacturer.Deleted) return NotFound();

        var model = await _manufacturerModelFactory.PrepareManufacturerModelAsync(null, manufacturer);
        return Ok(model);
    }

    [HttpPut("edit/{id:int}")]
    [CheckPermission(StandardPermission.Catalog.MANUFACTURER_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Edit(int id, [FromBody] ManufacturerModel model)
    {
        var manufacturer = await _manufacturerService.GetManufacturerByIdAsync(id);
        if (manufacturer == null || manufacturer.Deleted) return NotFound();

        if (!ModelState.IsValid) return BadRequest(ModelState);

        manufacturer = model.ToEntity(manufacturer);
        manufacturer.UpdatedOnUtc = DateTime.UtcNow;
        await _manufacturerService.UpdateManufacturerAsync(manufacturer);

        model.SeName = await _urlRecordService.ValidateSeNameAsync(manufacturer, model.SeName, manufacturer.Name, true);
        await _urlRecordService.SaveSlugAsync(manufacturer, model.SeName, 0);

        await UpdateLocalesAsync(manufacturer, model);
        await ApplyDiscountsAsync(manufacturer, model);
        await SaveStoreMappingsAsync(manufacturer, model);
        await UpdatePictureSeoNamesAsync(manufacturer);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Manufacturers.Updated"));
        return Ok(new { manufacturer.Id });
    }

    [HttpDelete("delete/{id:int}")]
    [CheckPermission(StandardPermission.Catalog.MANUFACTURER_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Delete(int id)
    {
        var manufacturer = await _manufacturerService.GetManufacturerByIdAsync(id);
        if (manufacturer == null) return NotFound();

        await _manufacturerService.DeleteManufacturerAsync(manufacturer);
        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Manufacturers.Deleted"));

        return NoContent();
    }

    [HttpPost("delete-selected")]
    [CheckPermission(StandardPermission.Catalog.MANUFACTURER_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> DeleteSelected([FromBody] ICollection<int> selectedIds)
    {
        if (selectedIds == null || !selectedIds.Any()) return BadRequest("No IDs provided");

        var manufacturers = await _manufacturerService.GetManufacturersByIdsAsync(selectedIds.ToArray());
        await _manufacturerService.DeleteManufacturersAsync(manufacturers);

        return Ok(new { success = true });
    }

    #endregion

    #region Export / Import

    [HttpGet("export/xml")]
    [CheckPermission(StandardPermission.Catalog.MANUFACTURER_IMPORT_EXPORT)]
    public async Task<IActionResult> ExportXml()
    {
        var manufacturers = await _manufacturerService.GetAllManufacturersAsync(showHidden: true);
        var xml = await _exportManager.ExportManufacturersToXmlAsync(manufacturers);
        return File(Encoding.UTF8.GetBytes(xml), "application/xml", "manufacturers.xml");
    }

    [HttpGet("export/xlsx")]
    [CheckPermission(StandardPermission.Catalog.MANUFACTURER_IMPORT_EXPORT)]
    public async Task<IActionResult> ExportXlsx()
    {
        var manufacturers = await _manufacturerService.GetAllManufacturersAsync(showHidden: true);
        var bytes = await _exportManager.ExportManufacturersToXlsxAsync(manufacturers.Where(m => !m.Deleted));
        return File(bytes, MimeTypes.TextXlsx, "manufacturers.xlsx");
    }
    //TODO: import File

    //[HttpPost("import/xlsx")]
    //[CheckPermission(StandardPermission.Catalog.MANUFACTURER_IMPORT_EXPORT)]
    //public async Task<IActionResult> ImportFromXlsx([FromBody] IFormFile importFile)
    //{
    //    if (importFile == null || importFile.Length == 0) return BadRequest("File not provided");

    //    await _importManager.ImportManufacturersFromXlsxAsync(importFile.OpenReadStream());
    //    return Ok(new { success = true });
    //}

    #endregion

    #region Helper Methods

    private async Task UpdateLocalesAsync(Manufacturer manufacturer, ManufacturerModel model)
    {
        foreach (var localized in model.Locales)
        {
            await _localizedEntityService.SaveLocalizedValueAsync(manufacturer, x => x.Name, localized.Name, localized.LanguageId);
            await _localizedEntityService.SaveLocalizedValueAsync(manufacturer, x => x.Description, localized.Description, localized.LanguageId);
            await _localizedEntityService.SaveLocalizedValueAsync(manufacturer, x => x.MetaKeywords, localized.MetaKeywords, localized.LanguageId);
            await _localizedEntityService.SaveLocalizedValueAsync(manufacturer, x => x.MetaDescription, localized.MetaDescription, localized.LanguageId);
            await _localizedEntityService.SaveLocalizedValueAsync(manufacturer, x => x.MetaTitle, localized.MetaTitle, localized.LanguageId);

            var seName = await _urlRecordService.ValidateSeNameAsync(manufacturer, localized.SeName, localized.Name, false);
            await _urlRecordService.SaveSlugAsync(manufacturer, seName, localized.LanguageId);
        }
    }

    private async Task ApplyDiscountsAsync(Manufacturer manufacturer, ManufacturerModel model)
    {
        var allDiscounts = await _discountService.GetAllDiscountsAsync(DiscountType.AssignedToManufacturers, showHidden: true);
        foreach (var discount in allDiscounts)
        {
            if (model.SelectedDiscountIds?.Contains(discount.Id) == true)
            {
                if (await _manufacturerService.GetDiscountAppliedToManufacturerAsync(manufacturer.Id, discount.Id) is null)
                    await _manufacturerService.InsertDiscountManufacturerMappingAsync(new DiscountManufacturerMapping { EntityId = manufacturer.Id, DiscountId = discount.Id });
            }
            else
            {
                var mapping = await _manufacturerService.GetDiscountAppliedToManufacturerAsync(manufacturer.Id, discount.Id);
                if (mapping != null)
                    await _manufacturerService.DeleteDiscountManufacturerMappingAsync(mapping);
            }
        }
    }

    private async Task UpdatePictureSeoNamesAsync(Manufacturer manufacturer)
    {
        var picture = await _pictureService.GetPictureByIdAsync(manufacturer.PictureId);
        if (picture != null)
            await _pictureService.SetSeoFilenameAsync(picture.Id, await _pictureService.GetPictureSeNameAsync(manufacturer.Name));
    }

    private async Task SaveStoreMappingsAsync(Manufacturer manufacturer, ManufacturerModel model)
    {
        manufacturer.LimitedToStores = model.SelectedStoreIds.Any();
        await _manufacturerService.UpdateManufacturerAsync(manufacturer);

        var existingStoreMappings = await _storeMappingService.GetStoreMappingsAsync(manufacturer);
        var allStores = await _storeService.GetAllStoresAsync();
        foreach (var store in allStores)
        {
            if (model.SelectedStoreIds.Contains(store.Id))
            {
                if (!existingStoreMappings.Any(sm => sm.StoreId == store.Id))
                    await _storeMappingService.InsertStoreMappingAsync(manufacturer, store.Id);
            }
            else
            {
                var mapping = existingStoreMappings.FirstOrDefault(sm => sm.StoreId == store.Id);
                if (mapping != null)
                    await _storeMappingService.DeleteStoreMappingAsync(mapping);
            }
        }
    }

    #endregion
}
