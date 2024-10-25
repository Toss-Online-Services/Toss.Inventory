using Nop.Web.Framework.Models;

namespace Toss.Api.Models.Checkout;

public partial record CheckoutProgressModel : BaseNopModel
{
    public CheckoutProgressStep CheckoutProgressStep { get; set; }
}

public enum CheckoutProgressStep
{
    Cart,
    Address,
    Shipping,
    Payment,
    Confirm,
    Complete
}