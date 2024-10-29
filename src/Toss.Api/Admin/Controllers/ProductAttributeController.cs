using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Catalog;

namespace Toss.Api.Admin.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public partial class ProductAttributeController : ControllerBase
{
    #region Fields

    private readonly ICustomerActivityService _customerActivityService;
    private readonly ILocalizationService _localizationService;
    private readonly ILocalizedEntityService _localizedEntityService;
    private readonly INotificationService _notificationService;
    private readonly IPermissionService _permissionService;
    private readonly IProductAttributeModelFactory _productAttributeModelFactory;
    private readonly IProductAttributeService _productAttributeService;

    #endregion

    #region Constructor

    public ProductAttributeController(ICustomerActivityService customerActivityService,
        ILocalizationService localizationService,
        ILocalizedEntityService localizedEntityService,
        INotificationService notificationService,
        IPermissionService permissionService,
        IProductAttributeModelFactory productAttributeModelFactory,
        IProductAttributeService productAttributeService)
    {
        _customerActivityService = customerActivityService;
        _localizationService = localizationService;
        _localizedEntityService = localizedEntityService;
        _notificationService = notificationService;
        _permissionService = permissionService;
        _productAttributeModelFactory = productAttributeModelFactory;
        _productAttributeService = productAttributeService;
    }

    #endregion

    #region Utilities

    protected virtual async Task UpdateLocalesAsync(ProductAttribute productAttribute, ProductAttributeModel model)
    {
        foreach (var localized in model.Locales)
        {
            await _localizedEntityService.SaveLocalizedValueAsync(productAttribute,
                x => x.Name,
                localized.Name,
                localized.LanguageId);

            await _localizedEntityService.SaveLocalizedValueAsync(productAttribute,
                x => x.Description,
                localized.Description,
                localized.LanguageId);
        }
    }

    protected virtual async Task UpdateLocalesAsync(PredefinedProductAttributeValue ppav, PredefinedProductAttributeValueModel model)
    {
        foreach (var localized in model.Locales)
        {
            await _localizedEntityService.SaveLocalizedValueAsync(ppav,
                x => x.Name,
                localized.Name,
                localized.LanguageId);
        }
    }

    #endregion

    #region Methods

    [HttpGet("list")]
    [CheckPermission(StandardPermission.Catalog.PRODUCT_ATTRIBUTES_VIEW)]
    public async Task<IActionResult> List()
    {
        var model = await _productAttributeModelFactory.PrepareProductAttributeSearchModelAsync(new ProductAttributeSearchModel());
        return Ok(model);
    }

    [HttpPost("list")]
    [CheckPermission(StandardPermission.Catalog.PRODUCT_ATTRIBUTES_VIEW)]
    public async Task<IActionResult> List([FromBody] ProductAttributeSearchModel searchModel)
    {
        var model = await _productAttributeModelFactory.PrepareProductAttributeListModelAsync(searchModel);
        return Ok(model);
    }

    [HttpPost("create")]
    [CheckPermission(StandardPermission.Catalog.PRODUCT_ATTRIBUTES_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Create([FromBody] ProductAttributeModel model, [FromQuery] bool continueEditing)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var productAttribute = model.ToEntity<ProductAttribute>();
        await _productAttributeService.InsertProductAttributeAsync(productAttribute);
        await UpdateLocalesAsync(productAttribute, model);

        await _customerActivityService.InsertActivityAsync("AddNewProductAttribute",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewProductAttribute"), productAttribute.Name), productAttribute);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Attributes.ProductAttributes.Added"));

        if (!continueEditing)
            return Ok(new { success = true });

        return Ok(new { success = true, id = productAttribute.Id });
    }

    [HttpGet("edit/{id}")]
    [CheckPermission(StandardPermission.Catalog.PRODUCT_ATTRIBUTES_VIEW)]
    public async Task<IActionResult> Edit(int id)
    {
        var productAttribute = await _productAttributeService.GetProductAttributeByIdAsync(id);
        if (productAttribute == null)
            return NotFound();

        var model = await _productAttributeModelFactory.PrepareProductAttributeModelAsync(null, productAttribute);
        return Ok(model);
    }

    [HttpPost("edit")]
    [CheckPermission(StandardPermission.Catalog.PRODUCT_ATTRIBUTES_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Edit([FromBody] ProductAttributeModel model, [FromQuery] bool continueEditing)
    {
        var productAttribute = await _productAttributeService.GetProductAttributeByIdAsync(model.Id);
        if (productAttribute == null)
            return NotFound();

        if (ModelState.IsValid)
        {
            productAttribute = model.ToEntity(productAttribute);
            await _productAttributeService.UpdateProductAttributeAsync(productAttribute);
            await UpdateLocalesAsync(productAttribute, model);

            await _customerActivityService.InsertActivityAsync("EditProductAttribute",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditProductAttribute"), productAttribute.Name), productAttribute);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Attributes.ProductAttributes.Updated"));

            if (!continueEditing)
                return Ok(new { success = true });

            return Ok(new { success = true, id = productAttribute.Id });
        }

        model = await _productAttributeModelFactory.PrepareProductAttributeModelAsync(model, productAttribute, true);
        return BadRequest(ModelState);
    }

    [HttpDelete("delete/{id}")]
    [CheckPermission(StandardPermission.Catalog.PRODUCT_ATTRIBUTES_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Delete(int id)
    {
        var productAttribute = await _productAttributeService.GetProductAttributeByIdAsync(id);
        if (productAttribute == null)
            return NotFound();

        await _productAttributeService.DeleteProductAttributeAsync(productAttribute);
        await _customerActivityService.InsertActivityAsync("DeleteProductAttribute",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteProductAttribute"), productAttribute.Name), productAttribute);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Attributes.ProductAttributes.Deleted"));

        return Ok(new { success = true });
    }

    [HttpPost("delete-selected")]
    [CheckPermission(StandardPermission.Catalog.PRODUCT_ATTRIBUTES_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> DeleteSelected([FromBody] ICollection<int> selectedIds)
    {
        if (selectedIds == null || !selectedIds.Any())
            return NoContent();

        var productAttributes = await _productAttributeService.GetProductAttributeByIdsAsync(selectedIds.ToArray());
        await _productAttributeService.DeleteProductAttributesAsync(productAttributes);

        foreach (var productAttribute in productAttributes)
        {
            await _customerActivityService.InsertActivityAsync("DeleteProductAttribute",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteProductAttribute"), productAttribute.Name), productAttribute);
        }

        return Ok(new { success = true });
    }

    [HttpPost("used-by-products")]
    [CheckPermission(StandardPermission.Catalog.PRODUCT_ATTRIBUTES_VIEW)]
    [CheckPermission(StandardPermission.Catalog.PRODUCTS_VIEW)]
    public async Task<IActionResult> UsedByProducts([FromBody] ProductAttributeProductSearchModel searchModel)
    {
        var productAttribute = await _productAttributeService.GetProductAttributeByIdAsync(searchModel.ProductAttributeId)
            ?? throw new ArgumentException("No product attribute found with the specified id");

        var model = await _productAttributeModelFactory.PrepareProductAttributeProductListModelAsync(searchModel, productAttribute);
        return Ok(model);
    }

    #endregion
}
