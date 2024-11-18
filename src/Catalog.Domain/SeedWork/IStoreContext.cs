using Catalog.Domain.AggregatesModel.Stores;


namespace Catalog.Domain.SeedWork;

/// <summary>
/// Store context
/// </summary>
public partial interface IStoreContext
{
    /// <summary>
    /// Gets the current store
    /// </summary>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task<Store> GetCurrentStoreAsync();

    /// <summary>
    /// Gets the current store
    /// </summary>
    Store GetCurrentStore();

    /// <summary>
    /// Gets active store scope configuration
    /// </summary>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task<int> GetActiveStoreScopeConfigurationAsync();
}
