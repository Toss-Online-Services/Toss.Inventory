namespace Web.Models.Customers;

/// <summary>
/// Represents a associated external auth records search model
/// </summary>
public partial record CustomerAssociatedExternalAuthRecordsSearchModel : BaseSearchModel
{
    #region Properties

    public int CustomerId { get; set; }

    [NopResourceDisplayName("Admin.Customers.Customers.AssociatedExternalAuth")]
    public IList<CustomerAssociatedExternalAuthModel> AssociatedExternalAuthRecords { get; set; } = new List<CustomerAssociatedExternalAuthModel>();

    #endregion
}