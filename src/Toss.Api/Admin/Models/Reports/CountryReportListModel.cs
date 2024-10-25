using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Reports;

/// <summary>
/// Represents a country report list model
/// </summary>
public partial record CountryReportListModel : BasePagedListModel<CountryReportModel>
{
}