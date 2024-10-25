using Nop.Web.Framework.Models;
using Toss.Api.Admin.Models.Orders;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a product order list model
/// </summary>
public partial record ProductOrderListModel : BasePagedListModel<OrderModel>
{
}