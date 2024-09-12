namespace Domain.Services.Discounts.Caching;

/// <summary>
/// Represents a discount-category mapping cache event consumer
/// </summary>
public partial class DiscountCategoryMappingCacheEventConsumer : CacheEventConsumer<DiscountCategoryMapping>
{
    protected override async Task ClearCacheAsync(DiscountCategoryMapping entity)
    {
        await RemoveAsync(NopDiscountDefaults.AppliedDiscountsCacheKey, nameof(Category), entity.EntityId);

        await base.ClearCacheAsync(entity);
    }
}