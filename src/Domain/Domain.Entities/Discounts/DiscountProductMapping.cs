using Domain.Infrastructure;

namespace Domain.Entities.Discounts;

/// <summary>
/// Represents a discount-product mapping class
/// </summary>
public class DiscountProductMapping : DiscountMapping, IDiscountMapping
{
    /// <summary>
    /// Gets or sets the product identifier
    /// </summary>
    public override int ProductId { get; set; }
}
