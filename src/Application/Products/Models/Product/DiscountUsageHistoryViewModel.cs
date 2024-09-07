namespace Application.Products.Models.Product;



/// <summary>
/// Represents a discount usage history entry
/// </summary>
/// <param name="DiscountId"> Gets or sets the discount identifier </param>
/// <param name="OrderId"> Gets or sets the order identifier </param>
/// <param name="CreatedOnUtc"> Gets or sets the date and time of instance creation </param>
public record DiscountUsageHistoryViewModel(int DiscountId, int OrderId, DateTime CreatedOnUtc);
