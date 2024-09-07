namespace Application.Products.Models.Product;




/// <summary>
/// Represents a specification attribute option
/// </summary>
/// <param name="SpecificationAttributeId"> Gets or sets the specification attribute identifier </param>
/// <param name="Name"> Gets or sets the name </param>
/// <param name="ColorSquaresRgb"> Gets or sets the color RGB value (used when you want to display "Color squares" instead of text) </param>
/// <param name="DisplayOrder"> Gets or sets the display order </param>
public record SpecificationAttributeOptionViewModel(int SpecificationAttributeId, string Name, string ColorSquaresRgb, int DisplayOrder);
