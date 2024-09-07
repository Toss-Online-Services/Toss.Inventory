namespace Application.Products.Models.Product;





/// <summary>
/// Represents a review type
/// </summary>
/// <param name="Name"> Gets or sets the name </param>
/// <param name="Description"> Gets or sets the description </param>
/// <param name="DisplayOrder"> Gets or sets the display order </param>
/// <param name="VisibleToAllCustomers"> Gets or sets a value indicating whether the review type is visible to all customers </param>
/// <param name="IsRequired"> Gets or sets a value indicating whether the review type is required </param>
public record ReviewTypeViewModel(string Name, string Description, int DisplayOrder, bool VisibleToAllCustomers, bool IsRequired);
