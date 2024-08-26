namespace Toss.Inventory.Domain.Entities;

/// <summary>
/// Represents a product attribute value picture
/// </summary>
public class ProductAttributeValuePicture : Entity
{
    /// <summary>
    /// Gets or sets the product attribute value id
    /// </summary>
    public int ProductAttributeValueId { get; set; }

    /// <summary>
    /// Gets or sets the picture (identifier) associated with this value. This picture should replace a product main picture once clicked (selected).
    /// </summary>
    public int PictureId { get; set; }
}