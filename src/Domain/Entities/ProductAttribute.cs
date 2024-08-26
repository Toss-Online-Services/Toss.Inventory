namespace Toss.Inventory.Domain.Entities;

/// <summary>
/// Represents a product attribute
/// </summary>
public class ProductAttribute : Entity, ILocalizedEntity
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