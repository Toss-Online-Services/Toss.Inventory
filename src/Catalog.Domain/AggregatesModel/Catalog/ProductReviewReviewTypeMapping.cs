namespace Catalog.Domain.AggregatesModel.Catalog;

/// <summary>
/// Represents a product review and review type mapping
/// </summary>
public class ProductReviewReviewTypeMapping : BaseEntity, ILocalizedEntity
{
    /// <summary>
    /// Gets or sets the product review identifier
    /// </summary>
    public int ProductReviewId { get; set; }

    /// <summary>
    /// Gets or sets the review type identifier
    /// </summary>
    public int ReviewTypeId { get; set; }

    /// <summary>
    /// Gets or sets the rating
    /// </summary>
    public int Rating { get; set; }
}