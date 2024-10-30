using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Events;
using Nop.Services.Catalog;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Models.Catalog;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/product-reviews")]
    [ApiController]
    public class ProductReviewController : ControllerBase
    {
        #region Fields

        private readonly CatalogSettings _catalogSettings;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ICustomerService _customerService;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IProductReviewModelFactory _productReviewModelFactory;
        private readonly IProductService _productService;
        private readonly IWorkContext _workContext;
        private readonly IWorkflowMessageService _workflowMessageService;

        #endregion Fields

        #region Ctor

        public ProductReviewController(
            CatalogSettings catalogSettings,
            ICustomerActivityService customerActivityService,
            ICustomerService customerService,
            IEventPublisher eventPublisher,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IProductReviewModelFactory productReviewModelFactory,
            IProductService productService,
            IWorkContext workContext,
            IWorkflowMessageService workflowMessageService)
        {
            _catalogSettings = catalogSettings;
            _customerActivityService = customerActivityService;
            _customerService = customerService;
            _eventPublisher = eventPublisher;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _productReviewModelFactory = productReviewModelFactory;
            _productService = productService;
            _workContext = workContext;
            _workflowMessageService = workflowMessageService;
        }

        #endregion

        #region Methods

        [HttpGet("list")]
        [CheckPermission(StandardPermission.Catalog.PRODUCT_REVIEWS_VIEW)]
        public async Task<IActionResult> List()
        {
            var model = await _productReviewModelFactory.PrepareProductReviewSearchModelAsync(new ProductReviewSearchModel());
            return Ok(model);
        }

        [HttpPost("list")]
        [CheckPermission(StandardPermission.Catalog.PRODUCT_REVIEWS_VIEW)]
        public async Task<IActionResult> List([FromBody] ProductReviewSearchModel searchModel)
        {
            var model = await _productReviewModelFactory.PrepareProductReviewListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpGet("{id}")]
        [CheckPermission(StandardPermission.Catalog.PRODUCT_REVIEWS_VIEW)]
        public async Task<IActionResult> Edit(int id)
        {
            var productReview = await _productService.GetProductReviewByIdAsync(id);
            if (productReview == null)
                return NotFound();

            var currentVendor = await _workContext.GetCurrentVendorAsync();
            if (currentVendor != null && (await _productService.GetProductByIdAsync(productReview.ProductId)).VendorId != currentVendor.Id)
                return Forbid();

            var model = await _productReviewModelFactory.PrepareProductReviewModelAsync(null, productReview);
            return Ok(model);
        }

        [HttpPut("{id}")]
        [CheckPermission(StandardPermission.Catalog.PRODUCT_REVIEWS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> Edit(int id, [FromBody] ProductReviewModel model)
        {
            var productReview = await _productService.GetProductReviewByIdAsync(id);
            if (productReview == null)
                return NotFound();

            var currentVendor = await _workContext.GetCurrentVendorAsync();
            if (currentVendor != null && (await _productService.GetProductByIdAsync(productReview.ProductId)).VendorId != currentVendor.Id)
                return Forbid();

            if (ModelState.IsValid)
            {
                var previousIsApproved = productReview.IsApproved;

                if (currentVendor == null)
                {
                    productReview.Title = model.Title;
                    productReview.ReviewText = model.ReviewText;
                    productReview.IsApproved = model.IsApproved;
                }

                productReview.ReplyText = model.ReplyText;

                if (productReview.IsApproved &&
                    !string.IsNullOrEmpty(productReview.ReplyText) &&
                    _catalogSettings.NotifyCustomerAboutProductReviewReply && !productReview.CustomerNotifiedOfReply)
                {
                    var customer = await _customerService.GetCustomerByIdAsync(productReview.CustomerId);
                    var customerLanguageId = customer?.LanguageId ?? 0;

                    var queuedEmailIds = await _workflowMessageService.SendProductReviewReplyCustomerNotificationMessageAsync(productReview, customerLanguageId);
                    if (queuedEmailIds.Any())
                        productReview.CustomerNotifiedOfReply = true;
                }

                await _productService.UpdateProductReviewAsync(productReview);

                await _customerActivityService.InsertActivityAsync("EditProductReview",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditProductReview"), productReview.Id), productReview);

                if (currentVendor == null)
                {
                    var product = await _productService.GetProductByIdAsync(productReview.ProductId);
                    await _productService.UpdateProductReviewTotalsAsync(product);

                    if (!previousIsApproved && productReview.IsApproved)
                        await _eventPublisher.PublishAsync(new ProductReviewApprovedEvent(productReview));
                }

                return Ok(new { Message = "Product review updated successfully" });
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [CheckPermission(StandardPermission.Catalog.PRODUCT_REVIEWS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> Delete(int id)
        {
            var productReview = await _productService.GetProductReviewByIdAsync(id);
            if (productReview == null)
                return NotFound();

            if (await _workContext.GetCurrentVendorAsync() != null)
                return Forbid();

            await _productService.DeleteProductReviewAsync(productReview);

            await _customerActivityService.InsertActivityAsync("DeleteProductReview",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteProductReview"), productReview.Id), productReview);

            var product = await _productService.GetProductByIdAsync(productReview.ProductId);
            await _productService.UpdateProductReviewTotalsAsync(product);

            return Ok(new { Message = "Product review deleted successfully" });
        }

        [HttpPost("approve-selected")]
        [CheckPermission(StandardPermission.Catalog.PRODUCT_REVIEWS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> ApproveSelected([FromBody] ICollection<int> selectedIds)
        {
            if (await _workContext.GetCurrentVendorAsync() != null)
                return Forbid();

            if (selectedIds == null || !selectedIds.Any())
                return NoContent();

            var productReviews = (await _productService.GetProductReviewsByIdsAsync(selectedIds.ToArray())).Where(review => !review.IsApproved);

            foreach (var productReview in productReviews)
            {
                productReview.IsApproved = true;
                await _productService.UpdateProductReviewAsync(productReview);

                var product = await _productService.GetProductByIdAsync(productReview.ProductId);
                await _productService.UpdateProductReviewTotalsAsync(product);

                await _eventPublisher.PublishAsync(new ProductReviewApprovedEvent(productReview));
            }

            return Ok(new { Message = "Selected product reviews approved" });
        }

        #endregion
    }
}
