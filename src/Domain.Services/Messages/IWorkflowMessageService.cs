namespace Domain.Services.Messages;

/// <summary>
/// Workflow message service
/// </summary>
public partial interface IWorkflowMessageService
{
    /// <summary>
    /// Sends a 'Back in stock' notification message to a customer
    /// </summary>
    /// <param name="subscription">Subscription</param>
    /// <param name="languageId">Message language identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the queued email identifier
    /// </returns>
    Task<IList<int>> SendBackInStockNotificationAsync(BackInStockSubscription subscription, int languageId);

    #region Misc
    /// <summary>
    /// Sends a "quantity below" notification to a store owner
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="languageId">Message language identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the queued email identifier
    /// </returns>
    Task<IList<int>> SendQuantityBelowStoreOwnerNotificationAsync(Product product, int languageId);

    /// <summary>
    /// Sends a "quantity below" notification to a store owner
    /// </summary>
    /// <param name="combination">Attribute combination</param>
    /// <param name="languageId">Message language identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the queued email identifier
    /// </returns>
    Task<IList<int>> SendQuantityBelowStoreOwnerNotificationAsync(ProductAttributeCombination combination, int languageId);
       

    #endregion
}
