# Problem: 
- Find the Second Largest Number in an Array Without Using Inbuilt Methods

# Question:
- Write a C# method to find the second largest number in a given array of integers without using any inbuilt sorting or utility methods. 
- The array can contain duplicate numbers. The function should handle edge cases, such as arrays with fewer than two elements.

# Explanation:

## 1. Logic:

- Use two variables largest and secondLargest initialized to int.MinValue.
- Traverse the array:
	a. If the `current element` is greater than `largest`, update `secondLargest` to `largest` and `largest` to the `current element`.
	b. If the `current element` is not equal to `largest` but greater than `secondLargest`, update `secondLargest`.
	c. After the loop, `secondLargest` will hold the `second largest` value.

## 2. Edge Cases:

- `Array with fewer than 2 elements`: Throws an exception.
- `Array with no distinct second element` (e.g., all identical values): Throws an exception.

## 3. Complexity:

- Time Complexity: `O(n)`, where 𝑛 is the number of elements in the array (single traversal)

- Space Complexity: `O(1)`, as no additional space is used.

# Explanation of XML Documentation:

## 1. Method-Level Documentation:

- ### FindSecondLargest:
	a. `Summary`: Describes the purpose of the method (finding the second largest number).
	b. `Parameters`: Details the expected input `(nums)`.
	c. `Returns`: Explains the return value.
	d. `Exceptions`: Lists possible exceptions and their conditions.

- ### Main Method Documentation:

	Describes the purpose of the `Main method` as the `program entry point` and explains that it is used for testing the `FindSecondLargestNumber` method.

- ### Why Use XML Documentation?
								
	Helps developers understand the purpose and usage of each method without delving into the implementation.
	Enables tools like `IntelliSense` to provide contextual help while coding.

- ### Sample Output:

Second Largest: 4
Error: Array must contain at least two distinct elements.
Error: Array does not contain enough distinct elements.
