namespace Web.Models.Customers;

/// <summary>
/// Represents a GDPR request list model
/// </summary>
public partial record GdprLogListModel : BasePagedListModel<GdprLogModel>
{
}