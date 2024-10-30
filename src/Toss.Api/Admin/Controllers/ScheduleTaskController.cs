using Microsoft.AspNetCore.Mvc;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.ScheduleTasks;
using Nop.Services.Security;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework.Mvc.ModelBinding;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Tasks;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/schedule-tasks")]
    [ApiController]
    public class ScheduleTaskController : ControllerBase
    {
        #region Fields

        private readonly ICustomerActivityService _customerActivityService;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IScheduleTaskModelFactory _scheduleTaskModelFactory;
        private readonly IScheduleTaskService _scheduleTaskService;
        private readonly IScheduleTaskRunner _taskRunner;

        #endregion

        #region Ctor

        public ScheduleTaskController(
            ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IScheduleTaskModelFactory scheduleTaskModelFactory,
            IScheduleTaskService scheduleTaskService,
            IScheduleTaskRunner taskRunner)
        {
            _customerActivityService = customerActivityService;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _scheduleTaskModelFactory = scheduleTaskModelFactory;
            _scheduleTaskService = scheduleTaskService;
            _taskRunner = taskRunner;
        }

        #endregion

        #region Methods

        [HttpGet("list")]
        [CheckPermission(StandardPermission.System.MANAGE_SCHEDULE_TASKS)]
        public async Task<IActionResult> List()
        {
            var model = await _scheduleTaskModelFactory.PrepareScheduleTaskSearchModelAsync(new ScheduleTaskSearchModel());
            return Ok(model);
        }

        [HttpPost("list")]
        [CheckPermission(StandardPermission.System.MANAGE_SCHEDULE_TASKS)]
        public async Task<IActionResult> List([FromBody] ScheduleTaskSearchModel searchModel)
        {
            var model = await _scheduleTaskModelFactory.PrepareScheduleTaskListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPut("update")]
        [CheckPermission(StandardPermission.System.MANAGE_SCHEDULE_TASKS)]
        public async Task<IActionResult> TaskUpdate([FromBody] ScheduleTaskModel model)
        {
            var scheduleTask = await _scheduleTaskService.GetTaskByIdAsync(model.Id);
            if (scheduleTask == null)
                return BadRequest("Schedule task cannot be loaded");

            if (!string.IsNullOrEmpty(scheduleTask.Name))
            {
                model.Name = scheduleTask.Name;
                ModelState.Remove(nameof(model.Name));
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState.SerializeErrors());

            if (!scheduleTask.Enabled && model.Enabled)
                scheduleTask.LastEnabledUtc = DateTime.UtcNow;

            scheduleTask = model.ToEntity(scheduleTask);
            await _scheduleTaskService.UpdateTaskAsync(scheduleTask);

            await _customerActivityService.InsertActivityAsync("EditTask",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditTask"), scheduleTask.Id), scheduleTask);

            return Ok(new { Message = "Schedule task updated successfully" });
        }

        [HttpPost("run-now/{id}")]
        [CheckPermission(StandardPermission.System.MANAGE_SCHEDULE_TASKS)]
        public async Task<IActionResult> RunNow(int id)
        {
            try
            {
                var scheduleTask = await _scheduleTaskService.GetTaskByIdAsync(id);
                if (scheduleTask == null)
                    return BadRequest("Schedule task cannot be loaded");

                await _taskRunner.ExecuteAsync(scheduleTask, true, true, false);
                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.System.ScheduleTasks.RunNow.Done"));

                return Ok(new { Message = "Schedule task executed successfully" });
            }
            catch (Exception exc)
            {
                await _notificationService.ErrorNotificationAsync(exc);
                return StatusCode(500, new { Message = exc.Message });
            }
        }

        #endregion
    }
}
