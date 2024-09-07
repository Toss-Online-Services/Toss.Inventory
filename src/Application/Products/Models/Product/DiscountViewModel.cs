namespace Application.Products.Models.Product;

















/// <summary>
/// Represents a discount
/// </summary>
/// <param name="Name"> Gets or sets the name </param>
/// <param name="AdminComment"> Gets or sets the admin comment </param>
/// <param name="DiscountTypeId"> Gets or sets the discount type identifier </param>
/// <param name="UsePercentage"> Gets or sets a value indicating whether to use percentage </param>
/// <param name="DiscountPercentage"> Gets or sets the discount percentage </param>
/// <param name="DiscountAmount"> Gets or sets the discount amount </param>
/// <param name="MaximumDiscountAmount"> Gets or sets the maximum discount amount (used with "UsePercentage") </param>
/// <param name="StartDateUtc"> Gets or sets the discount start date and time </param>
/// <param name="EndDateUtc"> Gets or sets the discount end date and time </param>
/// <param name="RequiresCouponCode"> Gets or sets a value indicating whether discount requires coupon code </param>
/// <param name="CouponCode"> Gets or sets the coupon code </param>
/// <param name="IsCumulative"> Gets or sets a value indicating whether discount can be used simultaneously with other discounts (with the same discount type) </param>
/// <param name="DiscountLimitationId"> Gets or sets the discount limitation identifier </param>
/// <param name="LimitationTimes"> Gets or sets the discount limitation times (used when Limitation is set to "N Times Only" or "N Times Per Customer") </param>
/// <param name="MaximumDiscountedQuantity"> Gets or sets the maximum product quantity which could be discounted
/// Used with "Assigned to products" or "Assigned to categories" type </param>
/// <param name="AppliedToSubCategories"> Gets or sets value indicating whether it should be applied to all subcategories or the selected one
/// Used with "Assigned to categories" type only. </param>
/// <param name="IsActive"> Gets or sets a value indicating whether the discount is active </param>
public record DiscountViewModel(string Name, string AdminComment, int DiscountTypeId, bool UsePercentage, decimal DiscountPercentage, decimal DiscountAmount, decimal? MaximumDiscountAmount, DateTime? StartDateUtc, DateTime? EndDateUtc, bool RequiresCouponCode, string CouponCode, bool IsCumulative, int DiscountLimitationId, int LimitationTimes, int? MaximumDiscountedQuantity, bool AppliedToSubCategories, bool IsActive);
