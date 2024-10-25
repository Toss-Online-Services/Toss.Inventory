using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;
using Toss.Api.Models.Checkout;

namespace Toss.Api.Components;

public partial class CheckoutProgressViewComponent : NopViewComponent
{
    protected readonly ICheckoutModelFactory _checkoutModelFactory;

    public CheckoutProgressViewComponent(ICheckoutModelFactory checkoutModelFactory)
    {
        _checkoutModelFactory = checkoutModelFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(CheckoutProgressStep step)
    {
        var model = await _checkoutModelFactory.PrepareCheckoutProgressModelAsync(step);
        return View(model);
    }
}
