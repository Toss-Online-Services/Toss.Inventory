namespace Web.Models.Catalog;

/// <summary>
/// Represents a product specification attribute search model
/// </summary>
public partial record ProductSpecificationAttributeSearchModel : BaseSearchModel
{
    #region Properties

    public int ProductId { get; set; }

    #endregion
}