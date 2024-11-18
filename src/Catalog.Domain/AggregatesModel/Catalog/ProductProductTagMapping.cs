namespace Catalog.Domain.AggregatesModel.Catalog;

/// <summary>
/// Represents a product-product tag mapping class
/// </summary>
public class ProductProductTagMapping : BaseEntity
{
    /// <summary>
    /// Gets or sets the product identifier
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the product tag identifier
    /// </summary>
    public int ProductTagId { get; set; }
}