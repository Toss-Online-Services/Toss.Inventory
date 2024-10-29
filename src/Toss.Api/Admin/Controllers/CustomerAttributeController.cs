using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Customers;
using Nop.Services.Attributes;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Customers;

namespace Toss.Api.Admin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerAttributeApiController : ControllerBase
{
    private readonly IAttributeService<CustomerAttribute, CustomerAttributeValue> _customerAttributeService;
    private readonly ICustomerActivityService _customerActivityService;
    private readonly ICustomerAttributeModelFactory _customerAttributeModelFactory;
    private readonly ILocalizationService _localizationService;
    private readonly ILocalizedEntityService _localizedEntityService;
    private readonly INotificationService _notificationService;
    private readonly IPermissionService _permissionService;

    public CustomerAttributeApiController(
        IAttributeService<CustomerAttribute, CustomerAttributeValue> customerAttributeService,
        ICustomerActivityService customerActivityService,
        ICustomerAttributeModelFactory customerAttributeModelFactory,
        ILocalizationService localizationService,
        ILocalizedEntityService localizedEntityService,
        INotificationService notificationService,
        IPermissionService permissionService)
    {
        _customerAttributeService = customerAttributeService;
        _customerActivityService = customerActivityService;
        _customerAttributeModelFactory = customerAttributeModelFactory;
        _localizationService = localizationService;
        _localizedEntityService = localizedEntityService;
        _notificationService = notificationService;
        _permissionService = permissionService;
    }

    private async Task UpdateAttributeLocalesAsync(CustomerAttribute customerAttribute, CustomerAttributeModel model)
    {
        foreach (var localized in model.Locales)
        {
            await _localizedEntityService.SaveLocalizedValueAsync(customerAttribute, x => x.Name, localized.Name, localized.LanguageId);
        }
    }

    private async Task UpdateValueLocalesAsync(CustomerAttributeValue customerAttributeValue, CustomerAttributeValueModel model)
    {
        foreach (var localized in model.Locales)
        {
            await _localizedEntityService.SaveLocalizedValueAsync(customerAttributeValue, x => x.Name, localized.Name, localized.LanguageId);
        }
    }

    [HttpGet("List")]
    public IActionResult List()
    {
        return Ok("Redirect to CustomerUser settings.");
    }

    [HttpPost("Search")]
    public async Task<IActionResult> List([FromBody] CustomerAttributeSearchModel searchModel)
    {
        var model = await _customerAttributeModelFactory.PrepareCustomerAttributeListModelAsync(searchModel);
        return Ok(model);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CustomerAttributeModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var customerAttribute = model.ToEntity<CustomerAttribute>();
        await _customerAttributeService.InsertAttributeAsync(customerAttribute);

        await _customerActivityService.InsertActivityAsync("AddNewCustomerAttribute",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewCustomerAttribute"), customerAttribute.Id),
            customerAttribute);

        await UpdateAttributeLocalesAsync(customerAttribute, model);
        return Ok(new { message = "Customer attribute added successfully", id = customerAttribute.Id });
    }

    [HttpGet("Edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var customerAttribute = await _customerAttributeService.GetAttributeByIdAsync(id);
        if (customerAttribute == null) return NotFound("Customer attribute not found.");

        var model = await _customerAttributeModelFactory.PrepareCustomerAttributeModelAsync(null, customerAttribute);
        return Ok(model);
    }

    [HttpPut("Edit/{id}")]
    public async Task<IActionResult> Edit(int id, [FromBody] CustomerAttributeModel model)
    {
        var customerAttribute = await _customerAttributeService.GetAttributeByIdAsync(id);
        if (customerAttribute == null) return NotFound("Customer attribute not found.");

        if (!ModelState.IsValid) return BadRequest(ModelState);

        customerAttribute = model.ToEntity(customerAttribute);
        await _customerAttributeService.UpdateAttributeAsync(customerAttribute);

        await _customerActivityService.InsertActivityAsync("EditCustomerAttribute",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditCustomerAttribute"), customerAttribute.Id),
            customerAttribute);

        await UpdateAttributeLocalesAsync(customerAttribute, model);
        return Ok("Customer attribute updated successfully.");
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var customerAttribute = await _customerAttributeService.GetAttributeByIdAsync(id);
        if (customerAttribute == null) return NotFound("Customer attribute not found.");

        await _customerAttributeService.DeleteAttributeAsync(customerAttribute);

        await _customerActivityService.InsertActivityAsync("DeleteCustomerAttribute",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteCustomerAttribute"), customerAttribute.Id),
            customerAttribute);

        return Ok("Customer attribute deleted successfully.");
    }

    [HttpPost("ValueList")]
    public async Task<IActionResult> ValueList([FromBody] CustomerAttributeValueSearchModel searchModel)
    {
        var customerAttribute = await _customerAttributeService.GetAttributeByIdAsync(searchModel.CustomerAttributeId);
        if (customerAttribute == null) return NotFound("Customer attribute not found.");

        var model = await _customerAttributeModelFactory.PrepareCustomerAttributeValueListModelAsync(searchModel, customerAttribute);
        return Ok(model);
    }

    [HttpPost("ValueCreate")]
    public async Task<IActionResult> ValueCreate([FromBody] CustomerAttributeValueModel model)
    {
        var customerAttribute = await _customerAttributeService.GetAttributeByIdAsync(model.AttributeId);
        if (customerAttribute == null) return NotFound("Customer attribute not found.");

        if (!ModelState.IsValid) return BadRequest(ModelState);

        var customerAttributeValue = model.ToEntity<CustomerAttributeValue>();
        await _customerAttributeService.InsertAttributeValueAsync(customerAttributeValue);

        await _customerActivityService.InsertActivityAsync("AddNewCustomerAttributeValue",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewCustomerAttributeValue"), customerAttributeValue.Id),
            customerAttributeValue);

        await UpdateValueLocalesAsync(customerAttributeValue, model);
        return Ok("Customer attribute value created successfully.");
    }

    [HttpPut("ValueEdit/{id}")]
    public async Task<IActionResult> ValueEdit(int id, [FromBody] CustomerAttributeValueModel model)
    {
        var customerAttributeValue = await _customerAttributeService.GetAttributeValueByIdAsync(id);
        if (customerAttributeValue == null) return NotFound("Customer attribute value not found.");

        if (!ModelState.IsValid) return BadRequest(ModelState);

        customerAttributeValue = model.ToEntity(customerAttributeValue);
        await _customerAttributeService.UpdateAttributeValueAsync(customerAttributeValue);

        await _customerActivityService.InsertActivityAsync("EditCustomerAttributeValue",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditCustomerAttributeValue"), customerAttributeValue.Id),
            customerAttributeValue);

        await UpdateValueLocalesAsync(customerAttributeValue, model);
        return Ok("Customer attribute value updated successfully.");
    }

    [HttpDelete("ValueDelete/{id}")]
    public async Task<IActionResult> ValueDelete(int id)
    {
        var customerAttributeValue = await _customerAttributeService.GetAttributeValueByIdAsync(id);
        if (customerAttributeValue == null) return NotFound("Customer attribute value not found.");

        await _customerAttributeService.DeleteAttributeValueAsync(customerAttributeValue);

        await _customerActivityService.InsertActivityAsync("DeleteCustomerAttributeValue",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteCustomerAttributeValue"), customerAttributeValue.Id),
            customerAttributeValue);

        return Ok("Customer attribute value deleted successfully.");
    }
}
