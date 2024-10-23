namespace Web.Models.Common;

/// <summary>
/// Represents an address attribute value search model
/// </summary>
public partial record AddressAttributeValueSearchModel : BaseSearchModel
{
    #region Properties

    public int AddressAttributeId { get; set; }

    #endregion
}