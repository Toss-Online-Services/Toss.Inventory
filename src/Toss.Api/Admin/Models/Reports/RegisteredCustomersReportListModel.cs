using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Reports;

/// <summary>
/// Represents a registered customers report list model
/// </summary>
public partial record RegisteredCustomersReportListModel : BasePagedListModel<RegisteredCustomersReportModel>
{
}