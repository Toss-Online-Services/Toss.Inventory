using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;

namespace Toss.Api.Components;

public partial class CategoryNavigationViewComponent : NopViewComponent
{
    protected readonly ICatalogModelFactory _catalogModelFactory;

    public CategoryNavigationViewComponent(ICatalogModelFactory catalogModelFactory)
    {
        _catalogModelFactory = catalogModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int currentCategoryId, int currentProductId)
    {
        var model = await _catalogModelFactory.PrepareCategoryNavigationModelAsync(currentCategoryId, currentProductId);
        return View(model);
    }
}