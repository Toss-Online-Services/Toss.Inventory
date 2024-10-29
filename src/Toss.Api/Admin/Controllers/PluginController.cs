using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Cms;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Payments;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Tax;
using Nop.Core.Events;
using Nop.Data.Extensions;
using Nop.Services.Authentication.External;
using Nop.Services.Authentication.MultiFactor;
using Nop.Services.Catalog;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Payments;
using Nop.Services.Plugins;
using Nop.Services.Security;
using Nop.Services.Shipping;
using Nop.Services.Shipping.Pickup;
using Nop.Services.Tax;
using Nop.Services.Themes;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Models.Common;
using Toss.Api.Admin.Models.Plugins;
using Toss.Api.Admin.Models.Plugins.Marketplace;

namespace Toss.Api.Admin.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public partial class PluginController : ControllerBase
{
    #region Fields

    private readonly CatalogSettings _catalogSettings;
    private readonly ExternalAuthenticationSettings _externalAuthenticationSettings;
    private readonly IAuthenticationPluginManager _authenticationPluginManager;
    private readonly ICommonModelFactory _commonModelFactory;
    private readonly ICustomerActivityService _customerActivityService;
    private readonly IEventPublisher _eventPublisher;
    private readonly ILocalizationService _localizationService;
    private readonly IMultiFactorAuthenticationPluginManager _multiFactorAuthenticationPluginManager;
    private readonly INotificationService _notificationService;
    private readonly IPermissionService _permissionService;
    private readonly IPaymentPluginManager _paymentPluginManager;
    private readonly IPickupPluginManager _pickupPluginManager;
    private readonly IPluginModelFactory _pluginModelFactory;
    private readonly IPluginService _pluginService;
    private readonly ISearchPluginManager _searchPluginManager;
    private readonly ISettingService _settingService;
    private readonly IShippingPluginManager _shippingPluginManager;
    private readonly IUploadService _uploadService;
    private readonly IWidgetPluginManager _widgetPluginManager;
    private readonly IWorkContext _workContext;
    private readonly MultiFactorAuthenticationSettings _multiFactorAuthenticationSettings;
    private readonly PaymentSettings _paymentSettings;
    private readonly ShippingSettings _shippingSettings;
    private readonly TaxSettings _taxSettings;
    private readonly WidgetSettings _widgetSettings;

    #endregion

    #region Constructor

    public PluginController(
        CatalogSettings catalogSettings,
        ExternalAuthenticationSettings externalAuthenticationSettings,
        IAuthenticationPluginManager authenticationPluginManager,
        ICommonModelFactory commonModelFactory,
        ICustomerActivityService customerActivityService,
        IEventPublisher eventPublisher,
        ILocalizationService localizationService,
        IMultiFactorAuthenticationPluginManager multiFactorAuthenticationPluginManager,
        INotificationService notificationService,
        IPermissionService permissionService,
        IPaymentPluginManager paymentPluginManager,
        IPickupPluginManager pickupPluginManager,
        IPluginModelFactory pluginModelFactory,
        IPluginService pluginService,
        ISearchPluginManager searchPluginManager,
        ISettingService settingService,
        IShippingPluginManager shippingPluginManager,
        IUploadService uploadService,
        IWidgetPluginManager widgetPluginManager,
        IWorkContext workContext,
        MultiFactorAuthenticationSettings multiFactorAuthenticationSettings,
        PaymentSettings paymentSettings,
        ShippingSettings shippingSettings,
        TaxSettings taxSettings,
        WidgetSettings widgetSettings)
    {
        _catalogSettings = catalogSettings;
        _externalAuthenticationSettings = externalAuthenticationSettings;
        _authenticationPluginManager = authenticationPluginManager;
        _commonModelFactory = commonModelFactory;
        _customerActivityService = customerActivityService;
        _eventPublisher = eventPublisher;
        _localizationService = localizationService;
        _multiFactorAuthenticationPluginManager = multiFactorAuthenticationPluginManager;
        _notificationService = notificationService;
        _permissionService = permissionService;
        _paymentPluginManager = paymentPluginManager;
        _pickupPluginManager = pickupPluginManager;
        _pluginModelFactory = pluginModelFactory;
        _pluginService = pluginService;
        _searchPluginManager = searchPluginManager;
        _settingService = settingService;
        _shippingPluginManager = shippingPluginManager;
        _uploadService = uploadService;
        _widgetPluginManager = widgetPluginManager;
        _workContext = workContext;
        _multiFactorAuthenticationSettings = multiFactorAuthenticationSettings;
        _paymentSettings = paymentSettings;
        _shippingSettings = shippingSettings;
        _taxSettings = taxSettings;
        _widgetSettings = widgetSettings;
    }

    #endregion

    #region Methods

