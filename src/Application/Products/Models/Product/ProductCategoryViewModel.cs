namespace Application.Products.Models.Product;




/// <summary>
/// Represents a product category mapping
/// </summary>
/// <param name="ProductId"> Gets or sets the product identifier </param>
/// <param name="CategoryId"> Gets or sets the category identifier </param>
/// <param name="IsFeaturedProduct"> Gets or sets a value indicating whether the product is featured </param>
/// <param name="DisplayOrder"> Gets or sets the display order </param>
public record ProductCategoryViewModel(int ProductId, int CategoryId, bool IsFeaturedProduct, int DisplayOrder);
