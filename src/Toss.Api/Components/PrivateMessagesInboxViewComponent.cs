using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;

namespace Toss.Api.Components;

public partial class PrivateMessagesInboxViewComponent : NopViewComponent
{
    protected readonly IPrivateMessagesModelFactory _privateMessagesModelFactory;

    public PrivateMessagesInboxViewComponent(IPrivateMessagesModelFactory privateMessagesModelFactory)
    {
        _privateMessagesModelFactory = privateMessagesModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int pageNumber, string tab)
    {
        var model = await _privateMessagesModelFactory.PrepareInboxModelAsync(pageNumber, tab);
        return View(model);
    }
}