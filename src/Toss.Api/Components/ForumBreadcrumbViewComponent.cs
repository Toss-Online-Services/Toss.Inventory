using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;

namespace Toss.Api.Components;

public partial class ForumBreadcrumbViewComponent : NopViewComponent
{
    protected readonly IForumModelFactory _forumModelFactory;

    public ForumBreadcrumbViewComponent(IForumModelFactory forumModelFactory)
    {
        _forumModelFactory = forumModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int? forumGroupId, int? forumId, int? forumTopicId)
    {
        var model = await _forumModelFactory.PrepareForumBreadcrumbModelAsync(forumGroupId, forumId, forumTopicId);
        return View(model);
    }
}