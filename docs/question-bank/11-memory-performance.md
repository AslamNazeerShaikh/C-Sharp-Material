# Memory / Performance

## 61. You have a large collection and only need to iterate through it once. Which can help avoid creating another collection?

- A. `IEnumerable<T>`
- B. `ToList()` immediately
- C. `ToArray()` immediately
- D. `Clone()`

**Answer: A**

**Why:** Keep the pipeline lazy: `IEnumerable<T>` with `yield` and deferred LINQ operators streams items one at a time with O(1) extra memory. `ToList()`/`ToArray()` eagerly duplicate the whole sequence on the heap.

## 62. You call `ToList()` on a huge database query. What is the main concern?

- A. It materializes the results into memory
- B. It makes SQL asynchronous
- C. It deletes database records
- D. It creates a new database

**Answer: A**

**Why:** `ToList()` pulls every row across the network and allocates objects for all of them — memory spikes, GC pressure, and slow responses. Filter/project in SQL first (`Where`/`Select`/`Take` before materialization) so only needed data is loaded.

## 63. You repeatedly concatenate many strings inside a loop. Which might be more appropriate?

- A. `StringBuilder`
- B. `string +` always
- C. `dynamic`
- D. `object`

**Answer: A**

**Why:** Strings are immutable, so each `+=` allocates a new string and copies — O(n²) total for n appends. `StringBuilder` buffers in a resizable array (amortized O(n)). See `ClassCodeLibrary/Strings/StringDuplicationFiltering/`, which was refactored from `+=` to `StringBuilder` for exactly this reason.

## 64. You have a high-throughput API and unnecessary allocations are hurting performance. What should you investigate?

- A. Allocation patterns and object lifetimes
- B. Add more `Task.Run`
- C. Make everything static
- D. Add `Thread.Sleep`

**Answer: A**

**Why:** GC pressure comes from *what* you allocate and *how long* it lives (closures, per-request buffers, string concatenation, boxing, LOH objects). Profile first (dotTrace, PerfView, `dotnet-counters`/`dotnet-trace`), then fix the hot allocations: pooling (`ArrayPool<T>`), structs/spans, reduced closure captures. `Task.Run` adds threads, not fewer allocations; `static` doesn't reduce allocations by itself.
