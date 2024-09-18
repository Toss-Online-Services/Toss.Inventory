using Domain.Entities;
using Domain.Services.Common;
using Domain.Services.Helpers;
using Domain.Services.Orders;
using Domain.Services.Vendors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Domain.Services.Messages;

/// <summary>
/// Message token provider
/// </summary>
public partial class MessageTokenProvider : IMessageTokenProvider
{
    #region Fields

    protected readonly CatalogSettings _catalogSettings;
    protected readonly CurrencySettings _currencySettings;
    protected readonly IActionContextAccessor _actionContextAccessor;
    protected readonly IAddressService _addressService;
    protected readonly IAttributeFormatter<AddressAttribute, AddressAttributeValue> _addressAttributeFormatter;
    protected readonly IAttributeFormatter<CustomerAttribute, CustomerAttributeValue> _customerAttributeFormatter;
    protected readonly IAttributeFormatter<VendorAttribute, VendorAttributeValue> _vendorAttributeFormatter;

    protected readonly ICountryService _countryService;
    protected readonly ICurrencyService _currencyService;
    protected readonly ICustomerService _customerService;
    protected readonly IDateTimeHelper _dateTimeHelper;
    protected readonly IEventPublisher _eventPublisher;
    protected readonly IGenericAttributeService _genericAttributeService;
    protected readonly IGiftCardService _giftCardService;
    protected readonly IHtmlFormatter _htmlFormatter;
    protected readonly ILanguageService _languageService;
    protected readonly ILocalizationService _localizationService;
    protected readonly ILogger _logger;
    protected readonly IPriceFormatter _priceFormatter;
    protected readonly IProductService _productService;
    protected readonly IStateProvinceService _stateProvinceService;
    protected readonly IStoreContext _storeContext;
    protected readonly IStoreService _storeService;
    protected readonly IUrlHelperFactory _urlHelperFactory;
    protected readonly IUrlRecordService _urlRecordService;
    protected readonly IWorkContext _workContext;
    protected readonly MessageTemplatesSettings _templatesSettings;
    protected readonly StoreInformationSettings _storeInformationSettings;
    protected readonly TaxSettings _taxSettings;

    protected Dictionary<string, IEnumerable<string>> _allowedTokens;

    #endregion

    #region Ctor

    public MessageTokenProvider(CatalogSettings catalogSettings,
        CurrencySettings currencySettings,
        IActionContextAccessor actionContextAccessor,
        IAddressService addressService,
        IAttributeFormatter<AddressAttribute, AddressAttributeValue> addressAttributeFormatter,
        IAttributeFormatter<CustomerAttribute, CustomerAttributeValue> customerAttributeFormatter,
        IAttributeFormatter<VendorAttribute, VendorAttributeValue> vendorAttributeFormatter,
 
        ICountryService countryService,
        ICurrencyService currencyService,
        ICustomerService customerService,
        IDateTimeHelper dateTimeHelper,
        IEventPublisher eventPublisher,
        IGenericAttributeService genericAttributeService,
        IGiftCardService giftCardService,
        IHtmlFormatter htmlFormatter,
        ILanguageService languageService,
        ILocalizationService localizationService,
        ILogger logger,
        IPriceFormatter priceFormatter,
        IProductService productService,
        IStateProvinceService stateProvinceService,
        IStoreContext storeContext,
        IStoreService storeService,
        IUrlHelperFactory urlHelperFactory,
        IUrlRecordService urlRecordService,
        IWorkContext workContext,
        MessageTemplatesSettings templatesSettings,
        StoreInformationSettings storeInformationSettings,
        TaxSettings taxSettings)
    {
        _catalogSettings = catalogSettings;
        _currencySettings = currencySettings;
        _actionContextAccessor = actionContextAccessor;
        _addressService = addressService;
        _addressAttributeFormatter = addressAttributeFormatter;
        _customerAttributeFormatter = customerAttributeFormatter;
        _vendorAttributeFormatter = vendorAttributeFormatter;
        _countryService = countryService;
        _currencyService = currencyService;
        _customerService = customerService;
        _dateTimeHelper = dateTimeHelper;
        _eventPublisher = eventPublisher;
        _genericAttributeService = genericAttributeService;
        _giftCardService = giftCardService;
        _htmlFormatter = htmlFormatter;
        _languageService = languageService;
        _localizationService = localizationService;
        _logger = logger;
        _priceFormatter = priceFormatter;
        _productService = productService;
        _stateProvinceService = stateProvinceService;
        _storeContext = storeContext;
        _storeService = storeService;
        _urlHelperFactory = urlHelperFactory;
        _urlRecordService = urlRecordService;
        _workContext = workContext;
        _templatesSettings = templatesSettings;
        _storeInformationSettings = storeInformationSettings;
        _taxSettings = taxSettings;
    }

    #endregion

    #region Allowed tokens

