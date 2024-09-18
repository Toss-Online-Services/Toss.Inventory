namespace Domain.Services.Messages;

/// <summary>
/// Message token provider
/// </summary>
public partial interface IMessageTokenProvider
{
    /// <summary>
    /// Add store tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="store">Store</param>
    /// <param name="emailAccount">Email account</param>
    /// <param name="languageId">Language identifier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task AddStoreTokensAsync(IList<Token> tokens, Store store, EmailAccount emailAccount, int languageId);

    /// <summary>
    /// Add refunded order tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="order">Order</param>
    /// <param name="refundedAmount">Refunded amount of order</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task AddOrderRefundedTokensAsync(IList<Token> tokens, Order order, decimal refundedAmount);

    /// <summary>
    /// Add return request tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="returnRequest">Return request</param>
    /// <param name="orderItem">Order item</param>
    /// <param name="languageId">Language identifier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task AddReturnRequestTokensAsync(IList<Token> tokens, ReturnRequest returnRequest, OrderItem orderItem, int languageId);

    /// <summary>
    /// Add gift card tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="giftCard">Gift card</param>
    /// <param name="languageId">Language identifier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task AddGiftCardTokensAsync(IList<Token> tokens, GiftCard giftCard, int languageId);

    /// <summary>
    /// Add customer tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="customerId">Customer identifier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task AddCustomerTokensAsync(IList<Token> tokens, int customerId);

    /// <summary>
    /// Add customer tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="customer">Customer</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task AddCustomerTokensAsync(IList<Token> tokens, Customer customer);

    /// <summary>
    /// Add vendor tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="vendor">Vendor</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task AddVendorTokensAsync(IList<Token> tokens, Vendor vendor);

    /// <summary>
    /// Add newsletter subscription tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="subscription">Newsletter subscription</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task AddNewsLetterSubscriptionTokensAsync(IList<Token> tokens, NewsLetterSubscription subscription);

    /// <summary>
    /// Add product review tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="productReview">Product review</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task AddProductReviewTokensAsync(IList<Token> tokens, ProductReview productReview);

    /// <summary>
    /// Add product tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="product">Product</param>
    /// <param name="languageId">Language identifier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task AddProductTokensAsync(IList<Token> tokens, Product product, int languageId);

    /// <summary>
    /// Add product attribute combination tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="combination">Product attribute combination</param>
    /// <param name="languageId">Language identifier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task AddAttributeCombinationTokensAsync(IList<Token> tokens, ProductAttributeCombination combination, int languageId);

    /// <summary>
    /// Add tokens of BackInStock subscription
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="subscription">BackInStock subscription</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task AddBackInStockTokensAsync(IList<Token> tokens, BackInStockSubscription subscription);

    /// <summary>
    /// Get collection of allowed (supported) message tokens for campaigns
    /// </summary>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task<IEnumerable<string>> GetListOfCampaignAllowedTokensAsync();

    /// <summary>
    /// Get collection of allowed (supported) message tokens
    /// </summary>
    /// <param name="tokenGroups">Collection of token groups; pass null to get all available tokens</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task<IEnumerable<string>> GetListOfAllowedTokensAsync(IEnumerable<string> tokenGroups = null);

    /// <summary>
    /// Get token groups of message template
    /// </summary>
    /// <param name="messageTemplate">Message template</param>
    /// <returns>Collection of token group names</returns>
    IEnumerable<string> GetTokenGroups(MessageTemplate messageTemplate);
}
