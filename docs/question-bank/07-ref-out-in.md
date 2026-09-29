# `ref` / `out` / `in`

## 47. A method needs to modify an existing variable supplied by the caller. Which keyword?

- A. `out`
- B. `ref`
- C. `in`
- D. `params`

**Answer: B**

**Why:** `ref` passes a managed reference to the caller's variable: the method reads the incoming value and can write a new one back. The caller must initialize it first.

## 48. A method needs to return an additional value through a parameter, and the caller doesn't need to initialize it. Which keyword?

- A. `ref`
- B. `out`
- C. `in`
- D. `readonly`

**Answer: B**

**Why:** `out` is the "extra return value" channel: the caller passes an uninitialized variable and the method *must* assign it before returning. Prefer tuples or result objects in new code; `out` shines for `TryXxx` patterns (`int.TryParse`).

## 49. You want to pass a value by reference but prevent the method from modifying it. Which keyword?

- A. `ref`
- B. `out`
- C. `in`
- D. `params`

**Answer: C**

**Why:** `in` passes a readonly reference: no copy of large structs, and the compiler forbids assignment inside the method. (Note: for mutable structs it only blocks reassignment, not mutation through members — true readonly-ness needs `readonly struct`.)
