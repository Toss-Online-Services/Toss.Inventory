namespace Catalog.Domain.AggregatesModel.Discounts;

/// <summary>
/// Represents a discount-product mapping class
/// </summary>
public partial class DiscountProductMapping : DiscountMapping
{
    /// <summary>
    /// Gets or sets the product identifier
    /// </summary>
    public override int EntityId { get; set; }
}