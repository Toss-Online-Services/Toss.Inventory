using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Cms;
using Nop.Core.Events;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Plugins;
using Nop.Services.Security;
using Toss.Api.Admin.Factories;
using System.Threading.Tasks;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Models.Cms;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/widgets")]
    [ApiController]
    public class WidgetController : ControllerBase
    {
        #region Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IWidgetModelFactory _widgetModelFactory;
        private readonly IWidgetPluginManager _widgetPluginManager;
        private readonly WidgetSettings _widgetSettings;

        #endregion

        #region Ctor

        public WidgetController(
            IEventPublisher eventPublisher,
            IPermissionService permissionService,
            ISettingService settingService,
            IWidgetModelFactory widgetModelFactory,
            IWidgetPluginManager widgetPluginManager,
            WidgetSettings widgetSettings)
        {
            _eventPublisher = eventPublisher;
            _permissionService = permissionService;
            _settingService = settingService;
            _widgetModelFactory = widgetModelFactory;
            _widgetPluginManager = widgetPluginManager;
            _widgetSettings = widgetSettings;
        }

        #endregion

        #region Widget Endpoints

        [HttpGet]
        [CheckPermission(StandardPermission.Configuration.MANAGE_WIDGETS)]
        public async Task<IActionResult> List([FromQuery] WidgetSearchModel searchModel)
        {
            var model = await _widgetModelFactory.PrepareWidgetListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPut("{systemName}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_WIDGETS)]
        public async Task<IActionResult> UpdateWidget(string systemName, [FromBody] WidgetModel model)
        {
            var widget = await _widgetPluginManager.LoadPluginBySystemNameAsync(systemName);
            if (widget == null)
                return NotFound($"Widget with system name '{systemName}' not found");

            if (_widgetPluginManager.IsPluginActive(widget, _widgetSettings.ActiveWidgetSystemNames))
            {
                if (!model.IsActive)
                {
                    _widgetSettings.ActiveWidgetSystemNames.Remove(widget.PluginDescriptor.SystemName);
                    await _settingService.SaveSettingAsync(_widgetSettings);
                }
            }
            else
            {
                if (model.IsActive)
                {
                    _widgetSettings.ActiveWidgetSystemNames.Add(widget.PluginDescriptor.SystemName);
                    await _settingService.SaveSettingAsync(_widgetSettings);
                }
            }

            var pluginDescriptor = widget.PluginDescriptor;
            pluginDescriptor.DisplayOrder = model.DisplayOrder;
            pluginDescriptor.Save();
            await _eventPublisher.PublishAsync(new PluginUpdatedEvent(pluginDescriptor));

            return NoContent();
        }

        #endregion
    }
}
