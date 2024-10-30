using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Messages;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Messages;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/queued-emails")]
    [ApiController]
    public class QueuedEmailController : ControllerBase
    {
        #region Fields

        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IQueuedEmailModelFactory _queuedEmailModelFactory;
        private readonly IQueuedEmailService _queuedEmailService;

        #endregion

        #region Ctor

        public QueuedEmailController(
            IDateTimeHelper dateTimeHelper,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IQueuedEmailModelFactory queuedEmailModelFactory,
            IQueuedEmailService queuedEmailService)
        {
            _dateTimeHelper = dateTimeHelper;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _queuedEmailModelFactory = queuedEmailModelFactory;
            _queuedEmailService = queuedEmailService;
        }

        #endregion

        #region Methods

        [HttpGet("list")]
        [CheckPermission(StandardPermission.System.MANAGE_MESSAGE_QUEUE)]
        public async Task<IActionResult> List()
        {
            var model = await _queuedEmailModelFactory.PrepareQueuedEmailSearchModelAsync(new QueuedEmailSearchModel());
            return Ok(model);
        }

        [HttpPost("list")]
        [CheckPermission(StandardPermission.System.MANAGE_MESSAGE_QUEUE)]
        public async Task<IActionResult> QueuedEmailList([FromBody] QueuedEmailSearchModel searchModel)
        {
            var model = await _queuedEmailModelFactory.PrepareQueuedEmailListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpGet("email/{id}")]
        [CheckPermission(StandardPermission.System.MANAGE_MESSAGE_QUEUE)]
        public async Task<IActionResult> GetEmailById(int id)
        {
            var email = await _queuedEmailService.GetQueuedEmailByIdAsync(id);
            if (email == null)
                return NotFound();

            var model = await _queuedEmailModelFactory.PrepareQueuedEmailModelAsync(null, email);
            return Ok(model);
        }

        [HttpPut("{id}")]
        [CheckPermission(StandardPermission.System.MANAGE_MESSAGE_QUEUE)]
        public async Task<IActionResult> UpdateEmail(int id, [FromBody] QueuedEmailModel model)
        {
            var email = await _queuedEmailService.GetQueuedEmailByIdAsync(id);
            if (email == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                email = model.ToEntity(email);
                email.DontSendBeforeDateUtc = model.SendImmediately || !model.DontSendBeforeDate.HasValue
                    ? null
                    : (DateTime?)_dateTimeHelper.ConvertToUtcTime(model.DontSendBeforeDate.Value);

                await _queuedEmailService.UpdateQueuedEmailAsync(email);
                return Ok(new { Message = "Queued email updated successfully" });
            }

            return BadRequest(ModelState);
        }

        [HttpPost("requeue")]
        [CheckPermission(StandardPermission.System.MANAGE_MESSAGE_QUEUE)]
        public async Task<IActionResult> RequeueEmail([FromBody] QueuedEmailModel queuedEmailModel)
        {
            var queuedEmail = await _queuedEmailService.GetQueuedEmailByIdAsync(queuedEmailModel.Id);
            if (queuedEmail == null)
                return NotFound();

            var requeuedEmail = new QueuedEmail
            {
                PriorityId = queuedEmail.PriorityId,
                From = queuedEmail.From,
                FromName = queuedEmail.FromName,
                To = queuedEmail.To,
                ToName = queuedEmail.ToName,
                ReplyTo = queuedEmail.ReplyTo,
                ReplyToName = queuedEmail.ReplyToName,
                CC = queuedEmail.CC,
                Bcc = queuedEmail.Bcc,
                Subject = queuedEmail.Subject,
                Body = queuedEmail.Body,
                AttachmentFilePath = queuedEmail.AttachmentFilePath,
                AttachmentFileName = queuedEmail.AttachmentFileName,
                AttachedDownloadId = queuedEmail.AttachedDownloadId,
                CreatedOnUtc = DateTime.UtcNow,
                EmailAccountId = queuedEmail.EmailAccountId,
                DontSendBeforeDateUtc = queuedEmailModel.SendImmediately || !queuedEmailModel.DontSendBeforeDate.HasValue
                    ? null
                    : (DateTime?)_dateTimeHelper.ConvertToUtcTime(queuedEmailModel.DontSendBeforeDate.Value)
            };
            await _queuedEmailService.InsertQueuedEmailAsync(requeuedEmail);
            return Ok(new { Message = "Queued email requeued successfully", Id = requeuedEmail.Id });
        }

        [HttpDelete("{id}")]
        [CheckPermission(StandardPermission.System.MANAGE_MESSAGE_QUEUE)]
        public async Task<IActionResult> DeleteEmail(int id)
        {
            var email = await _queuedEmailService.GetQueuedEmailByIdAsync(id);
            if (email == null)
                return NotFound();

            await _queuedEmailService.DeleteQueuedEmailAsync(email);
            return Ok(new { Message = "Queued email deleted successfully" });
        }

        [HttpPost("delete-selected")]
        [CheckPermission(StandardPermission.System.MANAGE_MESSAGE_QUEUE)]
        public async Task<IActionResult> DeleteSelected([FromBody] ICollection<int> selectedIds)
        {
            if (selectedIds == null || !selectedIds.Any())
                return NoContent();

            await _queuedEmailService.DeleteQueuedEmailsAsync(await _queuedEmailService.GetQueuedEmailsByIdsAsync(selectedIds.ToArray()));
            return Ok(new { Result = true });
        }

        [HttpDelete("delete-all")]
        [CheckPermission(StandardPermission.System.MANAGE_MESSAGE_QUEUE)]
        public async Task<IActionResult> DeleteAllEmails()
        {
            await _queuedEmailService.DeleteAllEmailsAsync();
            return Ok(new { Message = "All queued emails deleted successfully" });
        }

        #endregion
    }
}
