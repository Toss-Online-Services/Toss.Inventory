//using Microsoft.AspNetCore.Mvc;
//using Nop.Core;
//using Nop.Core.Domain.Blogs;
//using Nop.Core.Domain.Localization;
//using Nop.Core.Events;
//using Nop.Core.Rss;
//using Nop.Services.Blogs;
//using Nop.Services.Customers;
//using Nop.Services.Localization;
//using Nop.Services.Logging;
//using Nop.Services.Messages;
//using Nop.Services.Security;
//using Nop.Services.Seo;
//using Nop.Services.Stores;
//using Toss.Api.Factories;
//using Toss.Api.Models.Blogs;

//namespace Toss.Api.Controllers
//{
//    [Route("api/blog")]
//    [ApiController]
//    public class BlogController : ControllerBase
//    {
//        #region Fields

//        private readonly BlogSettings _blogSettings;
//        private readonly IBlogModelFactory _blogModelFactory;
//        private readonly IBlogService _blogService;
//        private readonly ICustomerActivityService _customerActivityService;
//        private readonly ICustomerService _customerService;
//        private readonly IEventPublisher _eventPublisher;
//        private readonly ILocalizationService _localizationService;
//        private readonly IPermissionService _permissionService;
//        private readonly IStoreContext _storeContext;
//        private readonly IStoreMappingService _storeMappingService;
//        private readonly IUrlRecordService _urlRecordService;
//        private readonly IWorkContext _workContext;
//        private readonly IWorkflowMessageService _workflowMessageService;
//        private readonly LocalizationSettings _localizationSettings;

//        #endregion

//        #region Ctor

//        public BlogController(
//            BlogSettings blogSettings,
//            IBlogModelFactory blogModelFactory,
//            IBlogService blogService,
//            ICustomerActivityService customerActivityService,
//            ICustomerService customerService,
//            IEventPublisher eventPublisher,
//            ILocalizationService localizationService,
//            IPermissionService permissionService,
//            IStoreContext storeContext,
//            IStoreMappingService storeMappingService,
//            IUrlRecordService urlRecordService,
//            IWorkContext workContext,
//            IWorkflowMessageService workflowMessageService,
//            LocalizationSettings localizationSettings)
//        {
//            _blogSettings = blogSettings;
//            _blogModelFactory = blogModelFactory;
//            _blogService = blogService;
//            _customerActivityService = customerActivityService;
//            _customerService = customerService;
//            _eventPublisher = eventPublisher;
//            _localizationService = localizationService;
//            _permissionService = permissionService;
//            _storeContext = storeContext;
//            _storeMappingService = storeMappingService;
//            _urlRecordService = urlRecordService;
//            _workContext = workContext;
//            _workflowMessageService = workflowMessageService;
//            _localizationSettings = localizationSettings;
//        }

//        #endregion

//        #region API Endpoints

//        [HttpGet("list")]
//        public async Task<IActionResult> List([FromQuery] BlogPagingFilteringModel command)
//        {
//            if (!_blogSettings.Enabled)
//                return NotFound("Blog is not enabled");

//            var model = await _blogModelFactory.PrepareBlogPostListModelAsync(command);
//            return Ok(model);
//        }

//        [HttpGet("tag")]
//        public async Task<IActionResult> BlogByTag([FromQuery] BlogPagingFilteringModel command)
//        {
//            if (!_blogSettings.Enabled)
//                return NotFound("Blog is not enabled");

//            var model = await _blogModelFactory.PrepareBlogPostListModelAsync(command);
//            return Ok(model);
//        }

//        [HttpGet("month")]
//        public async Task<IActionResult> BlogByMonth([FromQuery] BlogPagingFilteringModel command)
//        {
//            if (!_blogSettings.Enabled)
//                return NotFound("Blog is not enabled");

//            var model = await _blogModelFactory.PrepareBlogPostListModelAsync(command);
//            return Ok(model);
//        }

//        [HttpGet("rss/{languageId:int}")]
//        public async Task<IActionResult> ListRss(int languageId)
//        {
//            var store = await _storeContext.GetCurrentStoreAsync();
//            var feed = new RssFeed(
//                $"{await _localizationService.GetLocalizedAsync(store, x => x.Name)}: Blog",
//                "Blog",
//                new Uri(Request.Scheme + "://" + Request.Host),
//                DateTime.UtcNow);

