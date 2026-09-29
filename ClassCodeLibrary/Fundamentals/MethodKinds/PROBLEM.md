# Method Kinds: Static vs Instance vs Extension

## Category
Fundamentals

## Question
"Write a method that takes `a` and `b` and returns `c = a + b`. Should it be static, instance, or an extension method — and why?"

## Short Answer
`a + b -> c` is a stateless pure function, so **static**:

```csharp
public static int Add(int a, int b) => a + b;
// call: Calculator.Add(2, 3)
```

No object needs to exist for `2 + 3` to be `5`. Reach for instance only when the
method needs per-object state or polymorphism; reach for extension only when you
want instance-style call syntax on a type you do not own.

## Decision Table

| Situation | Kind | Example |
|---|---|---|
| No state, same inputs -> same output (pure) | `static` | `Calculator.Add(a, b)` |
| Operates on / mutates per-object state | instance | `accumulator.Add(x)` updates `accumulator.Total` |
| Needs `virtual`/`override`, interface, DI, mocking | instance | `IAdder.Add`, injected into services |
| Nice call syntax on a type you cannot modify | extension | `2.AddTo(3)`, `"aabb".RemoveDuplicates()` |
| You own the type and it is core domain behavior | instance (not extension) | `account.Deposit(x)` |
| Per-call scratch state shared across awaits | instance | service holding a buffer (or pass state explicitly) |

## Corrections to Common Claims

1. **"Static saves memory / instance consumes more."** Inaccurate as stated.
   Method IL is stored once per type regardless of kind. An instance method does
   not duplicate code per object; it just receives a hidden `this`. The real cost
   of instance is the *object allocation* (when you need state), not the method.
   Never pick static "to save memory" — pick it because there is no state.
2. **"Instance is needed for pass-by-value / `ref`."** Wrong. Parameter passing
   mode (`in`, `ref`, `out`, by value) is orthogonal to static vs instance.
   `Calculator.AddIntoRef(a, b, ref result)` in this exercise proves it.
3. **"Instance is needed for `async`/`await`."** Wrong. `static async Task<int>`
   is fully supported and common (e.g. `File.ReadAllTextAsync`). `AddAsync` in
   this exercise proves it. Choose `async` based on I/O-bound work, not on kind.
4. **"Libraries/NuGet packages need instance methods."** Wrong framing. Libraries
   expose both: static for pure helpers (`Math.Max`, `string.IsNullOrEmpty`),
   instance for stateful services and anything behind an interface.
5. **"Extension methods are a third runtime mechanism."** They are compile-time
   sugar over static calls (`x.Foo()` -> `Extensions.Foo(x)`). No virtual
   dispatch: an extension cannot override and cannot access privates.

## Rules of Thumb (Best Practices)

- Default stateless helpers to `static`; keep them pure and thread-safe (no
  mutable `static` fields — that is where real static memory/threading bugs live).
- Use instance when the method *is the behavior of an object*: reads/writes
  fields/properties, enforces invariants, or participates in inheritance.
- Program stateful collaborators behind interfaces (`IAdder`) and inject them;
  static cannot implement an interface, so it cannot be mocked or swapped in tests.
- Use extensions to extend sealed/BCL types (`string`, `IEnumerable<T>`) or to
  build fluent APIs; put them in a clearly named static class
  (`IntExtensions`) and namespace, and avoid extensions with the same signature
  as a future instance member (the instance member silently wins).
- `async` and `ref`/`out`/`in` are independent axes — each works with both
  static and instance.

## API

- `Calculator.Add(int, int)` -> `int` (static, pure).
- `Calculator.AddAsync(int, int, CancellationToken)` -> `Task<int>` (static async).
- `Calculator.AddIntoRef(int, int, ref int)` (static + `ref`).
- `Accumulator.Add(int)` / `Reset()` / `Total` (instance, stateful).
- `IAdder` + `Adder` (instance behind interface for DI/mocking).
- `IntExtensions.IsEven(this int)` / `AddTo(this int, int)` (extensions).

## Complexity
O(1) time and space for all members.

## Sample
`Calculator.Add(2, 3)` -> `5`; `new Accumulator().Add(2)` then `.Add(3)` -> `Total == 5`; `4.IsEven()` -> `true`.

## Demo
Menu key `6` in `MainConsoleApp/Program.cs`.

## Tests
`CSharpCodePractice.Tests/Fundamentals/MethodKindsTests.cs`
