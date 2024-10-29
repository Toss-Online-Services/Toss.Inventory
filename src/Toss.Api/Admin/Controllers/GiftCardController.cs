using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Orders;
using Nop.Services.Catalog;
using Nop.Services.Directory;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Orders;
using Nop.Services.Security;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Orders;

namespace Toss.Api.Admin.Controllers;

[ApiController]
[Route("api/admin/[controller]")]
public class GiftCardController : ControllerBase
{
    #region Fields

    protected readonly CurrencySettings _currencySettings;
    protected readonly ICurrencyService _currencyService;
    protected readonly ICustomerActivityService _customerActivityService;
    protected readonly IDateTimeHelper _dateTimeHelper;
    protected readonly IGiftCardModelFactory _giftCardModelFactory;
    protected readonly IGiftCardService _giftCardService;
    protected readonly ILanguageService _languageService;
    protected readonly ILocalizationService _localizationService;
    protected readonly INotificationService _notificationService;
    protected readonly IOrderService _orderService;
    protected readonly IPermissionService _permissionService;
    protected readonly IPriceFormatter _priceFormatter;
    protected readonly IWorkflowMessageService _workflowMessageService;
    protected readonly LocalizationSettings _localizationSettings;

    #endregion

    #region Ctor

    public GiftCardController(CurrencySettings currencySettings,
        ICurrencyService currencyService,
        ICustomerActivityService customerActivityService,
        IDateTimeHelper dateTimeHelper,
        IGiftCardModelFactory giftCardModelFactory,
        IGiftCardService giftCardService,
        ILanguageService languageService,
        ILocalizationService localizationService,
        INotificationService notificationService,
        IOrderService orderService,
        IPermissionService permissionService,
        IPriceFormatter priceFormatter,
        IWorkflowMessageService workflowMessageService,
        LocalizationSettings localizationSettings)
    {
        _currencySettings = currencySettings;
        _currencyService = currencyService;
        _customerActivityService = customerActivityService;
        _dateTimeHelper = dateTimeHelper;
        _giftCardModelFactory = giftCardModelFactory;
        _giftCardService = giftCardService;
        _languageService = languageService;
        _localizationService = localizationService;
        _notificationService = notificationService;
        _orderService = orderService;
        _permissionService = permissionService;
        _priceFormatter = priceFormatter;
        _workflowMessageService = workflowMessageService;
        _localizationSettings = localizationSettings;
    }

    #endregion

    #region Methods

    [HttpGet("list")]
    [CheckPermission(StandardPermission.Orders.GIFT_CARDS_VIEW)]
    public virtual async Task<IActionResult> GetGiftCards()
    {
        var model = await _giftCardModelFactory.PrepareGiftCardSearchModelAsync(new GiftCardSearchModel());
        return Ok(model);
    }

    [HttpPost("search")]
    [CheckPermission(StandardPermission.Orders.GIFT_CARDS_VIEW)]
    public virtual async Task<IActionResult> GetGiftCardList([FromBody] GiftCardSearchModel searchModel)
    {
        var model = await _giftCardModelFactory.PrepareGiftCardListModelAsync(searchModel);
        return Ok(model);
    }

