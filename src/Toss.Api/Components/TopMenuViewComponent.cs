using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;

namespace Toss.Api.Components;

public partial class TopMenuViewComponent : NopViewComponent
{
    protected readonly ICatalogModelFactory _catalogModelFactory;

    public TopMenuViewComponent(ICatalogModelFactory catalogModelFactory)
    {
        _catalogModelFactory = catalogModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int? productThumbPictureSize)
    {
        var model = await _catalogModelFactory.PrepareTopMenuModelAsync();
        return View(model);
    }
}