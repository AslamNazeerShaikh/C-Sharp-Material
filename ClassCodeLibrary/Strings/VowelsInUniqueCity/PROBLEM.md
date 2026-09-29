# Vowels In Unique City

## Input:
`string[] cities = ["Pune", "Mumbai", "Kolkata", "Munbai", "Kolkata", "Pune"];`

## Probelm:
Remove duplicates from above string array and find out vowels present inside each city name using C# but without using any inbuilt method.

Here is a C# program that removes duplicates from the cities array and finds the vowels present in each unique city name without using any inbuilt methods:

## Solution Approach:
1. Remove Duplicates Manually:
Iterate through the array and store unique cities in a new list.
2. Find Vowels in Each City:
Iterate through each city and check for vowels (a, e, i, o, u).
Store vowels found in a list and display them.

## Code Breakdown:

1. Removing Duplicates (`RemoveDuplicates method`)

- We manually iterate through the array and store only unique city names.
- We check if a city name already exists in a temporary array before adding it.
- We create a new array with only the unique values.

2. Finding Vowels (`FindVowels method`)

- We iterate through each letter of a city name.
- We check if the letter is a vowel (`a, e, i, o, u`).
- To avoid duplicate vowels in the result, we manually check before adding.
- We store vowels in a separate array and return them.

## Why No Inbuilt Methods?
- ✅ No use of `.Distinct(), HashSet, List<T>, Contains(), or ToLower()`.
- ✅ Fully implemented using loops and manual comparison.

# Output:
```
City: Pune, Vowels: ue
City: Mumbai, Vowels: uai
City: Kolkata, Vowels: oa
City: Munbai, Vowels: uai
```
<img src="/Images/VowelsInUniqueCity Screenshot_20250129_160357.png" />
