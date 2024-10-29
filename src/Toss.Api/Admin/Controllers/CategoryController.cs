using System.Text;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
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
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Catalog;

namespace Toss.Api.Admin.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    #region Fields

    private readonly IAclService _aclService;
    private readonly ICategoryModelFactory _categoryModelFactory;
    private readonly ICategoryService _categoryService;
    private readonly ICustomerActivityService _customerActivityService;
    private readonly ICustomerService _customerService;
    private readonly IDiscountService _discountService;
    private readonly IExportManager _exportManager;
    private readonly IImportManager _importManager;
    private readonly ILocalizationService _localizationService;
    private readonly ILocalizedEntityService _localizedEntityService;
    private readonly INotificationService _notificationService;
    private readonly IPermissionService _permissionService;
    private readonly IPictureService _pictureService;
    private readonly IProductService _productService;
    private readonly IStaticCacheManager _staticCacheManager;
    private readonly IStoreMappingService _storeMappingService;
    private readonly IStoreService _storeService;
    private readonly IUrlRecordService _urlRecordService;
    private readonly IWorkContext _workContext;

    #endregion

    #region Ctor

    public CategoryController(
        IAclService aclService,
        ICategoryModelFactory categoryModelFactory,
        ICategoryService categoryService,
        ICustomerActivityService customerActivityService,
        ICustomerService customerService,
        IDiscountService discountService,
        IExportManager exportManager,
        IImportManager importManager,
        ILocalizationService localizationService,
        ILocalizedEntityService localizedEntityService,
        INotificationService notificationService,
        IPermissionService permissionService,
        IPictureService pictureService,
        IProductService productService,
        IStaticCacheManager staticCacheManager,
        IStoreMappingService storeMappingService,
        IStoreService storeService,
        IUrlRecordService urlRecordService,
        IWorkContext workContext)
    {
        _aclService = aclService;
        _categoryModelFactory = categoryModelFactory;
        _categoryService = categoryService;
        _customerActivityService = customerActivityService;
        _customerService = customerService;
        _discountService = discountService;
        _exportManager = exportManager;
        _importManager = importManager;
        _localizationService = localizationService;
        _localizedEntityService = localizedEntityService;
        _notificationService = notificationService;
        _permissionService = permissionService;
        _pictureService = pictureService;
        _productService = productService;
        _staticCacheManager = staticCacheManager;
        _storeMappingService = storeMappingService;
        _storeService = storeService;
        _urlRecordService = urlRecordService;
        _workContext = workContext;
    }

    #endregion

    #region Methods

    [HttpGet("List")]
    [CheckPermission(StandardPermission.Catalog.CATEGORIES_VIEW)]
    public async Task<IActionResult> List()
    {
        var model = await _categoryModelFactory.PrepareCategorySearchModelAsync(new CategorySearchModel());
        return Ok(model);
    }

    [HttpPost("List")]
    [CheckPermission(StandardPermission.Catalog.CATEGORIES_VIEW)]
    public async Task<IActionResult> List([FromBody] CategorySearchModel searchModel)
    {
        var model = await _categoryModelFactory.PrepareCategoryListModelAsync(searchModel);
        return Ok(model);
    }

    [HttpPost("Create")]
    [CheckPermission(StandardPermission.Catalog.CATEGORIES_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Create([FromBody] CategoryModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var category = model.ToEntity<Category>();
        category.CreatedOnUtc = DateTime.UtcNow;
        category.UpdatedOnUtc = DateTime.UtcNow;
        await _categoryService.InsertCategoryAsync(category);

        // Configure SEO, locales, discounts, stores, activity log, and notifications
        await ConfigureCategoryDetailsAsync(category, model);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Categories.Added"));
        return CreatedAtAction(nameof(Edit), new { id = category.Id }, model);
    }

    [HttpGet("Edit/{id}")]
    [CheckPermission(StandardPermission.Catalog.CATEGORIES_VIEW)]
    public async Task<IActionResult> Edit(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null || category.Deleted)
            return NotFound();

        var model = await _categoryModelFactory.PrepareCategoryModelAsync(null, category);
        return Ok(model);
    }

    [HttpPut("Edit/{id}")]
    [CheckPermission(StandardPermission.Catalog.CATEGORIES_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Edit(int id, [FromBody] CategoryModel model)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null || category.Deleted)
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        category = model.ToEntity(category);
        category.UpdatedOnUtc = DateTime.UtcNow;
        await _categoryService.UpdateCategoryAsync(category);

        await ConfigureCategoryDetailsAsync(category, model);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Categories.Updated"));
        return NoContent();
    }

    [HttpDelete("{id}")]
    [CheckPermission(StandardPermission.Catalog.CATEGORIES_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null)
            return NotFound();

        await _categoryService.DeleteCategoryAsync(category);
        await _customerActivityService.InsertActivityAsync("DeleteCategory",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteCategory"), category.Name), category);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Categories.Deleted"));
        return NoContent();
    }

    [HttpPost("DeleteSelected")]
    [CheckPermission(StandardPermission.Catalog.CATEGORIES_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> DeleteSelected([FromBody] ICollection<int> selectedIds)
    {
        if (selectedIds == null || !selectedIds.Any())
            return BadRequest("No categories selected for deletion.");

        await _categoryService.DeleteCategoriesAsync(await _categoryService.GetCategoriesByIdsAsync(selectedIds.ToArray()));
        return NoContent();
    }

    [HttpGet("ExportXml")]
    [CheckPermission(StandardPermission.Catalog.CATEGORIES_IMPORT_EXPORT)]
    public async Task<IActionResult> ExportXml()
    {
        try
        {
            var xml = await _exportManager.ExportCategoriesToXmlAsync();
            return File(Encoding.UTF8.GetBytes(xml), "application/xml", "categories.xml");
        }
        catch (Exception exc)
        {
            await _notificationService.ErrorNotificationAsync(exc);
            return StatusCode(500, "An error occurred while exporting categories.");
        }
    }

    [HttpGet("ExportXlsx")]
    [CheckPermission(StandardPermission.Catalog.CATEGORIES_IMPORT_EXPORT)]
    public async Task<IActionResult> ExportXlsx()
    {
        try
        {
            var bytes = await _exportManager.ExportCategoriesToXlsxAsync(await _categoryService.GetAllCategoriesAsync(showHidden: true));
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "categories.xlsx");
        }
        catch (Exception exc)
        {
            await _notificationService.ErrorNotificationAsync(exc);
            return StatusCode(500, "An error occurred while exporting categories.");
        }
    }

    //TODO: Comeback and fix for swagger UI

    //[HttpPost("ImportFromXlsx")]
    //[CheckPermission(StandardPermission.Catalog.CATEGORIES_IMPORT_EXPORT)]
    //public async Task<IActionResult> ImportFromXlsx([FromBody] IFormFile importFile)
    //{
    //    if (importFile == null || importFile.Length == 0)
    //    {
    //        _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Common.UploadFile"));
    //        return BadRequest("File is empty or missing.");
    //    }

    //    try
    //    {
    //        await _importManager.ImportCategoriesFromXlsxAsync(importFile.OpenReadStream());
    //        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Categories.Imported"));
    //        return Ok();
    //    }
    //    catch (Exception exc)
    //    {
    //        await _notificationService.ErrorNotificationAsync(exc);
    //        return StatusCode(500, "An error occurred while importing categories.");
    //    }
    //}

    #endregion

    #region Private Methods

    private async Task ConfigureCategoryDetailsAsync(Category category, CategoryModel model)
    {
        model.SeName = await _urlRecordService.ValidateSeNameAsync(category, model.SeName, category.Name, true);
        await _urlRecordService.SaveSlugAsync(category, model.SeName, 0);
        await UpdateLocalesAsync(category, model);
        await UpdatePictureSeoNamesAsync(category);
        await SaveStoreMappingsAsync(category, model);

        // Handle discount associations
        var allDiscounts = await _discountService.GetAllDiscountsAsync(DiscountType.AssignedToCategories, showHidden: true);
        foreach (var discount in allDiscounts)
        {
            if (model.SelectedDiscountIds != null && model.SelectedDiscountIds.Contains(discount.Id))
                await _categoryService.InsertDiscountCategoryMappingAsync(new DiscountCategoryMapping { DiscountId = discount.Id, EntityId = category.Id });
            else if (await _categoryService.GetDiscountAppliedToCategoryAsync(category.Id, discount.Id) is DiscountCategoryMapping mapping)
                await _categoryService.DeleteDiscountCategoryMappingAsync(mapping);
        }

        await _categoryService.UpdateCategoryAsync(category);
    }

    private async Task UpdateLocalesAsync(Category category, CategoryModel model)
    {
        foreach (var localized in model.Locales)
        {
            await _localizedEntityService.SaveLocalizedValueAsync(category, x => x.Name, localized.Name, localized.LanguageId);
            await _localizedEntityService.SaveLocalizedValueAsync(category, x => x.Description, localized.Description, localized.LanguageId);
            await _localizedEntityService.SaveLocalizedValueAsync(category, x => x.MetaKeywords, localized.MetaKeywords, localized.LanguageId);
            await _localizedEntityService.SaveLocalizedValueAsync(category, x => x.MetaDescription, localized.MetaDescription, localized.LanguageId);
            await _localizedEntityService.SaveLocalizedValueAsync(category, x => x.MetaTitle, localized.MetaTitle, localized.LanguageId);

            var seName = await _urlRecordService.ValidateSeNameAsync(category, localized.SeName, localized.Name, false);
            await _urlRecordService.SaveSlugAsync(category, seName, localized.LanguageId);
        }
    }

    private async Task UpdatePictureSeoNamesAsync(Category category)
    {
        var picture = await _pictureService.GetPictureByIdAsync(category.PictureId);
        if (picture != null)
            await _pictureService.SetSeoFilenameAsync(picture.Id, await _pictureService.GetPictureSeNameAsync(category.Name));
    }

    private async Task SaveStoreMappingsAsync(Category category, CategoryModel model)
    {
        category.LimitedToStores = model.SelectedStoreIds.Any();
        await _categoryService.UpdateCategoryAsync(category);

        var existingStoreMappings = await _storeMappingService.GetStoreMappingsAsync(category);
        foreach (var store in await _storeService.GetAllStoresAsync())
        {
            if (model.SelectedStoreIds.Contains(store.Id))
            {
                if (!existingStoreMappings.Any(sm => sm.StoreId == store.Id))
                    await _storeMappingService.InsertStoreMappingAsync(category, store.Id);
            }
            else
            {
                var storeMappingToDelete = existingStoreMappings.FirstOrDefault(sm => sm.StoreId == store.Id);
                if (storeMappingToDelete != null)
                    await _storeMappingService.DeleteStoreMappingAsync(storeMappingToDelete);
            }
        }
    }

    #endregion
}
