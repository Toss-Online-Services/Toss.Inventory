namespace Web.Models.Customers;

/// <summary>
/// Represents a customer order list model
/// </summary>
public partial record CustomerOrderListModel : BasePagedListModel<CustomerOrderModel>
{
}