    /// <summary>
    /// Get all available tokens by token groups
    /// </summary>
    protected Dictionary<string, IEnumerable<string>> AllowedTokens
    {
        get
        {
            if (_allowedTokens != null)
                return _allowedTokens;

            _allowedTokens = new Dictionary<string, IEnumerable<string>>
            {
                //store tokens
                {
                    TokenGroupNames.StoreTokens,
                    new[]
                    {
                        "%Store.Name%",
                        "%Store.URL%",
                        "%Store.Email%",
                        "%Store.CompanyName%",
                        "%Store.CompanyAddress%",
                        "%Store.CompanyPhoneNumber%",
                        "%Store.CompanyVat%",
                        "%Facebook.URL%",
                        "%Twitter.URL%",
                        "%YouTube.URL%",
                        "%Instagram.URL%"
                    }
                },

                //customer tokens
                {
                    TokenGroupNames.CustomerTokens,
                    new[]
                    {
                        "%Customer.Email%",
                        "%Customer.Username%",
                        "%Customer.FullName%",
                        "%Customer.FirstName%",
                        "%Customer.LastName%",
                        "%Customer.VatNumber%",
                        "%Customer.VatNumberStatus%",
                        "%Customer.CustomAttributes%",
                        "%Customer.PasswordRecoveryURL%",
                        "%Customer.AccountActivationURL%",
                        "%Customer.EmailRevalidationURL%",
                        "%Wishlist.URLForCustomer%"
                    }
                },

                //order tokens
                {
                    TokenGroupNames.OrderTokens,
                    new[]
                    {
                        "%Order.OrderNumber%",
                        "%Order.CustomerFullName%",
                        "%Order.CustomerEmail%",
                        "%Order.BillingFirstName%",
                        "%Order.BillingLastName%",
                        "%Order.BillingPhoneNumber%",
                        "%Order.BillingEmail%",
                        "%Order.BillingFaxNumber%",
                        "%Order.BillingCompany%",
                        "%Order.BillingAddress1%",
                        "%Order.BillingAddress2%",
                        "%Order.BillingCity%",
                        "%Order.BillingCounty%",
                        "%Order.BillingStateProvince%",
                        "%Order.BillingZipPostalCode%",
                        "%Order.BillingCountry%",
                        "%Order.BillingCustomAttributes%",
                        "%Order.BillingAddressLine%",
                        "%Order.Shippable%",
                        "%Order.ShippingMethod%",
                        "%Order.ShippingFirstName%",
                        "%Order.ShippingLastName%",
                        "%Order.ShippingPhoneNumber%",
                        "%Order.ShippingEmail%",
                        "%Order.ShippingFaxNumber%",
                        "%Order.ShippingCompany%",
                        "%Order.ShippingAddress1%",
                        "%Order.ShippingAddress2%",
                        "%Order.ShippingCity%",
                        "%Order.ShippingCounty%",
                        "%Order.ShippingStateProvince%",
                        "%Order.ShippingZipPostalCode%",
                        "%Order.ShippingCountry%",
                        "%Order.ShippingCustomAttributes%",
                        "%Order.ShippingAddressLine%",
                        "%Order.PaymentMethod%",
                        "%Order.VatNumber%",
                        "%Order.CustomValues%",
                        "%Order.Product(s)%",
                        "%Order.CreatedOn%",
                        "%Order.OrderURLForCustomer%",
                        "%Order.PickupInStore%",
                        "%Order.OrderId%",
                        "%Order.IsCompletelyShipped%",
                        "%Order.IsCompletelyReadyForPickup%",
                        "%Order.IsCompletelyDelivered%"
                    }
                },

                //shipment tokens
                {
                    TokenGroupNames.ShipmentTokens,
                    new[]
                    {
                        "%Shipment.ShipmentNumber%",
                        "%Shipment.TrackingNumber%",
                        "%Shipment.TrackingNumberURL%",
                        "%Shipment.Product(s)%",
                        "%Shipment.URLForCustomer%"
                    }
                },

                //refunded order tokens
                {
                    TokenGroupNames.RefundedOrderTokens,
                    new[]
                    {
                        "%Order.AmountRefunded%"
                    }
                },

                //order note tokens
                {
                    TokenGroupNames.OrderNoteTokens,
                    new[]
                    {
                        "%Order.NewNoteText%",
                        "%Order.OrderNoteAttachmentUrl%"
                    }
                },

                //recurring payment tokens
                {
                    TokenGroupNames.RecurringPaymentTokens,
                    new[]
                    {
                        "%RecurringPayment.ID%",
                        "%RecurringPayment.CancelAfterFailedPayment%",
                        "%RecurringPayment.RecurringPaymentType%"
                    }
                },

                //newsletter subscription tokens
                {
                    TokenGroupNames.SubscriptionTokens,
                    new[]
                    {
                        "%NewsLetterSubscription.Email%",
                        "%NewsLetterSubscription.ActivationUrl%",
                        "%NewsLetterSubscription.DeactivationUrl%"
                    }
                },

                //product tokens
                {
                    TokenGroupNames.ProductTokens,
                    new[]
                    {
                        "%Product.ID%",
                        "%Product.Name%",
                        "%Product.ShortDescription%",
                        "%Product.ProductURLForCustomer%",
                        "%Product.SKU%",
                        "%Product.StockQuantity%"
                    }
                },

                //return request tokens
                {
                    TokenGroupNames.ReturnRequestTokens,
                    new[]
                    {
                        "%ReturnRequest.CustomNumber%",
                        "%ReturnRequest.OrderId%",
                        "%ReturnRequest.Product.Quantity%",
                        "%ReturnRequest.Product.Name%",
                        "%ReturnRequest.Reason%",
                        "%ReturnRequest.RequestedAction%",
                        "%ReturnRequest.CustomerComment%",
                        "%ReturnRequest.StaffNotes%",
                        "%ReturnRequest.Status%"
                    }
                },

                //forum tokens
                {
                    TokenGroupNames.ForumTokens,
                    new[]
                    {
                        "%Forums.ForumURL%",
                        "%Forums.ForumName%"
                    }
                },

                //forum topic tokens
                {
                    TokenGroupNames.ForumTopicTokens,
                    new[]
                    {
                        "%Forums.TopicURL%",
                        "%Forums.TopicName%"
                    }
                },

                //forum post tokens
                {
                    TokenGroupNames.ForumPostTokens,
                    new[]
                    {
                        "%Forums.PostAuthor%",
                        "%Forums.PostBody%"
                    }
                },

                //private message tokens
                {
                    TokenGroupNames.PrivateMessageTokens,
                    new[]
                    {
                        "%PrivateMessage.Subject%",
                        "%PrivateMessage.Text%"
                    }
                },

                //vendor tokens
                {
                    TokenGroupNames.VendorTokens,
                    new[]
                    {
                        "%Vendor.Name%",
                        "%Vendor.Email%",
                        "%Vendor.VendorAttributes%"
                    }
                },

                //gift card tokens
                {
                    TokenGroupNames.GiftCardTokens,
                    new[]
                    {
                        "%GiftCard.SenderName%",
                        "%GiftCard.SenderEmail%",
                        "%GiftCard.RecipientName%",
                        "%GiftCard.RecipientEmail%",
                        "%GiftCard.Amount%",
                        "%GiftCard.CouponCode%",
                        "%GiftCard.Message%"
                    }
                },

                //product review tokens
                {
                    TokenGroupNames.ProductReviewTokens,
                    new[]
                    {
                        "%ProductReview.ProductName%",
                        "%ProductReview.Title%",
                        "%ProductReview.IsApproved%",
                        "%ProductReview.ReviewText%",
                        "%ProductReview.ReplyText%"
                    }
                },

                //attribute combination tokens
                {
                    TokenGroupNames.AttributeCombinationTokens,
                    new[]
                    {
                        "%AttributeCombination.Formatted%",
                        "%AttributeCombination.SKU%",
                        "%AttributeCombination.StockQuantity%"
                    }
                },

                //blog comment tokens
                {
                    TokenGroupNames.BlogCommentTokens,
                    new[]
                    {
                        "%BlogComment.BlogPostTitle%"
                    }
                },

                //news comment tokens
                {
                    TokenGroupNames.NewsCommentTokens,
                    new[]
                    {
                        "%NewsComment.NewsTitle%"
                    }
                },

                //product back in stock tokens
                {
                    TokenGroupNames.ProductBackInStockTokens,
                    new[]
                    {
                        "%BackInStockSubscription.ProductName%",
                        "%BackInStockSubscription.ProductUrl%"
                    }
                },

                //email a friend tokens
                {
                    TokenGroupNames.EmailAFriendTokens,
                    new[]
                    {
                        "%EmailAFriend.PersonalMessage%",
                        "%EmailAFriend.Email%"
                    }
                },

                //wishlist to friend tokens
                {
                    TokenGroupNames.WishlistToFriendTokens,
                    new[]
                    {
                        "%Wishlist.PersonalMessage%",
                        "%Wishlist.Email%"
                    }
                },

                //VAT validation tokens
                {
                    TokenGroupNames.VatValidation,
                    new[]
                    {
                        "%VatValidationResult.Name%",
                        "%VatValidationResult.Address%"
                    }
                },

                //contact us tokens
                {
                    TokenGroupNames.ContactUs,
                    new[]
                    {
                        "%ContactUs.SenderEmail%",
                        "%ContactUs.SenderName%",
                        "%ContactUs.Body%"
                    }
                },

                //contact vendor tokens
                {
                    TokenGroupNames.ContactVendor,
                    new[]
                    {
                        "%ContactUs.SenderEmail%",
                        "%ContactUs.SenderName%",
                        "%ContactUs.Body%"
                    }
                }
            };

            return _allowedTokens;
        }
    }

