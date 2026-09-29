# Async / Await / Task

## 9. Your ASP.NET Core API calls SQL Server and waits for the database response. What should you use?

- A. `Thread.Sleep`
- B. `await` with async DB API
- C. `Task.Run`
- D. New Thread

**Answer: B**

**Why:** Database calls are I/O-bound: the thread would just wait. `await` releases the request thread back to the pool while the I/O completes, so the server handles more concurrent requests. `Task.Run` / new threads are for CPU-bound work, not waiting on I/O.

## 10. Your API calls three independent downstream APIs. What is generally the best approach?

- A. Call them sequentially
- B. `Task.WhenAll`
- C. `Thread.Sleep`
- D. Create three manual threads

**Answer: B**

**Why:** Independent I/O operations should overlap. Start all three tasks, then `await Task.WhenAll(...)` — total latency drops toward the slowest call instead of the sum, with no extra threads.

## 11. You have a CPU-intensive calculation inside an ASP.NET Core request. Which approach should you consider?

- A. `Thread.Sleep`
- B. `Task.Run` blindly for every request
- C. Appropriate background/CPU-work strategy
- D. Make the controller static

**Answer: C**

**Why:** CPU work genuinely needs a thread, but `Task.Run` per request under load just moves the bottleneck and can starve the thread pool. For heavy/long work, prefer a deliberate strategy: a bounded queue with `BackgroundService`, response caching, or pushing the job out of the request path — and measure.

## 12. A method performs no asynchronous operation. Should you mark it `async`?

- A. Always
- B. No
- C. Only public methods
- D. Only private methods

**Answer: B**

**Why:** `async` without `await` adds a state-machine overhead and misleads callers (plus a compiler warning). Return the value directly, or `Task.FromResult` / `ValueTask` if the signature must stay task-based for interface consistency.

## 13. A method performs asynchronous I/O and returns a value. Which return type is normally appropriate?

- A. `void`
- B. `Task<T>`
- C. `Thread`
- D. `object`

**Answer: B**

**Why:** `Task<T>` represents the in-flight operation and its future result, and it lets callers `await` it and observe exceptions. `Thread`/`object` carry none of that machinery.

## 14. A method performs asynchronous work but returns no result. Which is normally appropriate?

- A. `Task`
- B. `void`
- C. `Thread`
- D. `IEnumerable`

**Answer: A**

**Why:** `Task` (non-generic) is the awaitable "completion signal" with exception propagation. Reserve `async void` for event handlers only (see Q15).

## 15. When would `async void` generally be appropriate?

- A. Service methods
- B. Repository methods
- C. Event handlers
- D. Controller actions

**Answer: C**

**Why:** Event handlers must match a `void`-returning delegate signature, so `async void` is the only option. Everywhere else it is dangerous: exceptions cannot be awaited/caught by callers and can crash the process.

## 16. You have three independent async operations. When should you prefer `Task.WhenAll()`?

- A. When operations depend on each other
- B. When operations are independent
- C. Only for CPU-bound operations
- D. Never

**Answer: B**

**Why:** `WhenAll` runs the operations concurrently and completes when all finish. Dependent operations must be awaited in sequence because each needs the previous result.

## 17. You have:

```csharp
await GetUserAsync();
await GetOrdersAsync();
```

and the calls are independent. What is the main potential improvement?

- A. Use `Thread.Sleep`
- B. Start both tasks and await `Task.WhenAll`
- C. Convert both to synchronous calls
- D. Use `lock`

**Answer: B**

**Why:** Sequential awaits pay summed latency. `var u = GetUserAsync(); var o = GetOrdersAsync(); await Task.WhenAll(u, o);` overlaps the two I/Os. (`lock` is for shared-state protection, unrelated here.)

## 18. What happens when an async method reaches an incomplete `await`?

- A. It always blocks the thread
- B. It can return control while the operation continues
- C. It creates a new process
- D. It terminates the method permanently

**Answer: B**

**Why:** That is the core of async: the method yields (returns an incomplete `Task` to its caller), freeing the thread; when the awaited operation completes, the remainder runs as a continuation.

## 19. You need extremely high-performance code where an async operation frequently completes synchronously. What type might you consider?

- A. `void`
- B. `ValueTask<T>`
- C. `Thread`
- D. `dynamic`

**Answer: B**

**Why:** `Task<T>` allocates even when the result is already available. `ValueTask<T>` can wrap a synchronously-available result with no allocation — but only consider it after profiling a proven hot path.

## 20. Should you replace every `Task<T>` with `ValueTask<T>` for performance?

- A. Yes
- B. No
- C. Only in controllers
- D. Only in repositories

**Answer: B**

**Why:** `ValueTask<T>` has strict rules — await exactly once, never block on it, don't store and reuse it. Misuse causes subtle bugs. Default to `Task<T>`; use `ValueTask<T>` only where measurement justifies it.
