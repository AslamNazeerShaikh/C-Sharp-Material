using System.Threading;
using ClassCodeLibrary.Caching.InMemoryCache;

namespace CSharpCodePractice.Tests.Caching;

public class DictionaryCacheTests
{
    [Fact]
    public void Constructor_NullTimeProvider_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => new DictionaryCache<string, int>(null!));
    }

    [Fact]
    public void TryGet_Missing_ReturnsFalseAndNull()
    {
        var cache = new DictionaryCache<string, int>(TimeProvider.System);
        var found = cache.TryGet("missing", out var value);

        Assert.False(found);
        Assert.Equal(default, value);
    }

    [Fact]
    public void TryAdd_NewKey_ReturnsTrue()
    {
        var cache = new DictionaryCache<string, int>(TimeProvider.System);
        Assert.True(cache.TryAdd("a", 1));
        Assert.True(cache.TryGet("a", out var value));
        Assert.Equal(1, value);
    }

    [Fact]
    public void TryAdd_DuplicateKey_ReturnsFalseAndReportsExisting()
    {
        var cache = new DictionaryCache<string, int>(TimeProvider.System);
        cache.TryAdd("a", 1);

        var added = cache.TryAdd("a", 2, out var existing);

        Assert.False(added);
        Assert.Equal(1, existing);
        Assert.True(cache.TryGet("a", out var value));
        Assert.Equal(1, value);
    }

    [Fact]
    public void TryUpdate_ExistingKey_UpdatesAndReportsOldValue()
    {
        var cache = new DictionaryCache<string, int>(TimeProvider.System);
        cache.TryAdd("a", 1);

        var updated = cache.TryUpdate("a", 9, out var oldValue);

        Assert.True(updated);
        Assert.Equal(1, oldValue);
        Assert.True(cache.TryGet("a", out var value));
        Assert.Equal(9, value);
    }

    [Fact]
    public void TryUpdate_MissingKey_ReturnsFalse()
    {
        var cache = new DictionaryCache<string, int>(TimeProvider.System);
        var updated = cache.TryUpdate("missing", 9, out var oldValue);

        Assert.False(updated);
        Assert.Equal(default, oldValue);
    }

    [Fact]
    public void TryRemove_ExistingKey_RemovesAndReturnsValue()
    {
        var cache = new DictionaryCache<string, int>(TimeProvider.System);
        cache.TryAdd("a", 1);

        var removed = cache.TryRemove("a", out var value);

        Assert.True(removed);
        Assert.Equal(1, value);
        Assert.False(cache.ContainsKey("a"));
    }

    [Fact]
    public void Set_NewKey_ReturnsTrueOldValueNull()
    {
        var cache = new DictionaryCache<string, int>(TimeProvider.System);
        var added = cache.Set("a", 1, out var oldValue);

        Assert.True(added);
        Assert.Equal(default, oldValue);
    }

    [Fact]
    public void Set_ExistingKey_ReturnsFalseAndOldValue()
    {
        var cache = new DictionaryCache<string, int>(TimeProvider.System);
        cache.TryAdd("a", 1);

        var added = cache.Set("a", 2, out var oldValue);

        Assert.False(added);
        Assert.Equal(1, oldValue);
        Assert.True(cache.TryGet("a", out var value));
        Assert.Equal(2, value);
    }

    [Fact]
    public void Ttl_ExpiresEntry()
    {
        var timeProvider = new FakeTimeProvider(DateTimeOffset.UtcNow);
        var cache = new DictionaryCache<string, int>(
            timeProvider,
            new CacheOptions(TimeSpan.FromSeconds(5))
        );
        cache.TryAdd("a", 1);

        timeProvider.Advance(TimeSpan.FromSeconds(10));

        Assert.False(cache.TryGet("a", out _));
        Assert.Equal(0, cache.Count);
    }

    [Fact]
    public void FrozenSnapshot_ContainsOnlyAliveEntries()
    {
        var timeProvider = new FakeTimeProvider(DateTimeOffset.UtcNow);
        var cache = new DictionaryCache<string, int>(
            timeProvider,
            new CacheOptions(TimeSpan.FromSeconds(5))
        );
        cache.TryAdd("a", 1);
        cache.TryAdd("b", 2);
        timeProvider.Advance(TimeSpan.FromSeconds(10));
        cache.TryAdd("c", 3);

        var snapshot = cache.ToFrozenSnapshot();

        Assert.Single(snapshot);
        Assert.Equal(3, snapshot["c"]);
    }

    [Fact]
    public async Task Async_RoundTrip_Works()
    {
        var cache = new DictionaryCache<string, int>(TimeProvider.System);
        Assert.True(await cache.TryAddAsync("a", 1, TestContext.Current.CancellationToken));

        var (found, value) = await cache.TryGetAsync("a", TestContext.Current.CancellationToken);
        Assert.True(found);
        Assert.Equal(1, value);

        var (updated, old) = await cache.TryUpdateAsync(
            "a",
            2,
            TestContext.Current.CancellationToken
        );
        Assert.True(updated);
        Assert.Equal(1, old);

        var (removed, removedValue) = await cache.TryRemoveAsync(
            "a",
            TestContext.Current.CancellationToken
        );
        Assert.True(removed);
        Assert.Equal(2, removedValue);
    }
}

