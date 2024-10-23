namespace Web.Models.Catalog;

/// <summary>
/// Represents an associated product search model
/// </summary>
public partial record AssociatedProductSearchModel : BaseSearchModel
{
    #region Properties

    public int ProductId { get; set; }

    #endregion
}