namespace Web.Models.Catalog;

/// <summary>
/// Represents a product attribute combination search model
/// </summary>
public partial record ProductAttributeCombinationSearchModel : BaseSearchModel
{
    #region Properties

    public int ProductId { get; set; }

    #endregion
}