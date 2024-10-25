using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;

namespace Toss.Api.Components;

public partial class TopicBlockViewComponent : NopViewComponent
{
    protected readonly ITopicModelFactory _topicModelFactory;

    public TopicBlockViewComponent(ITopicModelFactory topicModelFactory)
    {
        _topicModelFactory = topicModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(string systemName)
    {
        var model = await _topicModelFactory.PrepareTopicModelBySystemNameAsync(systemName);
        if (model == null)
            return Content("");
        return View(model);
    }
}