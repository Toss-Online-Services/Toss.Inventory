using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;

namespace Toss.Api.Components;

public partial class HomepagePollsViewComponent : NopViewComponent
{
    protected readonly IPollModelFactory _pollModelFactory;

    public HomepagePollsViewComponent(IPollModelFactory pollModelFactory)
    {
        _pollModelFactory = pollModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _pollModelFactory.PrepareHomepagePollModelsAsync();
        if (!model.Any())
            return Content("");

        return View(model);
    }
}