using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a cross-sell product list model to add to the product
/// </summary>
public partial record AddCrossSellProductListModel : BasePagedListModel<ProductModel>
{
}