//            if (!_blogSettings.Enabled)
//                return Ok(feed);

//            var items = new List<RssItem>();
//            var blogPosts = await _blogService.GetAllBlogPostsAsync(store.Id, languageId);
//            foreach (var blogPost in blogPosts)
//            {
//                var seName = await _urlRecordService.GetSeNameAsync(blogPost, blogPost.LanguageId);
//                var blogPostUrl = Url.Action("GetBlogPost", "Blog", new { seName }, Request.Scheme);
//                items.Add(new RssItem(blogPost.Title, blogPost.Body, new Uri(blogPostUrl), $"urn:store:{store.Id}:blog:post:{blogPost.Id}", blogPost.CreatedOnUtc));
//            }
//            feed.Items = items;
//            return Ok(feed);
//        }

//        [HttpGet("post/{blogPostId:int}")]
//        public async Task<IActionResult> BlogPost(int blogPostId)
//        {
//            if (!_blogSettings.Enabled)
//                return NotFound("Blog is not enabled");

//            var blogPost = await _blogService.GetBlogPostByIdAsync(blogPostId);
//            if (blogPost == null)
//                return NotFound("Blog post not found");

//            var notAvailable =
//                !_blogService.BlogPostIsAvailable(blogPost) ||
//                !await _storeMappingService.AuthorizeAsync(blogPost);

//            var hasAdminAccess = await _permissionService.AuthorizeAsync(StandardPermission.Security.ACCESS_ADMIN_PANEL) &&
//                                 await _permissionService.AuthorizeAsync(StandardPermission.ContentManagement.BLOG_VIEW);
//            if (notAvailable && !hasAdminAccess)
//                return Forbid();

//            var model = new BlogPostModel();
//            await _blogModelFactory.PrepareBlogPostModelAsync(model, blogPost, true);

//            return Ok(model);
//        }

//        [HttpPost("comment/add/{blogPostId:int}")]
//        public async Task<IActionResult> BlogCommentAdd(int blogPostId, [FromBody] BlogPostModel model)
//        {
//            if (!_blogSettings.Enabled)
//                return NotFound("Blog is not enabled");

//            var blogPost = await _blogService.GetBlogPostByIdAsync(blogPostId);
//            if (blogPost == null || !blogPost.AllowComments)
//                return NotFound("Blog post not found or comments not allowed");

//            var customer = await _workContext.GetCurrentCustomerAsync();
//            if (await _customerService.IsGuestAsync(customer) && !_blogSettings.AllowNotRegisteredUsersToLeaveComments)
//                return Unauthorized(await _localizationService.GetResourceAsync("Blog.Comments.OnlyRegisteredUsersLeaveComments"));

//            if (ModelState.IsValid)
//            {
//                var store = await _storeContext.GetCurrentStoreAsync();
//                var comment = new BlogComment
//                {
//                    BlogPostId = blogPost.Id,
//                    CustomerId = customer.Id,
//                    CommentText = model.AddNewComment.CommentText,
//                    IsApproved = !_blogSettings.BlogCommentsMustBeApproved,
//                    StoreId = store.Id,
//                    CreatedOnUtc = DateTime.UtcNow,
//                };

//                await _blogService.InsertBlogCommentAsync(comment);

//                if (_blogSettings.NotifyAboutNewBlogComments)
//                    await _workflowMessageService.SendBlogCommentStoreOwnerNotificationMessageAsync(comment, _localizationSettings.DefaultAdminLanguageId);

//                await _customerActivityService.InsertActivityAsync("PublicStore.AddBlogComment",
//                    await _localizationService.GetResourceAsync("ActivityLog.PublicStore.AddBlogComment"), comment);

//                if (comment.IsApproved)
//                    await _eventPublisher.PublishAsync(new BlogCommentApprovedEvent(comment));

//                var resultMessage = comment.IsApproved
//                    ? await _localizationService.GetResourceAsync("Blog.Comments.SuccessfullyAdded")
//                    : await _localizationService.GetResourceAsync("Blog.Comments.SeeAfterApproving");

//                return Ok(resultMessage);
//            }

//            return BadRequest(ModelState);
//        }

//        #endregion
//    }
//}
