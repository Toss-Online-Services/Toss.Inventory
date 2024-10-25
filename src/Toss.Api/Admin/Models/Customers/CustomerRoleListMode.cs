using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Customers;

/// <summary>
/// Represents a customer role list model
/// </summary>
public partial record CustomerRoleListModel : BasePagedListModel<CustomerRoleModel>
{
}