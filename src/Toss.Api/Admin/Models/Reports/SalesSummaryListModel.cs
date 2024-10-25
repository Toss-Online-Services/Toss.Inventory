using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Reports;

/// <summary>
/// Represents a sales summary list model
/// </summary>
public partial record SalesSummaryListModel : BasePagedListModel<SalesSummaryModel>
{
}