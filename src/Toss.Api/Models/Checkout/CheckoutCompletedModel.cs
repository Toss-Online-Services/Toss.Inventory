using Nop.Web.Framework.Models;

namespace Toss.Api.Models.Checkout;

public partial record CheckoutCompletedModel : BaseNopModel
{
    public int OrderId { get; set; }
    public string CustomOrderNumber { get; set; }
    public bool OnePageCheckoutEnabled { get; set; }
}