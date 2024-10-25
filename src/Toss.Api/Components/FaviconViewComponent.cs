using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;

namespace Toss.Api.Components;

public partial class FaviconViewComponent : NopViewComponent
{
    protected readonly ICommonModelFactory _commonModelFactory;

    public FaviconViewComponent(ICommonModelFactory commonModelFactory)
    {
        _commonModelFactory = commonModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _commonModelFactory.PrepareFaviconAndAppIconsModelAsync();
        if (string.IsNullOrEmpty(model.HeadCode))
            return Content("");
        return View(model);
    }
}