//using Microsoft.AspNetCore.Mvc;
//using Nop.Services.Localization;
//using Nop.Services.Logging;
//using Nop.Services.Messages;
//using Nop.Services.Security;
//using Nop.Web.Framework.Controllers;
//using Nop.Web.Framework.Mvc.Filters;
//using Toss.Api.Admin.Factories;
//using Toss.Api.Admin.Models.Logging;
//using ILogger = Nop.Services.Logging.ILogger;

//namespace Nop.Web.Areas.Admin.Controllers
//{
//    [Route("api/admin/[controller]")]
//    [ApiController]
//    public partial class LogController : ControllerBase
//    {
//        #region Fields

//        protected readonly ICustomerActivityService _customerActivityService;
//        protected readonly ILocalizationService _localizationService;
//        protected readonly ILogger _logger;
//        protected readonly ILogModelFactory _logModelFactory;
//        protected readonly INotificationService _notificationService;
//        protected readonly IPermissionService _permissionService;

//        #endregion

//        #region Ctor

//        public LogController(ICustomerActivityService customerActivityService,
//        ILocalizationService localizationService,
//        ILogger logger,
//        ILogModelFactory logModelFactory,
//        INotificationService notificationService,
//        IPermissionService permissionService)
//        {
//            _customerActivityService = customerActivityService;
//            _localizationService = localizationService;
//            _logger = logger;
//            _logModelFactory = logModelFactory;
//            _notificationService = notificationService;
//            _permissionService = permissionService;
//        }

//        #endregion

//        #region Methods

//        [HttpGet("list")]
//        [CheckPermission(StandardPermission.System.MANAGE_SYSTEM_LOG)]
//        public async Task<IActionResult> List([FromQuery] LogSearchModel searchModel)
//        {
//            var model = await _logModelFactory.PrepareLogSearchModelAsync(new LogSearchModel());

//            return Ok(model);
//        }

//        [HttpPost]
//        [CheckPermission(StandardPermission.System.MANAGE_SYSTEM_LOG)]
//        public virtual async Task<IActionResult> LogList(LogSearchModel searchModel)
//        {
//            var model = await _logModelFactory.PrepareLogSearchModelAsync(new LogSearchModel());

//            return Ok(model);
//        }

//        //[HttpPost, ActionName("List")]
//        //[FormValueRequired("clearall")]
//        //[CheckPermission(StandardPermission.System.MANAGE_SYSTEM_LOG)]
//        //public virtual async Task<IActionResult> ClearAll()
//        //{
//        //    await _logger.ClearLogAsync();

//        //    //activity log
//        //    await _customerActivityService.InsertActivityAsync("DeleteSystemLog", await _localizationService.GetResourceAsync("ActivityLog.DeleteSystemLog"));

//        //    _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.System.Log.Cleared"));

//        //    return Ok("Logs entry cleared successfully"); 
//        //}


//        [CheckPermission(StandardPermission.System.MANAGE_SYSTEM_LOG)]
//        public virtual async Task<IActionResult> GetLog(int id)
//        {
//            //try to get a log with the specified id
//            var log = await _logger.GetLogByIdAsync(id);
//            if (log == null)
//                return BadRequest("Log not fount");

//            //prepare model
//            var model = await _logModelFactory.PrepareLogModelAsync(null, log);

//            return Ok(model);
//          }


//            //[HttpPost]
//            //[CheckPermission(StandardPermission.System.MANAGE_SYSTEM_LOG)]
//            //public virtual async Task<IActionResult> Delete(int id)
//            //{
//            //    //try to get a log with the specified id
//            //    var log = await _logger.GetLogByIdAsync(id);
//            //    if (log == null)
//            //        return RedirectToAction("List");

//            //    await _logger.DeleteLogAsync(log);

//            //    //activity log
//            //    await _customerActivityService.InsertActivityAsync("DeleteSystemLog", await _localizationService.GetResourceAsync("ActivityLog.DeleteSystemLog"), log);

//            //    _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.System.Log.Deleted"));

//            //    return Ok("Deleted");
//            //}

//            //[HttpPost]
//            //[CheckPermission(StandardPermission.System.MANAGE_SYSTEM_LOG)]
//            //public virtual async Task<IActionResult> DeleteSelected(ICollection<int> selectedIds)
//            //{
//            //    if (selectedIds == null || !selectedIds.Any())
//            //        return NoContent();

//            //    await _logger.DeleteLogsAsync((await _logger.GetLogByIdsAsync([.. selectedIds])).ToList());

//            //    //activity log
//            //    await _customerActivityService.InsertActivityAsync("DeleteSystemLog", await _localizationService.GetResourceAsync("ActivityLog.DeleteSystemLog"));

//            //    return Ok(new { Result = true });
//            //}

//            #endregion
//        }
//}
