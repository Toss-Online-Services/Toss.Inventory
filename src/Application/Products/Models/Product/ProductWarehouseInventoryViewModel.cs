namespace Application.Products.Models.Product;




/// <summary>
/// Represents a record to manage product inventory per warehouse
/// </summary>
/// <param name="ProductId"> Gets or sets the product identifier </param>
/// <param name="WarehouseId"> Gets or sets the warehouse identifier </param>
/// <param name="StockQuantity"> Gets or sets the stock quantity </param>
/// <param name="ReservedQuantity"> Gets or sets the reserved quantity (ordered but not shipped yet) </param>
public record ProductWarehouseInventoryViewModel(
                                                int ProductId, 
                                                int WarehouseId, 
                                                int StockQuantity, 
                                                int ReservedQuantity
                                                );
