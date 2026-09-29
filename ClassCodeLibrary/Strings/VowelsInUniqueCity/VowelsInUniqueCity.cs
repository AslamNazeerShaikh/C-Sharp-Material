namespace ClassCodeLibrary.Strings.VowelsInUniqueCity;

/// <summary>
/// Deduplicates city names and extracts vowels. Pure functions: no console output.
/// </summary>
public static class VowelsInUniqueCity
{
    private static bool IsVowelLower(char c) =>
        c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';

    /// <summary>
    /// Removes duplicate strings manually, preserving first-seen order.
    /// </summary>
    /// <param name="inputArray">Array that may contain duplicates.</param>
    /// <returns>Array with only unique values.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="inputArray"/> is null.</exception>
    public static string[] RemoveDuplicates(string[] inputArray)
    {
        ArgumentNullException.ThrowIfNull(inputArray);

        var unique = new List<string>(inputArray.Length);
        foreach (string item in inputArray)
        {
            bool isDuplicate = false;
            foreach (string seen in unique)
            {
                if (seen == item)
                {
                    isDuplicate = true;
                    break;
                }
            }

            if (!isDuplicate)
            {
                unique.Add(item);
            }
        }

        return [.. unique];
    }

    /// <summary>
    /// Removes duplicate strings using LINQ, preserving first-seen order.
    /// </summary>
    /// <param name="inputArray">Array that may contain duplicates.</param>
    /// <returns>Array with only unique values.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="inputArray"/> is null.</exception>
    public static string[] RemoveDuplicatesLinq(string[] inputArray)
    {
        ArgumentNullException.ThrowIfNull(inputArray);

        return inputArray.Distinct().ToArray();
    }

    /// <summary>
    /// Finds unique vowels in a word manually (case-insensitive, lowercase result).
    /// </summary>
    /// <param name="word">The word to scan.</param>
    /// <returns>Unique vowels in first-seen order.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="word"/> is null.</exception>
    public static char[] FindVowels(string word)
    {
        ArgumentNullException.ThrowIfNull(word);

        var found = new List<char>(word.Length);
        foreach (char original in word)
        {
            char lower = char.ToLowerInvariant(original);
            if (!IsVowelLower(lower))
            {
                continue;
            }

            bool alreadyExists = false;
            foreach (char seen in found)
            {
                if (seen == lower)
                {
                    alreadyExists = true;
                    break;
                }
            }

            if (!alreadyExists)
            {
                found.Add(lower);
            }
        }

        return [.. found];
    }

    /// <summary>
    /// Finds unique vowels in a word using LINQ (case-insensitive, lowercase result).
    /// </summary>
    /// <param name="word">The word to scan.</param>
    /// <returns>Unique vowels in first-seen order.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="word"/> is null.</exception>
    public static char[] FindVowelsLinq(string word)
    {
        ArgumentNullException.ThrowIfNull(word);

        return word.Select(char.ToLowerInvariant).Where(IsVowelLower).Distinct().ToArray();
    }
}
