namespace Application.Products.Models.Product;



/// <summary>
/// Represents a product review and review type mapping
/// </summary>
/// <param name="ProductReviewId"> Gets or sets the product review identifier </param>
/// <param name="ReviewTypeId"> Gets or sets the review type identifier </param>
/// <param name="Rating"> Gets or sets the rating </param>
public record ProductReviewReviewTypeMappingViewModel(int ProductReviewId, int ReviewTypeId, int Rating);
