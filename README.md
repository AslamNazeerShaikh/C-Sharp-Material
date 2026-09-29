# CSharpCodePractice

Interview-problem practice repo: manual implementation first, then the LINQ/built-in version.

## Layout

```text
ClassCodeLibrary/Arrays/<Topic>/... + PROBLEM.md
ClassCodeLibrary/Strings/<Topic>/... + PROBLEM.md
ClassCodeLibrary/Common/          # shared enums like SortDirection
CSharpCodePractice.Tests/Arrays|Strings/<Topic>Tests.cs
MainConsoleApp/Program.cs         # menu runner, only place with Console output
docs/PROBLEM_TEMPLATE.md
```

New exercise: copy `docs/PROBLEM_TEMPLATE.md` to `ClassCodeLibrary/<Category>/<Topic>/PROBLEM.md`,
add pure functions to the library (return values, no `Console`), add a menu entry + tests.

## Index

| Problem | Category | Technique | Complexity |
|---|---|---|---|
| SecondLargestNumber | Arrays | single pass / LINQ Distinct+OrderBy | O(n) / O(n log n) |
| CustomArraySorter | Arrays | built-in sort vs bubble sort | O(n log n) / O(n²) |
| StringDuplicationFiltering | Strings | manual scan vs LINQ+HashSet | O(n²) manual / O(n) LINQ |
| UniqueCharacterCounter | Strings | single pass / LINQ GroupBy | O(n) |
| VowelsInUniqueCity | Strings | manual dedupe+vowels / LINQ Distinct | O(n²) manual / O(n) LINQ |
| MethodKinds | Fundamentals | static vs instance vs extension | O(1) |

## Question Bank

Scenario-based interview MCQs with answers and explanations: [`docs/question-bank/`](docs/question-bank/) — 80 questions across method design, async/await, LINQ, OOP, DI, records/structs, `ref`/`out`/`in`, exceptions, `var`/`dynamic`, nullables, performance, collections, delegates, and modern C#.

## Commands

- `dotnet build`
- `dotnet test`
- `dotnet run --project MainConsoleApp`
- `dotnet tool restore && dotnet csharpier format .`

## Practice strategies

- Improve your logic-building skills and gain confidence in solving tricky C# questions, try the following strategies:

## 1. Practice Basics Without Inbuilt Methods 🛠️🐸
Write code for basic operations without using inbuilt methods to understand the underlying logic. Examples:

- Implement methods for common string manipulations like reversing a string, finding substrings, or checking for palindromes.
- Build custom implementations for List operations (e.g., adding, removing, finding elements).

## 2. Nested Loops and Arrays 🍃🔄
Nested for loops are frequently used for multidimensional arrays or matrices. Try problems involving:

- Matrix transposition and rotation.
- Summing diagonals, rows, or columns in a 2D array.
- Implementing your own sorting algorithms like Bubble Sort or Selection Sort on arrays without using Array.Sort().

## 3. String and Character Manipulations 🔠📜
String problems often test logic with character-by-character manipulations. Practice tasks such as:

- Counting specific characters or substrings.
- Removing duplicates or rearranging characters.
- Converting between character cases and implementing your own ToLower() or ToUpper().

## 4. Master Basic Data Structures 📊📅
Collections like List, Dictionary, and arrays are crucial in problem-solving:

- Write your own versions of Add and Remove for a dynamic array structure.
- Implement a simple key-value store like a Dictionary without using inbuilt dictionary classes.
- Practice data retrieval operations like searching for values or keys in a dictionary.

## 5. Explore Code Challenges 🧩🪛
Platforms like LeetCode, HackerRank, and Codewars offer problems categorized by topic (e.g., arrays, strings, data structures). These will help reinforce C# skills while building up speed and logic. Choose problems rated “easy” or “medium” to get comfortable before advancing to harder problems.

## 6. Read and Write Code Regularly 📚✍️
Find and read solutions to common algorithmic problems in C# to see different approaches. Then, try writing your own code based on what you learned without copying directly.
