using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;

namespace Toss.Api.Components;

public partial class ForumActiveDiscussionsSmallViewComponent : NopViewComponent
{
    protected readonly IForumModelFactory _forumModelFactory;

    public ForumActiveDiscussionsSmallViewComponent(IForumModelFactory forumModelFactory)
    {
        _forumModelFactory = forumModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _forumModelFactory.PrepareActiveDiscussionsModelAsync();
        if (!model.ForumTopics.Any())
            return Content("");

        return View(model);
    }
}