    [HttpPost("create")]
    [CheckPermission(StandardPermission.Orders.GIFT_CARDS_CREATE_EDIT_DELETE)]
    public virtual async Task<IActionResult> CreateGiftCard([FromBody] GiftCardModel model)
    {
        if (ModelState.IsValid)
        {
            var giftCard = model.ToEntity<GiftCard>();
            giftCard.CreatedOnUtc = DateTime.UtcNow;
            await _giftCardService.InsertGiftCardAsync(giftCard);

            await _customerActivityService.InsertActivityAsync("AddNewGiftCard",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewGiftCard"), giftCard.GiftCardCouponCode), giftCard);

            return Ok(new { success = true, message = await _localizationService.GetResourceAsync("Admin.GiftCards.Added"), giftCard.Id });
        }

        return BadRequest(ModelState);
    }

    [HttpGet("edit/{id}")]
    [CheckPermission(StandardPermission.Orders.GIFT_CARDS_VIEW)]
    public virtual async Task<IActionResult> GetGiftCardById(int id)
    {
        var giftCard = await _giftCardService.GetGiftCardByIdAsync(id);
        if (giftCard == null)
            return NotFound();

        var model = await _giftCardModelFactory.PrepareGiftCardModelAsync(null, giftCard);
        return Ok(model);
    }

    [HttpPut("edit/{id}")]
    [CheckPermission(StandardPermission.Orders.GIFT_CARDS_CREATE_EDIT_DELETE)]
    public virtual async Task<IActionResult> EditGiftCard(int id, [FromBody] GiftCardModel model)
    {
        var giftCard = await _giftCardService.GetGiftCardByIdAsync(id);
        if (giftCard == null)
            return NotFound();

        if (ModelState.IsValid)
        {
            giftCard = model.ToEntity(giftCard);
            await _giftCardService.UpdateGiftCardAsync(giftCard);

            await _customerActivityService.InsertActivityAsync("EditGiftCard",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditGiftCard"), giftCard.GiftCardCouponCode), giftCard);

            return Ok(new { success = true, message = await _localizationService.GetResourceAsync("Admin.GiftCards.Updated") });
        }

        return BadRequest(ModelState);
    }

    [HttpPost("generate-coupon-code")]
    [CheckPermission(StandardPermission.Orders.GIFT_CARDS_CREATE_EDIT_DELETE)]
    public virtual IActionResult GenerateCouponCode()
    {
        return Ok(new { CouponCode = _giftCardService.GenerateGiftCardCode() });
    }

    [HttpPost("notify-recipient/{id}")]
    [CheckPermission(StandardPermission.Orders.GIFT_CARDS_CREATE_EDIT_DELETE)]
    public virtual async Task<IActionResult> NotifyRecipient(int id)
    {
        var giftCard = await _giftCardService.GetGiftCardByIdAsync(id);
        if (giftCard == null)
            return NotFound();

        try
        {
            if (!CommonHelper.IsValidEmail(giftCard.RecipientEmail) || !CommonHelper.IsValidEmail(giftCard.SenderEmail))
                throw new NopException("Invalid email");

            var languageId = await DetermineLanguageIdForGiftCardNotification(giftCard);
            var queuedEmailIds = await _workflowMessageService.SendGiftCardNotificationAsync(giftCard, languageId);

            if (queuedEmailIds.Any())
            {
                giftCard.IsRecipientNotified = true;
                await _giftCardService.UpdateGiftCardAsync(giftCard);
            }

            return Ok(new { success = true, message = await _localizationService.GetResourceAsync("Admin.GiftCards.RecipientNotified") });
        }
        catch (Exception exc)
        {
            return BadRequest(new { success = false, message = exc.Message });
        }
    }

    [HttpDelete("{id}")]
    [CheckPermission(StandardPermission.Orders.GIFT_CARDS_CREATE_EDIT_DELETE)]
    public virtual async Task<IActionResult> DeleteGiftCard(int id)
    {
        var giftCard = await _giftCardService.GetGiftCardByIdAsync(id);
        if (giftCard == null)
            return NotFound();

        await _giftCardService.DeleteGiftCardAsync(giftCard);

        await _customerActivityService.InsertActivityAsync("DeleteGiftCard",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteGiftCard"), giftCard.GiftCardCouponCode), giftCard);

        return Ok(new { success = true, message = await _localizationService.GetResourceAsync("Admin.GiftCards.Deleted") });
    }

    [HttpPost("usage-history")]
    [CheckPermission(StandardPermission.Orders.GIFT_CARDS_CREATE_EDIT_DELETE)]
    public virtual async Task<IActionResult> GetUsageHistory([FromBody] GiftCardUsageHistorySearchModel searchModel)
    {
        var giftCard = await _giftCardService.GetGiftCardByIdAsync(searchModel.GiftCardId);
        if (giftCard == null)
            return NotFound("No gift card found with the specified ID");

        var model = await _giftCardModelFactory.PrepareGiftCardUsageHistoryListModelAsync(searchModel, giftCard);
        return Ok(model);
    }

    private async Task<int> DetermineLanguageIdForGiftCardNotification(GiftCard giftCard)
    {
        var order = await _orderService.GetOrderByOrderItemAsync(giftCard.PurchasedWithOrderItemId ?? 0);
        var customerLang = await _languageService.GetLanguageByIdAsync(order?.CustomerLanguageId ?? _localizationSettings.DefaultAdminLanguageId);
        return customerLang?.Id ?? _localizationSettings.DefaultAdminLanguageId;
    }

    #endregion
}
