using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Messages;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Stores;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Messages;
using Nop.Web.Framework.Mvc.Filters;

namespace Toss.Api.Admin.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public partial class MessageTemplateController : ControllerBase
{
    #region Fields

    private readonly ICustomerActivityService _customerActivityService;
    private readonly ILocalizationService _localizationService;
    private readonly ILocalizedEntityService _localizedEntityService;
    private readonly IMessageTemplateModelFactory _messageTemplateModelFactory;
    private readonly IMessageTemplateService _messageTemplateService;
    private readonly INotificationService _notificationService;
    private readonly IPermissionService _permissionService;
    private readonly IStoreMappingService _storeMappingService;
    private readonly IStoreService _storeService;
    private readonly IWorkflowMessageService _workflowMessageService;

    #endregion

    #region Constructor

    public MessageTemplateController(
        ICustomerActivityService customerActivityService,
        ILocalizationService localizationService,
        ILocalizedEntityService localizedEntityService,
        IMessageTemplateModelFactory messageTemplateModelFactory,
        IMessageTemplateService messageTemplateService,
        INotificationService notificationService,
        IPermissionService permissionService,
        IStoreMappingService storeMappingService,
        IStoreService storeService,
        IWorkflowMessageService workflowMessageService)
    {
        _customerActivityService = customerActivityService;
        _localizationService = localizationService;
        _localizedEntityService = localizedEntityService;
        _messageTemplateModelFactory = messageTemplateModelFactory;
        _messageTemplateService = messageTemplateService;
        _notificationService = notificationService;
        _permissionService = permissionService;
        _storeMappingService = storeMappingService;
        _storeService = storeService;
        _workflowMessageService = workflowMessageService;
    }

    #endregion

    #region Utilities

    private async Task UpdateLocalesAsync(MessageTemplate messageTemplate, MessageTemplateModel model)
    {
        foreach (var localized in model.Locales)
        {
            await _localizedEntityService.SaveLocalizedValueAsync(messageTemplate, x => x.BccEmailAddresses, localized.BccEmailAddresses, localized.LanguageId);
            await _localizedEntityService.SaveLocalizedValueAsync(messageTemplate, x => x.Subject, localized.Subject, localized.LanguageId);
            await _localizedEntityService.SaveLocalizedValueAsync(messageTemplate, x => x.Body, localized.Body, localized.LanguageId);
            await _localizedEntityService.SaveLocalizedValueAsync(messageTemplate, x => x.EmailAccountId, localized.EmailAccountId, localized.LanguageId);
        }
    }

    private async Task SaveStoreMappingsAsync(MessageTemplate messageTemplate, MessageTemplateModel model)
    {
        messageTemplate.LimitedToStores = model.SelectedStoreIds.Any();
        await _messageTemplateService.UpdateMessageTemplateAsync(messageTemplate);

        var existingStoreMappings = await _storeMappingService.GetStoreMappingsAsync(messageTemplate);
        var allStores = await _storeService.GetAllStoresAsync();
        foreach (var store in allStores)
        {
            if (model.SelectedStoreIds.Contains(store.Id))
            {
                if (!existingStoreMappings.Any(sm => sm.StoreId == store.Id))
                    await _storeMappingService.InsertStoreMappingAsync(messageTemplate, store.Id);
            }
            else
            {
                var storeMappingToDelete = existingStoreMappings.FirstOrDefault(sm => sm.StoreId == store.Id);
                if (storeMappingToDelete != null)
                    await _storeMappingService.DeleteStoreMappingAsync(storeMappingToDelete);
            }
        }
    }

    #endregion

    #region Methods

    [HttpGet("list")]
    [CheckPermission(StandardPermission.ContentManagement.MESSAGE_TEMPLATES_VIEW)]
    public async Task<IActionResult> List()
    {
        var model = await _messageTemplateModelFactory.PrepareMessageTemplateSearchModelAsync(new MessageTemplateSearchModel());
        return Ok(model);
    }

    [HttpPost("list")]
    [CheckPermission(StandardPermission.ContentManagement.MESSAGE_TEMPLATES_VIEW)]
    public async Task<IActionResult> List([FromBody] MessageTemplateSearchModel searchModel)
    {
        var model = await _messageTemplateModelFactory.PrepareMessageTemplateListModelAsync(searchModel);
        return Ok(model);
    }

    [HttpGet("{id:int}")]
    [CheckPermission(StandardPermission.ContentManagement.MESSAGE_TEMPLATES_VIEW)]
    public async Task<IActionResult> Edit(int id)
    {
        var messageTemplate = await _messageTemplateService.GetMessageTemplateByIdAsync(id);
        if (messageTemplate == null)
            return NotFound();

        var model = await _messageTemplateModelFactory.PrepareMessageTemplateModelAsync(null, messageTemplate);
        return Ok(model);
    }

