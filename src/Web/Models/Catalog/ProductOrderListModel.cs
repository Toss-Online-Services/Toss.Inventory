using Web.Models.Orders;

namespace Web.Models.Catalog;

/// <summary>
/// Represents a product order list model
/// </summary>
public partial record ProductOrderListModel : BasePagedListModel<OrderModel>
{
}
