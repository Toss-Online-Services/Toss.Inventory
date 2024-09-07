namespace Application.Products.Models.Product;



/// <summary>
/// Represents a product video mapping
/// </summary>
/// <param name="ProductId"> Gets or sets the product identifier </param>
/// <param name="VideoId"> Gets or sets the video identifier </param>
/// <param name="DisplayOrder"> Gets or sets the display order </param>
public record ProductVideoViewModel(int ProductId, int VideoId, int DisplayOrder);
