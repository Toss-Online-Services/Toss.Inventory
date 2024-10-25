using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.News;
using Nop.Web.Framework.Components;

namespace Toss.Api.Components;

public partial class NewsRssHeaderLinkViewComponent : NopViewComponent
{
    protected readonly NewsSettings _newsSettings;

    public NewsRssHeaderLinkViewComponent(NewsSettings newsSettings)
    {
        _newsSettings = newsSettings;
    }

    public IViewComponentResult Invoke(int currentCategoryId, int currentProductId)
    {
        if (!_newsSettings.Enabled || !_newsSettings.ShowHeaderRssUrl)
            return Content("");

        return View();
    }
}