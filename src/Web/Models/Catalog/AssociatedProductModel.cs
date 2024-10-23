namespace Web.Models.Catalog;

/// <summary>
/// Represents an associated product model
/// </summary>
public partial record AssociatedProductModel : BaseNopEntityModel
{
    #region Properties

    [NopResourceDisplayName("Admin.Catalog.Products.AssociatedProducts.Fields.Product")]
    public string ProductName { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Products.AssociatedProducts.Fields.DisplayOrder")]
    public int DisplayOrder { get; set; }

    #endregion
}