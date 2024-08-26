namespace Domain.Entities.Catalog;

/// <summary>
/// Represents a product picture mapping
/// </summary>
public class ProductPicture : Entity
{
    /// <summary>
    /// Gets or sets the product identifier
    /// </summary>
    public int ProductId { get; private set; }

    /// <summary>
    /// Gets or sets the picture identifier
    /// </summary>
    public int PictureId { get; private set; }

    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; private set; }
}
