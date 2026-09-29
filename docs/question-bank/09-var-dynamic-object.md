# `var` / `dynamic` / Object

## 54. You want compile-time type inference. What should you use?

- A. `var`
- B. `dynamic`
- C. `object`
- D. `ExpandoObject` only

**Answer: A**

**Why:** `var` is statically typed — the compiler infers the real type, so you keep IntelliSense, refactoring safety, and zero runtime cost. It is *not* a dynamic type.

## 55. You need runtime binding where members are resolved dynamically. What could you use?

- A. `var`
- B. `dynamic`
- C. `const`
- D. `readonly`

**Answer: B**

**Why:** `dynamic` defers member resolution to runtime (DLR), useful for COM interop, unstructured JSON/XML, and duck-typing scenarios. Cost: no compile-time checking, runtime binder exceptions on typos, and measurable overhead — contain it behind typed boundaries.

## 56. You want to store values of different types but don't need dynamic member binding. Which could you use?

- A. `object`
- B. `dynamic` only
- C. `var` only
- D. `const`

**Answer: A**

**Why:** Everything derives from `object`, so it can hold any value without opting into runtime binding. (Value types box on the way in.) In modern code, prefer generics or discriminated shapes first, and pattern matching (`is`) to recover the concrete type safely.
