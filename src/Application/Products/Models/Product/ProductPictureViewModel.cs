namespace Application.Products.Models.Product;



/// <summary>
/// Represents a product picture mapping
/// </summary>
/// <param name="ProductId"> Gets or sets the product identifier </param>
/// <param name="PictureId"> Gets or sets the picture identifier </param>
/// <param name="DisplayOrder"> Gets or sets the display order </param>
public record ProductPictureViewModel(int ProductId, int PictureId, int DisplayOrder);
