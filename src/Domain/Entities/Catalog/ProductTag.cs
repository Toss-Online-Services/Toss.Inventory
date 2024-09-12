using Domain.Entities.Localization;
using Domain.Entities.Seo;

namespace Domain.Entities.Catalog;

/// <summary>
/// Represents a product tag
/// </summary>
public partial class ProductTag : BaseEntity, ILocalizedEntity, ISlugSupported
{
    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; }
}