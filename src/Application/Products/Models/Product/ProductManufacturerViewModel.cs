namespace Application.Products.Models.Product;




/// <summary>
/// Represents a product manufacturer mapping
/// </summary>
/// <param name="ProductId"> Gets or sets the product identifier </param>
/// <param name="ManufacturerId"> Gets or sets the manufacturer identifier </param>
/// <param name="IsFeaturedProduct"> Gets or sets a value indicating whether the product is featured </param>
/// <param name="DisplayOrder"> Gets or sets the display order </param>
public record ProductManufacturerViewModel(int ProductId, int ManufacturerId, bool IsFeaturedProduct, int DisplayOrder);
