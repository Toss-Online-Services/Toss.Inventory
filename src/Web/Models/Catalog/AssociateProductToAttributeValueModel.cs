namespace Web.Models.Catalog;

/// <summary>
/// Represents a product model to associate to the product attribute value
/// </summary>
public partial record AssociateProductToAttributeValueModel : BaseNopModel
{
    #region Properties

    public int AssociatedToProductId { get; set; }

    #endregion
}