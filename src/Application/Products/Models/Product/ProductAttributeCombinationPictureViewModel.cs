namespace Application.Products.Models.Product;


/// <summary>
/// Represents a product attribute combination picture
/// </summary>
/// <param name="ProductAttributeCombinationId"> Gets or sets the product attribute combination id </param>
/// <param name="PictureId"> Gets or sets the identifier of picture associated with this combination </param>
public record ProductAttributeCombinationPictureViewModel(int ProductAttributeCombinationId, int PictureId);
