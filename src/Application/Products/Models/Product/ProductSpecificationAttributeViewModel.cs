namespace Application.Products.Models.Product;







/// <summary>
/// Represents a product specification attribute
/// </summary>
/// <param name="ProductId"> Gets or sets the product identifier </param>
/// <param name="AttributeTypeId"> Gets or sets the attribute type ID </param>
/// <param name="SpecificationAttributeOptionId"> Gets or sets the specification attribute identifier </param>
/// <param name="CustomValue"> Gets or sets the custom value </param>
/// <param name="AllowFiltering"> Gets or sets whether the attribute can be filtered by </param>
/// <param name="ShowOnProductPage"> Gets or sets whether the attribute will be shown on the product page </param>
/// <param name="DisplayOrder"> Gets or sets the display order </param>
public record ProductSpecificationAttributeViewModel(int ProductId, int AttributeTypeId, int SpecificationAttributeOptionId, string CustomValue, bool AllowFiltering, bool ShowOnProductPage, int DisplayOrder, SpecificationAttributeType AttributeType);
