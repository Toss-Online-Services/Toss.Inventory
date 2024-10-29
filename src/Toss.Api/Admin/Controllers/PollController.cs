using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Polls;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Polls;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Polls;

namespace Toss.Api.Admin.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public partial class PollController : ControllerBase
{
    #region Fields

    private readonly ILocalizationService _localizationService;
    private readonly INotificationService _notificationService;
    private readonly IPermissionService _permissionService;
    private readonly IPollModelFactory _pollModelFactory;
    private readonly IPollService _pollService;
    private readonly IStoreMappingService _storeMappingService;
    private readonly IStoreService _storeService;

    #endregion

    #region Constructor

    public PollController(ILocalizationService localizationService,
        INotificationService notificationService,
        IPermissionService permissionService,
        IPollModelFactory pollModelFactory,
        IPollService pollService,
        IStoreMappingService storeMappingService,
        IStoreService storeService)
    {
        _localizationService = localizationService;
        _notificationService = notificationService;
        _permissionService = permissionService;
        _pollModelFactory = pollModelFactory;
        _pollService = pollService;
        _storeMappingService = storeMappingService;
        _storeService = storeService;
    }

    #endregion

    #region Utilities

    protected virtual async Task SaveStoreMappingsAsync(Poll poll, PollModel model)
    {
        poll.LimitedToStores = model.SelectedStoreIds.Any();
        await _pollService.UpdatePollAsync(poll);

        var existingStoreMappings = await _storeMappingService.GetStoreMappingsAsync(poll);
        foreach (var store in await _storeService.GetAllStoresAsync())
        {
            var existingStoreMapping = existingStoreMappings.FirstOrDefault(storeMapping => storeMapping.StoreId == store.Id);

            if (model.SelectedStoreIds.Contains(store.Id))
            {
                if (existingStoreMapping == null)
                    await _storeMappingService.InsertStoreMappingAsync(poll, store.Id);
            }
            else if (existingStoreMapping != null)
                await _storeMappingService.DeleteStoreMappingAsync(existingStoreMapping);
        }
    }

    #endregion

    #region Polls

    [HttpGet("list")]
    [CheckPermission(StandardPermission.ContentManagement.POLLS_VIEW)]
    public async Task<IActionResult> List()
    {
        var model = await _pollModelFactory.PreparePollSearchModelAsync(new PollSearchModel());
        return Ok(model);
    }

    [HttpPost("list")]
    [CheckPermission(StandardPermission.ContentManagement.POLLS_VIEW)]
    public async Task<IActionResult> List([FromBody] PollSearchModel searchModel)
    {
        var model = await _pollModelFactory.PreparePollListModelAsync(searchModel);
        return Ok(model);
    }

    [HttpGet("create")]
    [CheckPermission(StandardPermission.ContentManagement.POLLS_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Create()
    {
        var model = await _pollModelFactory.PreparePollModelAsync(new PollModel(), null);
        return Ok(model);
    }

    [HttpPost("create")]
    [CheckPermission(StandardPermission.ContentManagement.POLLS_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Create([FromBody] PollModel model, bool continueEditing = false)
    {
        if (ModelState.IsValid)
        {
            var poll = model.ToEntity<Poll>();
            await _pollService.InsertPollAsync(poll);
            await SaveStoreMappingsAsync(poll, model);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.ContentManagement.Polls.Added"));
            return Ok(new { RedirectUrl = continueEditing ? Url.Action("Edit", new { id = poll.Id }) : Url.Action("List") });
        }

        model = await _pollModelFactory.PreparePollModelAsync(model, null, true);
        return BadRequest(ModelState);
    }

    [HttpGet("edit/{id}")]
    [CheckPermission(StandardPermission.ContentManagement.POLLS_VIEW)]
    public async Task<IActionResult> Edit(int id)
    {
        var poll = await _pollService.GetPollByIdAsync(id);
        if (poll == null)
            return NotFound();

        var model = await _pollModelFactory.PreparePollModelAsync(null, poll);
        return Ok(model);
    }

    [HttpPost("edit/{id}")]
    [CheckPermission(StandardPermission.ContentManagement.POLLS_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Edit(int id, [FromBody] PollModel model, bool continueEditing = false)
    {
        var poll = await _pollService.GetPollByIdAsync(id);
        if (poll == null)
            return NotFound();

        if (ModelState.IsValid)
        {
            poll = model.ToEntity(poll);
            await _pollService.UpdatePollAsync(poll);
            await SaveStoreMappingsAsync(poll, model);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.ContentManagement.Polls.Updated"));
            return Ok(new { RedirectUrl = continueEditing ? Url.Action("Edit", new { id = poll.Id }) : Url.Action("List") });
        }

        model = await _pollModelFactory.PreparePollModelAsync(model, poll, true);
        return BadRequest(ModelState);
    }

    [HttpDelete("delete/{id}")]
    [CheckPermission(StandardPermission.ContentManagement.POLLS_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Delete(int id)
    {
        var poll = await _pollService.GetPollByIdAsync(id);
        if (poll == null)
            return NotFound();

        await _pollService.DeletePollAsync(poll);
        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.ContentManagement.Polls.Deleted"));

        return Ok();
    }

    #endregion

    #region Poll Answers

    [HttpPost("poll-answers")]
    [CheckPermission(StandardPermission.ContentManagement.POLLS_VIEW)]
    public async Task<IActionResult> PollAnswers([FromBody] PollAnswerSearchModel searchModel)
    {
        var poll = await _pollService.GetPollByIdAsync(searchModel.PollId);
        if (poll == null)
            return NotFound();

        var model = await _pollModelFactory.PreparePollAnswerListModelAsync(searchModel, poll);
        return Ok(model);
    }

    [HttpPost("poll-answer/update")]
    [CheckPermission(StandardPermission.ContentManagement.POLLS_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> PollAnswerUpdate([FromBody] PollAnswerModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pollAnswer = await _pollService.GetPollAnswerByIdAsync(model.Id);
        if (pollAnswer == null)
            return NotFound();

        pollAnswer = model.ToEntity(pollAnswer);
        await _pollService.UpdatePollAnswerAsync(pollAnswer);

        return Ok();
    }

    [HttpPost("poll-answer/add")]
    [CheckPermission(StandardPermission.ContentManagement.POLLS_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> PollAnswerAdd(int pollId, [FromBody] PollAnswerModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pollAnswer = model.ToEntity<PollAnswer>();
        pollAnswer.PollId = pollId;
        await _pollService.InsertPollAnswerAsync(pollAnswer);

        return Ok(new { Result = true });
    }

    [HttpDelete("poll-answer/delete/{id}")]
    [CheckPermission(StandardPermission.ContentManagement.POLLS_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> PollAnswerDelete(int id)
    {
        var pollAnswer = await _pollService.GetPollAnswerByIdAsync(id);
        if (pollAnswer == null)
            return NotFound();

        await _pollService.DeletePollAnswerAsync(pollAnswer);
        return Ok();
    }

    #endregion
}
