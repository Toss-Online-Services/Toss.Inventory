using Domain.Infrastructure;

namespace Domain.Entities.Discounts;

public abstract class DiscountMapping : Entity
{
    /// <summary>
    /// Gets the entity identifier
    /// </summary>
    public new int Id { get; }

    /// <summary>
    /// Gets or sets the discount identifier
    /// </summary>
    public int DiscountId { get; private set; }

    /// <summary>
    /// Gets or sets the entity identifier
    /// </summary>
    public abstract int EntityId { get; set; }
}
