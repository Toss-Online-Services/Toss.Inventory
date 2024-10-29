using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Messages;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Messages;

namespace Toss.Api.Admin.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CampaignController : ControllerBase
{
    #region Fields

    private readonly EmailAccountSettings _emailAccountSettings;
    private readonly ICampaignModelFactory _campaignModelFactory;
    private readonly ICampaignService _campaignService;
    private readonly ICustomerActivityService _customerActivityService;
    private readonly IDateTimeHelper _dateTimeHelper;
    private readonly IEmailAccountService _emailAccountService;
    private readonly ILocalizationService _localizationService;
    private readonly INotificationService _notificationService;
    private readonly INewsLetterSubscriptionService _newsLetterSubscriptionService;
    private readonly IPermissionService _permissionService;
    private readonly IStoreContext _storeContext;
    private readonly IStoreService _storeService;
    private readonly IWorkContext _workContext;

    #endregion

    #region Ctor

    public CampaignController(
        EmailAccountSettings emailAccountSettings,
        ICampaignModelFactory campaignModelFactory,
        ICampaignService campaignService,
        ICustomerActivityService customerActivityService,
        IDateTimeHelper dateTimeHelper,
        IEmailAccountService emailAccountService,
        ILocalizationService localizationService,
        INotificationService notificationService,
        INewsLetterSubscriptionService newsLetterSubscriptionService,
        IPermissionService permissionService,
        IStoreContext storeContext,
        IStoreService storeService,
        IWorkContext workContext)
    {
        _emailAccountSettings = emailAccountSettings;
        _campaignModelFactory = campaignModelFactory;
        _campaignService = campaignService;
        _customerActivityService = customerActivityService;
        _dateTimeHelper = dateTimeHelper;
        _emailAccountService = emailAccountService;
        _localizationService = localizationService;
        _notificationService = notificationService;
        _newsLetterSubscriptionService = newsLetterSubscriptionService;
        _permissionService = permissionService;
        _storeContext = storeContext;
        _storeService = storeService;
        _workContext = workContext;
    }

    #endregion

    #region Methods

    [HttpGet("List")]
    [CheckPermission(StandardPermission.Promotions.CAMPAIGNS_VIEW)]
    public async Task<IActionResult> List()
    {
        var model = await _campaignModelFactory.PrepareCampaignSearchModelAsync(new CampaignSearchModel());
        return Ok(model);
    }

    [HttpPost("List")]
    [CheckPermission(StandardPermission.Promotions.CAMPAIGNS_VIEW)]
    public async Task<IActionResult> List([FromBody] CampaignSearchModel searchModel)
    {
        var model = await _campaignModelFactory.PrepareCampaignListModelAsync(searchModel);
        return Ok(model);
    }

    [HttpPost("Create")]
    [CheckPermission(StandardPermission.Promotions.CAMPAIGNS_CREATE_EDIT)]
    public async Task<IActionResult> Create([FromBody] CampaignModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var campaign = model.ToEntity<Campaign>();
        campaign.CreatedOnUtc = DateTime.UtcNow;
        campaign.DontSendBeforeDateUtc = model.DontSendBeforeDate.HasValue
            ? (DateTime?)_dateTimeHelper.ConvertToUtcTime(model.DontSendBeforeDate.Value)
            : null;

        await _campaignService.InsertCampaignAsync(campaign);
        await _customerActivityService.InsertActivityAsync("AddNewCampaign",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewCampaign"), campaign.Id), campaign);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Promotions.Campaigns.Added"));

