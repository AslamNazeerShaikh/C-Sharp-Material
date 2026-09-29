# Exception Handling

## 50. You want to rethrow the current exception while preserving the original stack trace. Which is preferable?

- A. `throw;`
- B. `throw ex;`
- C. `return ex;`
- D. `throw new Exception(ex.Message);`

**Answer: A**

**Why:** Bare `throw;` rethrows the in-flight exception untouched. `throw ex;` resets the stack trace to the rethrow site, destroying where the error actually originated; `new Exception(ex.Message)` additionally drops the type and inner chain.

## 51. You need cleanup code that should normally execute whether an exception occurs or not. What should you use?

- A. `catch`
- B. `finally`
- C. `throw`
- D. `using` only

**Answer: B**

**Why:** `finally` runs on both success and exceptional paths (short of process teardown). For disposable resources prefer `using`, which is `try`/`finally` + `Dispose()` in concise form.

## 52. You have an exception that you can handle meaningfully. Where should you generally handle it?

- A. At an appropriate boundary where it can be handled
- B. Everywhere
- C. Only in every method
- D. Never

**Answer: A**

**Why:** Handle where you can *act*: retry with backoff, fall back, or translate into a proper response at an application boundary (e.g. middleware → HTTP 503). Catching everywhere just to log-and-swallow hides failures; letting it bubble to a global handler beats catching where nothing useful can be done.

## 53. You need to preserve the original exception as an inner exception while adding context. What approach is appropriate?

- A. Throw a new exception with the original as inner exception
- B. `throw ex`
- C. Ignore the exception
- D. Return null

**Answer: A**

**Why:** `throw new OrderProcessingException($"Failed for order {id}", ex)` adds domain context while keeping the full original chain inspectable via `InnerException`. (`throw ex` would instead destroy the stack trace — see Q50.)
