using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Reports;

/// <summary>
/// Represents a low stock product list model
/// </summary>
public partial record LowStockProductListModel : BasePagedListModel<LowStockProductModel>
{
}