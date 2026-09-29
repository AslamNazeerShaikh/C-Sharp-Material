# Question:

1. Remove duplicate characters from a string:
- This will involve creating four specific functions to handle the removal of duplicates for: 
	- a. `special characters only`.
	- b. `numbers only`.
	- c. `lowercase letters only`.
	- d. `uppercase letters only`.

2. Remove `all special characters` from the string.
3. Remove `all numbers` from the string.
4. Remove `all lowercase characters` from the string.
5. Remove `all uppercase characters` from the string.

# Note:

1. Solve this problem without using collections, LINQ, or built-in methods like `Where(), Distinct()`.
2. No built-in methods like `Char.IsDigit(), Char.IsLetterOrDigit(), and Contains()`.
3. No Collections: Everything should be managed by basic string and char operations.

# Key Points:

## No Built-in Methods:
- We manually check whether a character is a letter, digit, lowercase, or uppercase by comparing the character's Unicode value `(c >= 'A' && c <= 'Z'` for uppercase, for example).
## No Contains():
- Instead of `Contains()`, we use a nested loop to check if a character already exists in the result string or tracking string (like `specialChars, numbers, etc.`).

# How the Code Works:

## Removing Duplicates:
- We iterate through the string and manually check if the character is already present in the result string by comparing each character.
## Handling Special Characters, Numbers, Uppercase, Lowercase:
- For each of these operations, we track characters that have been added and compare each character using loops, without using any advanced collection methods or LINQ.

# Explanation:

### RemoveDuplicates:
- Loops through the string and checks if a character has already been added to the result string using the `Contains()` method of the result string.

### RemoveDuplicateSpecialChars:
- Loops through each character, checks if it's a special character, and adds it to the result if it's not already in the specialChars string.

### RemoveDuplicateNumbers:
- Similar to the above, but it specifically looks for numeric characters.

### RemoveDuplicateLowerChars:
- Checks if a character is lowercase and ensures no duplicate lowercase letters.

### RemoveDuplicateUpperChars:
- Similar to the above, but it checks for uppercase letters.

### RemoveSpecialChars:
- Loops through the string and keeps only letters and digits, discarding any special characters.

### RemoveNumbers:
- Loops through the string and removes any numeric characters.

### RemoveLowerChars:
- Loops through the string and removes lowercase characters.

### RemoveUpperChars:
- Loops through the string and removes uppercase characters.