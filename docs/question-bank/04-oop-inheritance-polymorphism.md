# OOP / Inheritance / Polymorphism

## 29. You want to prevent a class from being inherited. What should you use?

- A. `abstract`
- B. `sealed`
- C. `static`
- D. `private`

**Answer: B**

**Why:** `sealed` forbids derivation (and enables devirtualization/JIT optimizations). `abstract` is the opposite — it *requires* inheritance to be useful.

## 30. You want a base class method to provide default behavior that derived classes can override. What should you use?

- A. `virtual`
- B. `const`
- C. `sealed`
- D. `static`

**Answer: A**

**Why:** `virtual` keeps a base implementation while opening a virtual-dispatch slot that derived classes may `override`. `static`/`const` members cannot participate in polymorphism at all.

## 31. You want to force derived classes to implement a method. What should you use?

- A. `virtual`
- B. `abstract`
- C. `static`
- D. `readonly`

**Answer: B**

**Why:** `abstract` provides no implementation, so every concrete derived class must supply one (or itself be abstract). `virtual` merely *allows* overriding while keeping a default.

## 32. You have a base class reference pointing to a derived object. You want the derived implementation to execute. What concept is this?

- A. Polymorphism
- B. Boxing
- C. Encapsulation
- D. Serialization

**Answer: A**

**Why:** Runtime (virtual) dispatch selecting the most-derived override through a base-typed reference is the definition of polymorphism. (Boxing is value→reference conversion; unrelated.)

## 33. You want to hide a base class member rather than override it. Which keyword is relevant?

- A. `override`
- B. `new`
- C. `virtual`
- D. `sealed`

**Answer: B**

**Why:** `new` declares an unrelated member that hides the base one by name (no virtual dispatch — the executed member depends on the *static* type of the reference). Use it deliberately and rarely; hiding is usually a design smell.

## 34. You have multiple unrelated classes that need to implement the same contract. What would you generally choose?

- A. Interface
- B. Static class
- C. Struct
- D. Enum

**Answer: A**

**Why:** Interfaces define behavior contracts across unrelated hierarchies (C# has single class inheritance, so a base class can't span unrelated trees). This also enables DI and mocking in tests.

## 35. You need shared implementation plus a common contract for derived classes. Which may be appropriate?

- A. Abstract class
- B. Enum
- C. Static class
- D. Delegate

**Answer: A**

**Why:** An abstract class combines both: concrete/protected members with reused logic plus abstract members forcing derived customization. Guideline: interface for "can-do" contracts (especially across unrelated types), abstract class for "is-a" hierarchies with shared code.
