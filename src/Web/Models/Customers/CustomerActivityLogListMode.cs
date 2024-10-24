namespace Web.Models.Customers;

/// <summary>
/// Represents a customer activity log list model
/// </summary>
public partial record CustomerActivityLogListModel : BasePagedListModel<CustomerActivityLogModel>
{
}