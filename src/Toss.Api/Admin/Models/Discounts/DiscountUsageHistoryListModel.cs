using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Discounts;

/// <summary>
/// Represents a discount usage history list model
/// </summary>
public partial record DiscountUsageHistoryListModel : BasePagedListModel<DiscountUsageHistoryModel>
{
}