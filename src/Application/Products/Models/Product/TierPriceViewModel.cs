namespace Application.Products.Models.Product;

/// <summary>
/// Represents a tier price
/// </summary>
/// <param name="ProductId"> Gets or sets the product identifier </param>
/// <param name="StoreId"> Gets or sets the store identifier (0 - all stores) </param>
/// <param name="CustomerRoleId"> Gets or sets the customer role identifier </param>
/// <param name="Quantity"> Gets or sets the quantity </param>
/// <param name="Price"> Gets or sets the price </param>
/// <param name="StartDateTimeUtc"> Gets or sets the start date and time in UTC </param>
/// <param name="EndDateTimeUtc"> Gets or sets the end date and time in UTC </param>
public record TierPrice(int ProductId, int StoreId, int? CustomerRoleId, int Quantity, decimal Price, DateTime? StartDateTimeUtc, DateTime? EndDateTimeUtc);
