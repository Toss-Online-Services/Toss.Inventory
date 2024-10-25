using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;

namespace Toss.Api.Components;

public partial class SearchBoxViewComponent : NopViewComponent
{
    protected readonly ICatalogModelFactory _catalogModelFactory;

    public SearchBoxViewComponent(ICatalogModelFactory catalogModelFactory)
    {
        _catalogModelFactory = catalogModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _catalogModelFactory.PrepareSearchBoxModelAsync();
        return View(model);
    }
}