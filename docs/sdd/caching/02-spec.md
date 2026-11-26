# Caching Mechanism — Specification (SDD)

## Public API
- `ICache<TKey,TValue>` where `TKey : notnull`
  - `int Count { get; }`
  - `bool TryGet(TKey key, out TValue? value)`
  - `bool TryAdd(TKey key, TValue value)`
  - `bool TryAdd(TKey key, TValue value, out TValue? existingValue)`
  - `bool TryUpdate(TKey key, TValue value, out TValue? oldValue)`
  - `bool TryRemove(TKey key, out TValue? value)`
  - `bool ContainsKey(TKey key)`
  - `void Clear()`
  - `FrozenDictionary<TKey,TValue> ToFrozenSnapshot()`
  - Async counterparts returning `Task<(bool Success, TValue? Value)>` / `Task<bool>`.

## Behavior
- Expired entries (TTL) are treated as missing and removed lazily.
- `TryAdd` returns `false` when the key already exists; `existingValue` is populated.
- `TryUpdate` returns `false` when the key is missing/expired; otherwise updates and returns old value.
- `TryRemove` returns `false` when missing/expired.
- Capacity (optional) rejects adds when full after expired cleanup.

## DI
- `TimeProvider` and `CacheOptions` are constructor-injected.
- Register the cache as a singleton in the composition root.
EOF