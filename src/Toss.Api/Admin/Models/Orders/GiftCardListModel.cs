using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Orders;

/// <summary>
/// Represents a gift card list model
/// </summary>
public partial record GiftCardListModel : BasePagedListModel<GiftCardModel>
{
}