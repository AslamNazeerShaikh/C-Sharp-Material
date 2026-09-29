# Delegates / Events / Lambdas

## 70. You need to pass a method as a parameter. What C# feature can you use?

- A. Delegate
- B. Enum
- C. Struct
- D. Namespace

**Answer: A**

**Why:** A delegate is a type-safe method reference: `void Process(Func<int,int> step)` accepts any matching method or lambda. LINQ itself is built on this (`Where(Func<T,bool>)`).

## 71. You need a delegate that returns a value. Which built-in delegate is commonly used?

- A. `Action`
- B. `Func`
- C. `EventHandler` only
- D. `Predicate` only

**Answer: B**

**Why:** `Func<...>` variants return a value (`Func<int,int>` takes an int, returns an int; the last type argument is always the return type). Declare custom delegate types only when the signature needs a meaningful name.

## 72. You need a delegate that doesn't return a value. Which?

- A. `Func`
- B. `Action`
- C. `Task`
- D. `IEnumerable`

**Answer: B**

**Why:** `Action<...>` variants return `void` (`Action<string>` takes a string, returns nothing) — callbacks, loggers, UI updates. (`Func` always returns something.)

## 73. You need a delegate that accepts one value and returns `bool`. Which could be used?

- A. `Predicate<T>`
- B. `Action<T>`
- C. `Func<T>`
- D. `EventHandler<T>`

**Answer: A**

**Why:** `Predicate<T>` is exactly `T → bool` (classic match/filter shape, e.g. `List<T>.Find`). In modern code `Func<T,bool>` is the interchangeable equivalent — know both names, since interviewers and legacy APIs use either.
