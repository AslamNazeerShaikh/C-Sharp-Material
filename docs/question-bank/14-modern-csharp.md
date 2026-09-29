# Modern C# / .NET

## 74. You need pattern matching based on the runtime type/value. What feature would you consider?

- A. Pattern matching
- B. Boxing
- C. Reflection only
- D. Serialization

**Answer: A**

**Why:** Type patterns (`if (x is Customer c)`), switch expressions, and property patterns dispatch on runtime shape with compiler exhaustiveness help — replacing brittle `GetType()`/cast chains and most reflection-based branching.

## 75. You want to execute different logic based on object type using modern C#. Which feature?

- A. Pattern matching
- B. `goto`
- C. `dynamic` only
- D. Reflection only

**Answer: A**

**Why:** A switch expression over type patterns is declarative, null-safe, and checked by the compiler — unlike `dynamic` (runtime failures) or reflection (slow, stringly-typed). Keep true polymorphic dispatch (virtual methods) for behavior that belongs to the types themselves.

## 76. You want an immutable DTO with concise syntax. Which is a strong candidate?

- A. Record
- B. Static class
- C. Delegate
- D. Enum

**Answer: A**

**Why:** `record` gives positional syntax, value equality, `with`-expressions for non-destructive mutation, and `init`-only properties in one line: `record Order(int Id, decimal Total);`.

## 77. You need a method to accept any number of arguments. Which keyword?

- A. `params`
- B. `ref`
- C. `out`
- D. `in`

**Answer: A**

**Why:** `params` collects variable arguments into an array (`void Log(params string[] messages)` → `Log("a", "b", "c")`). Prefer it over manual array construction at call sites; for hot paths consider overloads to avoid the array allocation.

## 78. You want to prevent modification of a field after construction. Which is appropriate?

- A. `readonly`
- B. `const` in all cases
- C. `dynamic`
- D. `virtual`

**Answer: A**

**Why:** `readonly` fields are assigned in the constructor, then frozen — works for any type, including runtime-computed values. `const` only handles compile-time literals and is implicitly static, so it can't cover instance state.

## 79. You want a value known at compile time and shared as a constant. Which?

- A. `readonly`
- B. `const`
- C. `static readonly` only
- D. `volatile`

**Answer: B**

**Why:** `const` values are baked in at compile time (literals, `const int Max = 100`) — zero memory per instance, usable in attributes and `case` labels. Note the trade-off: changing a `const` requires recompiling consumers; `static readonly` is resolved at runtime.

## 80. You need to ensure a class cannot be instantiated directly but can provide a base implementation for derived classes. What would you use?

- A. `abstract class`
- B. `static class`
- C. `sealed class`
- D. `record struct`

**Answer: A**

**Why:** `abstract` blocks direct instantiation while allowing constructors, concrete members with shared logic, and abstract members for derived classes to fill in. (`static` also blocks instantiation but forbids inheritance entirely; `sealed` does the reverse — allows instantiation, forbids inheritance.)
