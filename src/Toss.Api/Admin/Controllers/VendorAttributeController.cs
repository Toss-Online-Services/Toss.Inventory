using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Vendors;
using Nop.Services.Attributes;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using System.Threading.Tasks;
using System;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Models.Vendors;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/vendor-attributes")]
    [ApiController]
    public class VendorAttributeController : ControllerBase
    {
        #region Fields

        private readonly IAttributeService<VendorAttribute, VendorAttributeValue> _vendorAttributeService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedEntityService _localizedEntityService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IVendorAttributeModelFactory _vendorAttributeModelFactory;

        #endregion

        #region Ctor

        public VendorAttributeController(
            IAttributeService<VendorAttribute, VendorAttributeValue> vendorAttributeService,
            ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            ILocalizedEntityService localizedEntityService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IVendorAttributeModelFactory vendorAttributeModelFactory)
        {
            _vendorAttributeService = vendorAttributeService;
            _customerActivityService = customerActivityService;
            _localizationService = localizationService;
            _localizedEntityService = localizedEntityService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _vendorAttributeModelFactory = vendorAttributeModelFactory;
        }

        #endregion

        #region Utilities

        private async Task UpdateAttributeLocalesAsync(VendorAttribute vendorAttribute, VendorAttributeModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(vendorAttribute, x => x.Name, localized.Name, localized.LanguageId);
            }
        }

        private async Task UpdateValueLocalesAsync(VendorAttributeValue vendorAttributeValue, VendorAttributeValueModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(vendorAttributeValue, x => x.Name, localized.Name, localized.LanguageId);
            }
        }

        #endregion

        #region Vendor attributes

        [HttpGet]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> List(VendorAttributeSearchModel searchModel)
        {
            var model = await _vendorAttributeModelFactory.PrepareVendorAttributeListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> Create(VendorAttributeModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vendorAttribute = model.ToEntity<VendorAttribute>();
            await _vendorAttributeService.InsertAttributeAsync(vendorAttribute);

            await _customerActivityService.InsertActivityAsync("AddNewVendorAttribute",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewVendorAttribute"), vendorAttribute.Id), vendorAttribute);

            await UpdateAttributeLocalesAsync(vendorAttribute, model);

            return CreatedAtAction(nameof(Get), new { id = vendorAttribute.Id }, vendorAttribute);
        }

        [HttpGet("{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> Get(int id)
        {
            var vendorAttribute = await _vendorAttributeService.GetAttributeByIdAsync(id);
            if (vendorAttribute == null)
                return NotFound();

            var model = await _vendorAttributeModelFactory.PrepareVendorAttributeModelAsync(null, vendorAttribute);
            return Ok(model);
        }

        [HttpPut("{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> Edit(int id, VendorAttributeModel model)
        {
            var vendorAttribute = await _vendorAttributeService.GetAttributeByIdAsync(id);
            if (vendorAttribute == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            vendorAttribute = model.ToEntity(vendorAttribute);
            await _vendorAttributeService.UpdateAttributeAsync(vendorAttribute);

            await _customerActivityService.InsertActivityAsync("EditVendorAttribute",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditVendorAttribute"), vendorAttribute.Id), vendorAttribute);

            await UpdateAttributeLocalesAsync(vendorAttribute, model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> Delete(int id)
        {
            var vendorAttribute = await _vendorAttributeService.GetAttributeByIdAsync(id);
            if (vendorAttribute == null)
                return NotFound();

            await _vendorAttributeService.DeleteAttributeAsync(vendorAttribute);

            await _customerActivityService.InsertActivityAsync("DeleteVendorAttribute",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteVendorAttribute"), vendorAttribute.Id), vendorAttribute);

            return NoContent();
        }

        #endregion

        #region Vendor attribute values

        [HttpGet("{vendorAttributeId}/values")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> ValueList(int vendorAttributeId, VendorAttributeValueSearchModel searchModel)
        {
            var vendorAttribute = await _vendorAttributeService.GetAttributeByIdAsync(vendorAttributeId);
            if (vendorAttribute == null)
                return NotFound();

            var model = await _vendorAttributeModelFactory.PrepareVendorAttributeValueListModelAsync(searchModel, vendorAttribute);
            return Ok(model);
        }

        [HttpPost("{vendorAttributeId}/values")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> ValueCreate(int vendorAttributeId, VendorAttributeValueModel model)
        {
            var vendorAttribute = await _vendorAttributeService.GetAttributeByIdAsync(vendorAttributeId);
            if (vendorAttribute == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var value = model.ToEntity<VendorAttributeValue>();
            await _vendorAttributeService.InsertAttributeValueAsync(value);

            await _customerActivityService.InsertActivityAsync("AddNewVendorAttributeValue",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewVendorAttributeValue"), value.Id), value);

            await UpdateValueLocalesAsync(value, model);

            return CreatedAtAction(nameof(ValueGet), new { vendorAttributeId = vendorAttributeId, id = value.Id }, value);
        }

        [HttpGet("{vendorAttributeId}/values/{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> ValueGet(int vendorAttributeId, int id)
        {
            var vendorAttributeValue = await _vendorAttributeService.GetAttributeValueByIdAsync(id);
            if (vendorAttributeValue == null || vendorAttributeValue.AttributeId != vendorAttributeId)
                return NotFound();

            var vendorAttribute = await _vendorAttributeService.GetAttributeByIdAsync(vendorAttributeValue.AttributeId);
            var model = await _vendorAttributeModelFactory.PrepareVendorAttributeValueModelAsync(null, vendorAttribute, vendorAttributeValue);
            return Ok(model);
        }

        [HttpPut("{vendorAttributeId}/values/{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> ValueEdit(int vendorAttributeId, int id, VendorAttributeValueModel model)
        {
            var vendorAttributeValue = await _vendorAttributeService.GetAttributeValueByIdAsync(id);
            if (vendorAttributeValue == null || vendorAttributeValue.AttributeId != vendorAttributeId)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            vendorAttributeValue = model.ToEntity(vendorAttributeValue);
            await _vendorAttributeService.UpdateAttributeValueAsync(vendorAttributeValue);

            await _customerActivityService.InsertActivityAsync("EditVendorAttributeValue",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditVendorAttributeValue"), vendorAttributeValue.Id),
                vendorAttributeValue);

            await UpdateValueLocalesAsync(vendorAttributeValue, model);

            return NoContent();
        }

        [HttpDelete("{vendorAttributeId}/values/{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> ValueDelete(int vendorAttributeId, int id)
        {
            var value = await _vendorAttributeService.GetAttributeValueByIdAsync(id);
            if (value == null || value.AttributeId != vendorAttributeId)
                return NotFound();

            await _vendorAttributeService.DeleteAttributeValueAsync(value);

            await _customerActivityService.InsertActivityAsync("DeleteVendorAttributeValue",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteVendorAttributeValue"), value.Id), value);

            return NoContent();
        }

        #endregion
    }
}
