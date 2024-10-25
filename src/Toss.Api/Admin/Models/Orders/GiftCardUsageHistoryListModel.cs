using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Orders;

/// <summary>
/// Represents a gift card usage history list model
/// </summary>
public partial record GiftCardUsageHistoryListModel : BasePagedListModel<GiftCardUsageHistoryModel>
{
}