    [HttpGet("list")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_PLUGINS)]
    public async Task<IActionResult> List(bool showWarnings = true)
    {
        var model = await _pluginModelFactory.PreparePluginSearchModelAsync(new PluginSearchModel());

        if (showWarnings)
        {
            var warnings = new List<SystemWarningModel>();
            await _commonModelFactory.PreparePluginsWarningModelAsync(warnings);

            if (warnings.Any())
                _notificationService.WarningNotification(string.Join("<br />", warnings), false);
        }

        return Ok(model);
    }

    [HttpPost("list/select")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_PLUGINS)]
    public async Task<IActionResult> ListSelect([FromBody] PluginSearchModel searchModel)
    {
        var model = await _pluginModelFactory.PreparePluginListModelAsync(searchModel);
        return Ok(model);
    }

    [HttpGet("admin-navigation-plugins")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_PLUGINS)]
    public async Task<IActionResult> AdminNavigationPlugins()
    {
        var models = await (await _pluginModelFactory.PrepareAdminNavigationPluginModelsAsync()).SelectAwait(async model => new
        {
            title = model.FriendlyName,
            link = model.ConfigurationUrl,
            parent = await _localizationService.GetResourceAsync("Admin.Configuration.Plugins.Local"),
            grandParent = string.Empty,
            rate = -50 // Negative rate to move plugins to the end of list
        }).ToListAsync();

        return Ok(models);
    }

    [HttpPost("upload")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_PLUGINS)]
    public async Task<IActionResult> UploadPluginsAndThemes(IFormFile archivefile)
    {
        try
        {
            if (archivefile == null || archivefile.Length == 0)
                throw new NopException(await _localizationService.GetResourceAsync("Admin.Common.UploadFile"));

            var descriptors = await _uploadService.UploadPluginsAndThemesAsync(archivefile);
            var pluginDescriptors = descriptors.OfType<PluginDescriptor>().ToList();
            var themeDescriptors = descriptors.OfType<ThemeDescriptor>().ToList();

            // Log activity for each plugin and theme
            foreach (var descriptor in pluginDescriptors)
            {
                await _customerActivityService.InsertActivityAsync("UploadNewPlugin",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.UploadNewPlugin"), descriptor.FriendlyName));
            }
            foreach (var descriptor in themeDescriptors)
            {
                await _customerActivityService.InsertActivityAsync("UploadNewTheme",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.UploadNewTheme"), descriptor.FriendlyName));
            }

            // Publish events
            if (pluginDescriptors.Any())
                await _eventPublisher.PublishAsync(new PluginsUploadedEvent(pluginDescriptors));
            if (themeDescriptors.Any())
                await _eventPublisher.PublishAsync(new ThemesUploadedEvent(themeDescriptors));

            var message = string.Format(await _localizationService.GetResourceAsync("Admin.Configuration.Plugins.Uploaded"),
                pluginDescriptors.Count, themeDescriptors.Count);
            _notificationService.SuccessNotification(message);

            return Ok(new { RestartApplication = themeDescriptors.Any() });
        }
        catch (Exception exc)
        {
            await _notificationService.ErrorNotificationAsync(exc);
            return BadRequest(exc.Message);
        }
    }

    [HttpPost("install")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_PLUGINS)]
    public async Task<IActionResult> Install([FromForm] string systemName)
    {
        try
        {
            var pluginDescriptor = await _pluginService.GetPluginDescriptorBySystemNameAsync<IPlugin>(systemName, LoadPluginsMode.All);
            if (pluginDescriptor == null || pluginDescriptor.Installed)
                return NotFound();

            await _pluginService.PreparePluginToInstallAsync(pluginDescriptor.SystemName, await _workContext.GetCurrentCustomerAsync());
            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Configuration.Plugins.ChangesApplyAfterReboot"));

            return Ok();
        }
        catch (Exception exc)
        {
            await _notificationService.ErrorNotificationAsync(exc);
            return BadRequest(exc.Message);
        }
    }

    [HttpPost("uninstall")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_PLUGINS)]
    public async Task<IActionResult> Uninstall([FromForm] string systemName)
    {
        try
        {
            var pluginDescriptor = await _pluginService.GetPluginDescriptorBySystemNameAsync<IPlugin>(systemName, LoadPluginsMode.All);
            if (pluginDescriptor == null || !pluginDescriptor.Installed)
                return NotFound();

            await _pluginService.PreparePluginToUninstallAsync(pluginDescriptor.SystemName);
            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Configuration.Plugins.ChangesApplyAfterReboot"));

            return Ok();
        }
        catch (Exception exc)
        {
            await _notificationService.ErrorNotificationAsync(exc);
            return BadRequest(exc.Message);
        }
    }

    [HttpPost("delete")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_PLUGINS)]
    public async Task<IActionResult> Delete([FromForm] string systemName)
    {
        try
        {
            var pluginDescriptor = await _pluginService.GetPluginDescriptorBySystemNameAsync<IPlugin>(systemName, LoadPluginsMode.All);
            if (pluginDescriptor?.Installed == true)
                return BadRequest("Plugin is currently installed");

            await _pluginService.PreparePluginToDeleteAsync(pluginDescriptor.SystemName);
            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Configuration.Plugins.ChangesApplyAfterReboot"));

            return Ok();
        }
        catch (Exception exc)
        {
            await _notificationService.ErrorNotificationAsync(exc);
            return BadRequest(exc.Message);
        }
    }

    [HttpPost("reload-list")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_PLUGINS)]
    public async Task<IActionResult> ReloadList()
    {
        await _pluginService.UninstallPluginsAsync();
        await _pluginService.DeletePluginsAsync();

        return Ok(new { RestartApplication = true });
    }

    [HttpGet("official-feed")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_PLUGINS)]
    public async Task<IActionResult> OfficialFeed()
    {
        var model = await _pluginModelFactory.PrepareOfficialFeedPluginSearchModelAsync(new OfficialFeedPluginSearchModel());
        return Ok(model);
    }

    [HttpPost("official-feed/select")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_PLUGINS)]
    public async Task<IActionResult> OfficialFeedSelect([FromBody] OfficialFeedPluginSearchModel searchModel)
    {
        var model = await _pluginModelFactory.PrepareOfficialFeedPluginListModelAsync(searchModel);
        return Ok(model);
    }

    #endregion
}
