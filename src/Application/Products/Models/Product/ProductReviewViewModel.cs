namespace Application.Products.Models.Product;












/// <summary>
/// Represents a product review
/// </summary>
/// <param name="CustomerId"> Gets or sets the customer identifier </param>
/// <param name="ProductId"> Gets or sets the product identifier </param>
/// <param name="StoreId"> Gets or sets the store identifier </param>
/// <param name="IsApproved"> Gets or sets a value indicating whether the content is approved </param>
/// <param name="Title"> Gets or sets the title </param>
/// <param name="ReviewText"> Gets or sets the review text </param>
/// <param name="ReplyText"> Gets or sets the reply text </param>
/// <param name="CustomerNotifiedOfReply"> Gets or sets the value indicating whether the customer is already notified of the reply to review </param>
/// <param name="Rating"> Review rating </param>
/// <param name="HelpfulYesTotal"> Review helpful votes total </param>
/// <param name="HelpfulNoTotal"> Review not helpful votes total </param>
/// <param name="CreatedOnUtc"> Gets or sets the date and time of instance creation </param>
public record ProductReviewViewModel(int CustomerId, int ProductId, int StoreId, bool IsApproved, string Title, string ReviewText, string ReplyText, bool CustomerNotifiedOfReply, int Rating, int HelpfulYesTotal, int HelpfulNoTotal, DateTime CreatedOnUtc);
