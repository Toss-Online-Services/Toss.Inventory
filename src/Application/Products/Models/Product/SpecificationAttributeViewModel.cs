namespace Application.Products.Models.Product;



/// <summary>
/// Represents a specification attribute
/// </summary>
/// <param name="Name"> Gets or sets the name </param>
/// <param name="DisplayOrder"> Gets or sets the display order </param>
/// <param name="SpecificationAttributeGroupId"> Gets or sets the specification attribute group identifier </param>
public record SpecificationAttributeViewModel(string Name, int DisplayOrder, int? SpecificationAttributeGroupId);
