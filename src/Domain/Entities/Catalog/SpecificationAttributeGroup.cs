using Domain.Entities.Localization;

namespace Domain.Entities.Catalog;

/// <summary>
/// Represents a specification attribute group
/// </summary>
public partial class SpecificationAttributeGroup : BaseEntity, ILocalizedEntity
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