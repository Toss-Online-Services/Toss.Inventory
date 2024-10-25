using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Orders;

/// <summary>
/// Represents a recurring payment history list model
/// </summary>
public partial record RecurringPaymentHistoryListModel : BasePagedListModel<RecurringPaymentHistoryModel>
{
}