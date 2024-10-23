namespace Web.Models.Catalog;

/// <summary>
/// Represents a product attribute mapping search model
/// </summary>
public partial record ProductAttributeMappingSearchModel : BaseSearchModel
{
    #region Properties

    public int ProductId { get; set; }

    #endregion
}