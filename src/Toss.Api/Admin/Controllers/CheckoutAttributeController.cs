using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Orders;
using Nop.Services.Attributes;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Orders;

namespace Toss.Api.Admin.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CheckoutAttributeController : ControllerBase
{
    #region Fields

    private readonly CurrencySettings _currencySettings;
    private readonly IAttributeParser<CheckoutAttribute, CheckoutAttributeValue> _checkoutAttributeParser;
    private readonly IAttributeService<CheckoutAttribute, CheckoutAttributeValue> _checkoutAttributeService;
    private readonly ICheckoutAttributeModelFactory _checkoutAttributeModelFactory;
    private readonly ICurrencyService _currencyService;
    private readonly ICustomerActivityService _customerActivityService;
    private readonly ILocalizationService _localizationService;
    private readonly ILocalizedEntityService _localizedEntityService;
    private readonly INotificationService _notificationService;
    private readonly IMeasureService _measureService;
    private readonly IPermissionService _permissionService;
    private readonly IStoreMappingService _storeMappingService;
    private readonly IStoreService _storeService;
    private readonly MeasureSettings _measureSettings;

    #endregion

    #region Ctor

    public CheckoutAttributeController(
        CurrencySettings currencySettings,
        IAttributeParser<CheckoutAttribute, CheckoutAttributeValue> checkoutAttributeParser,
        IAttributeService<CheckoutAttribute, CheckoutAttributeValue> checkoutAttributeService,
        ICheckoutAttributeModelFactory checkoutAttributeModelFactory,
        ICurrencyService currencyService,
        ICustomerActivityService customerActivityService,
        ILocalizationService localizationService,
        ILocalizedEntityService localizedEntityService,
        INotificationService notificationService,
        IMeasureService measureService,
        IPermissionService permissionService,
        IStoreMappingService storeMappingService,
        IStoreService storeService,
        MeasureSettings measureSettings)
    {
        _currencySettings = currencySettings;
        _checkoutAttributeParser = checkoutAttributeParser;
        _checkoutAttributeService = checkoutAttributeService;
        _checkoutAttributeModelFactory = checkoutAttributeModelFactory;
        _currencyService = currencyService;
        _customerActivityService = customerActivityService;
        _localizationService = localizationService;
        _localizedEntityService = localizedEntityService;
        _notificationService = notificationService;
        _measureService = measureService;
        _permissionService = permissionService;
        _storeMappingService = storeMappingService;
        _storeService = storeService;
        _measureSettings = measureSettings;
    }

    #endregion

    #region Utilities

    private async Task UpdateAttributeLocalesAsync(CheckoutAttribute checkoutAttribute, CheckoutAttributeModel model)
    {
        foreach (var localized in model.Locales)
        {
            await _localizedEntityService.SaveLocalizedValueAsync(checkoutAttribute, x => x.Name, localized.Name, localized.LanguageId);
            await _localizedEntityService.SaveLocalizedValueAsync(checkoutAttribute, x => x.TextPrompt, localized.TextPrompt, localized.LanguageId);
            await _localizedEntityService.SaveLocalizedValueAsync(checkoutAttribute, x => x.DefaultValue, localized.DefaultValue, localized.LanguageId);
        }
    }

    private async Task UpdateValueLocalesAsync(CheckoutAttributeValue checkoutAttributeValue, CheckoutAttributeValueModel model)
    {
        foreach (var localized in model.Locales)
        {
            await _localizedEntityService.SaveLocalizedValueAsync(checkoutAttributeValue, x => x.Name, localized.Name, localized.LanguageId);
        }
    }

    private async Task SaveStoreMappingsAsync(CheckoutAttribute checkoutAttribute, CheckoutAttributeModel model)
    {
        checkoutAttribute.LimitedToStores = model.SelectedStoreIds.Any();
        await _checkoutAttributeService.UpdateAttributeAsync(checkoutAttribute);

        var existingStoreMappings = await _storeMappingService.GetStoreMappingsAsync(checkoutAttribute);
        var allStores = await _storeService.GetAllStoresAsync();

        foreach (var store in allStores)
        {
            if (model.SelectedStoreIds.Contains(store.Id))
            {
                if (!existingStoreMappings.Any(sm => sm.StoreId == store.Id))
                    await _storeMappingService.InsertStoreMappingAsync(checkoutAttribute, store.Id);
            }
            else
            {
                var storeMappingToDelete = existingStoreMappings.FirstOrDefault(sm => sm.StoreId == store.Id);
                if (storeMappingToDelete != null)
                    await _storeMappingService.DeleteStoreMappingAsync(storeMappingToDelete);
            }
        }
    }

