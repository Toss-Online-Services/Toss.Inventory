namespace Application.Products.Models.Product;

/// <summary>
/// Represents a stock quantity change entry
/// </summary>
/// <param name="QuantityAdjustment"> Gets or sets the stock quantity adjustment </param>
/// <param name="StockQuantity"> Gets or sets current stock quantity </param>
/// <param name="Message"> Gets or sets the message </param>
/// <param name="CreatedOnUtc"> Gets or sets the date and time of instance creation </param>
/// <param name="ProductId"> Gets or sets the product identifier </param>
/// <param name="CombinationId"> Gets or sets the product attribute combination identifier </param>
/// <param name="WarehouseId"> Gets or sets the warehouse identifier </param>
public record StockQuantityHistoryViewModel(int QuantityAdjustment, int StockQuantity, string Message, DateTime CreatedOnUtc, int ProductId, int? CombinationId, int? WarehouseId);
