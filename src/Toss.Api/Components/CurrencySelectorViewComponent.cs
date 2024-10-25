using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;

namespace Toss.Api.Components;

public partial class CurrencySelectorViewComponent : NopViewComponent
{
    protected readonly ICommonModelFactory _commonModelFactory;

    public CurrencySelectorViewComponent(ICommonModelFactory commonModelFactory)
    {
        _commonModelFactory = commonModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _commonModelFactory.PrepareCurrencySelectorModelAsync();
        if (model.AvailableCurrencies.Count == 1)
            return Content("");

        return View(model);
    }
}