public class ConcurrentDictionaryCacheTests
{
    [Fact]
    public void Constructor_NullTimeProvider_Throws()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new ConcurrentDictionaryCache<string, int>(null!)
        );
    }

    [Fact]
    public void TryGet_Missing_ReturnsFalseAndNull()
    {
        var cache = new ConcurrentDictionaryCache<string, int>(TimeProvider.System);
        var found = cache.TryGet("missing", out var value);

        Assert.False(found);
        Assert.Equal(default, value);
    }

    [Fact]
    public void TryAdd_DuplicateKey_ReturnsFalseAndReportsExisting()
    {
        var cache = new ConcurrentDictionaryCache<string, int>(TimeProvider.System);
        cache.TryAdd("a", 1);

        var added = cache.TryAdd("a", 2, out var existing);

        Assert.False(added);
        Assert.Equal(1, existing);
    }

    [Fact]
    public void TryUpdate_ExistingKey_UpdatesAndReportsOldValue()
    {
        var cache = new ConcurrentDictionaryCache<string, int>(TimeProvider.System);
        cache.TryAdd("a", 1);

        var updated = cache.TryUpdate("a", 9, out var oldValue);

        Assert.True(updated);
        Assert.Equal(1, oldValue);
        Assert.True(cache.TryGet("a", out var value));
        Assert.Equal(9, value);
    }

    [Fact]
    public void Ttl_ExpiresEntry()
    {
        var timeProvider = new FakeTimeProvider(DateTimeOffset.UtcNow);
        var cache = new ConcurrentDictionaryCache<string, int>(
            timeProvider,
            new CacheOptions(TimeSpan.FromSeconds(5))
        );
        cache.TryAdd("a", 1);

        timeProvider.Advance(TimeSpan.FromSeconds(10));

        Assert.False(cache.TryGet("a", out _));
        Assert.Equal(0, cache.Count);
    }

    [Fact]
    public async Task Async_RoundTrip_Works()
    {
        var cache = new ConcurrentDictionaryCache<string, int>(TimeProvider.System);
        Assert.True(await cache.TryAddAsync("a", 1, TestContext.Current.CancellationToken));

        var (found, value) = await cache.TryGetAsync("a", TestContext.Current.CancellationToken);
        Assert.True(found);
        Assert.Equal(1, value);

        var (updated, old) = await cache.TryUpdateAsync(
            "a",
            2,
            TestContext.Current.CancellationToken
        );
        Assert.True(updated);
        Assert.Equal(1, old);

        var (removed, removedValue) = await cache.TryRemoveAsync(
            "a",
            TestContext.Current.CancellationToken
        );
        Assert.True(removed);
        Assert.Equal(2, removedValue);
    }

    [Fact]
    public void Clear_RemovesAll()
    {
        var cache = new ConcurrentDictionaryCache<string, int>(TimeProvider.System);
        cache.TryAdd("a", 1);
        cache.TryAdd("b", 2);
        cache.Clear();

        Assert.Equal(0, cache.Count);
        Assert.False(cache.ContainsKey("a"));
    }
}

/// <summary>
/// Minimal controllable <see cref="TimeProvider"/> for tests.
/// </summary>
public sealed class FakeTimeProvider : TimeProvider
{
    private DateTimeOffset _now;

    public FakeTimeProvider(DateTimeOffset start) => _now = start;

    public override DateTimeOffset GetUtcNow() => _now;

    public void Advance(TimeSpan delta) => _now = _now.Add(delta);
}
