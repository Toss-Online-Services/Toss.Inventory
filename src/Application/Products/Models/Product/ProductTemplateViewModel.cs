namespace Application.Products.Models.Product;




/// <summary>
/// Represents a product template
/// </summary>
/// <param name="Name"> Gets or sets the template name </param>
/// <param name="ViewPath"> Gets or sets the view path </param>
/// <param name="DisplayOrder"> Gets or sets the display order </param>
/// <param name="IgnoredProductTypes"> Gets or sets a comma-separated list of product type identifiers NOT supported by this template </param>
public record ProductTemplateViewModel(string Name, string ViewPath, int DisplayOrder, string IgnoredProductTypes);
