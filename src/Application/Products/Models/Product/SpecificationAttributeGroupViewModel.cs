namespace Application.Products.Models.Product;


/// <summary>
/// Represents a specification attribute group
/// </summary>
/// <param name="Name"> Gets or sets the name </param>
/// <param name="DisplayOrder"> Gets or sets the display order </param>
public record SpecificationAttributeGroupViewModel(string Name, int DisplayOrder);
