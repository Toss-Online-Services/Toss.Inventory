namespace Domain.Services.Customers;

/// <summary>
/// Represents a customer event consumer
/// </summary>
public class CustomerEventConsumer : IConsumer<CustomerChangeWorkingLanguageEvent>
{
    #region Fields

    protected readonly ICustomerService _customerService;
    protected readonly IStoreContext _storeContext;

    #endregion

    #region Ctor

    public CustomerEventConsumer(ICustomerService customerService,
        IStoreContext storeContext)
    {
        _customerService = customerService;
        _storeContext = storeContext;
    }

    #endregion

    #region Methods
    /// <summary>
    /// Handle working language changed event
    /// </summary>
    /// <param name="eventMessage">Event message</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public async Task HandleEventAsync(CustomerChangeWorkingLanguageEvent eventMessage)
    {
        if (eventMessage.Customer is not Customer customer)
            return;

        if (await _customerService.IsGuestAsync(customer))
            return;

        var store = await _storeContext.GetCurrentStoreAsync();
       
    }

    #endregion
}