    [HttpPost("{id:int}")]
    [CheckPermission(StandardPermission.ContentManagement.MESSAGE_TEMPLATES_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Edit([FromBody] MessageTemplateModel model)
    {
        var messageTemplate = await _messageTemplateService.GetMessageTemplateByIdAsync(model.Id);
        if (messageTemplate == null)
            return NotFound();

        if (ModelState.IsValid)
        {
            messageTemplate = model.ToEntity(messageTemplate);

            if (!model.HasAttachedDownload)
                messageTemplate.AttachedDownloadId = 0;
            if (model.SendImmediately)
                messageTemplate.DelayBeforeSend = null;

            await _messageTemplateService.UpdateMessageTemplateAsync(messageTemplate);
            await _customerActivityService.InsertActivityAsync("EditMessageTemplate",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditMessageTemplate"), messageTemplate.Id), messageTemplate);

            await SaveStoreMappingsAsync(messageTemplate, model);
            await UpdateLocalesAsync(messageTemplate, model);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.ContentManagement.MessageTemplates.Updated"));
            return Ok();
        }

        return BadRequest(ModelState);
    }

    [HttpDelete("{id:int}")]
    [CheckPermission(StandardPermission.ContentManagement.MESSAGE_TEMPLATES_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Delete(int id)
    {
        var messageTemplate = await _messageTemplateService.GetMessageTemplateByIdAsync(id);
        if (messageTemplate == null)
            return NotFound();

        await _messageTemplateService.DeleteMessageTemplateAsync(messageTemplate);
        await _customerActivityService.InsertActivityAsync("DeleteMessageTemplate",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteMessageTemplate"), messageTemplate.Id), messageTemplate);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.ContentManagement.MessageTemplates.Deleted"));
        return Ok();
    }

    [HttpPost("{id:int}/copy")]
    [CheckPermission(StandardPermission.ContentManagement.MESSAGE_TEMPLATES_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> CopyTemplate(int id)
    {
        var messageTemplate = await _messageTemplateService.GetMessageTemplateByIdAsync(id);
        if (messageTemplate == null)
            return NotFound();

        try
        {
            var newMessageTemplate = await _messageTemplateService.CopyMessageTemplateAsync(messageTemplate);
            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.ContentManagement.MessageTemplates.Copied"));

            return Ok(new { newMessageTemplate.Id });
        }
        catch (Exception exc)
        {
            _notificationService.ErrorNotification(exc.Message);
            return BadRequest(exc.Message);
        }
    }

    [HttpGet("{id:int}/test")]
    [CheckPermission(StandardPermission.ContentManagement.MESSAGE_TEMPLATES_VIEW)]
    public async Task<IActionResult> TestTemplate(int id, [FromQuery] int languageId = 0)
    {
        var messageTemplate = await _messageTemplateService.GetMessageTemplateByIdAsync(id);
        if (messageTemplate == null)
            return NotFound();

        var model = await _messageTemplateModelFactory.PrepareTestMessageTemplateModelAsync(new TestMessageTemplateModel(), messageTemplate, languageId);
        return Ok(model);
    }

    [HttpPost("{id:int}/send-test")]
    [CheckPermission(StandardPermission.ContentManagement.MESSAGE_TEMPLATES_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> SendTest([FromBody] TestMessageTemplateModel model, [FromForm] IFormCollection form)
    {
        var messageTemplate = await _messageTemplateService.GetMessageTemplateByIdAsync(model.Id);
        if (messageTemplate == null)
            return NotFound();

        var tokens = form.Keys
            .Where(key => key.StartsWith("token_", StringComparison.InvariantCultureIgnoreCase))
            .Select(key =>
            {
                var tokenKey = key["token_".Length..].Replace("%", string.Empty);
                var value = form[key].ToString();
                if (bool.TryParse(value, out var boolValue)) return new Token(tokenKey, boolValue);
                if (int.TryParse(value, out var intValue)) return new Token(tokenKey, intValue);
                if (decimal.TryParse(value, out var decimalValue)) return new Token(tokenKey, decimalValue);
                return new Token(tokenKey, value);
            }).ToList();

        await _workflowMessageService.SendTestEmailAsync(messageTemplate.Id, model.SendTo, tokens, model.LanguageId);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.ContentManagement.MessageTemplates.Test.Success"));
        return Ok();
    }

    #endregion
}
