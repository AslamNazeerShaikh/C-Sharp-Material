# Caching Mechanism — Research (SDD)

## Scenario
Interview panel asked to design and demonstrate an in-memory cache in C#:
1. A simple cache backed by `Dictionary<TKey,TValue>`.
2. A thread-safe cache backed by `ConcurrentDictionary<TKey,TValue>` with async/await support.
3. Both must be usable through constructor dependency injection.
4. CRUD operations return `bool` and expose state via nullable `out` parameters.
5. Handle duplicate keys with different values (collisions/updates).
6. Support TTL (time-to-live) expiry checks.
7. Explain `FrozenDictionary`, singleton lifetime, and TTL handling.

## Findings
- `Dictionary<TKey,TValue>` is fastest for single-threaded access but not thread-safe.
- `ConcurrentDictionary<TKey,TValue>` provides fine-grained locking and is safe for concurrent reads/writes.
- `FrozenDictionary<TKey,TValue>` is immutable and read-optimized; ideal for static lookup tables, not mutable caches.
- TTL requires a clock abstraction (`TimeProvider`) for deterministic tests.
- Async methods cannot declare `out` parameters; sync `Try*` methods keep `out TValue?`, while async wrappers return tuples.
- Singleton lifetime in DI shares one cache instance across the application, which is the desired cache semantics.
EOF