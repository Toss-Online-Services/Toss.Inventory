using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Blogs;
using Nop.Core.Events;
using Nop.Services.Blogs;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Services.Stores;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Blogs;

namespace Toss.Api.Admin.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    #region Fields

    private readonly IBlogModelFactory _blogModelFactory;
    private readonly IBlogService _blogService;
    private readonly ICustomerActivityService _customerActivityService;
    private readonly IEventPublisher _eventPublisher;
    private readonly ILocalizationService _localizationService;
    private readonly INotificationService _notificationService;
    private readonly IPermissionService _permissionService;
    private readonly IStoreMappingService _storeMappingService;
    private readonly IStoreService _storeService;
    private readonly IUrlRecordService _urlRecordService;

    #endregion

    #region Ctor

    public BlogController(
        IBlogModelFactory blogModelFactory,
        IBlogService blogService,
        ICustomerActivityService customerActivityService,
        IEventPublisher eventPublisher,
        ILocalizationService localizationService,
        INotificationService notificationService,
        IPermissionService permissionService,
        IStoreMappingService storeMappingService,
        IStoreService storeService,
        IUrlRecordService urlRecordService)
    {
        _blogModelFactory = blogModelFactory;
        _blogService = blogService;
        _customerActivityService = customerActivityService;
        _eventPublisher = eventPublisher;
        _localizationService = localizationService;
        _notificationService = notificationService;
        _permissionService = permissionService;
        _storeMappingService = storeMappingService;
        _storeService = storeService;
        _urlRecordService = urlRecordService;
    }

    #endregion

    #region Methods        

    [HttpGet("BlogPosts")]
    [CheckPermission(StandardPermission.ContentManagement.BLOG_VIEW)]
    public async Task<IActionResult> GetBlogPosts(int? filterByBlogPostId)
    {
        var model = await _blogModelFactory.PrepareBlogContentModelAsync(new BlogContentModel(), filterByBlogPostId);
        return Ok(model);
    }

    [HttpPost("List")]
    [CheckPermission(StandardPermission.ContentManagement.BLOG_VIEW)]
    public async Task<IActionResult> List([FromBody] BlogPostSearchModel searchModel)
    {
        var model = await _blogModelFactory.PrepareBlogPostListModelAsync(searchModel);
        return Ok(model);
    }

    [HttpPost("Create")]
    [CheckPermission(StandardPermission.ContentManagement.BLOG_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Create([FromBody] BlogPostModel model, bool continueEditing)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var blogPost = model.ToEntity<BlogPost>();
        blogPost.CreatedOnUtc = DateTime.UtcNow;
        await _blogService.InsertBlogPostAsync(blogPost);

        await _customerActivityService.InsertActivityAsync("AddNewBlogPost",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewBlogPost"), blogPost.Id), blogPost);

        var seName = await _urlRecordService.ValidateSeNameAsync(blogPost, model.SeName, model.Title, true);
        await _urlRecordService.SaveSlugAsync(blogPost, seName, blogPost.LanguageId);

        await SaveStoreMappingsAsync(blogPost, model);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.ContentManagement.Blog.BlogPosts.Added"));

        return NoContent();
    }

    [HttpGet("Edit/{id}")]
    [CheckPermission(StandardPermission.ContentManagement.BLOG_VIEW)]
    public async Task<IActionResult> Edit(int id)
    {
        var blogPost = await _blogService.GetBlogPostByIdAsync(id);
        if (blogPost == null)
            return NotFound();

        var model = await _blogModelFactory.PrepareBlogPostModelAsync(null, blogPost);
        return Ok(model);
    }

    [HttpPost("Edit")]
    [CheckPermission(StandardPermission.ContentManagement.BLOG_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Edit([FromBody] BlogPostModel model, bool continueEditing)
    {
        var blogPost = await _blogService.GetBlogPostByIdAsync(model.Id);
        if (blogPost == null)
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        blogPost = model.ToEntity(blogPost);
        await _blogService.UpdateBlogPostAsync(blogPost);

        await _customerActivityService.InsertActivityAsync("EditBlogPost",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditBlogPost"), blogPost.Id), blogPost);

        var seName = await _urlRecordService.ValidateSeNameAsync(blogPost, model.SeName, model.Title, true);
        await _urlRecordService.SaveSlugAsync(blogPost, seName, blogPost.LanguageId);

        await SaveStoreMappingsAsync(blogPost, model);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.ContentManagement.Blog.BlogPosts.Updated"));

        return NoContent();
    }

    [HttpDelete("{id}")]
    [CheckPermission(StandardPermission.ContentManagement.BLOG_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> Delete(int id)
    {
        var blogPost = await _blogService.GetBlogPostByIdAsync(id);
        if (blogPost == null)
            return NotFound();

        await _blogService.DeleteBlogPostAsync(blogPost);
        await _customerActivityService.InsertActivityAsync("DeleteBlogPost",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteBlogPost"), blogPost.Id), blogPost);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.ContentManagement.Blog.BlogPosts.Deleted"));

        return NoContent();
    }

    #region Comments

    [HttpGet("Comments")]
    [CheckPermission(StandardPermission.ContentManagement.BLOG_COMMENTS_VIEW)]
    public async Task<IActionResult> GetBlogComments(int? filterByBlogPostId)
    {
        var blogPost = await _blogService.GetBlogPostByIdAsync(filterByBlogPostId ?? 0);
        if (blogPost == null && filterByBlogPostId.HasValue)
            return NotFound();

        var model = await _blogModelFactory.PrepareBlogCommentSearchModelAsync(new BlogCommentSearchModel(), blogPost);
        return Ok(model);
    }

    [HttpPost("Comments/List")]
    [CheckPermission(StandardPermission.ContentManagement.BLOG_COMMENTS_VIEW)]
    public async Task<IActionResult> GetComments([FromBody] BlogCommentSearchModel searchModel)
    {
        var model = await _blogModelFactory.PrepareBlogCommentListModelAsync(searchModel, searchModel.BlogPostId);
        return Ok(model);
    }

    [HttpPut("Comments/Update")]
    [CheckPermission(StandardPermission.ContentManagement.BLOG_COMMENTS_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> UpdateComment([FromBody] BlogCommentModel model)
    {
        var comment = await _blogService.GetBlogCommentByIdAsync(model.Id);
        if (comment == null)
            return NotFound();

        var previousIsApproved = comment.IsApproved;
        comment = model.ToEntity(comment);
        await _blogService.UpdateBlogCommentAsync(comment);

        if (!previousIsApproved && comment.IsApproved)
            await _eventPublisher.PublishAsync(new BlogCommentApprovedEvent(comment));

        await _customerActivityService.InsertActivityAsync("EditBlogComment",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditBlogComment"), comment.Id), comment);

        return NoContent();
    }

    [HttpDelete("Comments/{id}")]
    [CheckPermission(StandardPermission.ContentManagement.BLOG_COMMENTS_CREATE_EDIT_DELETE)]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var comment = await _blogService.GetBlogCommentByIdAsync(id);
        if (comment == null)
            return NotFound();

        await _blogService.DeleteBlogCommentAsync(comment);
        await _customerActivityService.InsertActivityAsync("DeleteBlogPostComment",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteBlogPostComment"), comment.Id), comment);

        return NoContent();
    }

    #endregion

    #endregion

    #region Utilities

    private async Task SaveStoreMappingsAsync(BlogPost blogPost, BlogPostModel model)
    {
        blogPost.LimitedToStores = model.SelectedStoreIds.Any();
        await _blogService.UpdateBlogPostAsync(blogPost);

        var existingStoreMappings = await _storeMappingService.GetStoreMappingsAsync(blogPost);
        var allStores = await _storeService.GetAllStoresAsync();
        foreach (var store in allStores)
        {
            if (model.SelectedStoreIds.Contains(store.Id))
            {
                if (!existingStoreMappings.Any(sm => sm.StoreId == store.Id))
                    await _storeMappingService.InsertStoreMappingAsync(blogPost, store.Id);
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
}
