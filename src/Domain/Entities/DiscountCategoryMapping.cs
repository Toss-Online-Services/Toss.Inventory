namespace Domain.Entities;

/// <summary>
/// Represents a discount-category mapping class
/// </summary>
public class DiscountCategoryMapping : DiscountMapping
{
    /// <summary>
    /// Gets or sets the category identifier
    /// </summary>
    public override int ProductId { get; set; }
}
