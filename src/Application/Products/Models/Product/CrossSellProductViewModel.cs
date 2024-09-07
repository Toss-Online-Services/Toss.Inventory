namespace Application.Products.Models.Product;


/// <summary>
/// Represents a cross-sell product
/// </summary>
/// <param name="ProductId1"> Gets or sets the first product identifier </param>
/// <param name="ProductId2"> Gets or sets the second product identifier </param>
public record CrossSellProductViewModel(int ProductId1, int ProductId2);
