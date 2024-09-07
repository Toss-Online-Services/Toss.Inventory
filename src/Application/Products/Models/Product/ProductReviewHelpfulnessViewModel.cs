namespace Application.Products.Models.Product;



/// <summary>
/// Represents a product review helpfulness
/// </summary>
/// <param name="ProductReviewId"> Gets or sets the product review identifier </param>
/// <param name="WasHelpful"> A value indicating whether a review a helpful </param>
/// <param name="CustomerId"> Gets or sets the customer identifier </param>
public record ProductReviewHelpfulnessViewModel(int ProductReviewId, bool WasHelpful, int CustomerId);
