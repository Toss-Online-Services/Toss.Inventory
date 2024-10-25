using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Reports;

/// <summary>
/// Represents a never sold products report list model
/// </summary>
public partial record NeverSoldReportListModel : BasePagedListModel<NeverSoldReportModel>
{
}