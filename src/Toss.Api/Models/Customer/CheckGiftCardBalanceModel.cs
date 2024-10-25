using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Models.Customer;

public partial record CheckGiftCardBalanceModel : BaseNopModel
{
    public string Result { get; set; }

    public string Message { get; set; }

    [NopResourceDisplayName("ShoppingCart.GiftCardCouponCode.Tooltip")]
    public string GiftCardCode { get; set; }
}