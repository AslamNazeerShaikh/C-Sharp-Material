# Question 
- Write a code using C# to find out how many unique char elements are present inside a given string and their repeatation count.
- Note: Avoid using inbuilt C# methods for searching, sorting, inserting or for comparison operations. Avoid use of collections.

# Explanation

## 1. ASCII Array Initialization:

- We initialize an integer array charCount of size 256, which represents all possible ASCII characters. Each index corresponds to an ASCII character code (0–255).
This array will store the count of each character as we iterate through the string.

## 2. Character Counting Loop:

- We loop through each character in the string and use its ASCII value as the index in charCount.
charCount[(int)currentChar]++ increments the count for each character in the string based on its ASCII index.

## 3. Displaying Results:

- We loop through the charCount array and check for any non-zero entries (indicating that the character was present in the input string).
For each character that appeared, we display its ASCII character representation and the count.

# Example Output

## 1. For the input string:

``` public string inputString = "AaaakkasklkdddekeooPOxOKMNNHHHDOBBBbbzhhsh"; ```

## 2. Output:

```
Unique characters and their counts:
Character 'A': 1 times
Character 'B': 3 times
Character 'D': 1 times
Character 'H': 3 times
Character 'K': 1 times
Character 'M': 1 times
Character 'N': 2 times
Character 'O': 3 times
Character 'P': 1 times
Character 'a': 4 times
Character 'b': 2 times
Character 'd': 3 times
Character 'e': 2 times
Character 'h': 3 times
Character 'k': 5 times
Character 'l': 1 times
Character 'o': 2 times
Character 's': 2 times
Character 'x': 1 times
Character 'z': 1 times
```

- This solution avoids inbuilt collections and directly uses ASCII indexing, making it efficient and easy to understand.

# Complexity

- Time Complexity: 
𝑂
(
𝑛
)
O(n) for iterating through the string, where 
𝑛
n is the length of the string.

- Space Complexity: 
𝑂
(
1
)
O(1), as we use a fixed-size array for ASCII characters.

# Explanation of XML Documentation Comments

## 1. Class Level: 
- Descriptions are provided for each class (UniqueCharacterCounter and Program) to outline its purpose.

## 2. Method Level: 
- Each method has a summary that briefly explains what the method does. The param tag describes each parameter to provide details on how to use it. For instance, in CountUniqueCharacters, the input parameter is described as the string for which character counts will be calculated.