    #endregion

    #region Utilities
   

    /// <summary>
    /// Generates an absolute URL for the specified store, routeName and route values
    /// </summary>
    /// <param name="storeId">Store identifier; Pass 0 to load URL of the current store</param>
    /// <param name="routeName">The name of the route that is used to generate URL</param>
    /// <param name="routeValues">An object that contains route values</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the generated URL
    /// </returns>
    protected virtual async Task<string> RouteUrlAsync(int storeId = 0, string routeName = null, object routeValues = null)
    {
        try
        {
            //try to get a store by the passed identifier
            var store = await _storeService.GetStoreByIdAsync(storeId) ?? await _storeContext.GetCurrentStoreAsync()
                ?? throw new Exception("No store could be loaded");

            //ensure that the store URL is specified
            if (string.IsNullOrEmpty(store.Url))
                throw new Exception("Store URL cannot be empty");

            //generate the relative URL
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);
            var url = urlHelper.RouteUrl(routeName, routeValues);

            //compose the result
            return new Uri(new Uri(store.Url), url).AbsoluteUri;
        }
        catch (Exception exception)
        {
            var warning = $"When sending a notification, an error occurred while creating a link for '{routeName}', ensure that URL of the store #{storeId} is correct.";
            await _logger.WarningAsync(warning, exception);

            return string.Empty;
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Add store tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="store">Store</param>
    /// <param name="emailAccount">Email account</param>
    /// <param name="languageId">Language identifier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task AddStoreTokensAsync(IList<Token> tokens, Store store, EmailAccount emailAccount, int languageId)
    {
        ArgumentNullException.ThrowIfNull(emailAccount);

        tokens.Add(new Token("Store.Name", await _localizationService.GetLocalizedAsync(store, x => x.Name, languageId)));
        tokens.Add(new Token("Store.URL", store.Url, true));
        tokens.Add(new Token("Store.Email", emailAccount.Email));
        tokens.Add(new Token("Store.CompanyName", store.CompanyName));
        tokens.Add(new Token("Store.CompanyAddress", store.CompanyAddress));
        tokens.Add(new Token("Store.CompanyPhoneNumber", store.CompanyPhoneNumber));
        tokens.Add(new Token("Store.CompanyVat", store.CompanyVat));

        tokens.Add(new Token("Facebook.URL", _storeInformationSettings.FacebookLink));
        tokens.Add(new Token("Twitter.URL", _storeInformationSettings.TwitterLink));
        tokens.Add(new Token("YouTube.URL", _storeInformationSettings.YoutubeLink));
        tokens.Add(new Token("Instagram.URL", _storeInformationSettings.InstagramLink));

        //event notification
        await _eventPublisher.EntityTokensAddedAsync(store, tokens);
    }


    /// <summary>
    /// Add refunded order tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="order">Order</param>
    /// <param name="refundedAmount">Refunded amount of order</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task AddOrderRefundedTokensAsync(IList<Token> tokens, Order order, decimal refundedAmount)
    {
        //should we convert it to customer currency?
        //most probably, no. It can cause some rounding or legal issues
        //furthermore, exchange rate could be changed
        //so let's display it the primary store currency

        var primaryStoreCurrencyCode = (await _currencyService.GetCurrencyByIdAsync(_currencySettings.PrimaryStoreCurrencyId)).CurrencyCode;
        var refundedAmountStr = await _priceFormatter.FormatPriceAsync(refundedAmount, true, primaryStoreCurrencyCode, false, (await _workContext.GetWorkingLanguageAsync()).Id);

        tokens.Add(new Token("Order.AmountRefunded", refundedAmountStr));

        //event notification
        await _eventPublisher.EntityTokensAddedAsync(order, tokens);
    }

    /// <summary>
    /// Add return request tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="returnRequest">Return request</param>
    /// <param name="orderItem">Order item</param>
    /// <param name="languageId">Language identifier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task AddReturnRequestTokensAsync(IList<Token> tokens, ReturnRequest returnRequest, OrderItem orderItem, int languageId)
    {
        var product = await _productService.GetProductByIdAsync(orderItem.ProductId);

        tokens.Add(new Token("ReturnRequest.CustomNumber", returnRequest.CustomNumber));
        tokens.Add(new Token("ReturnRequest.OrderId", orderItem.OrderId));
        tokens.Add(new Token("ReturnRequest.Product.Quantity", returnRequest.Quantity));
        tokens.Add(new Token("ReturnRequest.Product.Name", await _localizationService.GetLocalizedAsync(product, x => x.Name, languageId)));
        tokens.Add(new Token("ReturnRequest.Reason", returnRequest.ReasonForReturn));
        tokens.Add(new Token("ReturnRequest.RequestedAction", returnRequest.RequestedAction));
        tokens.Add(new Token("ReturnRequest.CustomerComment", _htmlFormatter.FormatText(returnRequest.CustomerComments, false, true, false, false, false, false), true));
        tokens.Add(new Token("ReturnRequest.StaffNotes", _htmlFormatter.FormatText(returnRequest.StaffNotes, false, true, false, false, false, false), true));
        tokens.Add(new Token("ReturnRequest.Status", await _localizationService.GetLocalizedEnumAsync(returnRequest.ReturnRequestStatus, languageId)));

        //event notification
        await _eventPublisher.EntityTokensAddedAsync(returnRequest, tokens);
    }

    /// <summary>
    /// Add gift card tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="giftCard">Gift card</param>
    /// <param name="languageId">Language identifier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task AddGiftCardTokensAsync(IList<Token> tokens, GiftCard giftCard, int languageId)
    {
        tokens.Add(new Token("GiftCard.SenderName", giftCard.SenderName));
        tokens.Add(new Token("GiftCard.SenderEmail", giftCard.SenderEmail));
        tokens.Add(new Token("GiftCard.RecipientName", giftCard.RecipientName));
        tokens.Add(new Token("GiftCard.RecipientEmail", giftCard.RecipientEmail));

        var primaryStoreCurrency = await _currencyService.GetCurrencyByIdAsync(_currencySettings.PrimaryStoreCurrencyId);
        tokens.Add(new Token("GiftCard.Amount", await _priceFormatter.FormatPriceAsync(giftCard.Amount, true, primaryStoreCurrency.CurrencyCode, false, languageId)));
        tokens.Add(new Token("GiftCard.CouponCode", giftCard.GiftCardCouponCode));

        var giftCardMessage = !string.IsNullOrWhiteSpace(giftCard.Message) ?
            _htmlFormatter.FormatText(giftCard.Message, false, true, false, false, false, false) : string.Empty;

        tokens.Add(new Token("GiftCard.Message", giftCardMessage, true));

        //event notification
        await _eventPublisher.EntityTokensAddedAsync(giftCard, tokens);
    }

    /// <summary>
    /// Add customer tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="customerId">Customer identifier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task AddCustomerTokensAsync(IList<Token> tokens, int customerId)
    {
        if (customerId <= 0)
            throw new ArgumentOutOfRangeException(nameof(customerId));

        var customer = await _customerService.GetCustomerByIdAsync(customerId);

        await AddCustomerTokensAsync(tokens, customer);
    }

    /// <summary>
    /// Add customer tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="customer">Customer</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task AddCustomerTokensAsync(IList<Token> tokens, Customer customer)
    {
        tokens.Add(new Token("Customer.Email", customer.Email));
        tokens.Add(new Token("Customer.Username", customer.Username));
        tokens.Add(new Token("Customer.FullName", await _customerService.GetCustomerFullNameAsync(customer)));
        tokens.Add(new Token("Customer.FirstName", customer.FirstName));
        tokens.Add(new Token("Customer.LastName", customer.LastName));
        tokens.Add(new Token("Customer.VatNumber", customer.VatNumber));
        tokens.Add(new Token("Customer.VatNumberStatus", ((VatNumberStatus)customer.VatNumberStatusId).ToString()));

        var customAttributesXml = customer.CustomCustomerAttributesXML;
        tokens.Add(new Token("Customer.CustomAttributes", await _customerAttributeFormatter.FormatAttributesAsync(customAttributesXml), true));

        //note: we do not use SEO friendly URLS for these links because we can get errors caused by having .(dot) in the URL (from the email address)
        var passwordRecoveryUrl = await RouteUrlAsync(routeName: "PasswordRecoveryConfirm", routeValues: new { token = await _genericAttributeService.GetAttributeAsync<string>(customer, NopCustomerDefaults.PasswordRecoveryTokenAttribute), guid = customer.CustomerGuid });
        var accountActivationUrl = await RouteUrlAsync(routeName: "AccountActivation", routeValues: new { token = await _genericAttributeService.GetAttributeAsync<string>(customer, NopCustomerDefaults.AccountActivationTokenAttribute), guid = customer.CustomerGuid });
        var emailRevalidationUrl = await RouteUrlAsync(routeName: "EmailRevalidation", routeValues: new { token = await _genericAttributeService.GetAttributeAsync<string>(customer, NopCustomerDefaults.EmailRevalidationTokenAttribute), guid = customer.CustomerGuid });
        var wishlistUrl = await RouteUrlAsync(routeName: "Wishlist", routeValues: new { customerGuid = customer.CustomerGuid });
        tokens.Add(new Token("Customer.PasswordRecoveryURL", passwordRecoveryUrl, true));
        tokens.Add(new Token("Customer.AccountActivationURL", accountActivationUrl, true));
        tokens.Add(new Token("Customer.EmailRevalidationURL", emailRevalidationUrl, true));
        tokens.Add(new Token("Wishlist.URLForCustomer", wishlistUrl, true));

        //event notification
        await _eventPublisher.EntityTokensAddedAsync(customer, tokens);
    }

    /// <summary>
    /// Add vendor tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="vendor">Vendor</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task AddVendorTokensAsync(IList<Token> tokens, Vendor vendor)
    {
        tokens.Add(new Token("Vendor.Name", vendor.Name));
        tokens.Add(new Token("Vendor.Email", vendor.Email));

        var vendorAttributesXml = await _genericAttributeService.GetAttributeAsync<string>(vendor, NopVendorDefaults.VendorAttributes);
        tokens.Add(new Token("Vendor.VendorAttributes", await _vendorAttributeFormatter.FormatAttributesAsync(vendorAttributesXml), true));

        //event notification
        await _eventPublisher.EntityTokensAddedAsync(vendor, tokens);
    }

    /// <summary>
    /// Add newsletter subscription tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="subscription">Newsletter subscription</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task AddNewsLetterSubscriptionTokensAsync(IList<Token> tokens, NewsLetterSubscription subscription)
    {
        tokens.Add(new Token("NewsLetterSubscription.Email", subscription.Email));

        var activationUrl = await RouteUrlAsync(routeName: "NewsletterActivation", routeValues: new { token = subscription.NewsLetterSubscriptionGuid, active = "true" });
        tokens.Add(new Token("NewsLetterSubscription.ActivationUrl", activationUrl, true));

        var deactivationUrl = await RouteUrlAsync(routeName: "NewsletterActivation", routeValues: new { token = subscription.NewsLetterSubscriptionGuid, active = "false" });
        tokens.Add(new Token("NewsLetterSubscription.DeactivationUrl", deactivationUrl, true));

        //event notification
        await _eventPublisher.EntityTokensAddedAsync(subscription, tokens);
    }

    /// <summary>
    /// Add product review tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="productReview">Product review</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task AddProductReviewTokensAsync(IList<Token> tokens, ProductReview productReview)
    {
        tokens.Add(new Token("ProductReview.ProductName", (await _productService.GetProductByIdAsync(productReview.ProductId))?.Name));
        tokens.Add(new Token("ProductReview.Title", productReview.Title));
        tokens.Add(new Token("ProductReview.IsApproved", productReview.IsApproved));
        tokens.Add(new Token("ProductReview.ReviewText", productReview.ReviewText));
        tokens.Add(new Token("ProductReview.ReplyText", productReview.ReplyText));

        //event notification
        await _eventPublisher.EntityTokensAddedAsync(productReview, tokens);
    }

    /// <summary>
    /// Add product tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="product">Product</param>
    /// <param name="languageId">Language identifier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task AddProductTokensAsync(IList<Token> tokens, Product product, int languageId)
    {
        tokens.Add(new Token("Product.ID", product.Id));
        tokens.Add(new Token("Product.Name", await _localizationService.GetLocalizedAsync(product, x => x.Name, languageId)));
        tokens.Add(new Token("Product.ShortDescription", await _localizationService.GetLocalizedAsync(product, x => x.ShortDescription, languageId), true));
        tokens.Add(new Token("Product.SKU", product.Sku));
        tokens.Add(new Token("Product.StockQuantity", await _productService.GetTotalStockQuantityAsync(product)));

        var seName = await _urlRecordService.GetSeNameAsync(product);
        var productUrl = await RouteUrlAsync(routeName: "ProductDetails", routeValues: new { SeName = seName });
        tokens.Add(new Token("Product.ProductURLForCustomer", productUrl, true));

        //event notification
        await _eventPublisher.EntityTokensAddedAsync(product, tokens);
    }

    /// <summary>
    /// Add product attribute combination tokens
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="combination">Product attribute combination</param>
    /// <param name="languageId">Language identifier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task AddAttributeCombinationTokensAsync(IList<Token> tokens, ProductAttributeCombination combination, int languageId)
    {
        //attributes
        //we cannot inject IProductAttributeFormatter into constructor because it'll cause circular references.
        //that's why we resolve it here this way
        var productAttributeFormatter = EngineContext.Current.Resolve<IProductAttributeFormatter>();

        var product = await _productService.GetProductByIdAsync(combination.ProductId);
        var currentCustomer = await _workContext.GetCurrentCustomerAsync();
        var currentStore = await _storeContext.GetCurrentStoreAsync();

        var attributes = await productAttributeFormatter.FormatAttributesAsync(product,
            combination.AttributesXml,
            currentCustomer,
            currentStore,
            renderPrices: false);

        tokens.Add(new Token("AttributeCombination.Formatted", attributes, true));
        tokens.Add(new Token("AttributeCombination.SKU", await _productService.FormatSkuAsync(await _productService.GetProductByIdAsync(combination.ProductId), combination.AttributesXml)));
        tokens.Add(new Token("AttributeCombination.StockQuantity", combination.StockQuantity));

        //event notification
        await _eventPublisher.EntityTokensAddedAsync(combination, tokens);
    }
   
    /// <summary>
    /// Add tokens of BackInStock subscription
    /// </summary>
    /// <param name="tokens">List of already added tokens</param>
    /// <param name="subscription">BackInStock subscription</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task AddBackInStockTokensAsync(IList<Token> tokens, BackInStockSubscription subscription)
    {
        var product = await _productService.GetProductByIdAsync(subscription.ProductId);

        tokens.Add(new Token("BackInStockSubscription.ProductName", product.Name));
        var productUrl = await RouteUrlAsync(subscription.StoreId, "Product", new { SeName = await _urlRecordService.GetSeNameAsync(product) });
        tokens.Add(new Token("BackInStockSubscription.ProductUrl", productUrl, true));

        //event notification
        await _eventPublisher.EntityTokensAddedAsync(subscription, tokens);
    }

    /// <summary>
    /// Get collection of allowed (supported) message tokens for campaigns
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the collection of allowed (supported) message tokens for campaigns
    /// </returns>
    public virtual async Task<IEnumerable<string>> GetListOfCampaignAllowedTokensAsync()
    {
        var additionalTokens = new CampaignAdditionalTokensAddedEvent();
        await _eventPublisher.PublishAsync(additionalTokens);

        var allowedTokens = (await GetListOfAllowedTokensAsync(new[] { TokenGroupNames.StoreTokens, TokenGroupNames.SubscriptionTokens })).ToList();
        allowedTokens.AddRange(additionalTokens.AdditionalTokens);

        return allowedTokens.Distinct();
    }

    /// <summary>
    /// Get collection of allowed (supported) message tokens
    /// </summary>
    /// <param name="tokenGroups">Collection of token groups; pass null to get all available tokens</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the collection of allowed message tokens
    /// </returns>
    public virtual async Task<IEnumerable<string>> GetListOfAllowedTokensAsync(IEnumerable<string> tokenGroups = null)
    {
        var additionalTokens = new AdditionalTokensAddedEvent
        {
            TokenGroups = tokenGroups
        };
        await _eventPublisher.PublishAsync(additionalTokens);

        var allowedTokens = AllowedTokens.Where(x => tokenGroups == null || tokenGroups.Contains(x.Key))
            .SelectMany(x => x.Value).ToList();

        allowedTokens.AddRange(additionalTokens.AdditionalTokens);

        return allowedTokens.Distinct();
    }

    /// <summary>
    /// Get token groups of message template
    /// </summary>
    /// <param name="messageTemplate">Message template</param>
    /// <returns>Collection of token group names</returns>
    public virtual IEnumerable<string> GetTokenGroups(MessageTemplate messageTemplate)
    {
        //groups depend on which tokens are added at the appropriate methods in IWorkflowMessageService
        return messageTemplate.Name switch
        {
            MessageTemplateSystemNames.CUSTOMER_REGISTERED_STORE_OWNER_NOTIFICATION or
                MessageTemplateSystemNames.CUSTOMER_WELCOME_MESSAGE or
                MessageTemplateSystemNames.CUSTOMER_EMAIL_VALIDATION_MESSAGE or
                MessageTemplateSystemNames.CUSTOMER_EMAIL_REVALIDATION_MESSAGE or
                MessageTemplateSystemNames.CUSTOMER_PASSWORD_RECOVERY_MESSAGE or
                MessageTemplateSystemNames.DELETE_CUSTOMER_REQUEST_STORE_OWNER_NOTIFICATION => new[] { TokenGroupNames.StoreTokens, TokenGroupNames.CustomerTokens },

            MessageTemplateSystemNames.ORDER_PLACED_VENDOR_NOTIFICATION or
                MessageTemplateSystemNames.ORDER_PLACED_STORE_OWNER_NOTIFICATION or
                MessageTemplateSystemNames.ORDER_PLACED_AFFILIATE_NOTIFICATION or
                MessageTemplateSystemNames.ORDER_PAID_STORE_OWNER_NOTIFICATION or
                MessageTemplateSystemNames.ORDER_PAID_CUSTOMER_NOTIFICATION or
                MessageTemplateSystemNames.ORDER_PAID_VENDOR_NOTIFICATION or
                MessageTemplateSystemNames.ORDER_PAID_AFFILIATE_NOTIFICATION or
                MessageTemplateSystemNames.ORDER_PLACED_CUSTOMER_NOTIFICATION or
                MessageTemplateSystemNames.ORDER_PROCESSING_CUSTOMER_NOTIFICATION or
                MessageTemplateSystemNames.ORDER_COMPLETED_CUSTOMER_NOTIFICATION or
                MessageTemplateSystemNames.ORDER_CANCELLED_VENDOR_NOTIFICATION or
                MessageTemplateSystemNames.ORDER_CANCELLED_CUSTOMER_NOTIFICATION => [TokenGroupNames.StoreTokens, TokenGroupNames.OrderTokens, TokenGroupNames.CustomerTokens],

            MessageTemplateSystemNames.SHIPMENT_SENT_CUSTOMER_NOTIFICATION or
            MessageTemplateSystemNames.SHIPMENT_READY_FOR_PICKUP_CUSTOMER_NOTIFICATION or
            MessageTemplateSystemNames.SHIPMENT_DELIVERED_CUSTOMER_NOTIFICATION => [TokenGroupNames.StoreTokens, TokenGroupNames.ShipmentTokens, TokenGroupNames.OrderTokens, TokenGroupNames.CustomerTokens],

            MessageTemplateSystemNames.ORDER_REFUNDED_STORE_OWNER_NOTIFICATION or
            MessageTemplateSystemNames.ORDER_REFUNDED_CUSTOMER_NOTIFICATION => [TokenGroupNames.StoreTokens, TokenGroupNames.OrderTokens, TokenGroupNames.RefundedOrderTokens, TokenGroupNames.CustomerTokens],

            MessageTemplateSystemNames.NEW_ORDER_NOTE_ADDED_CUSTOMER_NOTIFICATION => [TokenGroupNames.StoreTokens, TokenGroupNames.OrderNoteTokens, TokenGroupNames.OrderTokens, TokenGroupNames.CustomerTokens],

            MessageTemplateSystemNames.RECURRING_PAYMENT_CANCELLED_STORE_OWNER_NOTIFICATION or
            MessageTemplateSystemNames.RECURRING_PAYMENT_CANCELLED_CUSTOMER_NOTIFICATION or
            MessageTemplateSystemNames.RECURRING_PAYMENT_FAILED_CUSTOMER_NOTIFICATION => [TokenGroupNames.StoreTokens, TokenGroupNames.OrderTokens, TokenGroupNames.CustomerTokens, TokenGroupNames.RecurringPaymentTokens],

            MessageTemplateSystemNames.NEWSLETTER_SUBSCRIPTION_ACTIVATION_MESSAGE or
            MessageTemplateSystemNames.NEWSLETTER_SUBSCRIPTION_DEACTIVATION_MESSAGE => [TokenGroupNames.StoreTokens, TokenGroupNames.SubscriptionTokens],

            MessageTemplateSystemNames.EMAIL_A_FRIEND_MESSAGE => [TokenGroupNames.StoreTokens, TokenGroupNames.CustomerTokens, TokenGroupNames.ProductTokens, TokenGroupNames.EmailAFriendTokens],
            MessageTemplateSystemNames.WISHLIST_TO_FRIEND_MESSAGE => [TokenGroupNames.StoreTokens, TokenGroupNames.CustomerTokens, TokenGroupNames.WishlistToFriendTokens],

            MessageTemplateSystemNames.NEW_RETURN_REQUEST_STORE_OWNER_NOTIFICATION or
            MessageTemplateSystemNames.NEW_RETURN_REQUEST_CUSTOMER_NOTIFICATION or
            MessageTemplateSystemNames.RETURN_REQUEST_STATUS_CHANGED_CUSTOMER_NOTIFICATION => [TokenGroupNames.StoreTokens, TokenGroupNames.OrderTokens, TokenGroupNames.CustomerTokens, TokenGroupNames.ReturnRequestTokens],

            MessageTemplateSystemNames.NEW_FORUM_TOPIC_MESSAGE => [TokenGroupNames.StoreTokens, TokenGroupNames.ForumTopicTokens, TokenGroupNames.ForumTokens, TokenGroupNames.CustomerTokens],
            MessageTemplateSystemNames.NEW_FORUM_POST_MESSAGE => [TokenGroupNames.StoreTokens, TokenGroupNames.ForumPostTokens, TokenGroupNames.ForumTopicTokens, TokenGroupNames.ForumTokens, TokenGroupNames.CustomerTokens],
            MessageTemplateSystemNames.PRIVATE_MESSAGE_NOTIFICATION => [TokenGroupNames.StoreTokens, TokenGroupNames.PrivateMessageTokens, TokenGroupNames.CustomerTokens],
            MessageTemplateSystemNames.NEW_VENDOR_ACCOUNT_APPLY_STORE_OWNER_NOTIFICATION => [TokenGroupNames.StoreTokens, TokenGroupNames.CustomerTokens, TokenGroupNames.VendorTokens],
            MessageTemplateSystemNames.VENDOR_INFORMATION_CHANGE_STORE_OWNER_NOTIFICATION => [TokenGroupNames.StoreTokens, TokenGroupNames.VendorTokens],
            MessageTemplateSystemNames.GIFT_CARD_NOTIFICATION => [TokenGroupNames.StoreTokens, TokenGroupNames.GiftCardTokens],

            MessageTemplateSystemNames.PRODUCT_REVIEW_STORE_OWNER_NOTIFICATION or
            MessageTemplateSystemNames.PRODUCT_REVIEW_REPLY_CUSTOMER_NOTIFICATION => [TokenGroupNames.StoreTokens, TokenGroupNames.ProductReviewTokens, TokenGroupNames.CustomerTokens],

            MessageTemplateSystemNames.QUANTITY_BELOW_STORE_OWNER_NOTIFICATION => [TokenGroupNames.StoreTokens, TokenGroupNames.ProductTokens],
            MessageTemplateSystemNames.QUANTITY_BELOW_ATTRIBUTE_COMBINATION_STORE_OWNER_NOTIFICATION => [TokenGroupNames.StoreTokens, TokenGroupNames.ProductTokens, TokenGroupNames.AttributeCombinationTokens],
            MessageTemplateSystemNames.NEW_VAT_SUBMITTED_STORE_OWNER_NOTIFICATION => [TokenGroupNames.StoreTokens, TokenGroupNames.CustomerTokens, TokenGroupNames.VatValidation],
            MessageTemplateSystemNames.BLOG_COMMENT_STORE_OWNER_NOTIFICATION => [TokenGroupNames.StoreTokens, TokenGroupNames.BlogCommentTokens, TokenGroupNames.CustomerTokens],
            MessageTemplateSystemNames.NEWS_COMMENT_STORE_OWNER_NOTIFICATION => [TokenGroupNames.StoreTokens, TokenGroupNames.NewsCommentTokens, TokenGroupNames.CustomerTokens],
            MessageTemplateSystemNames.BACK_IN_STOCK_NOTIFICATION => [TokenGroupNames.StoreTokens, TokenGroupNames.CustomerTokens, TokenGroupNames.ProductBackInStockTokens],
            MessageTemplateSystemNames.CONTACT_US_MESSAGE => [TokenGroupNames.StoreTokens, TokenGroupNames.ContactUs],
            MessageTemplateSystemNames.CONTACT_VENDOR_MESSAGE => [TokenGroupNames.StoreTokens, TokenGroupNames.ContactVendor],
            _ => [],
        };
    }

    #endregion
}
