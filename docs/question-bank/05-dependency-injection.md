# Dependency Injection

## 36. A service requires `IRepository` through its constructor. What pattern is being used?

- A. Dependency Injection
- B. Reflection
- C. Boxing
- D. Method hiding

**Answer: A**

**Why:** The class declares what it needs (`IRepository`) and the container supplies it — constructor injection, the preferred DI form because dependencies are explicit and the object is never in a half-built state.

## 37. A service should have one instance for the entire application lifetime. Which lifetime?

- A. Transient
- B. Scoped
- C. Singleton
- D. Per-method

**Answer: C**

**Why:** Singleton = one instance shared for the app's lifetime. Only suitable for stateless, thread-safe services (or carefully synchronized state).

## 38. A service should normally get a new instance each time it is requested from DI. Which lifetime?

- A. Singleton
- B. Scoped
- C. Transient
- D. Static

**Answer: C**

**Why:** Transient services are constructed fresh per resolution — the safe default for lightweight stateful components with no sharing requirements.

## 39. A service should generally have one instance per HTTP request. Which lifetime?

- A. Singleton
- B. Scoped
- C. Transient
- D. Static

**Answer: B**

**Why:** Scoped = one instance per scope, and in ASP.NET Core each request is a scope. Ideal for per-request state such as a unit of work.

## 40. `DbContext` is registered with which lifetime by default through `AddDbContext()`?

- A. Singleton
- B. Scoped
- C. Transient
- D. Static

**Answer: B**

**Why:** `AddDbContext` registers scoped: one context per request, giving per-request change tracking and a short-lived unit of work. Singleton `DbContext` would cause concurrency and stale-data bugs (it is not thread-safe).

## 41. You inject a scoped service into a singleton. What is the main concern?

- A. Lifetime mismatch
- B. Compilation always succeeds with no issue
- C. Faster performance
- D. Automatic disposal of singleton

**Answer: A**

**Why:** The singleton holds the scoped instance captive far beyond its scope ("captive dependency") — e.g. a per-request `DbContext` reused across requests. The container flags this at validation/startup. Fix: inject `IServiceScopeFactory`/`IServiceProvider` and create a scope, or redesign lifetimes.

## 42. You have a stateless, thread-safe service that is expensive to construct. Which lifetime might you consider?

- A. Singleton
- B. Scoped only
- C. Transient only
- D. None

**Answer: A**

**Why:** Singleton pays the construction cost once and shares the instance. The preconditions matter: stateless (no per-request data leaking between callers) and thread-safe (concurrent requests share it).
