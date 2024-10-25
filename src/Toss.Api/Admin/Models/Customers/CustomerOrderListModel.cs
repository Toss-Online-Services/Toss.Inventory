using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Customers;

/// <summary>
/// Represents a customer order list model
/// </summary>
public partial record CustomerOrderListModel : BasePagedListModel<CustomerOrderModel>
{
}