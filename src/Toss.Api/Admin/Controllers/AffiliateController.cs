using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Affiliates;
using Nop.Core.Domain.Common;
using Nop.Services.Affiliates;
using Nop.Services.Common;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Affiliates;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffiliateController : ControllerBase
    {
        #region Fields

        private readonly IAddressService _addressService;
        private readonly IAffiliateModelFactory _affiliateModelFactory;
        private readonly IAffiliateService _affiliateService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;

        #endregion

        #region Ctor

        public AffiliateController(
            IAddressService addressService,
            IAffiliateModelFactory affiliateModelFactory,
            IAffiliateService affiliateService,
            ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService)
        {
            _addressService = addressService;
            _affiliateModelFactory = affiliateModelFactory;
            _affiliateService = affiliateService;
            _customerActivityService = customerActivityService;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
        }

        #endregion

        #region Methods

        [HttpGet]
        [CheckPermission(StandardPermission.Promotions.AFFILIATES_VIEW)]
        public async Task<IActionResult> List([FromQuery] AffiliateSearchModel searchModel)
        {
            var model = await _affiliateModelFactory.PrepareAffiliateListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Promotions.AFFILIATES_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> Create([FromBody] AffiliateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var address = model.Address.ToEntity<Address>();
            address.CreatedOnUtc = DateTime.UtcNow;
            address.CountryId = address.CountryId == 0 ? null : address.CountryId;
            address.StateProvinceId = address.StateProvinceId == 0 ? null : address.StateProvinceId;

            await _addressService.InsertAddressAsync(address);

            var affiliate = model.ToEntity<Affiliate>();
            affiliate.FriendlyUrlName = await _affiliateService.ValidateFriendlyUrlNameAsync(affiliate, model.FriendlyUrlName);
            affiliate.AddressId = address.Id;

            await _affiliateService.InsertAffiliateAsync(affiliate);
            await _customerActivityService.InsertActivityAsync("AddNewAffiliate",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewAffiliate"), affiliate.Id), affiliate);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Affiliates.Added"));

            return CreatedAtAction(nameof(List), new { id = affiliate.Id }, affiliate);
        }



        [HttpGet("{id}")]
        [CheckPermission(StandardPermission.Promotions.AFFILIATES_VIEW)]
        public async Task<IActionResult> GetById(int id)
        {
            var affiliate = await _affiliateService.GetAffiliateByIdAsync(id);
            if (affiliate == null || affiliate.Deleted)
                return NotFound();

            var model = await _affiliateModelFactory.PrepareAffiliateModelAsync(null, affiliate);
            return Ok(model);
        }

        [HttpPut("{id}")]
        [CheckPermission(StandardPermission.Promotions.AFFILIATES_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> Edit(int id, [FromBody] AffiliateModel model)
        {
            var affiliate = await _affiliateService.GetAffiliateByIdAsync(id);
            if (affiliate == null || affiliate.Deleted)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var address = await _addressService.GetAddressByIdAsync(affiliate.AddressId);
            address = model.Address.ToEntity(address);
            address.CountryId = address.CountryId == 0 ? null : address.CountryId;
            address.StateProvinceId = address.StateProvinceId == 0 ? null : address.StateProvinceId;

            await _addressService.UpdateAddressAsync(address);

            affiliate = model.ToEntity(affiliate);
            affiliate.FriendlyUrlName = await _affiliateService.ValidateFriendlyUrlNameAsync(affiliate, model.FriendlyUrlName);

            await _affiliateService.UpdateAffiliateAsync(affiliate);
            await _customerActivityService.InsertActivityAsync("EditAffiliate",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditAffiliate"), affiliate.Id), affiliate);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Affiliates.Updated"));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [CheckPermission(StandardPermission.Promotions.AFFILIATES_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> Delete(int id)
        {
            var affiliate = await _affiliateService.GetAffiliateByIdAsync(id);
            if (affiliate == null)
                return NotFound();

            await _affiliateService.DeleteAffiliateAsync(affiliate);
            await _customerActivityService.InsertActivityAsync("DeleteAffiliate",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteAffiliate"), affiliate.Id), affiliate);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Affiliates.Deleted"));
            return NoContent();
        }

        [HttpGet("{affiliateId}/orders")]
        [CheckPermission(StandardPermission.Promotions.AFFILIATES_VIEW)]
        public async Task<IActionResult> AffiliatedOrderListGrid([FromQuery] AffiliatedOrderSearchModel searchModel, int affiliateId)
        {
            var affiliate = await _affiliateService.GetAffiliateByIdAsync(affiliateId);
            if (affiliate == null)
                return NotFound();

            var model = await _affiliateModelFactory.PrepareAffiliatedOrderListModelAsync(searchModel, affiliate);
            return Ok(model);
        }

        [HttpGet("{affiliateId}/customers")]
        [CheckPermission(StandardPermission.Promotions.AFFILIATES_VIEW)]
        public async Task<IActionResult> AffiliatedCustomerList([FromQuery] AffiliatedCustomerSearchModel searchModel, int affiliateId)
        {
            var affiliate = await _affiliateService.GetAffiliateByIdAsync(affiliateId);
            if (affiliate == null)
                return NotFound();

            var model = await _affiliateModelFactory.PrepareAffiliatedCustomerListModelAsync(searchModel, affiliate);
            return Ok(model);
        }

        #endregion
    }
}
