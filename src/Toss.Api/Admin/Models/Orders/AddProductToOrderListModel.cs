using Nop.Web.Framework.Models;
using Toss.Api.Admin.Models.Catalog;

namespace Toss.Api.Admin.Models.Orders;

/// <summary>
/// Represents a product list model to add to the order
/// </summary>
public partial record AddProductToOrderListModel : BasePagedListModel<ProductModel>
{
}