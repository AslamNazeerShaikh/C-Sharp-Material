using System.Collections.Frozen;

namespace ClassCodeLibrary.Caching.InMemoryCache;

/// <summary>
/// A small in-memory cache contract. CRUD methods return <c>true</c> on success and
/// expose related state through nullable <c>out</c> parameters.
/// </summary>
/// <typeparam name="TKey">Key type (must be non-null).</typeparam>
/// <typeparam name="TValue">Value type. For value types, nullable out parameters return <c>default</c> rather than <c>null</c>.</typeparam>
public interface ICache<TKey, TValue>
    where TKey : notnull
{
    /// <summary>Number of (non-expired) entries currently stored.</summary>
    int Count { get; }

    /// <summary>Tries to read a value without changing the cache.</summary>
    bool TryGet(TKey key, out TValue? value);

    /// <summary>Asynchronously reads a value.</summary>
    Task<(bool Success, TValue? Value)> TryGetAsync(
        TKey key,
        CancellationToken cancellationToken = default
    );

    /// <summary>Adds a value only when the key is absent.</summary>
    bool TryAdd(TKey key, TValue value);

    /// <summary>Adds a value only when the key is absent; reports the existing value on collision.</summary>
    bool TryAdd(TKey key, TValue value, out TValue? existingValue);

    /// <summary>Asynchronously adds a value only when the key is absent.</summary>
    Task<bool> TryAddAsync(TKey key, TValue value, CancellationToken cancellationToken = default);

    /// <summary>Updates an existing value and returns the previous value.</summary>
    bool TryUpdate(TKey key, TValue value, out TValue? oldValue);

    /// <summary>Asynchronously updates an existing value.</summary>
    Task<(bool Success, TValue? OldValue)> TryUpdateAsync(
        TKey key,
        TValue value,
        CancellationToken cancellationToken = default
    );

    /// <summary>Removes a value and returns it.</summary>
    bool TryRemove(TKey key, out TValue? value);

    /// <summary>Asynchronously removes a value.</summary>
    Task<(bool Success, TValue? Value)> TryRemoveAsync(
        TKey key,
        CancellationToken cancellationToken = default
    );

    /// <summary>Returns <c>true</c> when a non-expired entry exists for <paramref name="key"/>.</summary>
    bool ContainsKey(TKey key);

    /// <summary>Inserts or overwrites a value, reporting the previous value. Returns <c>true</c> when a new entry was added, <c>false</c> when an existing entry was updated or the cache was full.</summary>
    bool Set(TKey key, TValue value, out TValue? oldValue);

    /// <summary>Removes all entries.</summary>
    void Clear();

    /// <summary>Creates an immutable, read-optimized snapshot of the current (non-expired) entries.</summary>
    FrozenDictionary<TKey, TValue> ToFrozenSnapshot();
}
