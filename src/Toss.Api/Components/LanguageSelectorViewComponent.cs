using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;

namespace Toss.Api.Components;

public partial class LanguageSelectorViewComponent : NopViewComponent
{
    protected readonly ICommonModelFactory _commonModelFactory;

    public LanguageSelectorViewComponent(ICommonModelFactory commonModelFactory)
    {
        _commonModelFactory = commonModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _commonModelFactory.PrepareLanguageSelectorModelAsync();

        if (model.AvailableLanguages.Count == 1)
            return Content("");

        return View(model);
    }
}