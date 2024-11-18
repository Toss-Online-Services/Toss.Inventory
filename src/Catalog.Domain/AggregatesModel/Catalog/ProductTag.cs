using Catalog.Domain.AggregatesModel.Seo;

namespace Catalog.Domain.AggregatesModel.Catalog;

/// <summary>
/// Represents a product tag
/// </summary>
public class ProductTag : BaseEntity, ILocalizedEntity, ISlugSupported
{
    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; }
}