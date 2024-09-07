namespace Application.Products.Models.Product;



/// <summary>
/// Represents a category template
/// </summary>
/// <param name="Name"> Gets or sets the template name </param>
/// <param name="ViewPath"> Gets or sets the view path </param>
/// <param name="DisplayOrder"> Gets or sets the display order </param>
public record CategoryTemplateViewModel(string Name, string ViewPath, int DisplayOrder);
