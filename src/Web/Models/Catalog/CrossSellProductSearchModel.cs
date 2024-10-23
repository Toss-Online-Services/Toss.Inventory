namespace Web.Models.Catalog;

/// <summary>
/// Represents a cross-sell product search model
/// </summary>
public partial record CrossSellProductSearchModel : BaseSearchModel
{
    #region Properties

    public int ProductId { get; set; }

    #endregion
}