    private async Task SaveConditionAttributesAsync(CheckoutAttribute checkoutAttribute, CheckoutAttributeModel model)
    {
        string attributesXml = null;

        if (model.ConditionModel.EnableCondition)
        {
            var attribute = await _checkoutAttributeService.GetAttributeByIdAsync(model.ConditionModel.SelectedAttributeId);
            if (attribute != null)
            {
                switch (attribute.AttributeControlType)
                {
                    case AttributeControlType.DropdownList:
                    case AttributeControlType.RadioList:
                    case AttributeControlType.ColorSquares:
                    case AttributeControlType.ImageSquares:
                        {
                            var selectedAttribute = model.ConditionModel.ConditionAttributes
                                .FirstOrDefault(x => x.Id == model.ConditionModel.SelectedAttributeId);
                            var selectedValue = selectedAttribute?.SelectedValueId;

                            // Ensure empty values are saved if nothing is selected
                            attributesXml = _checkoutAttributeParser.AddAttribute(null, attribute,
                                string.IsNullOrEmpty(selectedValue) ? string.Empty : selectedValue);
                        }
                        break;

                    case AttributeControlType.Checkboxes:
                        {
                            var selectedAttribute = model.ConditionModel.ConditionAttributes
                                .FirstOrDefault(x => x.Id == model.ConditionModel.SelectedAttributeId);
                            var selectedValues = selectedAttribute?.Values
                                .Where(x => x.Selected)
                                .Select(x => x.Value)
                                .ToList();

                            if (selectedValues?.Any() ?? false)
                            {
                                foreach (var value in selectedValues)
                                {
                                    attributesXml = _checkoutAttributeParser.AddAttribute(attributesXml, attribute, value);
                                }
                            }
                            else
                            {
                                attributesXml = _checkoutAttributeParser.AddAttribute(null, attribute, string.Empty);
                            }
                        }
                        break;

                    case AttributeControlType.ReadonlyCheckboxes:
                    case AttributeControlType.TextBox:
                    case AttributeControlType.MultilineTextbox:
                    case AttributeControlType.Datepicker:
                    case AttributeControlType.FileUpload:
                    default:
                        // Unsupported types for conditions
                        break;
                }
            }
        }

        checkoutAttribute.ConditionAttributeXml = attributesXml;
    }


    #endregion

    #region Checkout attributes

    [HttpGet("List")]
    [CheckPermission(StandardPermission.Catalog.CHECKOUT_ATTRIBUTES_VIEW)]
    public async Task<IActionResult> List()
    {
        var model = await _checkoutAttributeModelFactory.PrepareCheckoutAttributeSearchModelAsync(new CheckoutAttributeSearchModel());
        return Ok(model);
    }

