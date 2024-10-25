using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;

namespace Toss.Api.Components;

public partial class PrivateMessagesSentItemsViewComponent : NopViewComponent
{
    protected readonly IPrivateMessagesModelFactory _privateMessagesModelFactory;

    public PrivateMessagesSentItemsViewComponent(IPrivateMessagesModelFactory privateMessagesModelFactory)
    {
        _privateMessagesModelFactory = privateMessagesModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int pageNumber, string tab)
    {
        var model = await _privateMessagesModelFactory.PrepareSentModelAsync(pageNumber, tab);
        return View(model);
    }
}