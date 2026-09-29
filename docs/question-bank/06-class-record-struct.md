# Class / Record / Struct

## 43. You are creating a DTO where value-based equality is useful. What would you consider?

- A. `record`
- B. `static class`
- C. `enum`
- D. Delegate

**Answer: A**

**Why:** Records implement value-based `Equals`/`GetHashCode` over their properties, so two DTOs with the same data compare equal — exactly what you want for assertions, caching keys, and deduplication.

## 44. You need a small value type with value semantics. What could be appropriate?

- A. `struct`
- B. `static class`
- C. Interface only
- D. Abstract class only

**Answer: A**

**Why:** Structs are value types: copied on assignment, no heap allocation (when not boxed), no null by default. Keep them small (guideline: ≤16 bytes), immutable, and few in number of copies.

## 45. You have:

```csharp
record User(int Id, string Name);
```

Two records contain the same values. What equality behavior do you generally expect?

- A. Reference equality
- B. Value-based equality
- C. Always false
- D. Compilation error

**Answer: B**

**Why:** Records synthesize value equality: same runtime type plus equal members means `==` and `Equals` return true (unlike classes, which default to reference identity).

## 46. You need an object whose state should not change after construction. Which feature could help?

- A. `readonly` properties / immutable design
- B. `dynamic`
- C. `ref`
- D. `volatile`

**Answer: A**

**Why:** Get-only properties (set in the constructor), `init` accessors, `readonly struct`/`record`, and `readonly` fields make immutability compiler-enforced — safer sharing across threads and fewer temporal-coupling bugs.
