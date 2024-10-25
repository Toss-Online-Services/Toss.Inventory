using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Customers;

/// <summary>
/// Represents an online customer list model
/// </summary>
public partial record OnlineCustomerListModel : BasePagedListModel<OnlineCustomerModel>
{
}