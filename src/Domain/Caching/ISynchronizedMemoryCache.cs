using Microsoft.Extensions.Caching.Memory;

namespace Domain.Caching;

/// <summary>
/// Represents a local in-memory cache with distributed synchronization
/// </summary>
public partial interface ISynchronizedMemoryCache : IMemoryCache
{
}