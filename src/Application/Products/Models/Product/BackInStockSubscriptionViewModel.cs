namespace Application.Products.Models.Product;




/// <summary>
/// Represents a back in stock subscription
/// </summary>
/// <param name="StoreId"> Gets or sets the store identifier </param>
/// <param name="ProductId"> Gets or sets the product identifier </param>
/// <param name="CustomerId"> Gets or sets the customer identifier </param>
/// <param name="CreatedOnUtc"> Gets or sets the date and time of instance creation </param>
public record BackInStockSubscriptionViewModel(int StoreId, int ProductId, int CustomerId, DateTime CreatedOnUtc);
