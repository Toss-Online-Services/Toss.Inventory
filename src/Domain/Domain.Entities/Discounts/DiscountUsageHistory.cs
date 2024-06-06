namespace Domain.Entities.Discounts;

/// <summary>
/// Represents a discount usage history entry
/// </summary>
public class DiscountUsageHistory : Entity
{
    /// <summary>
    /// Gets or sets the discount identifier
    /// </summary>
    public int DiscountId { get; private set; }

    /// <summary>
    /// Gets or sets the order identifier
    /// </summary>
    public int OrderId { get; private set; }

    /// <summary>
    /// Gets or sets the date and time of instance creation
    /// </summary>
    public DateTime CreatedOnUtc { get; private set; }
}
