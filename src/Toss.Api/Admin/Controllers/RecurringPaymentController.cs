using Microsoft.AspNetCore.Mvc;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Orders;
using Nop.Services.Security;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Orders;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/recurring-payments")]
    [ApiController]
    public class RecurringPaymentController : ControllerBase
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IOrderProcessingService _orderProcessingService;
        private readonly IOrderService _orderService;
        private readonly IPermissionService _permissionService;
        private readonly IRecurringPaymentModelFactory _recurringPaymentModelFactory;

        #endregion

        #region Ctor

        public RecurringPaymentController(
            ILocalizationService localizationService,
            INotificationService notificationService,
            IOrderProcessingService orderProcessingService,
            IOrderService orderService,
            IPermissionService permissionService,
            IRecurringPaymentModelFactory recurringPaymentModelFactory)
        {
            _localizationService = localizationService;
            _notificationService = notificationService;
            _orderProcessingService = orderProcessingService;
            _orderService = orderService;
            _permissionService = permissionService;
            _recurringPaymentModelFactory = recurringPaymentModelFactory;
        }

        #endregion

        #region Methods

        [HttpGet("list")]
        [CheckPermission(StandardPermission.Orders.RECURRING_PAYMENTS_VIEW)]
        public async Task<IActionResult> List()
        {
            var model = await _recurringPaymentModelFactory.PrepareRecurringPaymentSearchModelAsync(new RecurringPaymentSearchModel());
            return Ok(model);
        }

        [HttpPost("list")]
        [CheckPermission(StandardPermission.Orders.RECURRING_PAYMENTS_VIEW)]
        public async Task<IActionResult> List([FromBody] RecurringPaymentSearchModel searchModel)
        {
            var model = await _recurringPaymentModelFactory.PrepareRecurringPaymentListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpGet("{id}")]
        [CheckPermission(StandardPermission.Orders.RECURRING_PAYMENTS_VIEW)]
        public async Task<IActionResult> Edit(int id)
        {
            var payment = await _orderService.GetRecurringPaymentByIdAsync(id);
            if (payment == null || payment.Deleted)
                return NotFound();

            var model = await _recurringPaymentModelFactory.PrepareRecurringPaymentModelAsync(null, payment);
            return Ok(model);
        }

        [HttpPut("{id}")]
        [CheckPermission(StandardPermission.Orders.RECURRING_PAYMENTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> Edit(int id, [FromBody] RecurringPaymentModel model)
        {
            var payment = await _orderService.GetRecurringPaymentByIdAsync(id);
            if (payment == null || payment.Deleted)
                return NotFound();

            if (ModelState.IsValid)
            {
                payment = model.ToEntity(payment);
                await _orderService.UpdateRecurringPaymentAsync(payment);
                return Ok(new { Message = "Recurring payment updated successfully" });
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [CheckPermission(StandardPermission.Orders.RECURRING_PAYMENTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> Delete(int id)
        {
            var payment = await _orderService.GetRecurringPaymentByIdAsync(id);
            if (payment == null)
                return NotFound();

            await _orderService.DeleteRecurringPaymentAsync(payment);
            return Ok(new { Message = "Recurring payment deleted successfully" });
        }

        [HttpPost("history")]
        [CheckPermission(StandardPermission.Orders.RECURRING_PAYMENTS_VIEW)]
        public async Task<IActionResult> HistoryList([FromBody] RecurringPaymentHistorySearchModel searchModel)
        {
            var payment = await _orderService.GetRecurringPaymentByIdAsync(searchModel.RecurringPaymentId)
                ?? throw new ArgumentException("No recurring payment found with the specified id");

            var model = await _recurringPaymentModelFactory.PrepareRecurringPaymentHistoryListModelAsync(searchModel, payment);
            return Ok(model);
        }

        [HttpPost("{id}/process-next-payment")]
        [CheckPermission(StandardPermission.Orders.RECURRING_PAYMENTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> ProcessNextPayment(int id)
        {
            var payment = await _orderService.GetRecurringPaymentByIdAsync(id);
            if (payment == null)
                return NotFound();

            try
            {
                var errors = (await _orderProcessingService.ProcessNextRecurringPaymentAsync(payment)).ToList();
                if (errors.Any())
                {
                    return BadRequest(errors);
                }

                return Ok(new { Message = "Next payment processed successfully" });
            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        [HttpPost("{id}/cancel")]
        [CheckPermission(StandardPermission.Orders.RECURRING_PAYMENTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> CancelRecurringPayment(int id)
        {
            var payment = await _orderService.GetRecurringPaymentByIdAsync(id);
            if (payment == null)
                return NotFound();

            try
            {
                var errors = await _orderProcessingService.CancelRecurringPaymentAsync(payment);
                if (errors.Any())
                {
                    return BadRequest(errors);
                }

                return Ok(new { Message = "Recurring payment canceled successfully" });
            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        #endregion
    }
}
