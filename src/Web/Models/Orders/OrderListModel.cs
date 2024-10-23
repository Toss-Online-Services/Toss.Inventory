namespace Web.Models.Orders;

/// <summary>
/// Represents an order list model
/// </summary>
public partial record OrderListModel : BasePagedListModel<OrderModel>
{
}