        return NoContent();
    }

    [HttpGet("Edit/{id}")]
    [CheckPermission(StandardPermission.Promotions.CAMPAIGNS_VIEW)]
    public async Task<IActionResult> Edit(int id)
    {
        var campaign = await _campaignService.GetCampaignByIdAsync(id);
        if (campaign == null)
            return NotFound();

        var model = await _campaignModelFactory.PrepareCampaignModelAsync(null, campaign);
        return Ok(model);
    }

    [HttpPut("Edit")]
    [CheckPermission(StandardPermission.Promotions.CAMPAIGNS_CREATE_EDIT)]
    public async Task<IActionResult> Edit([FromBody] CampaignModel model)
    {
        var campaign = await _campaignService.GetCampaignByIdAsync(model.Id);
        if (campaign == null)
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        campaign = model.ToEntity(campaign);
        campaign.DontSendBeforeDateUtc = model.DontSendBeforeDate.HasValue
            ? (DateTime?)_dateTimeHelper.ConvertToUtcTime(model.DontSendBeforeDate.Value)
            : null;

        await _campaignService.UpdateCampaignAsync(campaign);
        await _customerActivityService.InsertActivityAsync("EditCampaign",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditCampaign"), campaign.Id), campaign);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Promotions.Campaigns.Updated"));

        return NoContent();
    }

    [HttpPost("SendTestEmail")]
    [CheckPermission(StandardPermission.Promotions.CAMPAIGNS_SEND_EMAILS)]
    public async Task<IActionResult> SendTestEmail([FromBody] CampaignModel model)
    {
        var campaign = await _campaignService.GetCampaignByIdAsync(model.Id);
        if (campaign == null)
            return NotFound();

        if (!CommonHelper.IsValidEmail(model.TestEmail))
        {
            _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Common.WrongEmail"));
            return BadRequest("Invalid email format.");
        }

        try
        {
            var emailAccount = await GetEmailAccountAsync(model.EmailAccountId);
            var store = await _storeContext.GetCurrentStoreAsync();
            var subscription = await _newsLetterSubscriptionService
                .GetNewsLetterSubscriptionByEmailAndStoreIdAsync(model.TestEmail, store.Id);

            if (subscription != null)
            {
                await _campaignService.SendCampaignAsync(campaign, emailAccount, new List<NewsLetterSubscription> { subscription });
            }
            else
            {
                var workingLanguage = await _workContext.GetWorkingLanguageAsync();
                await _campaignService.SendCampaignAsync(campaign, emailAccount, model.TestEmail, workingLanguage.Id);
            }

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Promotions.Campaigns.TestEmailSentToCustomers"));
            return Ok();
        }
        catch (Exception exc)
        {
            await _notificationService.ErrorNotificationAsync(exc);
            return StatusCode(500, "An error occurred while sending the test email.");
        }
    }

    [HttpPost("SendMassEmail")]
    [CheckPermission(StandardPermission.Promotions.CAMPAIGNS_SEND_EMAILS)]
    public async Task<IActionResult> SendMassEmail([FromBody] CampaignModel model)
    {
        var campaign = await _campaignService.GetCampaignByIdAsync(model.Id);
        if (campaign == null)
            return NotFound();

        try
        {
            var emailAccount = await GetEmailAccountAsync(model.EmailAccountId);
            var storeId = (await _storeService.GetStoreByIdAsync(campaign.StoreId))?.Id ?? 0;
            var subscriptions = await _newsLetterSubscriptionService.GetAllNewsLetterSubscriptionsAsync(storeId: storeId,
                customerRoleId: model.CustomerRoleId,
                isActive: true);

            var totalEmailsSent = await _campaignService.SendCampaignAsync(campaign, emailAccount, subscriptions);
            _notificationService.SuccessNotification(string.Format(await _localizationService.GetResourceAsync("Admin.Promotions.Campaigns.MassEmailSentToCustomers"), totalEmailsSent));

            return Ok();
        }
        catch (Exception exc)
        {
            await _notificationService.ErrorNotificationAsync(exc);
            return StatusCode(500, "An error occurred while sending the mass email.");
        }
    }

    [HttpDelete("{id}")]
    [CheckPermission(StandardPermission.Promotions.CAMPAIGNS_DELETE)]
    public async Task<IActionResult> Delete(int id)
    {
        var campaign = await _campaignService.GetCampaignByIdAsync(id);
        if (campaign == null)
            return NotFound();

        await _campaignService.DeleteCampaignAsync(campaign);
        await _customerActivityService.InsertActivityAsync("DeleteCampaign",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteCampaign"), campaign.Id), campaign);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Promotions.Campaigns.Deleted"));

        return NoContent();
    }

    #endregion

    #region Utilities

    private async Task<EmailAccount> GetEmailAccountAsync(int emailAccountId)
    {
        return await _emailAccountService.GetEmailAccountByIdAsync(emailAccountId)
               ?? await _emailAccountService.GetEmailAccountByIdAsync(_emailAccountSettings.DefaultEmailAccountId)
               ?? throw new NopException("Email account could not be loaded");
    }

    #endregion
}
