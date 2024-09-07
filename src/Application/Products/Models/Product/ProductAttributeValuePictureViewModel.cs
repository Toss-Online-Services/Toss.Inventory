namespace Application.Products.Models.Product;


/// <summary>
/// Represents a product attribute value picture
/// </summary>
/// <param name="ProductAttributeValueId"> Gets or sets the product attribute value id </param>
/// <param name="PictureId"> Gets or sets the picture (identifier) associated with this value. This picture should replace a product main picture once clicked (selected). </param>
public record ProductAttributeValuePictureViewModel(int ProductAttributeValueId, int PictureId);
