# Nullable / Null Handling

## 57. An API property is allowed to be null. Which declaration communicates this with nullable reference types enabled?

- A. `string`
- B. `string?`
- C. `dynamic?`
- D. `nullable string`

**Answer: B**

**Why:** With `<Nullable>enable</Nullable>`, `string` means "never null — compiler will warn you if you assign null" and `string?` means "may be null — check me." The annotation turns null intent into compile-time-checked documentation.

## 58. You want to return a fallback value if something is null. Which operator?

- A. `?.`
- B. `??`
- C. `=>`
- D. `::`

**Answer: B**

**Why:** The null-coalescing operator: `name ?? "Guest"` evaluates to the left side unless it is null. Combine with assignment (`??=`) for lazy initialization: `_cache ??= Load();`.

## 59. You want to safely access a nested property when an intermediate object may be null. Which operator?

- A. `??`
- B. `?.`
- C. `!`
- D. `::`

**Answer: B**

**Why:** `order?.Customer?.Email` short-circuits to null at the first null link instead of throwing `NullReferenceException`. Chain it with `??` for a default: `order?.Customer?.Email ?? "unknown"`.

## 60. You know a nullable value is definitely not null and want to suppress the compiler warning. Which operator?

- A. `??`
- B. `?.`
- C. `!`
- D. `&`

**Answer: C**

**Why:** The null-forgiving operator tells the compiler "trust me, not null here." Use sparingly and only when you can prove it (e.g. framework-initialized properties) — every `!` is a bet against a future `NullReferenceException`; prefer real checks or contracts.
