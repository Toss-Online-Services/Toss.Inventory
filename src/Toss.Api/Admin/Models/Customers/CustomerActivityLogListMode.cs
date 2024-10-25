using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Customers;

/// <summary>
/// Represents a customer activity log list model
/// </summary>
public partial record CustomerActivityLogListModel : BasePagedListModel<CustomerActivityLogModel>
{
}