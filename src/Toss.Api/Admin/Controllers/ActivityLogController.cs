using Microsoft.AspNetCore.Mvc;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Models.Logging;

namespace Toss.Api.Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityLogController : ControllerBase
    {
        #region Fields

        private readonly IActivityLogModelFactory _activityLogModelFactory;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ILocalizationService _localizationService;
        private readonly IPermissionService _permissionService;
        private readonly INotificationService _notificationService;
        private static readonly char[] _separator = { ',' };

        #endregion

        #region Constructor

        public ActivityLogController(
            IActivityLogModelFactory activityLogModelFactory,
            ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService)
        {
            _activityLogModelFactory = activityLogModelFactory;
            _customerActivityService = customerActivityService;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
        }

        #endregion

        #region API Methods

        [HttpGet("activity-types")]
        [CheckPermission(StandardPermission.Customers.ACTIVITY_LOG_VIEW)]
        public async Task<IActionResult> GetActivityTypes()
        {
            var model = await _activityLogModelFactory.PrepareActivityLogTypeSearchModelAsync(new ActivityLogTypeSearchModel());
            return Ok(model);
        }

        [HttpPost("save-types")]
        [CheckPermission(StandardPermission.Customers.ACTIVITY_LOG_MANAGE_TYPES)]
        public async Task<IActionResult> SaveTypes([FromBody] List<int> selectedActivityTypeIds)
        {
            await _customerActivityService.InsertActivityAsync("EditActivityLogTypes",
                await _localizationService.GetResourceAsync("ActivityLog.EditActivityLogTypes"));

            var activityTypes = await _customerActivityService.GetAllActivityTypesAsync();
            foreach (var activityType in activityTypes)
            {
                activityType.Enabled = selectedActivityTypeIds.Contains(activityType.Id);
                await _customerActivityService.UpdateActivityTypeAsync(activityType);
            }

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Customers.ActivityLogType.Updated"));
            return Ok(new { Message = "Activity types updated successfully." });
        }

        [HttpGet("activity-logs")]
        [CheckPermission(StandardPermission.Customers.ACTIVITY_LOG_VIEW)]
        public async Task<IActionResult> GetActivityLogs()
        {
            var model = await _activityLogModelFactory.PrepareActivityLogSearchModelAsync(new ActivityLogSearchModel());
            return Ok(model);
        }

        [HttpPost("list-logs")]
        [CheckPermission(StandardPermission.Customers.ACTIVITY_LOG_VIEW)]
        public async Task<IActionResult> ListLogs([FromBody] ActivityLogSearchModel searchModel)
        {
            var model = await _activityLogModelFactory.PrepareActivityLogListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpDelete("delete-log/{id}")]
        [CheckPermission(StandardPermission.Customers.ACTIVITY_LOG_DELETE)]
        public async Task<IActionResult> DeleteActivityLog(int id)
        {
            var logItem = await _customerActivityService.GetActivityByIdAsync(id);
            if (logItem == null)
                return NotFound(new { Message = "No activity log found with the specified id." });

            await _customerActivityService.DeleteActivityAsync(logItem);
            await _customerActivityService.InsertActivityAsync("DeleteActivityLog",
                await _localizationService.GetResourceAsync("ActivityLog.DeleteActivityLog"), logItem);

            return NoContent();
        }

        [HttpDelete("clear-all")]
        [CheckPermission(StandardPermission.Customers.ACTIVITY_LOG_DELETE)]
        public async Task<IActionResult> ClearAllActivityLogs()
        {
            await _customerActivityService.ClearAllActivitiesAsync();
            await _customerActivityService.InsertActivityAsync("DeleteActivityLog",
                await _localizationService.GetResourceAsync("ActivityLog.DeleteActivityLog"));

            return Ok(new { Message = "All activity logs cleared." });
        }

        #endregion
    }
}
