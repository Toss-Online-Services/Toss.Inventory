using Domain.Services.Localization;

namespace Domain.Services.Stores.Caching;

/// <summary>
/// Represents a store cache event consumer
/// </summary>
public partial class StoreCacheEventConsumer : CacheEventConsumer<Store>
{
    /// <summary>
    /// Clear cache data
    /// </summary>
    /// <param name="entity">Entity</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    protected override async Task ClearCacheAsync(Store entity)
    {
        await RemoveByPrefixAsync(NopEntityCacheDefaults<ShoppingCartItem>.AllPrefix);
        await RemoveByPrefixAsync(NopLocalizationDefaults.LanguagesByStorePrefix, entity);
    }
}