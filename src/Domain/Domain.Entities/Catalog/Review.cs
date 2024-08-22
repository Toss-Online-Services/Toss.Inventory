namespace Domain.Entities.Catalog;

/// <summary>
/// Represents a product review
/// </summary>
public class Review : Entity
{

    /// <summary>
    /// Gets or sets the customer identifier
    /// </summary>
    public int CustomerId { get; private set; }

    /// <summary>
    /// Gets or sets the product identifier
    /// </summary>
    public int ProductId { get; private set; }

    /// <summary>
    /// Gets or sets the store identifier
    /// </summary>
    public int StoreId { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the content is approved
    /// </summary>
    public bool IsApproved { get; private set; }

    /// <summary>
    /// Gets or sets the title
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// Gets or sets the review text
    /// </summary>
    public string ReviewText { get; private set; }

    /// <summary>
    /// Gets or sets the reply text
    /// </summary>
    public string ReplyText { get; private set; }

    /// <summary>
    /// Gets or sets the value indicating whether the customer is already notified of the reply to review
    /// </summary>
    public bool CustomerNotifiedOfReply { get; private set; }

    /// <summary>
    /// Review rating
    /// </summary>
    public int Rating { get; private set; }

    /// <summary>
    /// Review helpful votes total
    /// </summary>
    public int HelpfulYesTotal { get; private set; }

    /// <summary>
    /// Review not helpful votes total
    /// </summary>
    public int HelpfulNoTotal { get; private set; }

    /// <summary>
    /// Gets or sets the date and time of instance creation
    /// </summary>
    public DateTime CreatedOnUtc { get; private set; }
}
