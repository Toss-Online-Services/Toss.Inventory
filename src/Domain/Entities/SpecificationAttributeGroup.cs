namespace Toss.Inventory.Domain.Entities;

/// <summary>
/// Represents a specification attribute group
/// </summary>
public class SpecificationAttributeGroup : Entity, ILocalizedEntity
{
    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; set; }
}