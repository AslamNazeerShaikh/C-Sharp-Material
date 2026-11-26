# In-Memory Cache (Dictionary vs ConcurrentDictionary)

## Category
Caching | Concurrency | Dependency Injection | OOP

## Question
Implement a simple in-memory caching mechanism using a plain `Dictionary<TKey,TValue>`, then a thread-safe version using `ConcurrentDictionary<TKey,TValue>` that supports async/await. Both must be usable through constructor dependency injection. Support TTL expiry, duplicate-key handling, and CRUD operations that return `bool` with nullable `out` parameters.

## Constraints
- Manual implementation first (no hidden framework cache).
- Thread-safe variant must be safe for concurrent access.
- TTL checks must use an injectable clock (`TimeProvider`).
- Handle duplicate keys with different values (collision/update).

## API
- `ICache<TKey,TValue>`:
  - `bool TryGet(TKey key, out TValue? value)`
  - `bool TryAdd(TKey key, TValue value)` / `bool TryAdd(TKey key, TValue value, out TValue? existingValue)`
  - `bool TryUpdate(TKey key, TValue value, out TValue? oldValue)`
  - `bool TryRemove(TKey key, out TValue? value)`
  - `bool Set(TKey key, TValue value, out TValue? oldValue)`
  - `FrozenDictionary<TKey,TValue> ToFrozenSnapshot()`
  - Async counterparts returning `Task`.

## Approach
1. Store entries as `CacheEntry<TValue>` (value + expiry).
2. Plain `DictionaryCache` for single-threaded scenarios.
3. `ConcurrentDictionaryCache` for thread-safe/async scenarios.
4. Lazy expiry cleanup on access.

## Why FrozenDictionary?
`FrozenDictionary` is immutable and read-optimized. It is ideal for static lookup snapshots, not for a mutable cache. Use `ToFrozenSnapshot()` to publish a read-only view.

## Why Singleton?
A cache must be shared application-wide; register it as a singleton in DI. The classes themselves are not singletons to keep them testable.

## Why TTL?
TTL prevents stale data and unbounded memory growth. Expiry is checked on read and during cleanup.

## Duplicate key / collision handling
- `TryAdd` returns `false` and reports the existing value.
- `TryUpdate` overwrites and reports the old value.
- `Set` upserts and reports the old value.

## Complexity
- Time: O(1) average for CRUD; O(n) for snapshot/cleanup.
- Space: O(n).

## Demo
Menu key in `MainConsoleApp/Program.cs`: `["7"]`.

## Tests
`CSharpCodePractice.Tests/Caching/InMemoryCacheTests.cs`
EOF