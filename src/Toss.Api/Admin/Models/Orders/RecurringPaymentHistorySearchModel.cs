using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Orders;

/// <summary>
/// Represents a recurring payment history search model
/// </summary>
public partial record RecurringPaymentHistorySearchModel : BaseSearchModel
{
    #region Properties

    public int RecurringPaymentId { get; set; }

    #endregion
}