using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;

namespace Toss.Api.Components;

public partial class StoreThemeSelectorViewComponent : NopViewComponent
{
    protected readonly ICommonModelFactory _commonModelFactory;
    protected readonly StoreInformationSettings _storeInformationSettings;

    public StoreThemeSelectorViewComponent(ICommonModelFactory commonModelFactory,
        StoreInformationSettings storeInformationSettings)
    {
        _commonModelFactory = commonModelFactory;
        _storeInformationSettings = storeInformationSettings;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        if (!_storeInformationSettings.AllowCustomerToSelectTheme)
            return Content("");

        var model = await _commonModelFactory.PrepareStoreThemeSelectorModelAsync();
        return View(model);
    }
}