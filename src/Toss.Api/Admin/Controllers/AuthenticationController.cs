using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Customers;
using Nop.Core.Events;
using Nop.Services.Authentication.External;
using Nop.Services.Authentication.MultiFactor;
using Nop.Services.Configuration;
using Nop.Services.Plugins;
using Nop.Services.Security;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Models.ExternalAuthentication;
using Toss.Api.Admin.Models.MultiFactorAuthentication;

namespace Toss.Api.Admin.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    #region Fields

    private readonly ExternalAuthenticationSettings _externalAuthenticationSettings;
    private readonly IAuthenticationPluginManager _authenticationPluginManager;
    private readonly IEventPublisher _eventPublisher;
    private readonly IExternalAuthenticationMethodModelFactory _externalAuthenticationMethodModelFactory;
    private readonly IMultiFactorAuthenticationMethodModelFactory _multiFactorAuthenticationMethodModelFactory;
    private readonly IMultiFactorAuthenticationPluginManager _multiFactorAuthenticationPluginManager;
    private readonly IPermissionService _permissionService;
    private readonly ISettingService _settingService;
    private readonly MultiFactorAuthenticationSettings _multiFactorAuthenticationSettings;

    #endregion

    #region Ctor

    public AuthenticationController(
        ExternalAuthenticationSettings externalAuthenticationSettings,
        IAuthenticationPluginManager authenticationPluginManager,
        IEventPublisher eventPublisher,
        IExternalAuthenticationMethodModelFactory externalAuthenticationMethodModelFactory,
        IMultiFactorAuthenticationMethodModelFactory multiFactorAuthenticationMethodModelFactory,
        IMultiFactorAuthenticationPluginManager multiFactorAuthenticationPluginManager,
        IPermissionService permissionService,
        ISettingService settingService,
        MultiFactorAuthenticationSettings multiFactorAuthenticationSettings)
    {
        _externalAuthenticationSettings = externalAuthenticationSettings;
        _authenticationPluginManager = authenticationPluginManager;
        _eventPublisher = eventPublisher;
        _externalAuthenticationMethodModelFactory = externalAuthenticationMethodModelFactory;
        _multiFactorAuthenticationMethodModelFactory = multiFactorAuthenticationMethodModelFactory;
        _multiFactorAuthenticationPluginManager = multiFactorAuthenticationPluginManager;
        _permissionService = permissionService;
        _settingService = settingService;
        _multiFactorAuthenticationSettings = multiFactorAuthenticationSettings;
    }

    #endregion

    #region External Authentication

    [HttpGet("ExternalMethods")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_EXTERNAL_AUTHENTICATION_METHODS)]
    public IActionResult GetExternalMethods()
    {
        var model = _externalAuthenticationMethodModelFactory
            .PrepareExternalAuthenticationMethodSearchModel(new ExternalAuthenticationMethodSearchModel());

        return Ok(model);
    }

    [HttpPost("ExternalMethods")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_EXTERNAL_AUTHENTICATION_METHODS)]
    public async Task<IActionResult> GetExternalMethods([FromBody] ExternalAuthenticationMethodSearchModel searchModel)
    {
        var model = await _externalAuthenticationMethodModelFactory.PrepareExternalAuthenticationMethodListModelAsync(searchModel);
        return Ok(model);
    }

    [HttpPost("ExternalMethodUpdate")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_EXTERNAL_AUTHENTICATION_METHODS)]
    public async Task<IActionResult> UpdateExternalMethod([FromBody] ExternalAuthenticationMethodModel model)
    {
        var method = await _authenticationPluginManager.LoadPluginBySystemNameAsync(model.SystemName);
        if (_authenticationPluginManager.IsPluginActive(method))
        {
            if (!model.IsActive)
            {
                _externalAuthenticationSettings.ActiveAuthenticationMethodSystemNames.Remove(method.PluginDescriptor.SystemName);
                await _settingService.SaveSettingAsync(_externalAuthenticationSettings);
            }
        }
        else
        {
            if (model.IsActive)
            {
                _externalAuthenticationSettings.ActiveAuthenticationMethodSystemNames.Add(method.PluginDescriptor.SystemName);
                await _settingService.SaveSettingAsync(_externalAuthenticationSettings);
            }
        }

        var pluginDescriptor = method.PluginDescriptor;
        pluginDescriptor.DisplayOrder = model.DisplayOrder;
        pluginDescriptor.Save();
        await _eventPublisher.PublishAsync(new PluginUpdatedEvent(pluginDescriptor));

        return NoContent();
    }

    #endregion

    #region Multi-factor Authentication

    [HttpGet("MultiFactorMethods")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_MULTIFACTOR_AUTHENTICATION_METHODS)]
    public IActionResult GetMultiFactorMethods()
    {
        var model = _multiFactorAuthenticationMethodModelFactory
            .PrepareMultiFactorAuthenticationMethodSearchModel(new MultiFactorAuthenticationMethodSearchModel());

        return Ok(model);
    }

    [HttpPost("MultiFactorMethods")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_MULTIFACTOR_AUTHENTICATION_METHODS)]
    public async Task<IActionResult> GetMultiFactorMethods([FromBody] MultiFactorAuthenticationMethodSearchModel searchModel)
    {
        var model = await _multiFactorAuthenticationMethodModelFactory.PrepareMultiFactorAuthenticationMethodListModelAsync(searchModel);
        return Ok(model);
    }

    [HttpPost("MultiFactorMethodUpdate")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_MULTIFACTOR_AUTHENTICATION_METHODS)]
    public async Task<IActionResult> UpdateMultiFactorMethod([FromBody] MultiFactorAuthenticationMethodModel model)
    {
        var method = await _multiFactorAuthenticationPluginManager.LoadPluginBySystemNameAsync(model.SystemName);
        if (_multiFactorAuthenticationPluginManager.IsPluginActive(method))
        {
            if (!model.IsActive)
            {
                _multiFactorAuthenticationSettings.ActiveAuthenticationMethodSystemNames.Remove(method.PluginDescriptor.SystemName);
                await _settingService.SaveSettingAsync(_multiFactorAuthenticationSettings);
            }
        }
        else
        {
            if (model.IsActive)
            {
                _multiFactorAuthenticationSettings.ActiveAuthenticationMethodSystemNames.Add(method.PluginDescriptor.SystemName);
                await _settingService.SaveSettingAsync(_multiFactorAuthenticationSettings);
            }
        }

        var pluginDescriptor = method.PluginDescriptor;
        pluginDescriptor.DisplayOrder = model.DisplayOrder;
        pluginDescriptor.Save();
        await _eventPublisher.PublishAsync(new PluginUpdatedEvent(pluginDescriptor));

        return NoContent();
    }

    #endregion
}
