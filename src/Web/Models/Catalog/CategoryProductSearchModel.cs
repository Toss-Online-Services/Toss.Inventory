namespace Web.Models.Catalog;

/// <summary>
/// Represents a category product search model
/// </summary>
public partial record CategoryProductSearchModel : BaseSearchModel
{
    #region Properties

    public int CategoryId { get; set; }

    #endregion
}