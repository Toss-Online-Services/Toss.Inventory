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
public record ReviewViewModel(int CustomerId, int ProductId, int StoreId, bool IsApproved, string Title, string ReviewText, string ReplyText, bool CustomerNotifiedOfReply, int Rating, int HelpfulYesTotal, int HelpfulNoTotal, DateTime CreatedOnUtc)
{
    /// <summary>
    /// Gets or sets the customer identifier
    /// </summary>
    public int CustomerId { get; private set; } = CustomerId;

    /// <summary>
    /// Gets or sets the product identifier
    /// </summary>
    public int ProductId { get; private set; } = ProductId;

    /// <summary>
    /// Gets or sets the store identifier
    /// </summary>
    public int StoreId { get; private set; } = StoreId;

    /// <summary>
    /// Gets or sets a value indicating whether the content is approved
    /// </summary>
    public bool IsApproved { get; private set; } = IsApproved;

    /// <summary>
    /// Gets or sets the title
    /// </summary>
    public string Title { get; private set; } = Title;

    /// <summary>
    /// Gets or sets the review text
    /// </summary>
    public string ReviewText { get; private set; } = ReviewText;

    /// <summary>
    /// Gets or sets the reply text
    /// </summary>
    public string ReplyText { get; private set; } = ReplyText;

    /// <summary>
    /// Gets or sets the value indicating whether the customer is already notified of the reply to review
    /// </summary>
    public bool CustomerNotifiedOfReply { get; private set; } = CustomerNotifiedOfReply;

    /// <summary>
    /// Review rating
    /// </summary>
    public int Rating { get; private set; } = Rating;

    /// <summary>
    /// Review helpful votes total
    /// </summary>
    public int HelpfulYesTotal { get; private set; } = HelpfulYesTotal;

    /// <summary>
    /// Review not helpful votes total
    /// </summary>
    public int HelpfulNoTotal { get; private set; } = HelpfulNoTotal;

    /// <summary>
    /// Gets or sets the date and time of instance creation
    /// </summary>
    public DateTime CreatedOnUtc { get; private set; } = CreatedOnUtc;
}
