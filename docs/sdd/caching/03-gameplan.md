# Caching Mechanism — Gameplan (SDD/TDD)

1. Create `ICache<TKey,TValue>`, `CacheEntry<TValue>`, `CacheOptions`.
2. Write failing tests for `DictionaryCache` (TDD).
3. Implement `DictionaryCache`.
4. Write failing tests for `ConcurrentDictionaryCache`.
5. Implement `ConcurrentDictionaryCache`.
6. Add async wrappers and frozen snapshot.
7. Add PROBLEM.md and question-bank entry.
8. Add demo to `MainConsoleApp`.
9. Run `dotnet build` and `dotnet test`.
EOF