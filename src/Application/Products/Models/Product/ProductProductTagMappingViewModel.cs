namespace Application.Products.Models.Product;


/// <summary>
/// Represents a product-product tag mapping class
/// </summary>
/// <param name="ProductId"> Gets or sets the product identifier </param>
/// <param name="ProductTagId"> Gets or sets the product tag identifier </param>
public record ProductProductTagMappingViewModel(int ProductId, int ProductTagId);
