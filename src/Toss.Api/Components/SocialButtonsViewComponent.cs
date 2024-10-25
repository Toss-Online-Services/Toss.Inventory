using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;

namespace Toss.Api.Components;

public partial class SocialButtonsViewComponent : NopViewComponent
{
    protected readonly ICommonModelFactory _commonModelFactory;

    public SocialButtonsViewComponent(ICommonModelFactory commonModelFactory)
    {
        _commonModelFactory = commonModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _commonModelFactory.PrepareSocialModelAsync();
        return View(model);
    }
}