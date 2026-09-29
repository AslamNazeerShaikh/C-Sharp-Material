# Custom Array Sorter

## Category
Arrays

## Question
Sort a given array in ascending and descending order, both with built-in methods and with a manual algorithm (bubble sort).

Example: `{ 24, 58, 99, 67, 75, 44, 73, 41, 74, 87 }`.

## API
- `CustomArraySorter.SortWithBuiltIn<T>(T[] inputArray, SortDirection direction)` -> new sorted array.
- `CustomArraySorter.SortWithBubbleSort<T>(T[] inputArray, SortDirection direction)` -> new sorted array.
- `SortDirection { Ascending, Descending }` replaces the old `bool sortOrder` flag.
- Both methods clone the input; the caller's array is never mutated. All console output lives in `MainConsoleApp/Program.cs`.

## Approach
1. Built-in: `Array.Sort(copy)` for ascending, `Array.Sort(copy, (x, y) => y.CompareTo(x))` for descending.
2. Manual: bubble sort with early exit when no swaps occur in a pass.

## Complexity
- Built-in: O(n log n) time, O(1) or O(n) extra depending on runtime.
- Bubble sort: O(n^2) time, O(n) space for the cloned array (O(1) extra besides the copy).

## Sample
Input: `24 58 99 67 75 44 73 41 74 87`
Ascending: `24 41 44 58 67 73 74 75 87 99`
Descending: `99 87 75 74 73 67 58 44 41 24`

## Why `IComparable<T>`?
Makes the sorter generic over any orderable type (`int`, `string`, custom types) with compile-time type safety instead of one method per type.

## Note on the old `void` version
Arrays are reference types, so an in-place `void Sort(...)` visibly mutates the caller's array. That was deliberately removed: pure functions that return a new array are testable and avoid surprise mutations.

## Demo
Menu key `3` in `MainConsoleApp/Program.cs`.

## Tests
`CSharpCodePractice.Tests/Arrays/CustomArraySorterTests.cs`
