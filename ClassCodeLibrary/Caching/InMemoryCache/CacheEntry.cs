namespace ClassCodeLibrary.Caching.InMemoryCache;

/// <summary>
/// Internal storage record for a cached value plus its optional expiry.
/// </summary>
/// <typeparam name="TValue">Cached value type.</typeparam>
/// <param name="Value">The cached value.</param>
/// <param name="ExpiresAt">Absolute expiry time in UTC, or <c>null</c> for no expiry.</param>
internal sealed record CacheEntry<TValue>(TValue Value, DateTimeOffset? ExpiresAt)
{
    /// <summary>
    /// Returns <c>true</c> when the entry has not expired relative to <paramref name="now"/>.
    /// </summary>
    public bool IsAlive(DateTimeOffset now) =>
        ExpiresAt is null || ExpiresAt > now;
}
