using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;

namespace Toss.Api.Components;

public partial class CustomerNavigationViewComponent : NopViewComponent
{
    protected readonly ICustomerModelFactory _customerModelFactory;

    public CustomerNavigationViewComponent(ICustomerModelFactory customerModelFactory)
    {
        _customerModelFactory = customerModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int selectedTabId = 0)
    {
        var model = await _customerModelFactory.PrepareCustomerNavigationModelAsync(selectedTabId);
        return View(model);
    }
}