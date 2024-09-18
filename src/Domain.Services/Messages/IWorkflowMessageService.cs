namespace Domain.Services.Messages
{
    /// <summary>
    /// Workflow message service interface
    /// </summary>
    public partial interface IWorkflowMessageService
    {
        #region Customer workflow

        Task<IList<int>> SendCustomerRegisteredStoreOwnerNotificationMessageAsync(Customer customer, int languageId);
        Task<IList<int>> SendCustomerWelcomeMessageAsync(Customer customer, int languageId);
        Task<IList<int>> SendCustomerEmailValidationMessageAsync(Customer customer, int languageId);
        Task<IList<int>> SendCustomerEmailRevalidationMessageAsync(Customer customer, int languageId);
        Task<IList<int>> SendCustomerPasswordRecoveryMessageAsync(Customer customer, int languageId);
        Task<IList<int>> SendDeleteCustomerRequestStoreOwnerNotificationAsync(Customer customer, int languageId);

        #endregion

        #region Send a message to a friend

        Task<IList<int>> SendProductEmailAFriendMessageAsync(Customer customer, int languageId, Product product, string customerEmail, string friendsEmail, string personalMessage);
        Task<IList<int>> SendWishlistEmailAFriendMessageAsync(Customer customer, int languageId, string customerEmail, string friendsEmail, string personalMessage);

        #endregion

        #region Misc

        Task<IList<int>> SendNewVendorAccountApplyStoreOwnerNotificationAsync(Customer customer, Vendor vendor, int languageId);
        Task<IList<int>> SendProductReviewStoreOwnerNotificationMessageAsync(ProductReview productReview, int languageId);
        Task<IList<int>> SendProductReviewReplyCustomerNotificationMessageAsync(ProductReview productReview, int languageId);
        Task<IList<int>> SendQuantityBelowStoreOwnerNotificationAsync(Product product, int languageId);
        Task<IList<int>> SendQuantityBelowStoreOwnerNotificationAsync(ProductAttributeCombination combination, int languageId);
        Task<IList<int>> SendNewVatSubmittedStoreOwnerNotificationAsync(Customer customer, string vatName, string vatAddress, int languageId);
        Task<IList<int>> SendContactUsMessageAsync(int languageId, string senderEmail, string senderName, string subject, string body);
        Task<IList<int>> SendContactVendorMessageAsync(Vendor vendor, int languageId, string senderEmail, string senderName, string subject, string body);
        Task<IList<int>> SendBackInStockNotificationAsync(BackInStockSubscription subscription, int languageId);

        #endregion

        #region Common

        Task<int> SendTestEmailAsync(int messageTemplateId, string sendToEmail, List<Token> tokens, int languageId);
        Task<int> SendNotificationAsync(MessageTemplate messageTemplate, EmailAccount emailAccount, int languageId, IList<Token> tokens, string toEmailAddress, string toName, string attachmentFilePath = null, string attachmentFileName = null, string replyToEmailAddress = null, string replyToName = null, string fromEmail = null, string fromName = null, string subject = null, bool ignoreDelayBeforeSend = false);

        #endregion
    }
}
