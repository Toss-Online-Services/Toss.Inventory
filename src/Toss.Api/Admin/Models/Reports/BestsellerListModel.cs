using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Reports;

/// <summary>
/// Represents a bestseller list model
/// </summary>
public partial record BestsellerListModel : BasePagedListModel<BestsellerModel>
{
}