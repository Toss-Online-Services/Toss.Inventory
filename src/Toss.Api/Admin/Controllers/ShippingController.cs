using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Nop.Core;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Shipping;
using Nop.Core.Events;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Plugins;
using Nop.Services.Security;
using Nop.Services.Shipping;
using Nop.Services.Shipping.Date;
using Nop.Services.Shipping.Pickup;
using Nop.Web.Framework.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Shipping;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/shipping")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        #region Fields

        private readonly IAddressService _addressService;
        private readonly ICountryService _countryService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly IDateRangeService _dateRangeService;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedEntityService _localizedEntityService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IPickupPluginManager _pickupPluginManager;
        private readonly ISettingService _settingService;
        private readonly IShippingModelFactory _shippingModelFactory;
        private readonly IShippingPluginManager _shippingPluginManager;
        private readonly IShippingService _shippingService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly ShippingSettings _shippingSettings;
        private static readonly char[] _separator = { ',' };

        #endregion

        #region Ctor

        public ShippingController(
            IAddressService addressService,
            ICountryService countryService,
            ICustomerActivityService customerActivityService,
            IDateRangeService dateRangeService,
            IEventPublisher eventPublisher,
            ILocalizationService localizationService,
            ILocalizedEntityService localizedEntityService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IPickupPluginManager pickupPluginManager,
            ISettingService settingService,
            IShippingModelFactory shippingModelFactory,
            IShippingPluginManager shippingPluginManager,
            IShippingService shippingService,
            IGenericAttributeService genericAttributeService,
            ShippingSettings shippingSettings)
        {
            _addressService = addressService;
            _countryService = countryService;
            _customerActivityService = customerActivityService;
            _dateRangeService = dateRangeService;
            _eventPublisher = eventPublisher;
            _localizationService = localizationService;
            _localizedEntityService = localizedEntityService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _pickupPluginManager = pickupPluginManager;
            _settingService = settingService;
            _shippingModelFactory = shippingModelFactory;
            _shippingPluginManager = shippingPluginManager;
            _shippingService = shippingService;
            _genericAttributeService = genericAttributeService;
            _shippingSettings = shippingSettings;
        }

        #endregion

        #region Shipping rate computation methods

        [HttpGet("providers")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SHIPPING_SETTINGS)]
        public async Task<IActionResult> GetProviders()
        {
            var model = await _shippingModelFactory.PrepareShippingProviderSearchModelAsync(new ShippingProviderSearchModel());
            return Ok(model);
        }

        [HttpPut("providers/update")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SHIPPING_SETTINGS)]
        public async Task<IActionResult> UpdateProvider([FromBody] ShippingProviderModel model)
        {
            var plugin = await _shippingPluginManager.LoadPluginBySystemNameAsync(model.SystemName);
            if (_shippingPluginManager.IsPluginActive(plugin))
            {
                if (!model.IsActive)
                {
                    _shippingSettings.ActiveShippingRateComputationMethodSystemNames.Remove(plugin.PluginDescriptor.SystemName);
                    await _settingService.SaveSettingAsync(_shippingSettings);
                }
            }
            else
            {
                if (model.IsActive)
                {
                    _shippingSettings.ActiveShippingRateComputationMethodSystemNames.Add(plugin.PluginDescriptor.SystemName);
                    await _settingService.SaveSettingAsync(_shippingSettings);
                }
            }

            plugin.PluginDescriptor.DisplayOrder = model.DisplayOrder;
            plugin.PluginDescriptor.Save();

            await _eventPublisher.PublishAsync(new PluginUpdatedEvent(plugin.PluginDescriptor));

            return Ok(new { Message = "Shipping provider updated successfully" });
        }

        #endregion

        #region Pickup point providers

        [HttpGet("pickup-point-providers")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SHIPPING_SETTINGS)]
        public async Task<IActionResult> GetPickupPointProviders()
        {
            var model = await _shippingModelFactory.PreparePickupPointProviderSearchModelAsync(new PickupPointProviderSearchModel());
            return Ok(model);
        }

        [HttpPut("pickup-point-providers/update")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SHIPPING_SETTINGS)]
        public async Task<IActionResult> UpdatePickupPointProvider([FromBody] PickupPointProviderModel model)
        {
            var plugin = await _pickupPluginManager.LoadPluginBySystemNameAsync(model.SystemName);
            if (_pickupPluginManager.IsPluginActive(plugin))
            {
                if (!model.IsActive)
                {
                    _shippingSettings.ActivePickupPointProviderSystemNames.Remove(plugin.PluginDescriptor.SystemName);
                    await _settingService.SaveSettingAsync(_shippingSettings);
                }
            }
            else
            {
                if (model.IsActive)
                {
                    _shippingSettings.ActivePickupPointProviderSystemNames.Add(plugin.PluginDescriptor.SystemName);
                    await _settingService.SaveSettingAsync(_shippingSettings);
                }
            }

            plugin.PluginDescriptor.DisplayOrder = model.DisplayOrder;
            plugin.PluginDescriptor.Save();

            await _eventPublisher.PublishAsync(new PluginUpdatedEvent(plugin.PluginDescriptor));

            return Ok(new { Message = "Pickup point provider updated successfully" });
        }

        #endregion

        #region Shipping methods

        [HttpGet("methods")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SHIPPING_SETTINGS)]
        public async Task<IActionResult> GetMethods()
        {
            var model = await _shippingModelFactory.PrepareShippingMethodSearchModelAsync(new ShippingMethodSearchModel());
            return Ok(model);
        }

        [HttpPut("methods/update")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SHIPPING_SETTINGS)]
        public async Task<IActionResult> UpdateMethod([FromBody] ShippingMethodModel model)
        {
            var shippingMethod = await _shippingService.GetShippingMethodByIdAsync(model.Id);
            if (shippingMethod == null)
                return NotFound("Shipping method not found.");

            shippingMethod = model.ToEntity(shippingMethod);
            await _shippingService.UpdateShippingMethodAsync(shippingMethod);
            await UpdateLocalesAsync(shippingMethod, model);

            return Ok(new { Message = "Shipping method updated successfully" });
        }

        [HttpPost("methods/create")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SHIPPING_SETTINGS)]
        public async Task<IActionResult> CreateMethod([FromBody] ShippingMethodModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var shippingMethod = model.ToEntity<ShippingMethod>();
            await _shippingService.InsertShippingMethodAsync(shippingMethod);
            await UpdateLocalesAsync(shippingMethod, model);

            return CreatedAtAction(nameof(GetMethods), new { id = shippingMethod.Id }, shippingMethod);
        }

        [HttpDelete("methods/delete/{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SHIPPING_SETTINGS)]
        public async Task<IActionResult> DeleteMethod(int id)
        {
            var shippingMethod = await _shippingService.GetShippingMethodByIdAsync(id);
            if (shippingMethod == null)
                return NotFound("Shipping method not found.");

            await _shippingService.DeleteShippingMethodAsync(shippingMethod);
            return Ok(new { Message = "Shipping method deleted successfully" });
        }

        #endregion

        #region Utilities

        private async Task UpdateLocalesAsync(ShippingMethod shippingMethod, ShippingMethodModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(shippingMethod, x => x.Name, localized.Name, localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(shippingMethod, x => x.Description, localized.Description, localized.LanguageId);
            }
        }

        #endregion
    }
}
