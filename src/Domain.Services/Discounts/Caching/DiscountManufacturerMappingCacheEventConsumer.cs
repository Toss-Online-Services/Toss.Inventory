namespace Domain.Services.Discounts.Caching;

/// <summary>
/// Represents a discount-manufacturer mapping cache event consumer
/// </summary>
public partial class DiscountManufacturerMappingCacheEventConsumer : CacheEventConsumer<DiscountManufacturerMapping>
{
    protected override async Task ClearCacheAsync(DiscountManufacturerMapping entity)
    {
        await RemoveAsync(NopDiscountDefaults.AppliedDiscountsCacheKey, nameof(Manufacturer), entity.EntityId);

        await base.ClearCacheAsync(entity);
    }
}