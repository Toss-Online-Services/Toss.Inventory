using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Orders;
using Nop.Services.Catalog;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Orders;
using Nop.Services.Security;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Orders;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/return-requests")]
    [ApiController]
    public class ReturnRequestController : ControllerBase
    {
        #region Fields

        private readonly ICustomerActivityService _customerActivityService;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedEntityService _localizedEntityService;
        private readonly INotificationService _notificationService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IPermissionService _permissionService;
        private readonly IReturnRequestModelFactory _returnRequestModelFactory;
        private readonly IReturnRequestService _returnRequestService;
        private readonly IWorkflowMessageService _workflowMessageService;

        #endregion

        #region Ctor

        public ReturnRequestController(
            ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            ILocalizedEntityService localizedEntityService,
            INotificationService notificationService,
            IOrderService orderService,
            IProductService productService,
            IPermissionService permissionService,
            IReturnRequestModelFactory returnRequestModelFactory,
            IReturnRequestService returnRequestService,
            IWorkflowMessageService workflowMessageService)
        {
            _customerActivityService = customerActivityService;
            _localizationService = localizationService;
            _localizedEntityService = localizedEntityService;
            _notificationService = notificationService;
            _orderService = orderService;
            _productService = productService;
            _permissionService = permissionService;
            _returnRequestModelFactory = returnRequestModelFactory;
            _returnRequestService = returnRequestService;
            _workflowMessageService = workflowMessageService;
        }

        #endregion


        #region Utilities

        protected virtual async Task UpdateLocalesAsync(ReturnRequestReason rrr, ReturnRequestReasonModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(rrr,
                    x => x.Name,
                    localized.Name,
                    localized.LanguageId);
            }
        }

        protected virtual async Task UpdateLocalesAsync(ReturnRequestAction rra, ReturnRequestActionModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(rra,
                    x => x.Name,
                    localized.Name,
                    localized.LanguageId);
            }
        }

        #endregion

        #region Methods

        [HttpGet("list")]
        [CheckPermission(StandardPermission.Orders.RETURN_REQUESTS_VIEW)]
        public async Task<IActionResult> List()
        {
            var model = await _returnRequestModelFactory.PrepareReturnRequestSearchModelAsync(new ReturnRequestSearchModel());
            return Ok(model);
        }

        [HttpPost("list")]
        [CheckPermission(StandardPermission.Orders.RETURN_REQUESTS_VIEW)]
        public async Task<IActionResult> List([FromBody] ReturnRequestSearchModel searchModel)
        {
            var model = await _returnRequestModelFactory.PrepareReturnRequestListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpGet("{id}")]
        [CheckPermission(StandardPermission.Orders.RETURN_REQUESTS_VIEW)]
        public async Task<IActionResult> Edit(int id)
        {
            var returnRequest = await _returnRequestService.GetReturnRequestByIdAsync(id);
            if (returnRequest == null)
                return NotFound();

            var model = await _returnRequestModelFactory.PrepareReturnRequestModelAsync(null, returnRequest);
            return Ok(model);
        }

        [HttpPut("{id}")]
        [CheckPermission(StandardPermission.Orders.RETURN_REQUESTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> Edit(int id, [FromBody] ReturnRequestModel model)
        {
            var returnRequest = await _returnRequestService.GetReturnRequestByIdAsync(id);
            if (returnRequest == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                var quantityToReturn = model.ReturnedQuantity - returnRequest.ReturnedQuantity;
                if (quantityToReturn < 0)
                {
                    return BadRequest($"Returned quantity cannot be less than the already returned quantity of {returnRequest.ReturnedQuantity}");
                }
                else if (quantityToReturn > 0)
                {
                    var orderItem = await _orderService.GetOrderItemByIdAsync(returnRequest.OrderItemId);
                    var product = await _productService.GetProductByIdAsync(orderItem.ProductId);
                    var productStockChangedMessage = $"Quantity returned to stock: {quantityToReturn}";

                    await _productService.AdjustInventoryAsync(product, quantityToReturn, orderItem.AttributesXml, productStockChangedMessage);
                }

                returnRequest = model.ToEntity(returnRequest);
                returnRequest.UpdatedOnUtc = DateTime.UtcNow;

                await _returnRequestService.UpdateReturnRequestAsync(returnRequest);
                return Ok(new { Message = "Return request updated successfully" });
            }

            return BadRequest(ModelState);
        }

        [HttpPost("{id}/notify-customer")]
        [CheckPermission(StandardPermission.Orders.RETURN_REQUESTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> NotifyCustomer(int id)
        {
            var returnRequest = await _returnRequestService.GetReturnRequestByIdAsync(id);
            if (returnRequest == null)
                return NotFound();

            var orderItem = await _orderService.GetOrderItemByIdAsync(returnRequest.OrderItemId);
            if (orderItem == null)
                return NotFound("Order item associated with the return request not found.");

            var order = await _orderService.GetOrderByIdAsync(orderItem.OrderId);
            await _workflowMessageService.SendReturnRequestStatusChangedCustomerNotificationAsync(returnRequest, orderItem, order);
            return Ok(new { Message = "Customer notified successfully" });
        }

        [HttpDelete("{id}")]
        [CheckPermission(StandardPermission.Orders.RETURN_REQUESTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> Delete(int id)
        {
            var returnRequest = await _returnRequestService.GetReturnRequestByIdAsync(id);
            if (returnRequest == null)
                return NotFound();

            await _returnRequestService.DeleteReturnRequestAsync(returnRequest);
            return Ok(new { Message = "Return request deleted successfully" });
        }

        #region Return request reasons

        [HttpGet("reasons")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> ReturnRequestReasonList([FromQuery] ReturnRequestReasonSearchModel searchModel)
        {
            var model = await _returnRequestModelFactory.PrepareReturnRequestReasonListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost("reasons")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> ReturnRequestReasonCreate([FromBody] ReturnRequestReasonModel model)
        {
            if (ModelState.IsValid)
            {
                var returnRequestReason = model.ToEntity<ReturnRequestReason>();
                await _returnRequestService.InsertReturnRequestReasonAsync(returnRequestReason);
                await UpdateLocalesAsync(returnRequestReason, model);
                return CreatedAtAction(nameof(ReturnRequestReasonList), new { id = returnRequestReason.Id });
            }

            return BadRequest(ModelState);
        }

        [HttpPut("reasons/{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> ReturnRequestReasonEdit(int id, [FromBody] ReturnRequestReasonModel model)
        {
            var returnRequestReason = await _returnRequestService.GetReturnRequestReasonByIdAsync(id);
            if (returnRequestReason == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                returnRequestReason = model.ToEntity(returnRequestReason);
                await _returnRequestService.UpdateReturnRequestReasonAsync(returnRequestReason);
                await UpdateLocalesAsync(returnRequestReason, model);
                return Ok(new { Message = "Return request reason updated successfully" });
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("reasons/{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> ReturnRequestReasonDelete(int id)
        {
            var returnRequestReason = await _returnRequestService.GetReturnRequestReasonByIdAsync(id);
            if (returnRequestReason == null)
                return NotFound();

            await _returnRequestService.DeleteReturnRequestReasonAsync(returnRequestReason);
            return Ok(new { Message = "Return request reason deleted successfully" });
        }

        #endregion

        #region Return request actions

        [HttpGet("actions")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> ReturnRequestActionList([FromQuery] ReturnRequestActionSearchModel searchModel)
        {
            var model = await _returnRequestModelFactory.PrepareReturnRequestActionListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost("actions")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> ReturnRequestActionCreate([FromBody] ReturnRequestActionModel model)
        {
            if (ModelState.IsValid)
            {
                var returnRequestAction = model.ToEntity<ReturnRequestAction>();
                await _returnRequestService.InsertReturnRequestActionAsync(returnRequestAction);
                await UpdateLocalesAsync(returnRequestAction, model);
                return CreatedAtAction(nameof(ReturnRequestActionList), new { id = returnRequestAction.Id });
            }

            return BadRequest(ModelState);
        }

        [HttpPut("actions/{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> ReturnRequestActionEdit(int id, [FromBody] ReturnRequestActionModel model)
        {
            var returnRequestAction = await _returnRequestService.GetReturnRequestActionByIdAsync(id);
            if (returnRequestAction == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                returnRequestAction = model.ToEntity(returnRequestAction);
                await _returnRequestService.UpdateReturnRequestActionAsync(returnRequestAction);
                await UpdateLocalesAsync(returnRequestAction, model);
                return Ok(new { Message = "Return request action updated successfully" });
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("actions/{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> ReturnRequestActionDelete(int id)
        {
            var returnRequestAction = await _returnRequestService.GetReturnRequestActionByIdAsync(id);
            if (returnRequestAction == null)
                return NotFound();

            await _returnRequestService.DeleteReturnRequestActionAsync(returnRequestAction);
            return Ok(new { Message = "Return request action deleted successfully" });
        }

        #endregion

        #endregion
    }
}
