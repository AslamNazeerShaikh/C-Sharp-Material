# Method Design — Static / Instance / Extension

See also: `ClassCodeLibrary/Fundamentals/MethodKinds/` (working code + tests for these decisions).

## 1. You have a method that does not use any instance fields or dependencies. How would you declare it?

- A. Static method
- B. Instance method
- C. Virtual method
- D. Abstract method

**Answer: A**

**Why:** No state and no dependencies means the result depends only on the arguments — a pure function. `static` expresses that and lets callers use it without constructing an object.

## 2. You have a method that uses a private field of the class. How should you generally declare it?

- A. Static
- B. Instance
- C. Extension
- D. Abstract

**Answer: B**

**Why:** A static method has no `this` and cannot touch instance fields. If the logic reads or writes per-object state, it must be an instance method.

## 3. You want to add `IsValidEmail()` to the existing `string` type without modifying `string`. What would you use?

- A. Inheritance
- B. Extension method
- C. Partial class
- D. Static constructor

**Answer: B**

**Why:** `string` is sealed (no inheritance) and owned by the BCL (no partial). An extension method (`static bool IsValidEmail(this string s)`) adds instance-style call syntax without touching the type.

## 4. You have a method that requires an injected `IRepository`. Should the method generally be static?

- A. Yes
- B. No
- C. Only in ASP.NET Core
- D. Only if async

**Answer: B**

**Why:** Injected dependencies live on the instance (constructor injection). A static method cannot receive them through the constructor; the containing class must be instantiated by DI, so the method is instance. (Async is orthogonal — `static async` is legal.)

## 5. You have a reusable utility method that doesn't maintain state. Which design is most appropriate?

- A. Static method
- B. Singleton instance
- C. Abstract method
- D. Virtual method

**Answer: A**

**Why:** Stateless helpers (`Math.Max`, `string.IsNullOrEmpty`) are the textbook static case. A singleton adds lifetime management overhead for zero benefit when there is no state to share.

## 6. You need polymorphic behavior where different classes provide different implementations of the same method. What would you choose?

- A. Static
- B. Virtual/override
- C. Extension
- D. Const

**Answer: B**

**Why:** Polymorphism requires virtual dispatch through a base reference. Static methods and extensions are resolved at compile time and cannot be overridden.

## 7. You need to add helper functionality to a third-party class that you cannot modify. What should you use?

- A. Extension method
- B. Constructor
- C. Override
- D. Partial class

**Answer: A**

**Why:** You cannot inherit-and-override every consumer's usage, and partial classes only work within the same assembly source. Extensions attach new behavior from the outside.

## 8. You have an extension method and an instance method with the same signature. Which one takes precedence?

- A. Extension method
- B. Instance method
- C. Both execute
- D. Compilation always fails

**Answer: B**

**Why:** The compiler considers instance members first; extensions are fallback candidates. This is why you should avoid extensions that shadow (or may later collide with) instance members — the behavior can silently change when the type gains a real member.
