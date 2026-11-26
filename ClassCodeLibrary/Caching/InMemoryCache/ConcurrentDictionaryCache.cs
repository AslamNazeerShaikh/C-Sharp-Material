using System.Collections.Concurrent;
using System.Collections.Frozen;

namespace ClassCodeLibrary.Caching.InMemoryCache;

/// <summary>
/// A thread-safe in-memory cache backed by <see cref="ConcurrentDictionary{TKey,TValue}"/>
/// with async-friendly APIs.
/// </summary>
/// <typeparam name="TKey">Key type.</typeparam>
/// <typeparam name="TValue">Value type.</typeparam>
public sealed class ConcurrentDictionaryCache<TKey, TValue> : ICache<TKey, TValue>
    where TKey : notnull
{
    private readonly ConcurrentDictionary<TKey, CacheEntry<TValue>> _entries = new();
    private readonly TimeProvider _timeProvider;
    private readonly CacheOptions _options;

    /// <summary>
    /// Creates a new thread-safe cache. Dependencies are injected via the constructor.
    /// </summary>
    public ConcurrentDictionaryCache(TimeProvider timeProvider, CacheOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(timeProvider);
        _timeProvider = timeProvider;
        _options = options ?? new CacheOptions();
    }

    // shortcut: Count cleans expired entries and is O(n); avoid in hot loops.
    /// <inheritdoc />
    public int Count
    {
        get
        {
            CleanupExpired();
            return _entries.Count;
        }
    }

    private DateTimeOffset Now => _timeProvider.GetUtcNow();

    private DateTimeOffset? ComputeExpiry() => _options.DefaultTtl is { } ttl ? Now.Add(ttl) : null;

    private void CleanupExpired()
    {
        var now = Now;
        foreach (
            var key in _entries.Where(kv => !kv.Value.IsAlive(now)).Select(kv => kv.Key).ToList()
        )
        {
            _entries.TryRemove(key, out _);
        }
    }

    /// <inheritdoc />
    public bool TryGet(TKey key, out TValue? value)
    {
        ArgumentNullException.ThrowIfNull(key);

        if (_entries.TryGetValue(key, out var entry) && entry.IsAlive(Now))
        {
            value = entry.Value;
            return true;
        }

        _entries.TryRemove(key, out _);
        value = default;
        return false;
    }

    // shortcut: async methods are synchronous wrappers; no I/O offloading.
    /// <inheritdoc />
    public async Task<(bool Success, TValue? Value)> TryGetAsync(
        TKey key,
        CancellationToken cancellationToken = default
    )
    {
        cancellationToken.ThrowIfCancellationRequested();
        await Task.CompletedTask.ConfigureAwait(false);
        return (TryGet(key, out var value), value);
    }

    /// <inheritdoc />
    public bool TryAdd(TKey key, TValue value) => TryAdd(key, value, out _);

    // shortcut: capacity and expiry checks are not atomic under concurrent writes; upgrade to a lock if strict limits matter.
    /// <inheritdoc />
    public bool TryAdd(TKey key, TValue value, out TValue? existingValue)
    {
        ArgumentNullException.ThrowIfNull(key);

        CleanupExpired();

        if (_entries.TryGetValue(key, out var entry) && entry.IsAlive(Now))
        {
            existingValue = entry.Value;
            return false;
        }

        if (_options.Capacity is { } capacity && _entries.Count >= capacity)
        {
            existingValue = default;
            return false;
        }

        var added = _entries.TryAdd(key, new CacheEntry<TValue>(value, ComputeExpiry()));
        if (!added)
        {
            // Lost a race; report the current value.
            if (_entries.TryGetValue(key, out entry) && entry.IsAlive(Now))
            {
                existingValue = entry.Value;
            }
            else
            {
                existingValue = default;
            }

            return false;
        }

        existingValue = default;
        return true;
    }

    /// <inheritdoc />
    public async Task<bool> TryAddAsync(
        TKey key,
        TValue value,
        CancellationToken cancellationToken = default
    )
    {
        cancellationToken.ThrowIfCancellationRequested();
        await Task.CompletedTask.ConfigureAwait(false);
        return TryAdd(key, value);
    }

    /// <inheritdoc />
    public bool TryUpdate(TKey key, TValue value, out TValue? oldValue)
    {
        ArgumentNullException.ThrowIfNull(key);

        if (!_entries.TryGetValue(key, out var entry) || !entry.IsAlive(Now))
        {
            _entries.TryRemove(key, out _);
            oldValue = default;
            return false;
        }

        oldValue = entry.Value;
        _entries[key] = new CacheEntry<TValue>(value, ComputeExpiry());
        return true;
    }

    /// <inheritdoc />
    public async Task<(bool Success, TValue? OldValue)> TryUpdateAsync(
        TKey key,
        TValue value,
        CancellationToken cancellationToken = default
    )
    {
        cancellationToken.ThrowIfCancellationRequested();
        await Task.CompletedTask.ConfigureAwait(false);
        return (TryUpdate(key, value, out var oldValue), oldValue);
    }

    /// <inheritdoc />
    public bool TryRemove(TKey key, out TValue? value)
    {
        ArgumentNullException.ThrowIfNull(key);

        if (_entries.TryGetValue(key, out var entry) && entry.IsAlive(Now))
        {
            _entries.TryRemove(key, out _);
            value = entry.Value;
            return true;
        }

        _entries.TryRemove(key, out _);
        value = default;
        return false;
    }

    /// <inheritdoc />
    public async Task<(bool Success, TValue? Value)> TryRemoveAsync(
        TKey key,
        CancellationToken cancellationToken = default
    )
    {
        cancellationToken.ThrowIfCancellationRequested();
        await Task.CompletedTask.ConfigureAwait(false);
        return (TryRemove(key, out var value), value);
    }

    /// <inheritdoc />
    public bool ContainsKey(TKey key) => TryGet(key, out _);

    /// <inheritdoc />
    public bool Set(TKey key, TValue value, out TValue? oldValue)
    {
        ArgumentNullException.ThrowIfNull(key);

        CleanupExpired();

        if (_entries.TryGetValue(key, out var entry) && entry.IsAlive(Now))
        {
            oldValue = entry.Value;
            _entries[key] = new CacheEntry<TValue>(value, ComputeExpiry());
            return false;
        }

        if (_options.Capacity is { } capacity && _entries.Count >= capacity)
        {
            oldValue = default;
            return false;
        }

        _entries[key] = new CacheEntry<TValue>(value, ComputeExpiry());
        oldValue = default;
        return true;
    }

    /// <inheritdoc />
    public void Clear() => _entries.Clear();

    /// <inheritdoc />
    public FrozenDictionary<TKey, TValue> ToFrozenSnapshot()
    {
        var now = Now;
        return _entries
            .Where(kv => kv.Value.IsAlive(now))
            .ToFrozenDictionary(kv => kv.Key, kv => kv.Value.Value);
    }
}
