namespace ClassCodeLibrary.Caching.InMemoryCache;

/// <summary>
/// Configuration options for an in-memory cache.
/// </summary>
/// <param name="DefaultTtl">
/// Default time-to-live applied to entries that do not specify one. <c>null</c> means no expiry.
/// </param>
/// <param name="Capacity">
/// Maximum number of entries. <c>null</c> means unbounded.
/// </param>
public sealed record CacheOptions(TimeSpan? DefaultTtl = null, int? Capacity = null);
