using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Forums;
using Nop.Services.Forums;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Forums;

namespace Nop.Web.Areas.Admin.Controllers;

[ApiController]
[Route("api/admin/[controller]")]
public class ForumController : ControllerBase
{
    #region Fields

    protected readonly IForumModelFactory _forumModelFactory;
    protected readonly IForumService _forumService;
    protected readonly ILocalizationService _localizationService;
    protected readonly INotificationService _notificationService;
    protected readonly IPermissionService _permissionService;

    #endregion

    #region Ctor

    public ForumController(IForumModelFactory forumModelFactory,
        IForumService forumService,
        ILocalizationService localizationService,
        INotificationService notificationService,
        IPermissionService permissionService)
    {
        _forumModelFactory = forumModelFactory;
        _forumService = forumService;
        _localizationService = localizationService;
        _notificationService = notificationService;
        _permissionService = permissionService;
    }

    #endregion

    #region Methods

    #region List

    [HttpGet("list")]
    [CheckPermission(StandardPermission.ContentManagement.FORUMS_VIEW)]
    public virtual async Task<IActionResult> GetForumGroups()
    {
        var model = await _forumModelFactory.PrepareForumGroupSearchModelAsync(new ForumGroupSearchModel());
        return Ok(model);
    }

    [HttpPost("forumgroups")]
    [CheckPermission(StandardPermission.ContentManagement.FORUMS_VIEW)]
    public virtual async Task<IActionResult> GetForumGroupList([FromBody] ForumGroupSearchModel searchModel)
    {
        var model = await _forumModelFactory.PrepareForumGroupListModelAsync(searchModel);
        return Ok(model);
    }

    [HttpPost("forums")]
    [CheckPermission(StandardPermission.ContentManagement.FORUMS_VIEW)]
    public virtual async Task<IActionResult> GetForumList([FromBody] ForumSearchModel searchModel)
    {
        var forumGroup = await _forumService.GetForumGroupByIdAsync(searchModel.ForumGroupId)
                         ?? throw new ArgumentException("No forum group found with the specified ID");

        var model = await _forumModelFactory.PrepareForumListModelAsync(searchModel, forumGroup);
        return Ok(model);
    }

    #endregion

    #region Create

    [HttpPost("forumgroups/create")]
    [CheckPermission(StandardPermission.ContentManagement.FORUMS_CREATE_EDIT_DELETE)]
    public virtual async Task<IActionResult> CreateForumGroup([FromBody] ForumGroupModel model)
    {
        if (ModelState.IsValid)
        {
            var forumGroup = model.ToEntity<ForumGroup>();
            forumGroup.CreatedOnUtc = DateTime.UtcNow;
            forumGroup.UpdatedOnUtc = DateTime.UtcNow;
            await _forumService.InsertForumGroupAsync(forumGroup);

            return Ok(new { success = true, message = await _localizationService.GetResourceAsync("Admin.ContentManagement.Forums.ForumGroup.Added") });
        }

        return BadRequest(ModelState);
    }

    [HttpPost("forums/create")]
    [CheckPermission(StandardPermission.ContentManagement.FORUMS_CREATE_EDIT_DELETE)]
    public virtual async Task<IActionResult> CreateForum([FromBody] ForumModel model)
    {
        if (ModelState.IsValid)
        {
            var forum = model.ToEntity<Forum>();
            forum.CreatedOnUtc = DateTime.UtcNow;
            forum.UpdatedOnUtc = DateTime.UtcNow;
            await _forumService.InsertForumAsync(forum);

            return Ok(new { success = true, message = await _localizationService.GetResourceAsync("Admin.ContentManagement.Forums.Forum.Added") });
        }

        return BadRequest(ModelState);
    }

    #endregion

    #region Edit

    [HttpGet("forumgroups/{id}")]
    [CheckPermission(StandardPermission.ContentManagement.FORUMS_VIEW)]
    public virtual async Task<IActionResult> GetForumGroupById(int id)
    {
        var forumGroup = await _forumService.GetForumGroupByIdAsync(id);
        if (forumGroup == null)
            return NotFound();

        var model = await _forumModelFactory.PrepareForumGroupModelAsync(null, forumGroup);
        return Ok(model);
    }

    [HttpPut("forumgroups/{id}")]
    [CheckPermission(StandardPermission.ContentManagement.FORUMS_CREATE_EDIT_DELETE)]
    public virtual async Task<IActionResult> UpdateForumGroup(int id, [FromBody] ForumGroupModel model)
    {
        var forumGroup = await _forumService.GetForumGroupByIdAsync(id);
        if (forumGroup == null)
            return NotFound();

        if (ModelState.IsValid)
        {
            forumGroup = model.ToEntity(forumGroup);
            forumGroup.UpdatedOnUtc = DateTime.UtcNow;
            await _forumService.UpdateForumGroupAsync(forumGroup);

            return Ok(new { success = true, message = await _localizationService.GetResourceAsync("Admin.ContentManagement.Forums.ForumGroup.Updated") });
        }

        return BadRequest(ModelState);
    }

    [HttpGet("forums/{id}")]
    [CheckPermission(StandardPermission.ContentManagement.FORUMS_VIEW)]
    public virtual async Task<IActionResult> GetForumById(int id)
    {
        var forum = await _forumService.GetForumByIdAsync(id);
        if (forum == null)
            return NotFound();

        var model = await _forumModelFactory.PrepareForumModelAsync(null, forum);
        return Ok(model);
    }

    [HttpPut("forums/{id}")]
    [CheckPermission(StandardPermission.ContentManagement.FORUMS_CREATE_EDIT_DELETE)]
    public virtual async Task<IActionResult> UpdateForum(int id, [FromBody] ForumModel model)
    {
        var forum = await _forumService.GetForumByIdAsync(id);
        if (forum == null)
            return NotFound();

        if (ModelState.IsValid)
        {
            forum = model.ToEntity(forum);
            forum.UpdatedOnUtc = DateTime.UtcNow;
            await _forumService.UpdateForumAsync(forum);

            return Ok(new { success = true, message = await _localizationService.GetResourceAsync("Admin.ContentManagement.Forums.Forum.Updated") });
        }

        return BadRequest(ModelState);
    }

    #endregion

    #region Delete

    [HttpDelete("forumgroups/{id}")]
    [CheckPermission(StandardPermission.ContentManagement.FORUMS_CREATE_EDIT_DELETE)]
    public virtual async Task<IActionResult> DeleteForumGroup(int id)
    {
        var forumGroup = await _forumService.GetForumGroupByIdAsync(id);
        if (forumGroup == null)
            return NotFound();

        await _forumService.DeleteForumGroupAsync(forumGroup);

        return Ok(new { success = true, message = await _localizationService.GetResourceAsync("Admin.ContentManagement.Forums.ForumGroup.Deleted") });
    }

    [HttpDelete("forums/{id}")]
    [CheckPermission(StandardPermission.ContentManagement.FORUMS_CREATE_EDIT_DELETE)]
    public virtual async Task<IActionResult> DeleteForum(int id)
    {
        var forum = await _forumService.GetForumByIdAsync(id);
        if (forum == null)
            return NotFound();

        await _forumService.DeleteForumAsync(forum);

        return Ok(new { success = true, message = await _localizationService.GetResourceAsync("Admin.ContentManagement.Forums.Forum.Deleted") });
    }

    #endregion

    #endregion
}
