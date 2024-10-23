namespace Web.Models.Catalog;

/// <summary>
/// Represents a tier price search model
/// </summary>
public partial record TierPriceSearchModel : BaseSearchModel
{
    #region Properties

    public int ProductId { get; set; }

    #endregion
}