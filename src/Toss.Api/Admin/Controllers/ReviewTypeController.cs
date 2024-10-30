using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Catalog;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/review-types")]
    [ApiController]
    public class ReviewTypeController : ControllerBase
    {
        #region Fields

        private readonly ICustomerActivityService _customerActivityService;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedEntityService _localizedEntityService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IReviewTypeModelFactory _reviewTypeModelFactory;
        private readonly IReviewTypeService _reviewTypeService;

        #endregion

        #region Ctor

        public ReviewTypeController(
            ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            ILocalizedEntityService localizedEntityService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IReviewTypeModelFactory reviewTypeModelFactory,
            IReviewTypeService reviewTypeService)
        {
            _reviewTypeModelFactory = reviewTypeModelFactory;
            _reviewTypeService = reviewTypeService;
            _customerActivityService = customerActivityService;
            _localizedEntityService = localizedEntityService;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
        }

        #endregion

        #region Utilities

        protected virtual async Task UpdateReviewTypeLocalesAsync(ReviewType reviewType, ReviewTypeModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(reviewType,
                    x => x.Name,
                    localized.Name,
                    localized.LanguageId);

                await _localizedEntityService.SaveLocalizedValueAsync(reviewType,
                    x => x.Description,
                    localized.Description,
                    localized.LanguageId);
            }
        }

        #endregion

        #region Review type

        [HttpGet("list")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> List([FromQuery] ReviewTypeSearchModel searchModel)
        {
            var model = await _reviewTypeModelFactory.PrepareReviewTypeListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost("create")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> Create([FromBody] ReviewTypeModel model)
        {
            if (ModelState.IsValid)
            {
                var reviewType = model.ToEntity<ReviewType>();
                await _reviewTypeService.InsertReviewTypeAsync(reviewType);

                await _customerActivityService.InsertActivityAsync("AddNewReviewType",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewReviewType"), reviewType.Id), reviewType);

                await UpdateReviewTypeLocalesAsync(reviewType, model);

                return CreatedAtAction(nameof(Edit), new { id = reviewType.Id }, model);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> Edit(int id)
        {
            var reviewType = await _reviewTypeService.GetReviewTypeByIdAsync(id);
            if (reviewType == null)
                return NotFound();

            var model = await _reviewTypeModelFactory.PrepareReviewTypeModelAsync(null, reviewType);
            return Ok(model);
        }

        [HttpPut("{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> Edit(int id, [FromBody] ReviewTypeModel model)
        {
            var reviewType = await _reviewTypeService.GetReviewTypeByIdAsync(id);
            if (reviewType == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                reviewType = model.ToEntity(reviewType);
                await _reviewTypeService.UpdateReviewTypeAsync(reviewType);

                await _customerActivityService.InsertActivityAsync("EditReviewType",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditReviewType"), reviewType.Id), reviewType);

                await UpdateReviewTypeLocalesAsync(reviewType, model);

                return Ok(new { Message = "Review type updated successfully" });
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_SETTINGS)]
        public async Task<IActionResult> Delete(int id)
        {
            var reviewType = await _reviewTypeService.GetReviewTypeByIdAsync(id);
            if (reviewType == null)
                return NotFound();

            try
            {
                await _reviewTypeService.DeleteReviewTypeAsync(reviewType);

                await _customerActivityService.InsertActivityAsync("DeleteReviewType",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteReviewType"), reviewType), reviewType);

                return Ok(new { Message = "Review type deleted successfully" });
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
