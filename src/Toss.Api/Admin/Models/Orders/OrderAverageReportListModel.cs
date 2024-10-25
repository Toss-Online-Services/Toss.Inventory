using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Orders;

/// <summary>
/// Represents an an order average report line summary list model
/// </summary>
public partial record OrderAverageReportListModel : BasePagedListModel<OrderAverageReportModel>
{
}