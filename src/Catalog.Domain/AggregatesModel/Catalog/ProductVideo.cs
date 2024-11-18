namespace Catalog.Domain.AggregatesModel.Catalog;

/// <summary>
/// Represents a product video mapping
/// </summary>
public class ProductVideo : BaseEntity
{
    /// <summary>
    /// Gets or sets the product identifier
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the video identifier
    /// </summary>
    public int VideoId { get; set; }

    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; set; }
}