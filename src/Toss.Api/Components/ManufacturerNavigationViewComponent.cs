using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Catalog;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;

namespace Toss.Api.Components;

public partial class ManufacturerNavigationViewComponent : NopViewComponent
{
    protected readonly CatalogSettings _catalogSettings;
    protected readonly ICatalogModelFactory _catalogModelFactory;

    public ManufacturerNavigationViewComponent(CatalogSettings catalogSettings, ICatalogModelFactory catalogModelFactory)
    {
        _catalogSettings = catalogSettings;
        _catalogModelFactory = catalogModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int currentManufacturerId)
    {
        if (_catalogSettings.ManufacturersBlockItemsToDisplay == 0)
            return Content("");

        var model = await _catalogModelFactory.PrepareManufacturerNavigationModelAsync(currentManufacturerId);
        if (!model.Manufacturers.Any())
            return Content("");

        return View(model);
    }
}