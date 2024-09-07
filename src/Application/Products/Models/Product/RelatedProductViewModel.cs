namespace Application.Products.Models.Product;



/// <summary>
/// Represents a related product
/// </summary>
/// <param name="ProductId1"> Gets or sets the first product identifier </param>
/// <param name="ProductId2"> Gets or sets the second product identifier </param>
/// <param name="DisplayOrder"> Gets or sets the display order </param>
public record RelatedProductViewModel(int ProductId1, int ProductId2, int DisplayOrder);
