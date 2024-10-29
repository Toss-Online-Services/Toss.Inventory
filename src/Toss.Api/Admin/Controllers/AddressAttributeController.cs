using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Common;
using Nop.Services.Attributes;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Common;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressAttributeController : ControllerBase
    {
        #region Fields

        private readonly IAddressAttributeModelFactory _addressAttributeModelFactory;
        private readonly IAttributeService<AddressAttribute, AddressAttributeValue> _addressAttributeService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ILocalizedEntityService _localizedEntityService;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;

        #endregion

        #region Ctor

        public AddressAttributeController(
            IAddressAttributeModelFactory addressAttributeModelFactory,
            IAttributeService<AddressAttribute, AddressAttributeValue> addressAttributeService,
            ICustomerActivityService customerActivityService,
            ILocalizedEntityService localizedEntityService,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService)
        {
            _addressAttributeModelFactory = addressAttributeModelFactory;
            _addressAttributeService = addressAttributeService;
            _customerActivityService = customerActivityService;
            _localizedEntityService = localizedEntityService;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
        }

        #endregion

        #region Utilities

        private async Task UpdateAttributeLocalesAsync(AddressAttribute addressAttribute, AddressAttributeModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(addressAttribute, x => x.Name, localized.Name, localized.LanguageId);
            }
        }

        private async Task UpdateValueLocalesAsync(AddressAttributeValue addressAttributeValue, AddressAttributeValueModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(addressAttributeValue, x => x.Name, localized.Name, localized.LanguageId);
            }
        }

        #endregion

        #region Address attributes

        [HttpGet]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> List([FromQuery] AddressAttributeSearchModel searchModel)
        {
            var model = await _addressAttributeModelFactory.PrepareAddressAttributeListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> Create([FromBody] AddressAttributeModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var addressAttribute = model.ToEntity<AddressAttribute>();
            await _addressAttributeService.InsertAttributeAsync(addressAttribute);
            await _customerActivityService.InsertActivityAsync("AddNewAddressAttribute",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewAddressAttribute"), addressAttribute.Id), addressAttribute);
            await UpdateAttributeLocalesAsync(addressAttribute, model);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Address.AddressAttributes.Added"));
            return CreatedAtAction(nameof(GetById), new { id = addressAttribute.Id }, addressAttribute);
        }

        [HttpGet("{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> GetById(int id)
        {
            var addressAttribute = await _addressAttributeService.GetAttributeByIdAsync(id);
            if (addressAttribute == null)
                return NotFound();

            var model = await _addressAttributeModelFactory.PrepareAddressAttributeModelAsync(null, addressAttribute);
            return Ok(model);
        }

        [HttpPut("{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> Edit(int id, [FromBody] AddressAttributeModel model)
        {
            var addressAttribute = await _addressAttributeService.GetAttributeByIdAsync(id);
            if (addressAttribute == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            addressAttribute = model.ToEntity(addressAttribute);
            await _addressAttributeService.UpdateAttributeAsync(addressAttribute);
            await _customerActivityService.InsertActivityAsync("EditAddressAttribute",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditAddressAttribute"), addressAttribute.Id), addressAttribute);
            await UpdateAttributeLocalesAsync(addressAttribute, model);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Address.AddressAttributes.Updated"));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> Delete(int id)
        {
            var addressAttribute = await _addressAttributeService.GetAttributeByIdAsync(id);
            if (addressAttribute == null)
                return NotFound();

            await _addressAttributeService.DeleteAttributeAsync(addressAttribute);
            await _customerActivityService.InsertActivityAsync("DeleteAddressAttribute",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteAddressAttribute"), addressAttribute.Id), addressAttribute);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Address.AddressAttributes.Deleted"));
            return NoContent();
        }

        #endregion

        #region Address attribute values

        [HttpGet("{attributeId}/values")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> ValueList(int attributeId, [FromQuery] AddressAttributeValueSearchModel searchModel)
        {
            var addressAttribute = await _addressAttributeService.GetAttributeByIdAsync(attributeId);
            if (addressAttribute == null)
                return NotFound();

            var model = await _addressAttributeModelFactory.PrepareAddressAttributeValueListModelAsync(searchModel, addressAttribute);
            return Ok(model);
        }

        [HttpPost("{attributeId}/values")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> ValueCreate(int attributeId, [FromBody] AddressAttributeValueModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var addressAttributeValue = model.ToEntity<AddressAttributeValue>();
            await _addressAttributeService.InsertAttributeValueAsync(addressAttributeValue);
            await UpdateValueLocalesAsync(addressAttributeValue, model);

            await _customerActivityService.InsertActivityAsync("AddNewAddressAttributeValue",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewAddressAttributeValue"), addressAttributeValue.Id), addressAttributeValue);

            return CreatedAtAction(nameof(GetValueById), new { attributeId = attributeId, id = addressAttributeValue.Id }, addressAttributeValue);
        }

        [HttpGet("{attributeId}/values/{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> GetValueById(int attributeId, int id)
        {
            var addressAttributeValue = await _addressAttributeService.GetAttributeValueByIdAsync(id);
            if (addressAttributeValue == null)
                return NotFound();

            var addressAttribute = await _addressAttributeService.GetAttributeByIdAsync(attributeId);
            if (addressAttribute == null)
                return NotFound();

            var model = await _addressAttributeModelFactory.PrepareAddressAttributeValueModelAsync(null, addressAttribute, addressAttributeValue);
            return Ok(model);
        }

        [HttpDelete("{attributeId}/values/{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> ValueDelete(int id)
        {
            var addressAttributeValue = await _addressAttributeService.GetAttributeValueByIdAsync(id);
            if (addressAttributeValue == null)
                return NotFound();

            await _addressAttributeService.DeleteAttributeValueAsync(addressAttributeValue);
            await _customerActivityService.InsertActivityAsync("DeleteAddressAttributeValue",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteAddressAttributeValue"), addressAttributeValue.Id), addressAttributeValue);

            return NoContent();
        }

        #endregion
    }
}