    [HttpPost("Create")]
    [CheckPermission(StandardPermission.Catalog.CHECKOUT_ATTRIBUTES_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Create([FromBody] CheckoutAttributeModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var checkoutAttribute = model.ToEntity<CheckoutAttribute>();
        await _checkoutAttributeService.InsertAttributeAsync(checkoutAttribute);

        await UpdateAttributeLocalesAsync(checkoutAttribute, model);
        await SaveStoreMappingsAsync(checkoutAttribute, model);

        await _customerActivityService.InsertActivityAsync("AddNewCheckoutAttribute",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewCheckoutAttribute"), checkoutAttribute.Name), checkoutAttribute);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Attributes.CheckoutAttributes.Added"));
        return CreatedAtAction(nameof(Edit), new { id = checkoutAttribute.Id }, model);
    }

    [HttpGet("Edit/{id}")]
    [CheckPermission(StandardPermission.Catalog.CHECKOUT_ATTRIBUTES_VIEW)]
    public async Task<IActionResult> Edit(int id)
    {
        var checkoutAttribute = await _checkoutAttributeService.GetAttributeByIdAsync(id);
        if (checkoutAttribute == null)
            return NotFound();

        var model = await _checkoutAttributeModelFactory.PrepareCheckoutAttributeModelAsync(null, checkoutAttribute);
        return Ok(model);
    }

    [HttpPut("Edit/{id}")]
    [CheckPermission(StandardPermission.Catalog.CHECKOUT_ATTRIBUTES_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Edit(int id, [FromBody] CheckoutAttributeModel model)
    {
        var checkoutAttribute = await _checkoutAttributeService.GetAttributeByIdAsync(id);
        if (checkoutAttribute == null)
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        checkoutAttribute = model.ToEntity(checkoutAttribute);
        await SaveConditionAttributesAsync(checkoutAttribute, model);
        await _checkoutAttributeService.UpdateAttributeAsync(checkoutAttribute);

        await UpdateAttributeLocalesAsync(checkoutAttribute, model);
        await SaveStoreMappingsAsync(checkoutAttribute, model);

        await _customerActivityService.InsertActivityAsync("EditCheckoutAttribute",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditCheckoutAttribute"), checkoutAttribute.Name), checkoutAttribute);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Attributes.CheckoutAttributes.Updated"));
        return NoContent();
    }

    [HttpDelete("{id}")]
    [CheckPermission(StandardPermission.Catalog.CHECKOUT_ATTRIBUTES_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Delete(int id)
    {
        var checkoutAttribute = await _checkoutAttributeService.GetAttributeByIdAsync(id);
        if (checkoutAttribute == null)
            return NotFound();

        await _checkoutAttributeService.DeleteAttributeAsync(checkoutAttribute);

        await _customerActivityService.InsertActivityAsync("DeleteCheckoutAttribute",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteCheckoutAttribute"), checkoutAttribute.Name), checkoutAttribute);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Attributes.CheckoutAttributes.Deleted"));
        return NoContent();
    }

    #endregion

    #region Checkout attribute values

    [HttpPost("ValueList")]
    [CheckPermission(StandardPermission.Catalog.CHECKOUT_ATTRIBUTES_VIEW)]
    public async Task<IActionResult> ValueList([FromBody] CheckoutAttributeValueSearchModel searchModel)
    {
        var checkoutAttribute = await _checkoutAttributeService.GetAttributeByIdAsync(searchModel.CheckoutAttributeId)
            ?? throw new ArgumentException("No checkout attribute found with the specified id");

        var model = await _checkoutAttributeModelFactory.PrepareCheckoutAttributeValueListModelAsync(searchModel, checkoutAttribute);
        return Ok(model);
    }

    [HttpPost("ValueCreate")]
    [CheckPermission(StandardPermission.Catalog.CHECKOUT_ATTRIBUTES_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> ValueCreate([FromBody] CheckoutAttributeValueModel model)
    {
        var checkoutAttribute = await _checkoutAttributeService.GetAttributeByIdAsync(model.AttributeId);
        if (checkoutAttribute == null)
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var checkoutAttributeValue = model.ToEntity<CheckoutAttributeValue>();
        await _checkoutAttributeService.InsertAttributeValueAsync(checkoutAttributeValue);

        await UpdateValueLocalesAsync(checkoutAttributeValue, model);
        return CreatedAtAction(nameof(ValueEdit), new { id = checkoutAttributeValue.Id }, model);
    }

    [HttpPut("ValueEdit/{id}")]
    [CheckPermission(StandardPermission.Catalog.CHECKOUT_ATTRIBUTES_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> ValueEdit(int id, [FromBody] CheckoutAttributeValueModel model)
    {
        var checkoutAttributeValue = await _checkoutAttributeService.GetAttributeValueByIdAsync(id);
        if (checkoutAttributeValue == null)
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        checkoutAttributeValue = model.ToEntity(checkoutAttributeValue);
        await _checkoutAttributeService.UpdateAttributeValueAsync(checkoutAttributeValue);

        await UpdateValueLocalesAsync(checkoutAttributeValue, model);
        return NoContent();
    }

    [HttpDelete("ValueDelete/{id}")]
    [CheckPermission(StandardPermission.Catalog.CHECKOUT_ATTRIBUTES_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> ValueDelete(int id)
    {
        var checkoutAttributeValue = await _checkoutAttributeService.GetAttributeValueByIdAsync(id);
        if (checkoutAttributeValue == null)
            return NotFound();

        await _checkoutAttributeService.DeleteAttributeValueAsync(checkoutAttributeValue);
        return NoContent();
    }

    #endregion
}
