namespace Catalog.Domain.AggregatesModel.Catalog;

/// <summary>
/// Represents a product attribute
/// </summary>
public class ProductAttribute : BaseEntity, ILocalizedEntity
{
    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description
    /// </summary>
    public string Description { get; set; }
}