using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Blogs;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;

namespace Toss.Api.Components;

public partial class BlogMonthsViewComponent : NopViewComponent
{
    protected readonly BlogSettings _blogSettings;
    protected readonly IBlogModelFactory _blogModelFactory;

    public BlogMonthsViewComponent(BlogSettings blogSettings, IBlogModelFactory blogModelFactory)
    {
        _blogSettings = blogSettings;
        _blogModelFactory = blogModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int currentCategoryId, int currentProductId)
    {
        if (!_blogSettings.Enabled)
            return Content("");

        var model = await _blogModelFactory.PrepareBlogPostYearModelAsync();
        return View(model);
    }
}