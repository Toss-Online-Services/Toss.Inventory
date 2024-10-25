using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a stock quantity history list model
/// </summary>
public partial record StockQuantityHistoryListModel : BasePagedListModel<StockQuantityHistoryModel>
{
}