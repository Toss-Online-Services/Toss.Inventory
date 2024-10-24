namespace Web.Models.Vendors;

/// <summary>
/// Represents a vendor attribute value search model
/// </summary>
public partial record VendorAttributeValueSearchModel : BaseSearchModel
{
    #region Properties

    public int VendorAttributeId { get; set; }

    #endregion
}