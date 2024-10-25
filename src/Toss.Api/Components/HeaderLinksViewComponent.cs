using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;

namespace Toss.Api.Components;

public partial class HeaderLinksViewComponent : NopViewComponent
{
    protected readonly ICommonModelFactory _commonModelFactory;

    public HeaderLinksViewComponent(ICommonModelFactory commonModelFactory)
    {
        _commonModelFactory = commonModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _commonModelFactory.PrepareHeaderLinksModelAsync();
        return View(model);
    }
}