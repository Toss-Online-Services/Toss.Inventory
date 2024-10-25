using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Customers;

/// <summary>
/// Represents a customer list model
/// </summary>
public partial record CustomerListModel : BasePagedListModel<CustomerModel>
{
}