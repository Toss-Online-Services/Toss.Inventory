using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Orders;

/// <summary>
/// Represents an incomplete order report list model
/// </summary>
public partial record OrderIncompleteReportListModel : BasePagedListModel<OrderIncompleteReportModel>
{
}