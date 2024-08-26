namespace Domain.Entities.Discounts;

/// <summary>
/// Represents a discount
/// </summary>
public class Discount : BaseAuditableEntity, IAggregateRoot
{
    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets or sets the admin comment
    /// </summary>
    public string AdminComment { get; private set; }

    /// <summary>
    /// Gets or sets the discount type identifier
    /// </summary>
    public int DiscountTypeId { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether to use percentage
    /// </summary>
    public bool UsePercentage { get; private set; }

    /// <summary>
    /// Gets or sets the discount percentage
    /// </summary>
    public decimal DiscountPercentage { get; private set; }

    /// <summary>
    /// Gets or sets the discount amount
    /// </summary>
    public decimal DiscountAmount { get; private set; }

    /// <summary>
    /// Gets or sets the maximum discount amount (used with "UsePercentage")
    /// </summary>
    public decimal? MaximumDiscountAmount { get; private set; }

    /// <summary>
    /// Gets or sets the discount start date and time
    /// </summary>
    public DateTime? StartDateUtc { get; private set; }

    /// <summary>
    /// Gets or sets the discount end date and time
    /// </summary>
    public DateTime? EndDateUtc { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether discount requires coupon code
    /// </summary>
    public bool RequiresCouponCode { get; private set; }

    /// <summary>
    /// Gets or sets the coupon code
    /// </summary>
    public string CouponCode { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether discount can be used simultaneously with other discounts (with the same discount type)
    /// </summary>
    public bool IsCumulative { get; private set; }

    /// <summary>
    /// Gets or sets the discount limitation identifier
    /// </summary>
    public int DiscountLimitationId { get; private set; }

    /// <summary>
    /// Gets or sets the discount limitation times (used when Limitation is set to "N Times Only" or "N Times Per Customer")
    /// </summary>
    public int LimitationTimes { get; private set; }

    /// <summary>
    /// Gets or sets the maximum product quantity which could be discounted
    /// Used with "Assigned to products" or "Assigned to categories" type
    /// </summary>
    public int? MaximumDiscountedQuantity { get; private set; }

    /// <summary>
    /// Gets or sets value indicating whether it should be applied to all subcategories or the selected one
    /// Used with "Assigned to categories" type only.
    /// </summary>
    public bool AppliedToSubCategories { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the discount is active
    /// </summary>
    public bool IsActive { get; private set; }

    /// <summary>
    /// Gets or sets the discount type
    /// </summary>
    public DiscountType DiscountType
    {
        get => (DiscountType)DiscountTypeId;
        set => DiscountTypeId = (int)value;
    }

    /// <summary>
    /// Gets or sets the discount limitation
    /// </summary>
    public DiscountLimitationType DiscountLimitation
    {
        get => (DiscountLimitationType)DiscountLimitationId;
        set => DiscountLimitationId = (int)value;
    }
}
