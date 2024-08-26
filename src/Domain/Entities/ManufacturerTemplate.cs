namespace Toss.Inventory.Domain.Entities;

/// <summary>
/// Represents a manufacturer template
/// </summary>
public class ManufacturerTemplate : Entity
{
    /// <summary>
    /// Gets or sets the template name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the view path
    /// </summary>
    public string ViewPath { get; set; }

    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; set; }
}