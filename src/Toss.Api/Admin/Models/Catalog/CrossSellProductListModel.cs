using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a cross-sell product list model
/// </summary>
public partial record CrossSellProductListModel : BasePagedListModel<CrossSellProductModel>
{
}